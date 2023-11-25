using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Globalization;
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

    public partial class SwitchActivityDesigner {
        public ModelItem SelectedItem { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand AddChildCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand UpCommand { get; set; }
        public ICommand DownCommand { get; set; }

        public SwitchActivityDesigner() {
            InitializeComponent();

            this.treeView.SelectedItemChanged += TreeView_SelectedItemChanged;

            this.AddCommand = new DelegateCommand(p => add());
            this.AddChildCommand = new DelegateCommand(p => addChild());
            this.DeleteCommand = new DelegateCommand(p => delete());

            this.UpCommand = new DelegateCommand(p => {
                var collection = getCurrentParent().Properties["Items"].Collection;
                var objectCollection =  collection.Select(t=> (Object) t).ToList();
                var index = objectCollection.IndexOf(SelectedItem);
                if (index > 0) {
                    var a = collection[index-1];
                    collection.Remove(a);
                    collection.Insert(index, a);
                }

            });
            this.DownCommand = new DelegateCommand(p => {
                var collection = getCurrentParent().Properties["Items"].Collection;
                var objectCollection = collection.Select(t => (Object)t).ToList();
                var index = objectCollection.IndexOf(SelectedItem);
                if (index < collection.Count - 1) {
                    var a = collection[index + 1];
                    collection.Remove(a);
                    collection.Insert(index, a);
                }
            });

        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
            SelectedItem =  (ModelItem) e.NewValue;

            var items = SelectedItem.Properties["Items"];
            if (items != null && items.Collection != null && items.Collection.Count > 0) {
                htCaption.Visibility = Visibility.Visible;
                htText.Visibility = Visibility.Visible;
                hdCaption.Visibility = Visibility.Visible;
                hdText.Visibility = Visibility.Visible;
            } else {
                htCaption.Visibility = Visibility.Hidden;
                htText.Visibility = Visibility.Hidden;
                hdCaption.Visibility = Visibility.Hidden;
                hdText.Visibility = Visibility.Hidden;
            }

        }

        private SwitchItem createDefault(ModelItem parent) {

            var name = "nm" + parent.Properties["Items"].Collection.Count.ToString();
            if (parent.Properties["Name"] != null)
                name = parent.Properties["Name"].ComputedValue + "_" + name;

            return new SwitchItem() {
                Name = name,
                Group = "group",
                Image = "image",
                Text = name
            };
        }

        public void add() {
            var newSwithItem = createDefault(getCurrentParent());
            var parent = getCurrentParent();
            parent.Properties["Items"].Collection.Add(newSwithItem);
        }

        public void addChild() {
            var newSwithItem = createDefault(SelectedItem);
            (SelectedItem ?? this.ModelItem).Properties["Items"].Collection.Add(newSwithItem);
        }

        public void delete() {
            if (SelectedItem == null)
                return;
            var parent = getCurrentParent();
            parent.Properties["Items"].Collection.Remove(SelectedItem);
        }

        ModelItem getCurrentParent() {
            if (SelectedItem == null)
                return this.ModelItem;

            var parent = SelectedItem.Parent.Parent;
            return parent ?? this.ModelItem;
        }

    }

}
