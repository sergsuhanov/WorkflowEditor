// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Activities;
using System.Activities.Presentation.Expressions;
using System.Activities.Presentation.Hosting;
using System.Activities.Presentation.Model;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace WorkflowEditor.Win {

    /// <summary>
    /// Interaction logic for RoslynExpressionEditor.xaml
    /// </summary>
    public partial class RoslynExpressionEditor : TextualExpressionEditor {
        private static readonly DependencyProperty s_validationErrorMessageProperty = DependencyProperty.Register("ValidationErrorMessage", typeof(string), typeof(RoslynExpressionEditor), new PropertyMetadata(null));
        private double _blockWidth = double.NaN;
        private static readonly int s_validationWaitTime = 800;
        private TextBlock _textBlock;
        private bool _isBeginEditPending;
        private Type _inferredType;

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public RoslynExpressionEditor() {
            InitializeComponent();

            MinHeight = FontSize + 4; /* 4 pixels for border*/

            ContentTemplate = (DataTemplate)FindResource("textblock");
            innerControl.ContentTemplate = ContentTemplate;
            HintText = "Enter C# Expression";
        }

        public override bool Commit(bool isExplicitCommit) {
            var committed = false;
            //only generate and validate the expression when when we don't require explicit commit change
            //or when the commit is explicit
            if (!ExplicitCommit || isExplicitCommit) {
                // Generate and validate the expression.
                // Get the text from the snapshot and set it to the Text property
                PreviousText = null;

                if (ExpressionEditorInstance != null) {
                    PreviousText = Text;
                    Text = ExpressionEditorInstance.GetCommittedText();
                }
                if (Expression != null) {
                    var expression = Expression.GetCurrentValue() as Activity;
                    // if expression is null, GetExpressionString will return null                           
                    PreviousText = ExpressionHelper.GetExpressionString(expression, OwnerActivity);
                } else {
                    PreviousText = null;
                }

                EditingTextBox?.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                // If the Text is null, or equal to the previous value, or changed from null to empty, don't bother generating the expression
                // We still need to generate the expression when it is changed from other value to EMPTY however - otherwise
                // the case where you had an expression (valid or invalid), then deleted the whole thing will not be evaluated.
                if (ShouldGenerateExpression(PreviousText, Text)) {
                    GenerateExpression();
                    committed = true;
                }
            }
            if (!ContentTemplate.Equals((DataTemplate)FindResource("textblock"))) {
                ContentTemplate = (DataTemplate)FindResource("textblock");
            }
            return committed;
        }

        internal static bool ShouldGenerateExpression(string oldText, string newText) {
            return newText != null && !string.Equals(newText, oldText) && !(oldText == null && newText.Equals(string.Empty));
        }

        private void GenerateExpression() {
            //TODO: Enhance the type infering logic
            if (ExpressionType == null) {
                // Get the variables in scope
                var declaredVariables = CSharpExpressionHelper.GetVariablesInScope(OwnerActivity);

                if (declaredVariables.Count > 0) {
                    InferredType = ((LocationReference)declaredVariables[0].GetCurrentValue()).Type;
                }
            }

            var resultType = (ExpressionType ?? InferredType) ?? typeof(object);

            // If the text is null we don't need to bother generating the expression (this would be the case the
            // first time you enter an ETB. We still need to generate the expression when it is EMPTY however - otherwise
            // the case where you had an expression (valid or invalid), then deleted the whole thing will not be evaluated.
            if (Text != null) {
                using (var scope = OwnerActivity.BeginEdit("Property Change")) {
                    if (OwnerActivity != null) {
                        EditingState = EditingState.Validating;
                        // we set the expression to null
                        // a) when the expressionText is empty AND it's a reference expression or
                        // b) when the expressionText is empty AND the DefaultValue property is null
                        if (Text.Length == 0 &&
                            (UseLocationExpression || (DefaultValue == null))) {
                            Expression = null;
                        } else {
                            if (Text.Length == 0) {
                                Text = DefaultValue;
                            }

                            var modelTreeManager = Context.Services.GetService<ModelTreeManager>();
                            var newExpression = CSharpExpressionHelper.CreateExpressionFromString(Text, UseLocationExpression, resultType);
                            var expressionItem = modelTreeManager.CreateModelItem(null, newExpression);

                            Expression = expressionItem;
                        }
                        scope.Complete();
                    }
                }
            }
        }

        internal bool HasErrors {
            get {
                var hasErrors = false;
                return hasErrors;
            }
        }

        internal bool HasValidationError {
            get { return (bool)GetValue(HasValidationErrorProperty); }
            set { SetValue(HasValidationErrorProperty, value); }
        }

        internal string ValidationErrorMessage {
            get { return (string)GetValue(ValidationErrorMessageProperty); }
            set { SetValue(ValidationErrorMessageProperty, value); }
        }

        internal EditingState EditingState {
            get { return (EditingState)GetValue(EditingStateProperty); }
            set { SetValue(EditingStateProperty, value); }
        }

        internal static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(RoslynExpressionEditor));

        internal static DependencyProperty EditingStateProperty { get; } = DependencyProperty.Register("EditingState", typeof(EditingState), typeof(RoslynExpressionEditor), new PropertyMetadata(EditingState.Idle));

        internal static DependencyProperty HasValidationErrorProperty { get; } = DependencyProperty.Register("HasValidationError", typeof(bool), typeof(RoslynExpressionEditor), new PropertyMetadata(false));

        internal static DependencyProperty ValidationErrorMessageProperty {
            get {
                return s_validationErrorMessageProperty;
            }
        }

        public double BlockHeight { get; set; } = double.NaN;

        public double BlockWidth {
            get {
                return _blockWidth;
            }

            set {
                _blockWidth = value;
            }
        }

        public static int ValidationWaitTime {
            get {
                return s_validationWaitTime;
            }
        }

        public bool IsEditorLoaded { get; set; } = false;

        public string PreviousText { get; set; } = null;

        public IExpressionEditorService ExpressionEditorService1 { get; set; }

        public IExpressionEditorInstance ExpressionEditorInstance { get; set; }

        public Control HostControl { get; set; }

        public string EditorName { get; set; }

        public TextBox EditingTextBox { get; set; }

        public Type InferredType {
            get {
                return _inferredType;
            }

            set {
                _inferredType = value;
            }
        }

        public BackgroundWorker Validator { get; set; } = null;

        private void OnTextBlockMouseLeftButtonDown(object sender, RoutedEventArgs e) {
            if (!IsReadOnly) {
                if (sender is TextBlock textBlock) {
                    _ = Keyboard.Focus(textBlock);
                    e.Handled = true;
                }
            }
        }

        private void OnGotTextBlockFocus(object sender, RoutedEventArgs e) {
            if (Context == null) {
                return;
            }

            var designerView = Context.Services.GetService<DesignerView>();

            if (!designerView.IsMultipleSelectionMode) {
                var isInReadOnlyMode = IsReadOnly;
                if (Context != null) {
                    var readOnlyState = Context.Items.GetValue<ReadOnlyState>();
                    isInReadOnlyMode |= readOnlyState.IsReadOnly;
                }
                if (sender is TextBlock textBlock) {
                    BlockHeight = textBlock.ActualHeight;
                    BlockHeight = Math.Max(BlockHeight, textBlock.MinHeight);
                    BlockHeight = Math.Min(BlockHeight, textBlock.MaxHeight);
                    BlockWidth = textBlock.ActualWidth;
                    BlockWidth = Math.Max(BlockWidth, textBlock.MinWidth);
                    BlockWidth = Math.Min(BlockWidth, textBlock.MaxWidth);

                    // If it's already an editor, don't need to switch it/reload it (don't create another editor/grid if we don't need to)
                    // Also don't create editor when we are in read only mode
                    if (ContentTemplate.Equals((DataTemplate)FindResource("textblock")) && !isInReadOnlyMode) {
                        if (Context != null) {
                            // Get the ExpressionEditorService
                            ExpressionEditorService1 = Context.Services.GetService<IExpressionEditorService>();
                        }

                        // If the service exists, use the editor template - else switch to the textbox template
                        if (ExpressionEditorService1 != null) {
                            ContentTemplate = (DataTemplate)FindResource("expressioneditor");
                        }
                    }
                }

                if (!isInReadOnlyMode) {
                    //disable the error icon
                    StartValidator();
                    EditingState = EditingState.Editing;
                    e.Handled = true;
                }
            }
        }

        private void OnEditorLoaded(object sender, RoutedEventArgs e) {
            if (!IsEditorLoaded) {
                // If the service exists, create an expression editor and add it to the grid - else switch to the textbox data template
                if (ExpressionEditorService1 != null) {
                    var border = (Border)sender;
                    // Get the references and variables in scope
                    var assemblies = (AssemblyContextControlItem)Context.Items.GetValue(typeof(AssemblyContextControlItem));
                    var declaredVariables = CSharpExpressionHelper.GetVariablesInScope(OwnerActivity);

                    var importedNamespaces = Context.Items.GetValue<ImportedNamespaceContextItem>();
                    importedNamespaces.EnsureInitialized(Context);
                    //if the expression text is empty and the expression type is set, then we initialize the text to prompt text
                    if (string.Equals(Text, string.Empty, StringComparison.OrdinalIgnoreCase) && ExpressionType != null) {
                        Text = TypeToPromptTextConverter.GetPromptText(ExpressionType);
                    }

                    //this is a hack
                    BlockWidth = Math.Max(ActualWidth - 8, 0);  //8 is the margin
                    if (HasErrors) {
                        BlockWidth = Math.Max(BlockWidth - 16, 0); //give 16 for error icon
                    }
                    try {
                        ExpressionEditorInstance = ExpressionType != null
                            ? ExpressionEditorService1.CreateExpressionEditor(assemblies, importedNamespaces, declaredVariables, Text, ExpressionType, new Size(BlockWidth, BlockHeight))
                            : ExpressionEditorService1.CreateExpressionEditor(assemblies, importedNamespaces, declaredVariables, Text, new Size(BlockWidth, BlockHeight));
                    } catch (Exception ex) {
                        throw ex;
                    }

                    if (ExpressionEditorInstance != null) {
                        try {
                            ExpressionEditorInstance.VerticalScrollBarVisibility = VerticalScrollBarVisibility;
                            ExpressionEditorInstance.HorizontalScrollBarVisibility = HorizontalScrollBarVisibility;

                            ExpressionEditorInstance.AcceptsReturn = AcceptsReturn;
                            ExpressionEditorInstance.AcceptsTab = AcceptsTab;

                            // Add the expression editor to the text panel, at column 1
                            HostControl = ExpressionEditorInstance.HostControl;

                            // Subscribe to this event to change scrollbar visibility on the fly for auto, and to resize the hostable editor
                            // as necessary
                            ExpressionEditorInstance.LostAggregateFocus += new EventHandler(OnEditorLostAggregateFocus);
                            ExpressionEditorInstance.Closing += new EventHandler(OnEditorClosing);

                            // Set up Hostable Editor properties
                            ExpressionEditorInstance.MinLines = MinLines;
                            ExpressionEditorInstance.MaxLines = MaxLines;

                            ExpressionEditorInstance.HostControl.Style = (Style)FindResource("editorStyle");

                            border.Child = HostControl;
                            ExpressionEditorInstance.Focus();
                        } catch (KeyNotFoundException) {
                            _ = new ApplicationException("Unable to find editor with the following editor name: " + EditorName);
                        }
                    }
                }
                IsEditorLoaded = true;
            }
        }

        private void OnEditorUnloaded(object sender, RoutedEventArgs e) {
            // Blank the editorSession and the expressionEditor so as not to use up memory
            // Destroy both as you can only ever spawn one editor per session
            if (ExpressionEditorInstance != null) {
                //if we are unloaded during editing, this means we got here by someone clicking breadcrumb, we should try to commit
                if (EditingState == EditingState.Editing) {
                    _ = Commit(false);
                }
                ExpressionEditorInstance.Close();
            } else {
                EditingTextBox = null;
            }

            IsEditorLoaded = false;
        }

        private void OnGotEditingFocus(object sender, RoutedEventArgs e) {
            //disable the error icon
            EditingState = EditingState.Editing;
            StartValidator();
        }

        private void StartValidator() {
            if (Validator == null) {
                Validator = new BackgroundWorker() {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                Validator.DoWork += delegate (object obj, DoWorkEventArgs args) {
                    var worker = obj as BackgroundWorker;
                    if (worker.CancellationPending) {
                        args.Cancel = true;
                        return;
                    }
                    if (args.Argument is ExpressionValidationContext validationContext) {
                        if (DoValidation(validationContext, out var errorMessage)) {
                            worker.ReportProgress(0, errorMessage);
                        }

                        //sleep
                        if (worker.CancellationPending) {
                            args.Cancel = true;
                            return;
                        }

                        Thread.Sleep(ValidationWaitTime);
                        args.Result = validationContext;
                    }
                };

                Validator.RunWorkerCompleted += delegate (object obj, RunWorkerCompletedEventArgs args) {
                    if (!args.Cancelled) {
                        if (args.Result is ExpressionValidationContext validationContext) {
                            _ = Dispatcher.BeginInvoke(new Action<ExpressionValidationContext>((target) => {
                                //validator could be null by the time we try to validate again or
                                //if it's already busy
                                if (Validator != null && !Validator.IsBusy) {
                                    target.Update(this);
                                    Validator.RunWorkerAsync(target);
                                }
                            }), validationContext);
                        }
                    }
                };

                Validator.ProgressChanged += delegate (object obj, ProgressChangedEventArgs args) {
                    var error = args.UserState as string;
                    _ = Dispatcher.BeginInvoke(new Action<string>(UpdateValidationError), error);
                };

                Validator.RunWorkerAsync(new ExpressionValidationContext(this));
            }
        }

        private void OnEditorLostAggregateFocus(object sender, EventArgs e) {
            DoLostFocus();
        }

        private void OnEditorClosing(object sender, EventArgs e) {
            if (ExpressionEditorInstance != null) {
                //these events are expected to be unregistered during lost focus event, but
                //we are unregistering them during unload just in case.  Ideally we want to
                //do this in the CloseExpressionEditor method
                ExpressionEditorInstance.LostAggregateFocus -= new EventHandler(OnEditorLostAggregateFocus);

                ExpressionEditorInstance.Closing -= new EventHandler(OnEditorClosing);
                ExpressionEditorInstance = null;
            }
            if (HostControl.Parent is Border boarder) {
                boarder.Child = null;
            }
            HostControl = null;
            EditorName = null;
        }
        private void KillValidator() {
            if (Validator != null) {
                Validator.CancelAsync();
                Validator.Dispose();
                Validator = null;
            }
        }

        private static void ValidateExpression(RoslynExpressionEditor etb) {
            if (etb.DoValidation(new ExpressionValidationContext(etb), out var errorMessage)) {
                etb.UpdateValidationError(errorMessage);
            }
        }

        private void UpdateValidationError(string errorMessage) {
            if (!string.IsNullOrEmpty(errorMessage)) {
                //report error
                HasValidationError = true;
                ValidationErrorMessage = errorMessage;
            } else {
                HasValidationError = false;
                ValidationErrorMessage = null;
            }
        }

        private bool DoValidation(ExpressionValidationContext validationContext, out string errorMessage) {
            errorMessage = null;

            //validate
            //if the text is empty we clear the error message
            if (string.IsNullOrEmpty(validationContext.ExpressionText)) {
                errorMessage = null;
                return true;
            }
            // if the expression text is different from the last time we run the validation we run the validation
            else if (!string.Equals(validationContext.ExpressionText, validationContext.ValidatedExpressionText)) {
                try {
                    //TODO: Add logic to validate expression
                } catch (Exception err) {
                    errorMessage = err.Message;
                }

                return true;
            }

            return false;
        }

        private void DoLostFocus() {
            KillValidator();

            ValidateExpression(this);

            if (Context != null) {   // Unselect if this is the currently selected one.
                var current = Context.Items.GetValue<ExpressionSelection>();
                if (current != null && current.ModelItem == Expression) {
                    var emptySelection = new ExpressionSelection(null);
                    Context.Items.SetValue(emptySelection);
                }
            }

            // Generate and validate the expression.
            // Get the text from the snapshot and set it to the Text property
            ExpressionEditorInstance?.ClearSelection();
            if (!ExplicitCommit) {
                //commit change and let the commit change code do the revert
                var committed = Commit(false);

                //reset the error icon if we didn't get to set it in the commit
                if (!committed || IsIndependentExpression) {
                    EditingState = EditingState.Idle;
                    // Switch the control back to a textbox -
                    // but give it the text from the editor (textbox should be bound to the Text property, so should
                    // automatically be filled with the correct text, from when we set the Text property earlier)
                    if (!ContentTemplate.Equals((DataTemplate)FindResource("textblock"))) {
                        ContentTemplate = (DataTemplate)FindResource("textblock");
                    }
                }
            }

            //raise EditorLostLogical focus - in case when some clients need to do explicit commit
            RaiseEvent(new RoutedEventArgs(ExpressionTextBox.EditorLostLogicalFocusEvent, this));
        }

        private void OnTextBlockLoaded(object sender, RoutedEventArgs e) {
            _textBlock = sender as TextBlock;
            if (_isBeginEditPending) {
                BeginEdit();
            }
        }

        public override void BeginEdit() {
            if (_textBlock != null) {
                _ = Keyboard.Focus(_textBlock);
                _isBeginEditPending = false;
            } else {
                _isBeginEditPending = true;
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e) {
            switch (e.Property.Name) {
                case "Expression":

                    OnExpressionChanged();
                    break;
            }

            base.OnPropertyChanged(e);
        }

        private void OnExpressionChanged() {
            IsSupportedExpression = true;
            if (Expression == null) {
                Text = null;
            } else {
                // This is a necessary work-around for design-time validation to work properly on Variable/Argument designer. For ETB in Variable/Argument designer,
                // this.Expression is actually a FakeModelItemImpl. For non-editing scenario, when the validation is done, it actually updates the validation related
                // attached properties of the real ModelItem. So if we hook on this.Expression.PropertyChanged directly, we cannot get the property change notification.
                // As the result, the UI of Variable/Argument designer won't be updated when the validation status is changed.

                var expression = Expression.GetCurrentValue() as ActivityWithResult;
                Text = ExpressionHelper.GetExpressionString(expression);
            }
        }

        internal sealed class TypeToPromptTextConverter : IValueConverter {
            #region IValueConverter Members

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
                return TypeToPromptTextConverter.GetPromptText(value);
            }

            internal static string GetPromptText(object value) {
                var expressionType = value as Type;
                return value == DependencyProperty.UnsetValue || expressionType == null || !expressionType.IsValueType
                    ? "Nothing"
                    : Activator.CreateInstance(expressionType).ToString();
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
                throw new NotSupportedException();
            }

            #endregion
        }
    }
}
