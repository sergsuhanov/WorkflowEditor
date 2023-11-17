// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Activities.Presentation.Model;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WorkflowEditor.Win {
    public class RoslynExpressionEditorInstance : TextEditor, IExpressionEditorInstance {
        private CompletionWindow completionWindow;
        private string variableDeclarations;

        public RoslynExpressionEditorInstance() {
            TextArea.TextEntering += TextArea_TextEntering;
            TextArea.PreviewKeyDown += TextArea_PreviewKeyDown;
            TextArea.LostKeyboardFocus += TextArea_LostFocus; // Need to detach events.

            SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
            FontFamily = new System.Windows.Media.FontFamily("Consolas");
            FontSize = 12;
        }

        private void TextArea_PreviewKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Space && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) {
                bla();
                e.Handled = true;
            }
        }

#pragma warning disable IDE0060 // Remove unused parameter
        public RoslynExpressionEditorInstance(Size initialSize) : this() {
            //this.Width = initialSize.Width;
            //this.Height = initialSize.Height;
        }
#pragma warning restore IDE0060 // Remove unused parameter

        public void UpdateInstance(List<ModelItem> variables, string text) {
            Text = text;

            variableDeclarations = string.Join("", variables.Select(v => {
                if (!(v.GetCurrentValue() is System.Activities.Variable c)) {
                    return string.Empty;
                }

                if (c.Type.Name == "Nullable`1") {
                    var argType = c.Type.GenericTypeArguments.First();
                    return string.Format("{0}<{1}>", "Nullable", argType.FullName) + " " + c.Name + ";\n";
                }
                if (c.Type.IsGenericType) {
                    var argType = c.Type.GenericTypeArguments.First();
                    var implInterface = c.Type.GetInterfaces().First();

                    return c.Type.Name == "List`1"
                        ? $"List<{argType.FullName}> {c.Name};\n"
                        : string.Format("{0}<{1}>", implInterface.FullName, argType.FullName) + " " + c.Name + ";\n";
                }

                return c.Type.FullName + " " + c.Name + ";\n";
            }).ToArray());
        }

        private void bla() {
            try {
                //string startString = RoslynExpressionEditorService.Instance.UsingNamespaces
                //    + "namespace SomeNamespace { public class NotAProgram { private void SomeMethod() { "
                //    + variableDeclarations + "var blah = ";
                //string endString = "ToString(); } } }";

                var startString = RoslynExpressionEditorService.Instance.UsingNamespaces
                    + "namespace SomeNamespace { public class NotAProgram { private void SomeMethod() { "
                    + variableDeclarations;
                var endString = "ToString(); } } }";

                var text = string.Empty;
                text = Text != " " ? startString + Text.Substring(0, CaretOffset) + endString : startString + "." + endString;
                var tree = CSharpSyntaxTree.ParseText(text);
                var compilation = CSharpCompilation.Create(
                    "MyCompilation",
                    syntaxTrees: new[] { tree },
                    references: RoslynExpressionEditorService.Instance.BaseAssemblies);
                var semanticModel = compilation.GetSemanticModel(tree);

                // Ask for symbols at the caret position.
                var position = startString.Length;
                var token = tree.GetRoot().FindToken(position);
                var identifier = token.Parent;
                IList<ISymbol> symbols = null;
                if (identifier is QualifiedNameSyntax) {
                    var semanticInfo = semanticModel.GetTypeInfo((identifier as QualifiedNameSyntax).Left);
                    var type = semanticInfo.Type;
                    symbols = semanticModel.LookupSymbols(position, container: type, includeReducedExtensionMethods: true);
                } else if (identifier is MemberAccessExpressionSyntax) {
                    var semanticInfo = semanticModel.GetTypeInfo((identifier as MemberAccessExpressionSyntax).Expression);
                    var type = semanticInfo.Type;
                    symbols = semanticModel.LookupSymbols(position, container: type, includeReducedExtensionMethods: true);
                } else if (identifier is IdentifierNameSyntax) {
                    var semanticInfo = semanticModel.GetTypeInfo(identifier as IdentifierNameSyntax);
                    var type = semanticInfo.Type;
                    symbols = semanticModel.LookupSymbols(position,
                        container: type, includeReducedExtensionMethods: true);
                }

                if (symbols != null && symbols.Count > 0) {
                    completionWindow = new CompletionWindow(TextArea);
                    var data = completionWindow.CompletionList.CompletionData;

                    //var distinctSymbols = from s in symbols group s by s.Name into g select new { Name = g.Key, Symbols = g, Kind = g.First().Kind };
                    //foreach (var group in distinctSymbols.OrderBy(t => t.Kind).ThenBy(s => s.Name)) {
                    //    data.Add(new QueryCompletionData(group.Name, group.Symbols.ToArray()));
                    //}

                    foreach (var item in symbols.Where(p =>
                                p.Kind == SymbolKind.Property ||
                                p.Kind == SymbolKind.Local ||
                                p.Kind == SymbolKind.Field /*|| 
                                p.Kind == SymbolKind.Method */ ).OrderBy(p => p.Name)) {
                        var name = item.Name;

                        if (item.ContainingType.TypeKind == TypeKind.Enum) {
                            name = string.Format("{0}.{1}",
                                item.ContainingType.Name,
                                item.Name);
                        }

                        data.Add(new QueryCompletionData(name, new[] { item }));
                    }

                    if (data.Count > 0) {
                        completionWindow.Show();
                        completionWindow.Closed += delegate {
                            completionWindow = null;
                        };
                    }
                }
            } catch (Exception) {

            }
        }

        private void TextArea_TextEntering(object sender, System.Windows.Input.TextCompositionEventArgs e) {
            if (e.Text.Length > 0 && completionWindow != null) {
                if (!char.IsLetterOrDigit(e.Text[0])) {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
            // Do not set e.Handled=true.
            // We still want to insert the character that was typed.
        }

        private void TextArea_LostFocus(object sender, RoutedEventArgs e) {
            LostAggregateFocus?.Invoke(sender, e);
        }

        #region IExpressionEditorInstance implicit

        public bool AcceptsReturn { get; set; }

        public bool AcceptsTab { get; set; }

        public bool HasAggregateFocus {
            get {
                return true;
            }
        }

        public Control HostControl {
            get {
                return this;
            }
        }

        public int MaxLines { get; set; }

        public int MinLines { get; set; }

#pragma warning disable 0067
        public event EventHandler Closing;
        public event EventHandler GotAggregateFocus;
#pragma warning restore 0067
        public event EventHandler LostAggregateFocus;

        public bool CanCompleteWord() {
            return true;
        }

        public bool CanCopy() {
            return true;
        }

        public bool CanCut() {
            return true;
        }

        public bool CanDecreaseFilterLevel() {
            return true;
        }

        public bool CanGlobalIntellisense() {
            return true;
        }

        public bool CanIncreaseFilterLevel() {
            return true;
        }

        public bool CanParameterInfo() {
            return true;
        }

        public bool CanPaste() {
            return true;
        }

        public bool CanQuickInfo() {
            return true;
        }

        public void ClearSelection() {

        }

        public void Close() {

        }

        public bool CompleteWord() {
            return true;
        }

        public string GetCommittedText() {
            return Text;
        }

        public bool GlobalIntellisense() {
            return true;
        }
        public bool DecreaseFilterLevel() {
            return true;
        }

        public bool IncreaseFilterLevel() {
            return true;
        }

        public bool ParameterInfo() {
            return true;
        }

        public bool QuickInfo() {
            return true;
        }

        #endregion

        #region IExpressionEditorInstance explicit

        void IExpressionEditorInstance.Focus() {
            _ = base.Focus();
        }

        bool IExpressionEditorInstance.Cut() {
            base.Cut();
            return true;
        }

        bool IExpressionEditorInstance.Copy() {
            base.Copy();
            return true;
        }

        bool IExpressionEditorInstance.Paste() {
            base.Paste();
            return true;
        }

        bool IExpressionEditorInstance.Undo() {
            return base.Undo();
        }

        bool IExpressionEditorInstance.Redo() {
            return base.Redo();
        }

        bool IExpressionEditorInstance.CanUndo() {
            return base.CanUndo;
        }

        bool IExpressionEditorInstance.CanRedo() {
            return base.CanRedo;
        }

        event EventHandler IExpressionEditorInstance.TextChanged {
            add {
                base.TextChanged += value;
            }

            remove {
                base.TextChanged -= value;
            }
        }

        string IExpressionEditorInstance.Text {
            get {
                return base.Text;
            }

            set {
                base.Text = value;
            }
        }

        ScrollBarVisibility IExpressionEditorInstance.VerticalScrollBarVisibility {
            get {
                return base.VerticalScrollBarVisibility;
            }

            set {
                base.VerticalScrollBarVisibility = value;
            }
        }

        ScrollBarVisibility IExpressionEditorInstance.HorizontalScrollBarVisibility {
            get {
                return base.HorizontalScrollBarVisibility;
            }

            set {
                base.HorizontalScrollBarVisibility = value;
            }
        }

        #endregion
    }
}
