namespace glassPeople.CRM {
    public enum IssueStatus {
        Opened, Сlosed, InWork, InTest, InDiscuss, InGrayFolder
    }
}
namespace glassPeople.CRM {
    public enum IssuePriority {
        Low, Normal, Hight
    }
}
namespace glassPeople.CRM {
    public enum IssueMemberType {
        None, Responsible, Performe, ResponsiblePerforme
    }
}
namespace glassPeople.CRM {
    public enum IssueFilterList {
        BY_STATUS, BY_PRIORITY, BY_PERFORME_MEMBER, BY_CREATED_AT, BY_LAST_COMMENT, BY_STATUS_CHNAGED
    }
}
namespace glassPeople.CRM {
    public enum IssueHistoryType {
        CreateIssue, CreateIssueComment, ChangeIssueStatus, ChangeIssuePriority, ChangeIssueMembers, ChangeIssuePerformeMembers, ViewIssue
    }
}
namespace glassPeople.Model.Workflow {
    public enum State {
        Created, Running, Idle, Freeze, Complited, Error, Paused, Stopped, Cancel, Empty, Kill
    }
}
namespace glassPeople.Model.Scheduler {
    public enum ResourceMode {
        Stack, Parallel
    }
}
namespace glassPeople.Model.Scheduler {
    public enum ResourceType {
        Other, Human, Equipment
    }
}
namespace glassPeople.Model.Scheduler {
    public enum Status {
        Normal, Wait, Reserved, PreWorkIn, WorkIn, WorkOut, Used, Defective, PreDefective, Mixed, Canceled
    }
}
namespace glassPeople.Model.Documents {
    public enum DocumentType {
        None, Input, Output, Movement, Initial, Annulment
    }
}
namespace glassPeople.Model.Dictionaries {
    public enum ContragentType {
        Unknown, BuyerOfGoods, SupplierOfGoods
    }
}
namespace glassPeople.Model.Dictionaries {
    public enum AccountingScheme {
        Unknown, White, Gray, Fictive
    }
}
namespace glassPeople.Model.Dictionaries {
    public enum InventoryControlMode {
        Off, On
    }
}
namespace glassPeople.Model.Account {
    public enum Status {
        Active, Paused, Passive
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public enum CodeInfoStatus {
        Fail, Ok, Warning
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public enum ScancodeType {
        Unknown, Pyramid, Shift, Storehouse, Transport, CauseDefective, Glasspack, Command, ScanActivity
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    public enum BlockARMMode {
        People, Shift, Calendar
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    public enum TaskStatus {
        Default, WorkIn, WorkOut
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    public enum AppointmentItemStatus {
        Normal, WorkIn, WorkOut, Defective, MovedToNextOperation, Suspend, PreDefective, PreWorkIn
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    public enum AppointmentStatus {
        Normal, WorkIn, WorkOut, Mixed, Reserved, Defective, MovedToNextOperation, Suspend, PreDefective, PreWorkIn
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    public enum Direction {
        Forward, Reverse
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    public enum GroupCodeStatus {
        Normal, WorkIn, WorkOut, Mixed, Reserved, Defective, MovedToNextOperation, Suspend, PreDefective, PreWorkIn
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity {
    public enum CapacityType {
        A, L, Arfa, Box, Space
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    public enum DateUseMode {
        ChildRestrictDate, ParentRestrictDate, DeliverDate
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    public enum Navigation {
        LeftToRight, RightToLeft
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
    public enum NeighborsCheckMode {
        Any, All
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
    public enum SavePlanningContextMode {
        SetFlagOnly, StoreByFlag, StoreAlways
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    public enum DeliverStatus {
        Normal, Suspend
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public enum SetNumposByChildGroupCodeActivity_SourceIs {
        IsParent, IsChild, IsGlass
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public enum BufferSecondNameMode {
        None, Default, ByInternalEticets, OrderInfo, ChildNumPos
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public enum ScanerDataMode {
        None, GlassPack, AppointmentItems
    }
}
namespace glassPeople.ActivityLibrary.Core {
    public enum InvokeMode {
        InMemory, Task, Freeze, BuildReport
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    public enum MarkingMode {
        Default, OnlyPyramidInfo, OnlyBufferSecondName
    }
}
