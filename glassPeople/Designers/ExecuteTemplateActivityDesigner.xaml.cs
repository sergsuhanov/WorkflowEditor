using System;
using System.Activities;
using System.IO;
using System.Linq;
using System.Windows.Input;
using glassPeople.ActivityLibrary;

namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    public partial class ExecuteTemplateActivityDesigner {

        public ICommand SelectTemplate { get; set; }

        public ExecuteTemplateActivityDesigner() {
            InitializeComponent();

            this.SelectTemplate = new DelegateCommand(p => {
                var ofd = new Microsoft.Win32.OpenFileDialog() {
                    Filter = "Template files (*.xml)|*.xml"
                };
                if (ofd.ShowDialog() == false)
                    return;

                var arguments = this.ModelItem.Properties["InArguments"].Collection;
                arguments.Clear();

                var output = this.ModelItem.Properties["OutArguments"].Collection;
                output.Clear();

                var name = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                this.ModelItem.Properties["DisplayName"].SetValue(name);

                var xaml = File.ReadAllText(ofd.FileName);
                var root = load(xaml);
                if (root == null)
                    return;

                var guid = glassPeople.Helper.GetVariables(root).FirstOrDefault(t => t.Name == "GUID");
                if (guid != null && guid.Default != null && Guid.TryParse(guid.Default.ToString(), out var guidValue))
                    this.ModelItem.Properties["GuidWorkFlowTemplate"].SetValue(guidValue);

                foreach (var args in root.Properties.Where(t => t.Type.BaseType == typeof(InArgument))) {
                    arguments.Add(new TemplateInArg() {
                        Name = args.Name,
                        Argument = (InArgument)Activator.CreateInstance(args.Type)
                    });
                }

                foreach (var args in root.Properties.Where(t => t.Type.BaseType == typeof(OutArgument))) {
                    output.Add(new TemplateOutArg() {
                        Name = args.Name,
                        Argument = (OutArgument)Activator.CreateInstance(args.Type)
                    });
                }
            });
        }

        protected override void OnModelItemChanged(object newItem) {
            base.OnModelItemChanged(newItem);
        }

        private System.Activities.ActivityBuilder load(String xaml) {
            xaml = glassPeople.Helper.PreLoadTemplateData(xaml);

            ActivityBuilder root = null;
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
