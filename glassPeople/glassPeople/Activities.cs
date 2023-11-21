namespace glassPeople.ActivityLibrary.Test {
    public class DebugActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Object> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Test {
    public class GetActivityInfoFromTemplateActivity : System.Activities.NativeActivity {
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Scheduler {
    public class ResourceFilterByNameActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Scheduler.Resource> {
		public System.Activities.InArgument<System.String> Name { get; set; }
        protected override System.Collections.Generic.List<glassPeople.Model.Scheduler.Resource> Filter(System.Activities.NativeActivityContext context, System.Collections.Generic.IEnumerable<glassPeople.Model.Scheduler.Resource> source) {
            throw new System.NotImplementedException();
        }
        protected override System.Linq.IQueryable<glassPeople.Model.Scheduler.Resource> GetByDefault(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Scheduler {
    public class ResourceFilterByResourceGroupIdActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Scheduler.Resource> {
		public System.Activities.InArgument<System.Int32> ResourceGroupId { get; set; }
        protected override System.Collections.Generic.List<glassPeople.Model.Scheduler.Resource> Filter(System.Activities.NativeActivityContext context, System.Collections.Generic.IEnumerable<glassPeople.Model.Scheduler.Resource> source) {
            throw new System.NotImplementedException();
        }
        protected override System.Linq.IQueryable<glassPeople.Model.Scheduler.Resource> GetByDefault(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Scheduler {
    public class ResourceGroupFilterByNameActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Scheduler.ResourceGroup> {
		public System.Activities.InArgument<System.String> Name { get; set; }
        protected override System.Collections.Generic.List<glassPeople.Model.Scheduler.ResourceGroup> Filter(System.Activities.NativeActivityContext context, System.Collections.Generic.IEnumerable<glassPeople.Model.Scheduler.ResourceGroup> source) {
            throw new System.NotImplementedException();
        }
        protected override System.Linq.IQueryable<glassPeople.Model.Scheduler.ResourceGroup> GetByDefault(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    public class LogActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    public class Processing_AppointmentItemWorkStatus : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.OutArgument<System.Exception> Exception { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    public class Processing_GoodsReserv : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    public class Processing_OrderItemsIdentWorkStatus : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    public class TemplateSyncActivity : System.Activities.NativeActivity {
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    public class TestQueryActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> AdminEmail { get; set; }
		public System.Activities.InArgument<System.String> Subject { get; set; }
		public System.Activities.InArgument<System.Guid> Ident { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class AddScannerUserActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> UserName { get; set; }
		public System.Activities.InArgument<System.String> EMail { get; set; }
		public System.Activities.InArgument<System.String> BusinessRole { get; set; }
		public System.Activities.InArgument<System.String> Password { get; set; }
		public System.Activities.OutArgument<System.Int32> AccountUserId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class BLEScannerActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<System.String> DeviceName { get; set; }
		public System.Activities.InArgument<System.String> ServiceUUID { get; set; }
		public System.Activities.InArgument<System.String> CharacteristicUUID { get; set; }
		public System.Activities.InArgument<System.String> Mode { get; set; }
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Result { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasData { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class BLESimpleScanActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<System.String> DeviceName { get; set; }
		public System.Activities.InArgument<System.String> ServiceUUID { get; set; }
		public System.Activities.InArgument<System.String> CharacteristicUUID { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class ScannerActivity : glassPeople.ActivityLibrary.glassCAD.Scanner.CameraScannerActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class CameraScannerActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<System.String> Mode { get; set; }
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Result { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasData { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class CheckCameraActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.OutArgument<System.Boolean> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class CheckScannerUserEmailActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<System.String> EMail { get; set; }
		public System.Activities.OutArgument<System.String> PeopleName { get; set; }
		public System.Activities.OutArgument<System.Boolean> IsExist { get; set; }
		public System.Activities.OutArgument<System.Boolean> IsNotExist { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class ClearPyramidModeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; }
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> Identificator { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class IncomingPyramidModeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; }
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> Identificator { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class IncomingToSGPModeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; }
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> Identificator { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class MoveFromSGPToSGPModeActivity : glassPeople.ActivityLibrary.glassCAD.Scanner.IncomingToSGPModeActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class MovePyramidModeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; }
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> Identificator { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class OutcomingFromSGPModeActivity : glassPeople.ActivityLibrary.glassCAD.Scanner.IncomingToSGPModeActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class OutcomingPyramidModeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; }
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> Identificator { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class ReturnToSGPModeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; }
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> Identificator { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class SetDefectiveModeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; }
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> Identificator { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class SetGlasspackToPyramidModeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; }
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<System.String> Identificator { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class SyncRolesWithScan : System.Activities.NativeActivity {
		public System.Activities.OutArgument<System.Int32> AddedRolesCount { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public class TestScannerActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<System.String> Mode { get; set; }
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Result { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasData { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    public class AddProcessingInfoActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLog> ScanLog { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLogProcessing> ScanLogProcessing { get; set; }
		public System.Activities.InArgument<System.String> Text { get; set; }
		public System.Activities.InArgument<System.String> OtherEmails { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    public class BlockARMActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLog> ScanLog { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLogProcessing> ScanLogProcessing { get; set; }
		public System.Activities.InArgument<System.String> BlockText { get; set; }
		public System.Activities.InArgument<System.Int32> BlockKey { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.BlockARMMode Mode { get; set; }
		public System.Activities.InArgument<System.Int32> IDCalendar { get; set; }
		public System.Activities.InArgument<System.Int32> IDPeople { get; set; }
		public System.Activities.InArgument<System.Int32> IDShift { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    public class UnblockARMActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLog> ScanLog { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLogProcessing> ScanLogProcessing { get; set; }
		public System.Activities.InArgument<System.Int32> BlockKey { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    public class ScannerWorker : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.OutArgument<System.Exception> Exception { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.String WorkerName { get; set; }
		public System.Activities.ActivityAction<System.String, glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLog, glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLogProcessing> NextActivity { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    public class ViewBlockARMActivity : System.Activities.NativeActivity {
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.GGC {
    public class OutcomingFromSGPModeActivity : glassPeople.ActivityLibrary.glassCAD.Scanner.OutcomingFromSGPModeActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    public class GroupCodeToGroup : System.Activities.CodeActivity<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> GroupCodes { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> GroupCode { get; set; }
        protected override System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group> Execute(System.Activities.CodeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    public class GroupToGroupCode : System.Activities.CodeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> PrevoisGroups { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> NewGroups { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> NewGroupCodes { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> PrevoisGroupCodes { get; set; }
        protected override void Execute(System.Activities.CodeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    public abstract class MultiGroupActivity : System.Activities.NativeActivity<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> {
		public System.Boolean Enabled { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> Source { get; set; }
		public System.Activities.ActivityFunc<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>, System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> NextActivity { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    public abstract class OneGroupActivity : System.Activities.NativeActivity<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> {
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> Source { get; set; }
		public System.Activities.ActivityFunc<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>, System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> NextActivity { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    public abstract class TwoGroupActivity : System.Activities.NativeActivity<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> {
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> Source { get; set; }
		public System.Activities.ActivityFunc<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>, System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> LeftActivity { get; set; }
		public System.Activities.ActivityFunc<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>, System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> RightActivity { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByBufferDetails : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.BaseStrategy> Startegy { get; set; }
		public System.Activities.InArgument<System.Boolean> EnabledParentRelation { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class BySpacePacking : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByCalendar : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByChild : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByChildCalendar : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Boolean ByAllChild { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByCustomer : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByGoods : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByLevel : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByOperationParameter : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Activities.InArgument<System.String> Name { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByOrder : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByOut : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByParentCalendar : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByPlanDateOut : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByProperty : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Activities.InArgument<System.String> Name { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class HasThreadPathName : glassPeople.ActivityLibrary.glassCAD.Planing.Union.TwoGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> schedulerContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ByThreadPathName : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class DavGlass : glassPeople.ActivityLibrary.glassCAD.Planing.Union.TwoGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> schedulerContext { get; set; }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    public class ToOneGroup : glassPeople.ActivityLibrary.glassCAD.Planing.Union.OneGroupActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Status {
    public class UpdateStatusActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> PaintingGroupCodes { get; set; }
		public System.Activities.OutArgument<System.Boolean> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    public class AnyInTreeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus> RequiredAnyInTree { get; set; }
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus> RequiredAnyInGroupCode { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    public class FirstSimpleActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    public class FromNeighborsActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Coloring.NeighborsCheckMode CheckMode { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    public class FromParentActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCodeStatus> RequiredParentLinkedGroupCodeStatus { get; set; }
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCodeStatus> RequiredParentGroupCodeStatus { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    public class SequenceActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    public class SimpleActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCodeStatus> RequiredParentLinkedGroupCodeStatus { get; set; }
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCodeStatus> RequiredParentGroupCodeStatus { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring.GGC {
    public class RamkaActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class ArmPackingActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.BaseStrategy> Strategy { get; set; }
		public System.Activities.InArgument<System.String> NmDoc { get; set; }
		public System.Activities.InArgument<System.Int32> ArmPackingId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class BeforeVerifyActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Int32> AccountId { get; set; }
		public System.Activities.OutArgument<System.Boolean> ConnectionStringIsEmpty { get; set; }
		public System.Activities.OutArgument<System.Boolean> FailOpenConnection { get; set; }
		public System.Activities.OutArgument<System.Boolean> FailCheckVersion { get; set; }
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; }
		public System.Activities.OutArgument<System.String> ConnectionString { get; set; }
		public System.Activities.OutArgument<System.Boolean> ServiceNotEnabled { get; set; }
		public System.Activities.OutArgument<System.Boolean> PlaningEnabled { get; set; }
		public System.Activities.OutArgument<System.Boolean> FailDifferentDateTime { get; set; }
		public System.Activities.OutArgument<System.Boolean> EquipmentSettingsEmpty { get; set; }
		public System.Activities.OutArgument<System.Boolean> AdminEmailsSettingsEmpty { get; set; }
		public System.Activities.OutArgument<System.String> AdminEmailsSettings { get; set; }
		public System.Activities.OutArgument<System.Boolean> PackingCalendarBufferEmpty { get; set; }
		public System.Activities.OutArgument<System.Boolean> CuttingCalendarBufferEmpty { get; set; }
		public System.Activities.OutArgument<System.Boolean> CalendarFail { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class CreatePlanningContextActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class GetAllTasksActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Int32> AccountId { get; set; }
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task>> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class GetCalendarsActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> StringSource { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> Source { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar>> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class GetPlanningJsonDataActivity : System.Activities.NativeActivity<System.String> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Period> Period { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class SavePlanningContextActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.SavePlanningContextMode Mode { get; set; }
		public System.String Comment { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class SetTaskResultActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> ConnectionString { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task> Source { get; set; }
		public System.Boolean SetWorked { get; set; }
		public System.Activities.InArgument<System.Object> Parameters { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class SettingsGetActivity : System.Activities.NativeActivity<glassPeople.ActivityLibrary.glassCAD.Planing.Settings> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.String> Name { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public class SettingsSetActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Settings> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class AddToSchedulerActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders.DeliverStatus> Status { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> GroupCodes { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Appointment>> Appointments { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem>> AppointmentItems { get; set; }
		public System.Activities.OutArgument<System.Boolean> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class DeliverAppointmentsActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Appointment>> Source { get; set; }
		public System.Activities.InArgument<System.DateTime> EndDeliverDate { get; set; }
		public System.Activities.InArgument<System.DateTime> RestrictionDate { get; set; }
		public System.Activities.OutArgument<System.Boolean> Succsed { get; set; }
		public System.Activities.OutArgument<System.DateTime> ResultDate { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class GetOrdersByPeriodActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> Offcet { get; set; }
		public System.Activities.InArgument<System.Int32> Interval { get; set; }
		public System.Activities.InArgument<System.Int32> StartHour { get; set; }
		public System.Activities.InArgument<System.DateTime> CurrentDateTime { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Order>> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class LoadOrderActivity : System.Activities.NativeActivity<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Order> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class OrderItemsIdentCanceledActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> IDOrderItemsIdentList { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.OutArgument<System.Int32> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class RemoveFromSchedulerActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> OrderId { get; set; }
		public System.Activities.OutArgument<System.Boolean> Result { get; set; }
		public System.Activities.OutArgument<System.Boolean> IsLocked { get; set; }
		public System.Activities.OutArgument<System.Boolean> IsNothing { get; set; }
		public System.Activities.OutArgument<System.Boolean> IsStatusFailed { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class SetFabricaDiractionPlanDateActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; }
		public System.Activities.InArgument<System.DateTime> Dt { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class RemoveFabricaDiractionPlanDateActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class SetNormalOrderActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class SetPreWorkInOrderActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public class SetSuspendOrderActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Helpers {
    public class GetIndexInStringsArrayActivity : System.Activities.NativeActivity<System.Int32> {
		public System.Activities.InArgument<System.Int32> Value { get; set; }
		public System.Activities.InArgument<System.String> Source1 { get; set; }
		public System.Activities.InArgument<System.String> Source2 { get; set; }
		public System.Activities.InArgument<System.String> Source3 { get; set; }
		public System.Activities.InArgument<System.String> Source4 { get; set; }
		public System.Activities.InArgument<System.String> Source5 { get; set; }
		public System.Activities.InArgument<System.String> Source6 { get; set; }
		public System.Activities.InArgument<System.String> Source7 { get; set; }
		public System.Activities.InArgument<System.String> Source8 { get; set; }
		public System.Activities.InArgument<System.String> Source9 { get; set; }
		public System.Activities.InArgument<System.String> Text { get; set; }
		public System.Activities.OutArgument<System.Int32[]> Results { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Helpers {
    public class GetLineFromTextActivity : System.Activities.NativeActivity<System.String> {
		public System.Activities.InArgument<System.String> Source { get; set; }
		public System.Int32 Index { get; set; }
		public System.Activities.OutArgument<System.Boolean> IsOversize { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Helpers {
    public class SetLineToTextActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> Source { get; set; }
		public System.Activities.InOutArgument<System.String> Destination { get; set; }
		public System.Int32 Index { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Helpers {
    public class GroupCodeToListActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> GroupCode { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class BackToPreWorkInGroupCodeAcitvity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
		public System.Activities.InArgument<System.Int32> GroupCodeId { get; set; }
		public System.Activities.OutArgument<System.Boolean> Result { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class CreateArmSquareCuttingActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> Source { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		//public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.MarkingMode SetMarkingMode { get; set; }
		public System.Boolean DiasbleRemoveCoatingRule { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class DeliverActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Activities.InArgument<System.DateTime> ManualDateDeliver { get; set; }
		public System.Activities.OutArgument<System.Boolean> Result { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> GroupCodes { get; set; }
		public System.Activities.OutArgument<System.Boolean> NoSpace { get; set; }
		public System.Activities.OutArgument<System.Boolean> NotValid { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class DisbandGroupCodesActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> GroupCodesId { get; set; }
		public System.Activities.InArgument<System.Boolean> ResetThreadPartName { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class DisbandOrderActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; }
		public System.Activities.InArgument<System.Boolean> SetSuspend { get; set; }
		public System.Activities.OutArgument<System.String> Info { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class GetGroupCodesbyStatusesActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsPrepared { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsOptimazied { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsAccepted { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsProcessed { get; set; }
		public System.Activities.InArgument<System.Nullable<System.DateTime>> StartStatusDateTimeChanged { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar>> Calendars { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar>> IncludeCalendars { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar>> ExcludeCalendars { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> GroupCodes { get; set; }
		public System.Nullable<System.Boolean> IsNormalStatus { get; set; }
		public System.Nullable<System.Boolean> IsSuspendStatus { get; set; }
		public System.Nullable<System.Boolean> IsReservedStatus { get; set; }
		public System.Nullable<System.Boolean> IsPreWorkInStatus { get; set; }
		public System.Nullable<System.Boolean> IsWorkInStatus { get; set; }
		public System.Nullable<System.Boolean> IsWorkOutStatus { get; set; }
		public System.Nullable<System.Boolean> IsMovedToNextOperationStatus { get; set; }
		public System.Nullable<System.Boolean> IsDefectiveStatus { get; set; }
		public System.Nullable<System.Boolean> IsPreDefectiveStatus { get; set; }
		public System.Nullable<System.Boolean> IsMixedStatus { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class GroupCodesFilterByChildsStateActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> {
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsPrepared { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsOptimazied { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsAccepted { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsProcessed { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
        protected override System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Filter(System.Activities.NativeActivityContext context, System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> source) {
            throw new System.NotImplementedException();
        }
        protected override System.Linq.IQueryable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> GetByDefault(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class LinkGroupcodesActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32[]> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class MoveCalendarToCalendarActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32> Source { get; set; }
		public System.Activities.InArgument<System.Int32> Destination { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class MoveGroupCodesToCalendarActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Int32[]> Source { get; set; }
		public System.Activities.InArgument<System.Int32> Destination { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetBufferSecondNameByGlassActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetNumposByChildGroupCodeActivity : System.Activities.CodeActivity {
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.SetNumposByChildGroupCodeActivity_SourceIs SourceIs { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Activities.InArgument<System.Boolean> SetNumPos { get; set; }
		public System.Activities.InArgument<System.Boolean> SetScanerData { get; set; }
		public System.Activities.InArgument<System.Boolean> SetBufferSecondName { get; set; }
        protected override void Execute(System.Activities.CodeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class RefreshAppointmentItemsActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> IDAppointmentItemsList { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetAcceptedGroupCodesActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> GroupCodesId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetGroupCodesStatusActivity : System.Activities.CodeActivity {
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> Source { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> Prepared { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> Accepted { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> Optimized { get; set; }
		public System.Activities.InArgument<System.Nullable<System.Boolean>> Processed { get; set; }
        protected override void Execute(System.Activities.CodeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetOptimizedGroupCodesActivity : System.Activities.NativeActivity<System.Boolean> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> GroupCodesId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetBufferSecondNameActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.BufferSecondNameMode BufferSecondNameMode { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetNumPosByChildActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetPackingInfoFromChildActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetScanerDataFromChildActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetPackingResultActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> GroupCode { get; set; }
		public System.Activities.InArgument<System.Boolean> SetScanerData { get; set; }
		public System.Activities.InArgument<System.Boolean> SetBufferSecondName { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.BufferSecondNameMode BufferSecondNameMode { get; set; }
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.ScanerDataMode ScanerDataMode { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class SetCuttingResultActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; }
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class UnblockGroupCodesByDateTimeActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; }
		public System.Activities.InArgument<System.Int32> Duration { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class UnionAppointmentItemsActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> AppointmentItemsId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class UnionArmSquareCuttingsActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> ArmSquareCuttingsId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public class UnionGroupCodesActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> GroupCodesId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dictionaries {
    public class AttributeGetByNameActivity : System.Activities.NativeActivity<glassPeople.Model.Core.Attribute> {
		public System.Activities.InArgument<System.String> Name { get; set; }
		public System.Boolean CreateIfNotExist { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dictionaries {
    public class BusinessRolesActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Activities.OutArgument<System.Collections.Generic.List<System.Int32>> SelectedRolesId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dictionaries {
    public class DictionaryItemGetActivity : System.Activities.NativeActivity<glassPeople.Model.Dictionaries.DictionaryItem> {
		public System.Activities.InArgument<glassPeople.Model.Account.Account> Account { get; set; }
		public System.Activities.InArgument<System.String> Name { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dictionaries {
    public class DictionaryItemSetActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.Model.Account.Account> Account { get; set; }
		public System.Activities.InArgument<glassPeople.Model.Dictionaries.DictionaryItem> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dialog {
    public class EditTextActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<System.Boolean> HtmlEditor { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Activities.InArgument<System.String> Placeholder { get; set; }
		public System.Activities.InArgument<System.String> Description { get; set; }
		public System.Activities.InArgument<System.Boolean> MultiLine { get; set; }
		public System.Activities.InArgument<System.Boolean> ValueRequired { get; set; }
		public System.Activities.InArgument<System.String> Mask { get; set; }
		public System.Activities.InOutArgument<System.String> Text { get; set; }
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public class EditStringValueActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Activities.InArgument<System.String> Text { get; set; }
		public System.Activities.InArgument<System.String> Placeholder { get; set; }
		public System.Activities.InOutArgument<System.String> Source { get; set; }
		public System.Activities.InArgument<System.String> ButtonText { get; set; }
		public System.Activities.InArgument<System.Boolean> ValueRequired { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public class InvokeActivity : System.Activities.NativeActivity {
		public System.String Template { get; set; }
		public System.String TemplateGuid { get; set; }
		public System.Collections.ObjectModel.Collection<glassPeople.ActivityLibrary.Core.InvokeInArgument> Arguments { get; set; }
		public System.Collections.ObjectModel.Collection<glassPeople.ActivityLibrary.Core.InvokeOutArgument> Output { get; set; }
		public glassPeople.ActivityLibrary.Core.InvokeMode Mode { get; set; }
		public System.Activities.InArgument<System.String> AssignToBusinessRole { get; set; }
		public System.Activities.InArgument<glassPeople.Model.Account.User> AssignToUser { get; set; }
		public System.Activities.InArgument<glassPeople.Model.Account.AccountUsers> AssignToAccountUser { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public class NewObjectActivity<T> : System.Activities.NativeActivity<T> {
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public class SaveObjectActivity<T> : System.Activities.NativeActivity {
		public System.Activities.InArgument<T> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public class SendExceptionInfoActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> Emails { get; set; }
		public System.Activities.InArgument<System.String> Subject { get; set; }
		public System.Activities.InArgument<System.Exception> Source { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public class ShowMessageActivity : System.Activities.NativeActivity {
		public System.Boolean Localization { get; set; }
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Activities.InArgument<System.String> Description { get; set; }
		public System.Activities.InArgument<System.String> Text { get; set; }
		public System.Activities.InArgument<System.String> ButtonText { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public class ShowReportActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<Stimulsoft.Report.StiReport> Report { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public class SwitchActivity : System.Activities.NativeActivity {
		public System.Boolean Localization { get; set; }
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.InArgument<System.String> Text { get; set; }
		public System.Activities.InArgument<System.String> Description { get; set; }
		public System.Activities.InArgument<System.String> FocusItemName { get; set; }
		public System.Collections.ObjectModel.Collection<glassPeople.ActivityLibrary.Core.SwitchItem> Items { get; set; }
		public System.Activities.OutArgument<System.String> Result { get; set; }
		public System.Activities.OutArgument<System.String> ResultText { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public class UpdateTemplatesFromLocalDirectoryActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> Path { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    public class AccountUsersAddByEmailActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> Email { get; set; }
		public System.Activities.OutArgument<System.Boolean> UserNotFound { get; set; }
		public System.Activities.OutArgument<System.Boolean> UserHasAdded { get; set; }
		public System.Activities.OutArgument<System.Boolean> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    public class AccountUsersAttributesActivity : glassPeople.ActivityLibrary.AttributesActivity<glassPeople.Model.Account.AccountUsersAttributes> {
		public System.Activities.InArgument<System.Int32> AccountUserId { get; set; }
		public System.Activities.InOutArgument<glassPeople.Model.Account.AccountUsersAttributes> AccountUsersAttributes { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    public class AccountUsersFilterByAttributeActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Account.AccountUsers> {
		public System.Activities.InArgument<System.Int32> AttributeId { get; set; }
		public System.Activities.InArgument<System.String> StringValue { get; set; }
		public System.Activities.InArgument<System.Boolean> BoolValue { get; set; }
        protected override System.Collections.Generic.List<glassPeople.Model.Account.AccountUsers> Filter(System.Activities.NativeActivityContext context, System.Collections.Generic.IEnumerable<glassPeople.Model.Account.AccountUsers> source) {
            throw new System.NotImplementedException();
        }
        protected override System.Linq.IQueryable<glassPeople.Model.Account.AccountUsers> GetByDefault(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    public class AccountUsersFilterByStatusActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Account.AccountUsers> {
		public System.Activities.InArgument<glassPeople.Model.Account.Status> Status { get; set; }
        protected override System.Collections.Generic.List<glassPeople.Model.Account.AccountUsers> Filter(System.Activities.NativeActivityContext context, System.Collections.Generic.IEnumerable<glassPeople.Model.Account.AccountUsers> source) {
            throw new System.NotImplementedException();
        }
        protected override System.Linq.IQueryable<glassPeople.Model.Account.AccountUsers> GetByDefault(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    public class AccountUsersListActivity : glassPeople.ActivityLibrary.ListActivity<glassPeople.Model.Account.AccountUsers> {
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; }
		public System.Activities.InArgument<System.String> Title { get; set; }
		public System.Boolean AutoTerminate { get; set; }
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.ListDocumentAction> Action { get; set; }
		public System.Activities.OutArgument<System.String> CustomActionName { get; set; }
		public System.Activities.InArgument<System.DateTime> StartDateTime { get; set; }
		public System.Activities.InArgument<System.DateTime> EndDateTime { get; set; }
		public glassPeople.ActivityLibrary.PeriodDateMode PeriodMode { get; set; }
		public System.Activities.InArgument<System.Boolean> AllowChangePeriod { get; set; }
		public System.Boolean FilterRow { get; set; }
		public glassPeople.ActivityLibrary.SelectMode SelectionMode { get; set; }
		public System.Boolean AllowSelectAll { get; set; }
		public System.Activities.InOutArgument<System.Collections.Generic.List<System.Int32>> SelectedKeys { get; set; }
		public System.Activities.InOutArgument<System.Int32> SelectedKey { get; set; }
		public System.Activities.OutArgument<System.Int32> SelectedCount { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    public class AccountUsersSetBlockUnblockActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Int32> AccountUserId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    public class AccountUsersSetBusinessRolesActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Int32> AccountUserId { get; set; }
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> BusinessRolesId { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    public class GetAccountActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.Model.Account.Account> Result { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    public class GetAccountsActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.Model.Account.Account>> Results { get; set; }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
