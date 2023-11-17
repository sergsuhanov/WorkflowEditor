// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Activities.Presentation.Toolbox;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WorkflowEditor.Win {
    public class ToolbarView {
        public Dictionary<ToolbarViewItem, ToolboxCategory> Items = new Dictionary<ToolbarViewItem, ToolboxCategory>();
        private readonly System.Activities.Presentation.Toolbox.ToolboxControl _mainToolbox;

        public ToolbarView(System.Activities.Presentation.Toolbox.ToolboxControl mainToolbox) {
            this._mainToolbox = mainToolbox;
        }

        internal void Add(ToolboxCategory categories) {
            var toolBarView = new ToolbarViewItem() {
                Name = categories.CategoryName,
                Visible = true
            };

            toolBarView.PropertyChanged += (s, e) => {
                var i = s as ToolbarViewItem;
                var j = Items[i];
                if (e.PropertyName == "Visible") {

                    if (i.Visible == false) {
                        _ = _mainToolbox.Categories.Remove(j);
                    } else {
                        if (_mainToolbox.Categories.Contains(j) == false) {
                            _mainToolbox.Categories.Add(j);
                        }
                    }
                }
            };

            Items.Add(toolBarView, categories);
        }

        internal void SaveLayoutFromXml(string layoutPath) {
            var str = Items.Select(p => $"Name:{p.Key.Name}, Visible: {p.Key.Visible}").ToArray();
            File.WriteAllLines(layoutPath + "-toolbarVisible", str);
        }

        internal void RestoreLayoutFromXml(string layoutPath) {
            var fileName = layoutPath + "-toolbarVisible";
            if (File.Exists(fileName)) {
                var str = File.ReadAllLines(fileName);
                foreach (var item in str) {
                    var v = item.Split(',');
                    var name = v[0].Replace("Name:", string.Empty).Trim();
                    var visibleStr = v[1].Replace("Visible:", string.Empty).Trim();
                    _ = bool.TryParse(visibleStr, out var visible);

                    //...
                    foreach (var item1 in Items.Where(p => p.Key.Name == name)) {
                        item1.Key.Visible = visible;
                    }
                }
            }
        }
    }

    public class ToolbarViewItem : INotifyPropertyChanged {
        private bool visible;

        public string Name { get; set; }
        public bool Visible {
            get => visible;
            set {
                visible = value;
                OnPropertyChanged("Visible");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
