// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Windows;
using System.Windows.Input;
using Microsoft.CSharp.Activities;
using Microsoft.Win32;

namespace WorkflowEditor.Win {

    public partial class MainWindow : Window {
        private readonly string _layoutPath = string.Format(@"{0}layout.xml", System.AppDomain.CurrentDomain.BaseDirectory);

        private RoslynExpressionEditorService expressionEditorService;

        public WorkflowDesigner Designer {
            get { return (WorkflowDesigner)GetValue(DesignerProperty); }
            set { SetValue(DesignerProperty, value); }
        }

        public static readonly DependencyProperty DesignerProperty =
            DependencyProperty.Register("Designer", typeof(WorkflowDesigner), typeof(MainWindow));

        public System.Activities.Presentation.Toolbox.ToolboxControl MainToolbox {
            get { return (System.Activities.Presentation.Toolbox.ToolboxControl)GetValue(MainToolboxProperty); }
            set { SetValue(MainToolboxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainToolbox.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainToolboxProperty =
            DependencyProperty.Register("MainToolbox", typeof(System.Activities.Presentation.Toolbox.ToolboxControl), typeof(MainWindow));

        private readonly ToolbarView toolbarView;
        public List<ToolbarViewItem> ToolbarViews {
            get {
                return toolbarView.Items.Keys.ToList();
            }
        }

        public UIElement PropertyView {
            get { return (UIElement)GetValue(PropertyViewProperty); }
            set { SetValue(PropertyViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PropertyView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PropertyViewProperty =
            DependencyProperty.Register("PropertyView", typeof(UIElement), typeof(MainWindow));

        public string WorkflowName {
            get { return (string)GetValue(WorkflowNameProperty); }
            set { SetValue(WorkflowNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WorkflowName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkflowNameProperty =
            DependencyProperty.Register("WorkflowName", typeof(string), typeof(MainWindow));

        public string FileName {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(MainWindow));

        #region Commands
        public ICommand OpenFileCommand {
            get { return (ICommand)GetValue(OpenFileCommandProperty); }
            set { SetValue(OpenFileCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenFileCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenFileCommandProperty =
            DependencyProperty.Register("OpenFileCommand", typeof(ICommand), typeof(MainWindow));

        public ICommand NewFileCommand {
            get { return (ICommand)GetValue(NewFileCommandProperty); }
            set { SetValue(NewFileCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewFileCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewFileCommandProperty =
            DependencyProperty.Register("NewFileCommand", typeof(ICommand), typeof(MainWindow));

        public ICommand SaveFileCommand {
            get { return (ICommand)GetValue(SaveFileCommandProperty); }
            set { SetValue(SaveFileCommandProperty, value); }
        }
        public static readonly DependencyProperty SaveFileCommandProperty =
            DependencyProperty.Register("SaveFileCommand", typeof(ICommand), typeof(MainWindow));

        #endregion

        public ICommand ExitCommand {
            get { return (ICommand)GetValue(ExitCommandProperty); }
            set { SetValue(ExitCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExitCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExitCommandProperty =
            DependencyProperty.Register("ExitCommand", typeof(ICommand), typeof(MainWindow));

        public MainWindow() {
            InitializeComponent();
            DataContext = this;
            Closing += MainWindow_Closing;

            ExitCommand = new RelayCommand((p) => Close());
            SaveFileCommand = new RelayCommand((p) => saveWorkflow());
            OpenFileCommand = new RelayCommand((p) => openWorkflow());
            NewFileCommand = new RelayCommand((p) => newWorkflow());

            MainToolbox = new System.Activities.Presentation.Toolbox.ToolboxControl();
            DesignerService.FillToolBar(MainToolbox);

            toolbarView = new ToolbarView(MainToolbox);
            foreach (var categories in MainToolbox.Categories) {
                toolbarView.Add(categories);
            }
            toolbarView.RestoreLayoutFromXml(_layoutPath);
            toolBarViewList.ItemsSource = toolbarView.Items.Keys.ToList();

            newWorkflow();

            try {
                if (File.Exists(_layoutPath)) {
                    layoutManager.RestoreLayoutFromXml(_layoutPath);
                }
            } catch (Exception) {
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            layoutManager.SaveLayoutToXml(_layoutPath);
            toolbarView.SaveLayoutFromXml(_layoutPath);
        }

        private void initDesigner() {
            Designer = new WorkflowDesigner();
            var metadata = new DesignerMetadata();
            metadata.Register();

            expressionEditorService = new RoslynExpressionEditorService();
            ExpressionTextBox.RegisterExpressionActivityEditor(
                new CSharpValue<string>().Language,
                typeof(RoslynExpressionEditor),
                CSharpExpressionHelper.CreateExpressionFromString);
            Designer.Context.Services.Publish<IExpressionEditorService>(expressionEditorService);

            var configurationService = Designer.Context.Services.GetService<DesignerConfigurationService>();
            configurationService.TargetFrameworkName = new FrameworkName(".NETFramework", new System.Version(4, 7, 2));
            configurationService.LoadingFromUntrustedSourceEnabled = true;

            PropertyView = Designer.PropertyInspectorView;

        }

        private void newWorkflow() {
            initDesigner();

            var builder = new System.Activities.ActivityBuilder() { Name = "newWorkflow" };
            DesignerService.AddImports(builder);
            Designer.Load(builder);
        }

        private void openWorkflow() {
            var ofd = new OpenFileDialog() {
                CheckFileExists = true,
                FilterIndex = 0, Multiselect = false, Filter = "Xaml files (.xaml)|*.xaml"
            };
            if (ofd.ShowDialog() == true) {
                initDesigner();
                FileName = ofd.FileName;
                Designer.Load(FileName);
            }
        }

        private void saveWorkflow() {
            var fileName = "file.xaml";
            if (string.IsNullOrEmpty(FileName) == false) {
                fileName = FileName;
            }

            var sfd = new SaveFileDialog() {
                FileName = fileName,
                DefaultExt = "xaml",
                Filter = "Xaml files (.xaml)|*.xaml"
            };

            if (sfd.ShowDialog() == true) {
                var filename = sfd.FileName;
                Designer.Save(filename);
            }
        }

    }
}
