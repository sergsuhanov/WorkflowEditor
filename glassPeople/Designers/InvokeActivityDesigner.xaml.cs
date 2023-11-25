using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace glassPeople.ActivityLibrary.Core {
    public partial class InvokeActivityDesigner
    {

        public Object SelectedItem { get; set; }

        public ICommand SelectTemplate { get; set; }



        public Visibility ArgumentsVisibility
        {
            get { return (Visibility)GetValue(ArgumentsVisibilityProperty); }
            set { SetValue(ArgumentsVisibilityProperty, value); }
        }
        public Visibility OutputVisibility
        {
            get { return (Visibility)GetValue(OutputVisibilityProperty); }
            set { SetValue(OutputVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ArgumentsVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArgumentsVisibilityProperty =
            DependencyProperty.Register("ArgumentsVisibility", typeof(Visibility), typeof(InvokeActivityDesigner), new PropertyMetadata(Visibility.Collapsed));

        public static readonly DependencyProperty OutputVisibilityProperty =
            DependencyProperty.Register("OutputVisibility", typeof(Visibility), typeof(InvokeActivityDesigner), new PropertyMetadata(Visibility.Collapsed));


        public InvokeActivityDesigner() {
            InitializeComponent();

            this.SelectTemplate = new DelegateCommand(p => {
                var ofd = new Microsoft.Win32.OpenFileDialog() {
                    Filter = "Template files (*.xaml)|*.xaml|Report files (*.mrt)|*.mrt",
                    FilterIndex = (((InvokeMode)this.ModelItem.Properties["Mode"].ComputedValue) == InvokeMode.BuildReport) ? 2 : 1
                };
                if (ofd.ShowDialog() == true) {
                    var name = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                    var ext = System.IO.Path.GetExtension(ofd.FileName);

                    this.ModelItem.Properties["Template"].SetValue(name);

                    var arguments = this.ModelItem.Properties["Arguments"].Collection;
                    arguments.Clear();

                    var output = this.ModelItem.Properties["Output"].Collection;
                    output.Clear();

                    #region load
                    if (ext == ".xaml") {
                        var xaml = File.ReadAllText(ofd.FileName);
                        var root = load(xaml);
                        if (root != null) {

                            foreach (var args in root.Properties.Where(t => t.Type.BaseType == typeof(InArgument))) {
                 
                                arguments.Add(new InvokeInArgument() {
                                    Name = args.Name,
                                    Value = (InArgument)Activator.CreateInstance(args.Type)
                                });
                            }

                            foreach (var args in root.Properties.Where(t => t.Type.BaseType == typeof(OutArgument))) {
                                output.Add(new InvokeOutArgument() {
                                    Name = args.Name,
                                    Value = (OutArgument)Activator.CreateInstance(args.Type)
                                });
                            }

                        }
                    }
                    if (ext == ".mrt") {
                        this.ModelItem.Properties["Mode"].SetValue(InvokeMode.BuildReport);

                        var r = new Stimulsoft.Report.StiReport();
                        r.Load(ofd.FileName);
                        
                        foreach (var args in r.Dictionary.Variables.ToList()) {
                            if (args.Name.ToLower() == "accountid")
                                continue;

                            arguments.Add(new InvokeInArgument() {
                                Name = args.Name,
                                Value = (InArgument) InArgument.Create(args.Type, ArgumentDirection.In)
                            });
                        }


                        output.Add(new InvokeOutArgument() {
                            Name = "Result",
                            Value = (OutArgument) Argument.Create(typeof(Stimulsoft.Report.StiReport), ArgumentDirection.Out)
                        });
                    }
                    #endregion

                    ArgumentsVisibility = (arguments.Count > 0) ? Visibility.Visible : Visibility.Collapsed;
                    OutputVisibility = (output.Count > 0) ? Visibility.Visible : Visibility.Collapsed;

                    var invokeMode = (InvokeMode)this.ModelItem.Properties["Mode"].ComputedValue;
                    if (invokeMode == InvokeMode.Task)
                        OutputVisibility = Visibility.Collapsed;


                }


            });


        }

        protected override void OnModelItemChanged(object newItem)
        {
            base.OnModelItemChanged(newItem);
            base.OnModelItemChanged(newItem);

            var invokeMode = (InvokeMode) this.ModelItem.Properties["Mode"].ComputedValue;
            
            var arguments = this.ModelItem.Properties["Arguments"].Collection;
            ArgumentsVisibility = (arguments.Count > 0) ? Visibility.Visible : Visibility.Collapsed;

            var output = this.ModelItem.Properties["Output"].Collection;
            OutputVisibility = (output.Count > 0) ? Visibility.Visible : Visibility.Collapsed;
            if (invokeMode == InvokeMode.Task)
                OutputVisibility = Visibility.Collapsed;

        }

        System.Activities.ActivityBuilder load(String xaml) {
            System.Activities.ActivityBuilder root = null;
            try {
                var stringReader = new System.IO.StringReader(xaml);
                var xamlReader = new System.Xaml.XamlXmlReader(stringReader);
                var builder = System.Activities.XamlIntegration.ActivityXamlServices.CreateBuilderReader(xamlReader);
                root = System.Xaml.XamlServices.Load(builder) as System.Activities.ActivityBuilder;
            } catch (Exception) {
            }

            return root;
        }

  

 

    }
}
