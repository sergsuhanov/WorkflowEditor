using System.Activities.Presentation.Model;
using System.Windows;
using System.Windows.Input;
using glassPeople.ActivityLibrary;
using ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input;

namespace glassPeople.Designers {
    public partial class ButtonsActivityDesigner {

        public ICommand AddButtonCommand { get; set; }
        public ICommand AddDefaultButtonCommand { get; set; }
        public ICommand RemoveButtonCommand { get; set; }
        public ICommand UpButtonCommand { get; set; }
        public ICommand DownButtonCommand { get; set; }

        public ButtonsActivityDesigner() {
            InitializeComponent();

            this.AddButtonCommand = new DelegateCommand(p => {
                var selected = new Button() { Name = "Name", Text = "Text" };
                this.ModelItem.Properties[(string)p].Collection.Add(selected);
            });

            this.AddDefaultButtonCommand = new DelegateCommand(p => {
                var Buttons = this.ModelItem.Properties[(string)p].Collection;
                Buttons.Add(new Button() { Name = "setPeriod", Text = "Выбрать период", ImageName = "Calendar" });
                Buttons.Add(new Button() { Name = "add", Text = "Добавить", ImageName = "AddDocument" });
                Buttons.Add(new Button() { Name = "dublicate", Text = "Дублировать", ImageName = "DublicateDocument" });
                Buttons.Add(new Button() { Name = "edit", Text = "Редактировать", ImageName = "EditDocument" });
                Buttons.Add(new Button() { Name = "delete", Text = "Удалить", ImageName = "DeleteDocument" });
            });

            this.RemoveButtonCommand = new DelegateCommand(p => {
                var selected = getSelected(p);
                if (selected == null)
                    return;

                this.ModelItem.Properties[(string)p].Collection.Remove(selected);
            });

            this.UpButtonCommand = new DelegateCommand(p => {
                var selected = getSelected(p);
                if (selected == null)
                    return;

                var collections = this.ModelItem.Properties[(string)p].Collection;
                var index = collections.IndexOf(selected);
                if (index != 0) {
                    collections.Move(index - 1, index);

                    //var a = collections[index - 1];
                    //collections[index - 1] = selected;
                    //collections[index] = a;

                    //collections.Remove(selected);
                    //collections.Insert(index - 1, selected);
                    //this.buttonsList.SelectedItem = selected;
                }
            });

            this.DownButtonCommand = new DelegateCommand(p => {
                var selected = getSelected(p);
                if (selected == null)
                    return;

                var collections = this.ModelItem.Properties[(string)p].Collection;
                var index = collections.IndexOf(selected);
                if (index != (collections.Count - 1)) {
                    collections.Move(index + 1, index);

                    //var a = collections[index + 1];
                    //collections[index + 1] = selected;
                    //collections[index] = a;

                    //collections.Remove(selected);
                    //collections.Insert(index + 1, selected);
                    //this.buttonsList.SelectedItem = selected;
                }
            });

        }

        private ModelItem getSelected(object p) {
            ModelItem selected = null;
            if ((string)p == "Buttons")
                selected = (ModelItem)this.buttonsList.SelectedItem;
            else if ((string)p == "ToolBar")
                selected = (ModelItem)this.toolbarList.SelectedItem;
            else if ((string)p == "BottomBar")
                selected = (ModelItem)this.bottombarList.SelectedItem;
            else if ((string)p == "Custom")
                selected = (ModelItem)this.customList.SelectedItem;
            return selected;
        }

        protected override void OnModelItemChanged(object newItem) {
            base.OnModelItemChanged(newItem);
            //this.VariableDecorator.ChangeModelItem1(newItem as ModelItem);
        }

        private void imageSelectButton_Click(object sender, RoutedEventArgs e) {
            var dc = ((System.Windows.Controls.Button)e.Source).DataContext;
            var mi = dc as ModelItem;

            //var form = new ImageFromResourcesSelectForm();
            //if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK && form.Selected != null) {
            //    mi.Properties["ImageName"].SetValue(form.Selected.Name);
            //}
        }
    }
}
