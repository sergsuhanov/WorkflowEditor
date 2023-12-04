namespace glassPeople.CRM {
    
    public partial class AddIssueAttributeActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.String> Attribute { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.CRM {
    
    public partial class AddUsersToAccountActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.String> Email { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> Action { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.Int32> TaskId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueAddActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		public System.Activities.InArgument<System.Int32> TaskId { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueAddAttributeActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.String> AttributeName { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueListActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> Action { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Int32> TaskId { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.Int32> ResourceId { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<glassPeople.CRM.IssueFilter> Filter { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Test {
    
    public partial class DebugActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Object> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Test {
    
    public partial class GetActivityInfoFromTemplateActivity : System.Activities.NativeActivity {
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Scheduler {
    
    public partial class ResourceFilterByNameActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Scheduler.Resource> {
		[System.ComponentModel.CategoryAttribute("Property")]
		[System.Activities.RequiredArgumentAttribute()]
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
    
    public partial class ResourceFilterByResourceGroupIdActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Scheduler.Resource> {
		[System.ComponentModel.CategoryAttribute("Property")]
		[System.Activities.RequiredArgumentAttribute()]
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
    
    public partial class ResourceGroupFilterByNameActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Scheduler.ResourceGroup> {
		[System.ComponentModel.CategoryAttribute("Property")]
		[System.Activities.RequiredArgumentAttribute()]
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
    
    public partial class LogActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		public System.Activities.InArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    
    public partial class Processing_AppointmentItemWorkStatus : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		public System.Activities.OutArgument<System.Exception> Exception { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    
    public partial class Processing_GoodsReserv : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    
    public partial class Processing_OrderItemsIdentWorkStatus : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    
    public partial class TemplateSyncActivity : System.Activities.NativeActivity {
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    
    public partial class TestQueryActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
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
    
    public partial class AddScannerUserActivity : System.Activities.NativeActivity {
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
    
    public partial class BLEScannerActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.String> Title { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> DeviceName { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> ServiceUUID { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
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
    
    public partial class BLESimpleScanActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.String> Title { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> DeviceName { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> ServiceUUID { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> CharacteristicUUID { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class ScannerActivity : glassPeople.ActivityLibrary.glassCAD.Scanner.CameraScannerActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class CameraScannerActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.String> Title { get; set; } 
		[System.ComponentModel.Browsable(false)]
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
    
    public partial class CheckCameraActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.String> Title { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class CheckScannerUserEmailActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
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
    
    public partial class ClearPyramidModeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Identificator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class IncomingPyramidModeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Identificator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class IncomingToSGPModeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Identificator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class MoveFromSGPToSGPModeActivity : glassPeople.ActivityLibrary.glassCAD.Scanner.IncomingToSGPModeActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class MovePyramidModeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Identificator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class OutcomingFromSGPModeActivity : glassPeople.ActivityLibrary.glassCAD.Scanner.IncomingToSGPModeActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class OutcomingPyramidModeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Identificator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class ReturnToSGPModeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Identificator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class SetDefectiveModeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Identificator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class SetGlasspackToPyramidModeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Scancode[]> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Identificator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class SyncRolesWithScan : System.Activities.NativeActivity {
		public System.Activities.OutArgument<System.Int32> AddedRolesCount { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class TestScannerActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.String> Title { get; set; } 
		[System.ComponentModel.Browsable(false)]
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
    
    public partial class AddProcessingInfoActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLog> ScanLog { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLogProcessing> ScanLogProcessing { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Text { get; set; } 
		public System.Activities.InArgument<System.String> OtherEmails { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    
    public partial class BlockARMActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLog> ScanLog { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLogProcessing> ScanLogProcessing { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> BlockText { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
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
    
    public partial class UnblockARMActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLog> ScanLog { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLogProcessing> ScanLogProcessing { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> BlockKey { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    
    public partial class ScannerWorker : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		public System.Activities.OutArgument<System.Exception> Exception { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		public System.String WorkerName { get; set; } 
		[System.ComponentModel.DefaultValue(null)]
		public System.Activities.ActivityAction<System.String, glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLog, glassPeople.ActivityLibrary.glassCAD.Scanner.Workers.ScanLogProcessing> NextActivity { get; set; } 
        protected override void CacheMetadata(System.Activities.NativeActivityMetadata metadata) {
			metadata.AddDelegate(this.NextActivity);
            base.CacheMetadata(metadata);
        }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    
    public partial class ViewBlockARMActivity : System.Activities.NativeActivity {
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.GGC {
    
    public partial class OutcomingFromSGPModeActivity : glassPeople.ActivityLibrary.glassCAD.Scanner.OutcomingFromSGPModeActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    
    public partial class GroupCodeToGroup : System.Activities.CodeActivity<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		[System.Activities.OverloadGroupAttribute("G1")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> GroupCodes { get; set; } 
		[System.Activities.OverloadGroupAttribute("G2")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> GroupCode { get; set; } 
        protected override System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group> Execute(System.Activities.CodeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    
    public partial class GroupToGroupCode : System.Activities.CodeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		[System.ComponentModel.CategoryAttribute("Group (In)")]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> PrevoisGroups { get; set; } 
		[System.ComponentModel.CategoryAttribute("Group (In)")]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> NewGroups { get; set; } 
		[System.ComponentModel.CategoryAttribute("GroupCodes (Out)")]
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> NewGroupCodes { get; set; } 
		[System.ComponentModel.CategoryAttribute("GroupCodes (Out)")]
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> PrevoisGroupCodes { get; set; } 
        protected override void Execute(System.Activities.CodeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    [System.Windows.Markup.ContentPropertyAttribute("NextActivity")]
    public abstract partial class MultiGroupActivity : System.Activities.NativeActivity<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> {
		public System.Boolean Enabled { get; set; } 
		[System.ComponentModel.CategoryAttribute("Source")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> Source { get; set; } 
		[System.ComponentModel.DefaultValue(null)]
		public System.Activities.ActivityFunc<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>, System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> NextActivity { get; set; } 
        protected override void CacheMetadata(System.Activities.NativeActivityMetadata metadata) {
			metadata.AddDelegate(this.NextActivity);
            base.CacheMetadata(metadata);
        }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    [System.Windows.Markup.ContentPropertyAttribute("NextActivity")]
    public abstract partial class OneGroupActivity : System.Activities.NativeActivity<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> {
		[System.ComponentModel.CategoryAttribute("Source")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> Source { get; set; } 
		[System.ComponentModel.DefaultValue(null)]
		public System.Activities.ActivityFunc<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>, System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> NextActivity { get; set; } 
        protected override void CacheMetadata(System.Activities.NativeActivityMetadata metadata) {
			metadata.AddDelegate(this.NextActivity);
            base.CacheMetadata(metadata);
        }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    [System.Windows.Markup.ContentPropertyAttribute("LeftActivity, RightActivity")]
    public abstract partial class TwoGroupActivity : System.Activities.NativeActivity<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> {
		[System.ComponentModel.CategoryAttribute("Source")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> Source { get; set; } 
		public System.Activities.ActivityFunc<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>, System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> LeftActivity { get; set; } 
		public System.Activities.ActivityFunc<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>, System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group>> RightActivity { get; set; } 
        protected override void CacheMetadata(System.Activities.NativeActivityMetadata metadata) {
			metadata.AddDelegate(this.LeftActivity);
			metadata.AddDelegate(this.RightActivity);
            base.CacheMetadata(metadata);
        }
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByBufferDetails : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.BaseStrategy> Startegy { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Boolean> EnabledParentRelation { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class BySpacePacking : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByCalendar : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByChild : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByChildCalendar : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		public System.Boolean ByAllChild { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByCustomer : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByGoods : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByLevel : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByOperationParameter : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		public System.Activities.InArgument<System.String> Name { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByOrder : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByOut : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByParentCalendar : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByPlanDateOut : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByProperty : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		public System.Activities.InArgument<System.String> Name { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class HasThreadPathName : glassPeople.ActivityLibrary.glassCAD.Planing.Union.TwoGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> schedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByThreadPathName : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class DavGlass : glassPeople.ActivityLibrary.glassCAD.Planing.Union.TwoGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> schedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ToOneGroup : glassPeople.ActivityLibrary.glassCAD.Planing.Union.OneGroupActivity {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Status {
    
    public partial class UpdateStatusActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> PaintingGroupCodes { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    
    public partial class AnyInTreeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
		[System.Activities.OverloadGroupAttribute("G1")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus> RequiredAnyInTree { get; set; } 
		[System.Activities.OverloadGroupAttribute("G2")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus> RequiredAnyInGroupCode { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    
    public partial class FirstSimpleActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    
    public partial class FromNeighborsActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Coloring.NeighborsCheckMode CheckMode { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    
    public partial class FromParentActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCodeStatus> RequiredParentLinkedGroupCodeStatus { get; set; } 
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCodeStatus> RequiredParentGroupCodeStatus { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    
    public partial class SequenceActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    
    public partial class SimpleActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus From { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus To { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCodeStatus> RequiredParentLinkedGroupCodeStatus { get; set; } 
		public System.Nullable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCodeStatus> RequiredParentGroupCodeStatus { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring.GGC {
    
    public partial class RamkaActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class ArmPackingActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.BaseStrategy> Strategy { get; set; } 
		[System.Activities.OverloadGroupAttribute("G1")]
		public System.Activities.InArgument<System.String> NmDoc { get; set; } 
		[System.Activities.OverloadGroupAttribute("G1")]
		public System.Activities.InArgument<System.Int32> ArmPackingId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class BeforeVerifyActivity : System.Activities.NativeActivity {
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> AccountId { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> ConnectionStringIsEmpty { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> FailOpenConnection { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> FailCheckVersion { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> HasError { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> ConnectionString { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> ServiceNotEnabled { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<System.Boolean> PlaningEnabled { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> FailDifferentDateTime { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> EquipmentSettingsEmpty { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> AdminEmailsSettingsEmpty { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> AdminEmailsSettings { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> PackingCalendarBufferEmpty { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> CuttingCalendarBufferEmpty { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> CalendarFail { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class CreatePlanningContextActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class GetAllTasksActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> AccountId { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task>> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class GetCalendarsActivity : System.Activities.NativeActivity {
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.OverloadGroupAttribute("G1")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> StringSource { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.OverloadGroupAttribute("G2")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> Source { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar>> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class GetPlanningJsonDataActivity : System.Activities.NativeActivity<System.String> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Period> Period { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class SavePlanningContextActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.SavePlanningContextMode Mode { get; set; } 
		public System.String Comment { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class SetTaskResultActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task> Source { get; set; } 
		public System.Boolean SetWorked { get; set; } 
		public System.Activities.InArgument<System.Object> Parameters { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class SettingsGetActivity : System.Activities.NativeActivity<glassPeople.ActivityLibrary.glassCAD.Planing.Settings> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Name { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    
    public partial class SettingsSetActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Settings> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class AddToSchedulerActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders.DeliverStatus> Status { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> GroupCodes { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Appointment>> Appointments { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem>> AppointmentItems { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class DeliverAppointmentsActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Appointment>> Source { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.DateTime> EndDeliverDate { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.DateTime> RestrictionDate { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> Succsed { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.DateTime> ResultDate { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class GetOrdersByPeriodActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> Offcet { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> Interval { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> StartHour { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.DateTime> CurrentDateTime { get; set; } 
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Order>> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class LoadOrderActivity : System.Activities.NativeActivity<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Order> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class OrderItemsIdentCanceledActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> IDOrderItemsIdentList { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		public System.Activities.OutArgument<System.Int32> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class RemoveFromSchedulerActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> OrderId { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<System.Boolean> IsLocked { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsNothing { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsStatusFailed { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class SetFabricaDiractionPlanDateActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.DateTime> Dt { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class RemoveFabricaDiractionPlanDateActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class SetNormalOrderActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class SetPreWorkInOrderActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class SetSuspendOrderActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Helpers {
    
    public partial class GetIndexInStringsArrayActivity : System.Activities.NativeActivity<System.Int32> {
		[System.Activities.RequiredArgumentAttribute()]
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
    
    public partial class GetLineFromTextActivity : System.Activities.NativeActivity<System.String> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Int32 Index { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsOversize { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Helpers {
    
    public partial class SetLineToTextActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InOutArgument<System.String> Destination { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Int32 Index { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Helpers {
    
    public partial class GroupCodeToListActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> GroupCode { get; set; } 
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class BackToPreWorkInGroupCodeAcitvity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
		public System.Activities.InArgument<System.Int32> GroupCodeId { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class CreateArmSquareCuttingActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.MarkingMode SetMarkingMode { get; set; } 
		public System.Boolean DiasbleRemoveCoatingRule { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class DeliverActivity : System.Activities.NativeActivity {
		[System.ComponentModel.CategoryAttribute("Context")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		public System.Activities.InArgument<System.DateTime> ManualDateDeliver { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> GroupCodes { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> NoSpace { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> NotValid { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class DisbandGroupCodesActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> GroupCodesId { get; set; } 
		public System.Activities.InArgument<System.Boolean> ResetThreadPartName { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class DisbandOrderActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Boolean> SetSuspend { get; set; } 
		public System.Activities.OutArgument<System.String> Info { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class GetGroupCodesbyStatusesActivity : System.Activities.NativeActivity {
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsPrepared { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsOptimazied { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsAccepted { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsProcessed { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.Nullable<System.DateTime>> StartStatusDateTimeChanged { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar>> Calendars { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar>> IncludeCalendars { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar>> ExcludeCalendars { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> GroupCodes { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsNormalStatus { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsSuspendStatus { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsReservedStatus { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsPreWorkInStatus { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsWorkInStatus { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsWorkOutStatus { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsMovedToNextOperationStatus { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsDefectiveStatus { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsPreDefectiveStatus { get; set; } 
		[System.ComponentModel.CategoryAttribute("Status")]
		public System.Nullable<System.Boolean> IsMixedStatus { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class GroupCodesFilterByChildsStateActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> {
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsPrepared { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsOptimazied { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsAccepted { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsProcessed { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
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
    
    public partial class LinkGroupcodesActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32[]> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class MoveCalendarToCalendarActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> Destination { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class MoveGroupCodesToCalendarActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32[]> Source { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> Destination { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetBufferSecondNameByGlassActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetNumposByChildGroupCodeActivity : System.Activities.CodeActivity {
		[System.Activities.OverloadGroupAttribute("G1")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; } 
		[System.Activities.OverloadGroupAttribute("G2")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.SetNumposByChildGroupCodeActivity_SourceIs SourceIs { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		[System.ComponentModel.CategoryAttribute("Flag")]
		public System.Activities.InArgument<System.Boolean> SetNumPos { get; set; } 
		[System.ComponentModel.CategoryAttribute("Flag")]
		public System.Activities.InArgument<System.Boolean> SetScanerData { get; set; } 
		[System.ComponentModel.CategoryAttribute("Flag")]
		public System.Activities.InArgument<System.Boolean> SetBufferSecondName { get; set; } 
        protected override void Execute(System.Activities.CodeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class RefreshAppointmentItemsActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> IDAppointmentItemsList { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetAcceptedGroupCodesActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> GroupCodesId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetGroupCodesStatusActivity : System.Activities.CodeActivity {
		[System.ComponentModel.CategoryAttribute("Source")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> Source { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> Prepared { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> Accepted { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> Optimized { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> Processed { get; set; } 
        protected override void Execute(System.Activities.CodeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetOptimizedGroupCodesActivity : System.Activities.NativeActivity<System.Boolean> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> GroupCodesId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetBufferSecondNameActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.OverloadGroupAttribute("G1")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; } 
		[System.Activities.OverloadGroupAttribute("G2")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
		[System.ComponentModel.CategoryAttribute("Mode")]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.BufferSecondNameMode BufferSecondNameMode { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetNumPosByChildActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.OverloadGroupAttribute("G1")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; } 
		[System.Activities.OverloadGroupAttribute("G2")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetPackingInfoFromChildActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.OverloadGroupAttribute("G1")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; } 
		[System.Activities.OverloadGroupAttribute("G2")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetScanerDataFromChildActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.OverloadGroupAttribute("G1")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; } 
		[System.Activities.OverloadGroupAttribute("G2")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetPackingResultActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> GroupCode { get; set; } 
		[System.ComponentModel.CategoryAttribute("Flag")]
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.Boolean> SetScanerData { get; set; } 
		[System.ComponentModel.CategoryAttribute("Flag")]
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.Boolean> SetBufferSecondName { get; set; } 
		[System.ComponentModel.CategoryAttribute("Mode")]
		[System.ComponentModel.Browsable(false)]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.BufferSecondNameMode BufferSecondNameMode { get; set; } 
		[System.ComponentModel.CategoryAttribute("Mode")]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.ScanerDataMode ScanerDataMode { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class SetCuttingResultActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.OverloadGroupAttribute("G1")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> SourceList { get; set; } 
		[System.Activities.OverloadGroupAttribute("G2")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class UnblockGroupCodesByDateTimeActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> Duration { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class UnionAppointmentItemsActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> AppointmentItemsId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class UnionArmSquareCuttingsActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> ArmSquareCuttingsId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class UnionGroupCodesActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> GroupCodesId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dictionaries {
    
    public partial class AttributeGetByNameActivity : System.Activities.NativeActivity<glassPeople.Model.Core.Attribute> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Name { get; set; } 
		public System.Boolean CreateIfNotExist { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dictionaries {
    
    public partial class BusinessRolesActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		public System.Activities.InArgument<System.String> Title { get; set; } 
		public System.Activities.OutArgument<System.Collections.Generic.List<System.Int32>> SelectedRolesId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dictionaries {
    
    public partial class DictionaryItemGetActivity : System.Activities.NativeActivity<glassPeople.Model.Dictionaries.DictionaryItem> {
		public System.Activities.InArgument<glassPeople.Model.Account.Account> Account { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Name { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dictionaries {
    
    public partial class DictionaryItemSetActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<glassPeople.Model.Account.Account> Account { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.Model.Dictionaries.DictionaryItem> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Dialog {
    
    public partial class EditTextActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.DefaultValue(false)]
		public System.Activities.InArgument<System.Boolean> HtmlEditor { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> Title { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> Placeholder { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> Description { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		[System.ComponentModel.DefaultValue(false)]
		public System.Activities.InArgument<System.Boolean> MultiLine { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Boolean> ValueRequired { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> Mask { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Source")]
		[System.ComponentModel.CategoryAttribute("In/Out")]
		public System.Activities.InOutArgument<System.String> Text { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class EditStringValueActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		public System.Activities.InArgument<System.String> Title { get; set; } 
		public System.Activities.InArgument<System.String> Text { get; set; } 
		public System.Activities.InArgument<System.String> Placeholder { get; set; } 
		public System.Activities.InOutArgument<System.String> Source { get; set; } 
		[System.ComponentModel.DefaultValueAttribute("Close")]
		public System.Activities.InArgument<System.String> ButtonText { get; set; } 
		public System.Activities.InArgument<System.Boolean> ValueRequired { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class InvokeActivity : System.Activities.NativeActivity {
		[System.Activities.OverloadGroupAttribute("Template")]
		public System.String Template { get; set; } 
		[System.Activities.OverloadGroupAttribute("Template")]
		public System.String TemplateGuid { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Collections.ObjectModel.Collection<glassPeople.ActivityLibrary.Core.InvokeInArgument> Arguments { get; set; } = new System.Collections.ObjectModel.Collection<glassPeople.ActivityLibrary.Core.InvokeInArgument>();
		[System.ComponentModel.Browsable(false)]
		public System.Collections.ObjectModel.Collection<glassPeople.ActivityLibrary.Core.InvokeOutArgument> Output { get; set; } = new System.Collections.ObjectModel.Collection<glassPeople.ActivityLibrary.Core.InvokeOutArgument>();
		public glassPeople.ActivityLibrary.Core.InvokeMode Mode { get; set; } 
		[System.ComponentModel.CategoryAttribute("Assign")]
		[System.Activities.OverloadGroupAttribute("Assign")]
		public System.Activities.InArgument<System.String> AssignToBusinessRole { get; set; } 
		[System.ComponentModel.CategoryAttribute("Assign")]
		[System.Activities.OverloadGroupAttribute("Assign")]
		public System.Activities.InArgument<glassPeople.Model.Account.User> AssignToUser { get; set; } 
		[System.ComponentModel.CategoryAttribute("Assign")]
		[System.Activities.OverloadGroupAttribute("Assign")]
		public System.Activities.InArgument<glassPeople.Model.Account.AccountUsers> AssignToAccountUser { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class NewObjectActivity<T> : System.Activities.NativeActivity<T> {
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class SaveObjectActivity<T> : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<T> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class SendExceptionInfoActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Emails { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Subject { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Exception> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class ShowMessageActivity : System.Activities.NativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Boolean Localization { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		public System.Activities.InArgument<System.String> Title { get; set; } 
		public System.Activities.InArgument<System.String> Description { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Text { get; set; } 
		[System.ComponentModel.DefaultValueAttribute("Close")]
		public System.Activities.InArgument<System.String> ButtonText { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class ShowReportActivity : System.Activities.NativeActivity {
		[System.ComponentModel.CategoryAttribute("Out")]
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.String> Title { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		[System.ComponentModel.DescriptionAttribute("If UserAction result Stop, activity exec terminate")]
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<Stimulsoft.Report.StiReport> Report { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class SwitchActivity : System.Activities.NativeActivity {
		[System.ComponentModel.CategoryAttribute("In")]
		[System.ComponentModel.Browsable(false)]
		public System.Boolean Localization { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.String> Title { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.String> Text { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.String> Description { get; set; } 
		[System.ComponentModel.DescriptionAttribute("Set focus SwithItem Name")]
		[System.ComponentModel.CategoryAttribute("In")]
		public System.Activities.InArgument<System.String> FocusItemName { get; set; } 
		public System.Collections.ObjectModel.Collection<glassPeople.ActivityLibrary.Core.SwitchItem> Items { get; set; } = new System.Collections.ObjectModel.Collection<glassPeople.ActivityLibrary.Core.SwitchItem>();
		[System.ComponentModel.DescriptionAttribute("SwithItem Name")]
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> Result { get; set; } 
		[System.ComponentModel.DescriptionAttribute("SwithItem Text")]
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> ResultText { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class UpdateTemplatesFromLocalDirectoryActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Path { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    
    public partial class AccountUsersAddByEmailActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Email { get; set; } 
		public System.Activities.OutArgument<System.Boolean> UserNotFound { get; set; } 
		public System.Activities.OutArgument<System.Boolean> UserHasAdded { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
		public System.Activities.OutArgument<System.Int32> AccountUserId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    
    public partial class AccountUsersAttributesActivity : glassPeople.ActivityLibrary.AttributesActivity<glassPeople.Model.Account.AccountUsersAttributes> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> AccountUserId { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InOutArgument<glassPeople.Model.Account.AccountUsersAttributes> AccountUsersAttributes { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    
    public partial class AccountUsersEMailNotifyActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> AccountUserId { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Subject { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Body { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    
    public partial class AccountUsersFilterByAttributeActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Account.AccountUsers> {
		[System.ComponentModel.CategoryAttribute("Property")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> AttributeId { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> StringValue { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
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
    
    public partial class AccountUsersFilterByStatusActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.Model.Account.AccountUsers> {
		[System.ComponentModel.CategoryAttribute("Property")]
		[System.Activities.RequiredArgumentAttribute()]
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
    
    public partial class AccountUsersListActivity : glassPeople.ActivityLibrary.ListActivity<glassPeople.Model.Account.AccountUsers> {
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.BookmarkActivityUserAction> UserAction { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.String> Title { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AutoTerminate { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<glassPeople.ActivityLibrary.ListDocumentAction> Action { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<System.String> CustomActionName { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.DateTime> StartDateTime { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.DateTime> EndDateTime { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public glassPeople.ActivityLibrary.PeriodDateMode PeriodMode { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InArgument<System.Boolean> AllowChangePeriod { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean FilterRow { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public glassPeople.ActivityLibrary.SelectMode SelectionMode { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean AllowSelectAll { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InOutArgument<System.Collections.Generic.List<System.Int32>> SelectedKeys { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.InOutArgument<System.Int32> SelectedKey { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<System.Int32> SelectedCount { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    
    public partial class AccountUsersSetBlockUnblockActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Int32> AccountUserId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    
    public partial class AccountUsersSetBusinessRolesActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.Int32> AccountUserId { get; set; } 
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> BusinessRolesId { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    
    public partial class GetAccountActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<glassPeople.Model.Account.Account> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.Account {
    
    public partial class GetAccountsActivity : System.Activities.NativeActivity {
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.Model.Account.Account>> Results { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
