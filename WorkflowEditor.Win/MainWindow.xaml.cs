﻿
using System;
using System.Activities;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.CSharp.Activities;
using Microsoft.Win32;

namespace WorkflowEditor.Win {

    public partial class MainWindow : Window {
        private readonly string layoutPath = string.Format(@"{0}layout.xml", System.AppDomain.CurrentDomain.BaseDirectory);

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
            toolbarView.RestoreLayoutFromXml(layoutPath);
            toolBarViewList.ItemsSource = toolbarView.Items.Keys.ToList();

            newWorkflow();

            try {
                if (File.Exists(layoutPath)) {
                    layoutManager.RestoreLayoutFromXml(layoutPath);
                }
            } catch (Exception) {
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            layoutManager.SaveLayoutToXml(layoutPath);
            toolbarView.SaveLayoutFromXml(layoutPath);
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

                var xaml = File.ReadAllText(FileName);
                xaml = PreLoadTemplateData(xaml);

                /*
                Activity rootActivity;
                var stringReader = new System.IO.StringReader(xaml);
                rootActivity = System.Activities.XamlIntegration.ActivityXamlServices.Load(stringReader,
                        new System.Activities.XamlIntegration.ActivityXamlServicesSettings { CompileExpressions = true });
                stringReader.Close();
                */

                Designer.Text = xaml;
                Designer.Load();
            }
        }

        private static string PreLoadTemplateData(string xaml) {
            var _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

            if (xaml.StartsWith(_byteOrderMarkUtf8)) {
                xaml = xaml.Remove(0, _byteOrderMarkUtf8.Length);

                if (xaml.StartsWith("<") == false) {
                    xaml = "<" + xaml;
                }
            }

            xaml = xaml.Replace("assembly=glassPeople.ActivityLibrary", "assembly=glassPeople");
            xaml = xaml.Replace("assembly=glassPeople.Model", "assembly=glassPeople");
            xaml = xaml.Replace("assembly=ITAP.glassCAD", "assembly=glassPeople");
            xaml = xaml.Replace("assembly=ITAP.Database", "assembly=glassPeople");

            var doc = new System.Xml.XmlDocument();
            doc.LoadXml(xaml);
            var activityNode = doc?.FirstChild;

            if (activityNode != null) {
                //NamespacesForImplementation
                var namespacesForImplementation = activityNode.ChildNodes.OfType<System.Xml.XmlElement>().FirstOrDefault(p => p.Name.EndsWith("NamespacesForImplementation"))?.FirstChild;
                if (namespacesForImplementation != null) {
                    var childs = namespacesForImplementation?.ChildNodes.OfType<System.Xml.XmlElement>().ToList();
                    if (childs.Count() > 0 && childs.Any(p => p.InnerText == "Microsoft.VisualBasic") == false) {
                        var element = doc.CreateElement("x:String", @"http://schemas.microsoft.com/winfx/2006/xaml");
                        element.InnerText = "Microsoft.VisualBasic";

                        _ = namespacesForImplementation.AppendChild(element);
                        if (namespacesForImplementation.Attributes["Capacity"] != null) {
                            namespacesForImplementation.Attributes["Capacity"].Value = namespacesForImplementation.ChildNodes.Count.ToString();
                        }
                    }
                }

                //ReferencesForImplementation
                var referencesForImplementation = activityNode.ChildNodes.OfType<System.Xml.XmlElement>().FirstOrDefault(p => p.Name.EndsWith("ReferencesForImplementation"))?.FirstChild;
                if (referencesForImplementation != null) {

                    while (referencesForImplementation.ChildNodes.Count > 0) {
                        _ = referencesForImplementation.RemoveChild(referencesForImplementation.ChildNodes[0]);
                    }

                    void add(System.Xml.XmlNode parent, string name) {
                        var element = doc.CreateElement("AssemblyReference", @"http://schemas.microsoft.com/netfx/2009/xaml/activities");
                        element.InnerText = name;
                        _ = parent.AppendChild(element);
                    }

                    add(referencesForImplementation, "Microsoft.VisualBasic");
                    add(referencesForImplementation, "glassPeople");
                    add(referencesForImplementation, "System.Activities");
                    add(referencesForImplementation, "System");
                    add(referencesForImplementation, "System.Xaml");
                    add(referencesForImplementation, "Microsoft.EntityFrameworkCore");
                    //"Microsoft.EntityFrameworkCore.Abstractions"

                    //((System.Xml.XmlElement)referencesForImplementation).SetAttribute("Capacity", "6");
                    if (referencesForImplementation.Attributes["Capacity"] != null) {
                        referencesForImplementation.Attributes["Capacity"].Value = "6";
                    }
                }
            }

            return doc.InnerXml;
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
