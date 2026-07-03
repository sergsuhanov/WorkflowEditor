using System.Activities.Presentation;
using System.Activities.Presentation.Model;

namespace ITAP.glassCAD.Dictionary.WorkFlow.Designers {
    public partial class EmptyActivityDesigner {
        public Components.VariableDesignerDecorator VariableDecorator { get; set; }
        public EmptyActivityDesigner() {
            InitializeComponent();
            this.VariableDecorator = new Components.VariableDesignerDecorator(this);
        }

        protected override void OnModelItemChanged(object newItem) {
            base.OnModelItemChanged(newItem);
            this.VariableDecorator.ChangeModelItem1(newItem as ModelItem);
        }

        /*
        public void Dispose() {
            this.VariableDecorator.Dispose();
            this.VariableDecorator = null;
        }*/


    }
}

namespace ITAP.glassCAD.Dictionary.WorkFlow.Components {

    public class VariableDesignerDecorator {
        public VariableDesignerDecorator(ActivityDesigner designer) {

        }

        public void ChangeModelItem1(ModelItem modelItem) {

        }
    }
}
