using System;
using System.Activities;
using System.ComponentModel;

namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    [Designer(typeof(ExecuteTemplateActivityDesigner))]
    public partial class ExecuteTemplateActivity {

        protected override void CacheMetadata(NativeActivityMetadata metadata) {
            base.CacheMetadata(metadata);

            //Проверка всех связей с InArgument
            if (this.GuidWorkFlowTemplate == null || this.GuidWorkFlowTemplate == Guid.Empty)
                metadata.AddValidationError("Необходимо указать GUID шаблона");

            {
                foreach (var arg in this.InArguments) {
                    if (arg.Argument == null || arg.Argument.Expression == null) {
                        metadata.AddValidationError("Необходимо связать все аргументы");
                    }
                }

                for (var k = 0; k < this.InArguments.Count; k++) {
                    var argument3 = new RuntimeArgument("Argument" + k, this.InArguments[k].Argument.ArgumentType, this.InArguments[k].Argument.Direction, true);
                    metadata.Bind(this.InArguments[k].Argument, argument3);
                    metadata.AddArgument(argument3);
                }
            }

            {
                for (var k = 0; k < this.OutArguments.Count; k++) {
                    var argument3 = new RuntimeArgument("OutArgument" + k, this.OutArguments[k].Argument.ArgumentType, this.OutArguments[k].Argument.Direction, true);
                    metadata.Bind(this.OutArguments[k].Argument, argument3);
                    metadata.AddArgument(argument3);
                }
            }
        }
    }
}

