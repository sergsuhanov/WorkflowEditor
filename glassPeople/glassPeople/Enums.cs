namespace ITAP.ProductionWorkingRelation.Modeling {
public enum ConnectionType {
    Work,Relation,Result
} 
}
namespace ITAP.ProductionWorkingRelation.Modeling {
public enum ElementFilter {
    None,OnlyWorkElements,OnlyRelationElements
} 
}
namespace ITAP.ProductionWorkingRelation.Modeling {
public enum ViewSide {
    Internal,External
} 
}
namespace ITAP.ProductionWorkingRelation.Modeling {
public enum OperationParamValueType {
    String,Boolean,Decimal,DateTime,Bytes,Enums,Dxf
} 
}
namespace ITAP.Components.Enums {
public enum SelectFormType {
    MultiRecord,OnlyRecord,None,MultiRecordAndCount
} 
}
namespace ITAP.Components.Enums {
public enum SortOrder {
    Unspecified,Ascending,Descending
} 
}
namespace ITAP.Components.Enums {
public enum LogImage {
    Default,Save,Info,Alert,Start,End
} 
}
namespace ITAP.Components.Enums {
public enum LogCriticalLevel {
    Low,Medium,Hight
} 
}
namespace ITAP.Components.Dialog {
public enum SelectViewType {
    EditableForm,SelectForm,TokenEditForm
} 
}
namespace ITAP.Components.Dialog.InputEditors {
public enum EditorType {
    Simple,Diapason,List
} 
}
namespace ITAP.glassCAD {
public enum CriterionFilterMode {
    All,Current
} 
}
namespace ITAP.glassCAD {
public enum CriterionGroupResultMode {
    Overwrite,All
} 
}
namespace ITAP.glassCAD.Workflow {
public enum WorkflowResult {
    Terminate,Success,Exception
} 
}
namespace ITAP.glassCAD.Workflow.Components {
public enum NDSCalculationMode {
    CalcNDSThenCalcValue,CalcValueThenCalcNDS
} 
}
namespace ITAP.glassCAD.Workflow.Components {
public enum RoundMode {
    Up,Down,Bankers
} 
}
namespace ITAP.glassCAD.Settings {
public enum PlateInfoInFrame {
    Nothing,GlobalPos,GlobalPosAndPack,AllInfo
} 
}
namespace ITAP.glassCAD.Settings {
public enum CuttingSizeType {
    FromPacking,FromFolder
} 
}
namespace ITAP.glassCAD.Settings {
public enum ProductionUniqueNumberType {
    ForOne,ForGroup
} 
}
namespace ITAP.glassCAD.Documents.Orders {
public enum ProductionModelElementType {
    Good,Operation,Halfproduction,Production
} 
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
public enum OperationConstraintMode {
    Full,Simple,Disabled
} 
}
namespace ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate {
public enum DocumentDocOper {
    Orders,ExternalRequest,GoodsHouse,ServiceDocument,Selling,BoxProduction
} 
}
namespace ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate {
public enum WorkFlowDocumentType {
    Document,DocumentItems,Goods,Service,Name,GroupItems
} 
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
public enum InterfaceItemMode {
    Default,ReadOnly,Hidden,Filter
} 
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
public enum SetObjectAttributesMode {
    Add,ReplaceIfExist,AddOrReplace
} 
}
namespace glassPeople.glassCAD.Components {
public enum FormItemButton {
    SaveCancel,Ok
} 
}
namespace glassPeople.glassCAD.Components {
public enum GridContextMenuItemType {
    FullExpand,FullCollapse,SortAscending,SortDescending,ClearSorting,GroupByColumn,UngroupColumn,ClearGrouping,ShowGroupPanel,HideColumn,ShowColumnChooser,ClearFilter,ShowFilterRow,ShowFooter,ExpandRow,CollapseRow,ExpandDetailRow,CollapseDetailRow,NewRow,EditRow,DeleteRow,FixColumnToRight,FixColumnToLeft,Unfix,SaveUpdates,CancelUpdates,UserAction
} 
}
namespace glassPeople.CRM {
public enum IssueStatus {
    Opened,Сlosed,InWork,InTest,InDiscuss,InGrayFolder
} 
}
namespace glassPeople.CRM {
public enum IssuePriority {
    Low,Normal,Hight
} 
}
namespace glassPeople.CRM {
public enum IssueMemberType {
    None,Responsible,Performe,ResponsiblePerforme
} 
}
namespace glassPeople.CRM {
public enum IssueFilterList {
    BY_STATUS,BY_PRIORITY,BY_PERFORME_MEMBER,BY_CREATED_AT,BY_LAST_COMMENT,BY_STATUS_CHNAGED
} 
}
namespace glassPeople.CRM {
public enum IssueHistoryType {
    CreateIssue,CreateIssueComment,ChangeIssueStatus,ChangeIssuePriority,ChangeIssueMembers,ChangeIssuePerformeMembers,ViewIssue
} 
}
namespace glassPeople.Model.Workflow {
public enum State {
    Created,Running,Idle,Freeze,Complited,Error,Paused,Stopped,Cancel,Empty,Kill
} 
}
namespace glassPeople.Model.Scheduler {
public enum ResourceMode {
    Stack,Parallel
} 
}
namespace glassPeople.Model.Scheduler {
public enum ResourceType {
    Other,Human,Equipment
} 
}
namespace glassPeople.Model.Scheduler {
public enum Status {
    Normal,Wait,Reserved,PreWorkIn,WorkIn,WorkOut,Used,Defective,PreDefective,Mixed,Canceled
} 
}
namespace glassPeople.Model.Documents {
public enum DocumentType {
    None,Input,Output,Movement,Initial,Annulment
} 
}
namespace glassPeople.Model.Dictionaries {
public enum ContragentType {
    Unknown,BuyerOfGoods,SupplierOfGoods
} 
}
namespace glassPeople.Model.Dictionaries {
public enum AccountingScheme {
    Unknown,White,Gray,Fictive
} 
}
namespace glassPeople.Model.Dictionaries {
public enum InventoryControlMode {
    Off,On
} 
}
namespace glassPeople.Model.Account {
public enum Status {
    Active,Paused,Passive
} 
}
namespace glassPeople.ActivityLibrary {
public enum AddRemoveExtraMode {
    AddOrUpdate,Add,Update,Remove,Get,Filter
} 
}
namespace glassPeople.ActivityLibrary {
public enum SelectionMode {
    None,Single,Multi
} 
}
namespace glassPeople.ActivityLibrary {
public enum SelectMode {
    Single,Multi
} 
}
namespace glassPeople.ActivityLibrary {
public enum BookmarkActivityUserAction {
    NextRun,Stop,Pause
} 
}
namespace glassPeople.ActivityLibrary {
public enum ListDocumentAction {
    None,Add,Edit,Dublicate,Delete,Custom
} 
}
namespace glassPeople.ActivityLibrary {
public enum PeriodDateMode {
    Manual,CurrentDay,PreviousWeek,PreviousMonth
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
public enum CodeInfoStatus {
    Fail,Ok,Warning
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
public enum ScancodeType {
    Unknown,Pyramid,Shift,Storehouse,Transport,CauseDefective,Glasspack,Command,ScanActivity
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
public enum BlockARMMode {
    People,Shift,Calendar
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
public enum TaskStatus {
    Default,WorkIn,WorkOut
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
public enum AppointmentItemStatus {
    Normal,WorkIn,WorkOut,Defective,MovedToNextOperation,Suspend,PreDefective,PreWorkIn
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
public enum AppointmentStatus {
    Normal,WorkIn,WorkOut,Mixed,Reserved,Defective,MovedToNextOperation,Suspend,PreDefective,PreWorkIn
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
public enum Direction {
    Forward,Reverse
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
public enum GroupCodeStatus {
    Normal,WorkIn,WorkOut,Mixed,Reserved,Defective,MovedToNextOperation,Suspend,PreDefective,PreWorkIn
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity {
public enum CapacityType {
    A,L,Arfa,Box,Space
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
public enum DateUseMode {
    ChildRestrictDate,ParentRestrictDate,DeliverDate
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
public enum Navigation {
    LeftToRight,RightToLeft
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring {
public enum NeighborsCheckMode {
    Any,All
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity {
public enum SavePlanningContextMode {
    SetFlagOnly,StoreByFlag,StoreAlways
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
public enum DeliverStatus {
    Normal,Suspend
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
public enum SetNumposByChildGroupCodeActivity_SourceIs {
    IsParent,IsChild,IsGlass
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
public enum BufferSecondNameMode {
    None,Default,ByInternalEticets,OrderInfo,ChildNumPos
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
public enum ScanerDataMode {
    None,GlassPack,AppointmentItems
} 
}
namespace glassPeople.ActivityLibrary.Core {
public enum InvokeMode {
    InMemory,Task,Freeze,BuildReport
} 
}
namespace ITAP.ProductionWorkingRelation {
public enum StateStatuses {
    Normal,Error,Warning
} 
}
namespace ITAP.Components {
public enum RoundType {
    Ceiling,Floor
} 
}
namespace ITAP.glassCAD.Helpers {
public enum FormMode {
    List,Select
} 
}
namespace ITAP.glassCAD.Helpers {
public enum SelectedMode {
    Single,Multiple
} 
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
public enum Mode {
    Default,Hidden,BeginRegion,EndRegion
} 
}
namespace glassPeople.glassCAD.Message {
public enum MessageDiraction {
    Incoming,Outcoming
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
public enum Status {
    InOrder,InPlan,SuspenedInPlan,InWork,Defective,WorkOut,StorehouseIn,StorehouseOut,StorehouseReturn,DefectiveOuter,StorehouseWriteOff,FixDefective,Canceled
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
public enum Mode {
    Add,Remove
} 
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
public enum MarkingMode {
    Default,OnlyPyramidInfo,OnlyBufferSecondName
} 
}
