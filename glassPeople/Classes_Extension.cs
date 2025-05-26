
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
