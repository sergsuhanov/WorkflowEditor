
using System.Collections.Generic;

namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    public partial class AppointmentItem {
        public IEnumerable<AppointmentItem> GetChilds(PlanningContext pc = null) => null;
        public IEnumerable<AppointmentItem> GetAllChilds(PlanningContext pc = null) => null;

        public IEnumerable<AppointmentItem> GetAllParents(PlanningContext pc = null) => null;
        public IEnumerable<AppointmentItem> GetParents(PlanningContext pc = null) => null;

        public IEnumerable<AppointmentItem> GetAll() => null;
    }
}

namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public partial class CreateArmSquareCuttingActivity {
        public CreateArmSquareCuttingActivity() {
            StringTemplateForAPyramid = "A{0}/П{1}";
            StringTemplateForLPyramid = "L{0}/П{1}";
            StringTemplateForArfa = "{0:00}/{1:00}";
            StringTemplateForBox = "B{0}:{1}";
            StringTemplateForSpace = "S{1}";
        }
    }
}
