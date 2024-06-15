namespace glassPeople.CRM {
    
    public partial class IssueMember {
		public System.Int32 IssueMemberId { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
		public System.String CompanyName { get; set; } 
		public System.String Email { get; set; } 
		public glassPeople.CRM.IssueMemberType MemberType { get; set; } 
		public System.Int32 UserStatus { get; set; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueFile {
		public System.Int32 TaskAttributeId { get; set; } 
		public System.Int32 IssueFileId { get; set; } 
		public System.String Name { get; set; } 
		public System.String ContentType { get; set; } 
		public System.Boolean IsImage { get; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueComment {
		public System.Int32 IssueCommentId { get; set; } 
		public System.String Text { get; set; } 
		public System.DateTime CreatedAt { get; set; } 
		public System.Int32 OwnerId { get; set; } 
		public glassPeople.CRM.IssueMember Owner { get; set; } 
		public System.Collections.Generic.List<glassPeople.CRM.IssueFile> Files { get; set; } 
		public System.Boolean UnreadComment { get; set; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueHistory {
		public System.DateTime HistoryDate { get; set; } 
		public glassPeople.CRM.IssueHistoryType HistoryType { get; set; } 
		public glassPeople.CRM.IssueStatus Status { get; set; } 
		public glassPeople.CRM.IssuePriority Priority { get; set; } 
		public System.String AccountUserString { get; set; } 
		public System.String PerformeUserString { get; set; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueRelation {
		public System.Int32 TaskId { get; set; } 
		public System.String Caption { get; set; } 
		public System.String AccountName { get; set; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class Issue {
		public System.Int32 TaskId { get; set; } 
		public System.Int32 TaskAttributeId { get; set; } 
		public System.Int32 ResourceId { get; set; } 
		public System.String Caption { get; set; } 
		public System.String Text { get; set; } 
		public glassPeople.CRM.IssueStatus Status { get; set; } 
		public glassPeople.CRM.IssuePriority Priority { get; set; } 
		public System.DateTime CreatedAt { get; set; } 
		public System.DateTime UpdatedAt { get; set; } 
		public System.DateTime LastCommentAt { get; set; } 
		public System.Int32 OwnerId { get; set; } 
		public glassPeople.CRM.IssueMember Owner { get; set; } 
		public System.Collections.Generic.List<glassPeople.CRM.IssueMember> Members { get; set; } 
		public System.Int32 PerformeMemberId { get; set; } 
		public glassPeople.CRM.IssueMember PerformeMember { get; set; } 
		public System.Collections.Generic.List<glassPeople.CRM.IssueFile> Files { get; set; } 
		public System.Collections.Generic.List<glassPeople.CRM.IssueComment> Comments { get; set; } 
		public System.Boolean HasUnreadComment { get; set; } 
		public System.Collections.Generic.List<glassPeople.CRM.IssueRelation> Relations { get; set; } 
		public System.Collections.Generic.List<System.String> Versions { get; set; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueFilter {
		public System.Collections.Generic.IEnumerable<glassPeople.CRM.IssueMember> ByPerformeMember { get; set; } 
		public System.Collections.Generic.IEnumerable<System.Int32> ByStatus { get; set; } 
		public System.Collections.Generic.IEnumerable<System.Int32> ByPriority { get; set; } 
		public System.Int32 GroupOrder { get; set; } 
		public System.Int32 SortOrder { get; set; } 
		public System.Boolean IsEnabled { get; set; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueFilterHelper {
		public glassPeople.CRM.IssueFilter Filter { get; set; } 
		public System.Action StateHasChanged { get; set; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class UserAccountHelper {
		public System.Int32 AccountId { get; set; } 
		public System.Int32 AccountRootId { get; set; } 
		public System.Int32 AccountUserId { get; set; } 
		public System.Int32 AccountUserRootId { get; set; } 
		public System.String AccountRootName { get; set; } 
		public System.String AccountName { get; set; } 
		public System.String UserName { get; set; } 
		public System.String UserNameRoot { get; set; } 
		public System.String UserEMail { get; set; } 
		public System.Int32[] AccountUserIds { get; set; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueMemberHelper : glassPeople.CRM.UserAccountHelper {
		public glassPeople.CRM.IssueMemberType MemberType { get; set; } 
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueHelper {
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueByStatusComparer {
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueByPriorityComparer {
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueByStatusChangeComparer {
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueByPerformeMemberComparer {
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueByLastCommentComparer {
    }
}
namespace glassPeople.CRM {
    
    public partial class IssueByCreatedAtComparer {
    }
}
namespace glassPeople.Model {
    
    public partial class Context : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<glassPeople.Model.Account.User> {
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Account.Account> Accounts { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Account.AccountUserRoles> AccountUserRoles { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Account.AccountUsers> AccountUsers { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Account.AccountUsersAttributes> AccountUsersAttributes { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.BusinessRole> BusinessRoles { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Charts.DateDataSource> ChartsDateDataSources { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Core.Attribute> Attributes { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.Agreement> Agreements { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ContragentGroup> ContragentGroups { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ContragentItem> ContragentItems { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ContragentItemAttributes> ContragentItemAttributes { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.Currency> Currency { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.DictionaryItem> Dictionaries { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.Equipment> Equipments { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.Localization> Localization { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.Measure> Measures { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.Operation> Operations { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ProductionGroup> ProductionGroups { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ProductionItem> ProductionItems { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ProductionItemAttributes> ProductionItemAttributes { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ProductionPart> ProductionParties { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ProductionPrice> ProductionPrices { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ProductionPriceDetail> ProductionPriceDetails { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ProductionPriceValue> ProductionPriceValues { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.ProductionType> ProductionTypes { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.Storehouse> Storehouses { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.Vat> Vats { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Dictionaries.WorkingPosition> WorkingPositions { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Documents.DocumentNameGenerator> DocumentNameGenerators { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Documents.ProductionDocument> ProductionDocuments { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Documents.ProductionDocumentItem> ProductionDocumentItems { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Documents.ProductionMovementDocument> ProductionMovementDocuments { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Documents.ProductionMovementDocumentItem> ProductionMovementDocumentItems { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Workflow.Instance> Instances { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Workflow.InstanceLog> InstanceLogs { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Log> Logs { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Registers.AccountBalanceRegister> AccountBalanceRegister { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Registers.ProductionRegister> ProductionRegister { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Scheduler.Resource> Resources { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Scheduler.ResourceAttributes> ResourceAttributes { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Scheduler.ResourceGroup> ResourceGroups { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Scheduler.Task> Task { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Scheduler.TaskAppointment> TaskAppointments { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Scheduler.TaskAttributes> TaskAttributes { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.TaskScheduler> TaskScheduler { get; set; } 
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.Model.Template> Templates { get; set; } 
    }
}
namespace glassPeople.Model {
    
    public abstract partial class ContextExtension {
    }
}
namespace glassPeople.Model {
    
    public partial class BusinessRole {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 BusinessRoleId { get; set; } 
		public System.String Name { get; set; } 
    }
}
namespace glassPeople.Model {
    
    public partial class Log {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 LogId { get; set; } 
		public System.Nullable<System.Int32> AccountId { get; set; } 
		public System.String Text { get; set; } 
		public System.DateTime DtLog { get; set; } 
    }
}
namespace glassPeople.Model {
    
    public partial class TaskScheduler {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 TaskSchedulerId { get; set; } 
		public System.Boolean Enabled { get; set; } 
		public System.String Name { get; set; } 
		public System.String Data { get; set; } 
		public System.String WhenToRun { get; set; } 
		public System.String Repeat { get; set; } 
		public System.Nullable<System.DateTime> LastRun { get; set; } 
		public System.Nullable<System.DateTime> NextRun { get; set; } 
		public System.String Result { get; set; } 
    }
}
namespace glassPeople.Model {
    
    public partial class Template {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 TemplateId { get; set; } 
		public System.String Name { get; set; } 
		public System.String GroupName { get; set; } 
		public System.String Description { get; set; } 
		public System.String Image { get; set; } 
		public System.String Data { get; set; } 
		public System.Boolean IsWorkflow { get; set; } 
		public System.Boolean IsReport { get; set; } 
		public System.Nullable<System.Int32> ToBusinessRoleId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("ToBusinessRoleId")]
		public glassPeople.Model.BusinessRole ToBusinessRole { get; set; } 
		public System.Nullable<System.Int32> NumPos { get; set; } 
		public System.Nullable<System.DateTime> LastUpdate { get; set; } 
		public System.Nullable<System.Guid> GUID { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Nullable<System.Int32> AccountId { get; set; } 
    }
}
namespace glassPeople.Model.Workflow {
    
    public partial class Instance {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 InstanceId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.DateTime CreateDateTime { get; set; } 
		public glassPeople.Model.Account.User AssignedToUser { get; set; } 
		public glassPeople.Model.BusinessRole AssignedToRole { get; set; } 
		public System.Nullable<System.Int32> ParentInstanceId { get; set; } 
		public glassPeople.Model.Workflow.Instance ParentInstance { get; set; } 
		public System.Guid ClientSessionId { get; set; } 
		public System.Int32 TemplateId { get; set; } 
		public System.String Arguments { get; set; } 
		public System.String Outputs { get; set; } 
		public System.String FormHtml { get; set; } 
		public glassPeople.Model.Workflow.State State { get; set; } 
		public System.DateTime UpdateStateDateTime { get; set; } 
		public glassPeople.Model.Account.User Owner { get; set; } 
		public System.String OwnerId { get; set; } 
		public System.String ErrorText { get; set; } 
		public System.Byte[] StoreBytes { get; set; } 
    }
}
namespace glassPeople.Model.Workflow {
    
    public partial class InstanceLog {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 InstanceLogId { get; set; } 
		public System.Int32 InstanceId { get; set; } 
		public System.DateTime DtLog { get; set; } 
		public glassPeople.Model.Workflow.State BeginState { get; set; } 
		public glassPeople.Model.Workflow.State EndState { get; set; } 
		public glassPeople.Model.Account.User Owner { get; set; } 
		public System.String OwnerId { get; set; } 
		public System.Byte[] ZipData { get; set; } 
		public System.String JsonData { get; set; } 
    }
}
namespace glassPeople.Model.Scheduler {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("Resource", Schema = "Scheduler")]
    public partial class Resource {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ResourceId { get; set; } 
		public System.String Name { get; set; } 
		public System.String Image { get; set; } 
		public System.String Description { get; set; } 
		public glassPeople.Model.Scheduler.ResourceMode Mode { get; set; } 
		public glassPeople.Model.Scheduler.ResourceType Type { get; set; } 
		public glassPeople.Model.Scheduler.ResourceGroup ResourceGroup { get; set; } 
		public System.Int32 ResourceGroupId { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Scheduler.ResourceAttributes> ResourceAttributes { get; set; } 
    }
}
namespace glassPeople.Model.Scheduler {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("ResourceAttributes", Schema = "Scheduler")]
    public partial class ResourceAttributes : glassPeople.Model.Dictionaries.AttributeValue {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ResourceAttributesId { get; set; } 
		public System.Int32 ResourceId { get; set; } 
		public glassPeople.Model.Scheduler.Resource Resource { get; set; } 
    }
}
namespace glassPeople.Model.Scheduler {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("ResourceGroup", Schema = "Scheduler")]
    public partial class ResourceGroup {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ResourceGroupId { get; set; } 
		public System.String Name { get; set; } 
		public System.Nullable<System.Int32> ParentId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
    }
}
namespace glassPeople.Model.Scheduler {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("Task", Schema = "Scheduler")]
    public partial class Task {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 TaskId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public glassPeople.Model.Scheduler.Resource Resource { get; set; } 
		public System.Int32 ResourceId { get; set; } 
		public glassPeople.Model.Scheduler.Status Status { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Scheduler.TaskAppointment> TaskAppointments { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Scheduler.TaskAttributes> Attributes { get; set; } 
    }
}
namespace glassPeople.Model.Scheduler {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("TaskAppointment", Schema = "Scheduler")]
    public partial class TaskAppointment {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 TaskAppointmentId { get; set; } 
		public glassPeople.Model.Scheduler.Task Task { get; set; } 
		public System.Int32 TaskId { get; set; } 
		public glassPeople.Model.Scheduler.Resource Resource { get; set; } 
		public System.Int32 ResourceId { get; set; } 
		public glassPeople.Model.Scheduler.Status Status { get; set; } 
		public System.String Subject { get; set; } 
		public System.DateTime Start { get; set; } 
		public System.DateTime End { get; set; } 
    }
}
namespace glassPeople.Model.Scheduler {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("TaskAttributes", Schema = "Scheduler")]
    public partial class TaskAttributes : glassPeople.Model.Dictionaries.AttributeValue {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 TaskAttributesId { get; set; } 
		public System.Int32 TaskId { get; set; } 
		public glassPeople.Model.Scheduler.Task Task { get; set; } 
    }
}
namespace glassPeople.Model.Registers {
    
    public partial class AccountBalanceRegister {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 AccountBalanceRegistrId { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.DateTime DtReg { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Value { get; set; } 
		public System.String Comment { get; set; } 
    }
}
namespace glassPeople.Model.Registers {
    
    public partial class ProductionRegister {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionRegisterId { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.Int32 ProductionPartId { get; set; } 
		public System.Int32 StorehouseId { get; set; } 
		public glassPeople.Model.Dictionaries.Storehouse Storehouse { get; set; } 
		public System.Int32 ObjectId { get; set; } 
		public System.DateTime DtReg { get; set; } 
		public System.Int32 ProductionItemId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Value { get; set; } 
    }
}
namespace glassPeople.Model.Documents {
    
    public abstract partial class Document {
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String NmDoc { get; set; } 
		public System.DateTime DtDoc { get; set; } 
		public System.String Comment { get; set; } 
		public System.Boolean IsEntry { get; set; } 
		public glassPeople.Model.Documents.DocumentType DocumentType { get; set; } 
    }
}
namespace glassPeople.Model.Documents {
    
    public partial class DocumentNameGenerator {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 DocumentNameGeneratorId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 Counter { get; set; } 
		public System.String Prefix { get; set; } 
    }
}
namespace glassPeople.Model.Documents {
    
    public partial class ProductionDocument : glassPeople.Model.Documents.Document {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionDocumentId { get; set; } 
		public System.Nullable<System.Int32> ContragentItemId { get; set; } 
		public glassPeople.Model.Dictionaries.ContragentItem ContragentItem { get; set; } 
		public glassPeople.Model.Dictionaries.Agreement Agreement { get; set; } 
		public System.Nullable<System.Int32> AgreementId { get; set; } 
		public System.Nullable<System.Int32> StorehouseId { get; set; } 
		public glassPeople.Model.Dictionaries.Storehouse Storehouse { get; set; } 
		public System.Nullable<System.Int32> ProductionPartId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionPart ProductionPart { get; set; } 
		public glassPeople.Model.Dictionaries.BankAccount ContragentItemBankAccount { get; set; } 
		public System.Nullable<System.Int32> ContragentItemBankAccountId { get; set; } 
		public glassPeople.Model.Dictionaries.BankAccount SellerBankAccount { get; set; } 
		public System.Nullable<System.Int32> SellerBankAccountId { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Documents.ProductionDocumentItem> Items { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Sm { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal SmWithoutVat { get; set; } 
		public glassPeople.Model.Account.User User { get; set; } 
    }
}
namespace glassPeople.Model.Documents {
    
    public partial class ProductionDocumentItem {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionDocumentItemId { get; set; } 
		public System.Int32 ProductionDocumentId { get; set; } 
		public glassPeople.Model.Documents.ProductionDocument ProductionDocument { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Int32 ProductionItemId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionItem ProductionItem { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Qu { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Price { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal PriceWithoutVat { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Sm { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal SmWithoutVat { get; set; } 
		public System.String ScanCode { get; set; } 
    }
}
namespace glassPeople.Model.Documents {
    
    public partial class ProductionMovementDocument : glassPeople.Model.Documents.Document {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionMovementDocumentId { get; set; } 
		public System.Nullable<System.Int32> SourceStorehouseId { get; set; } 
		public glassPeople.Model.Dictionaries.Storehouse SourceStorehouse { get; set; } 
		public System.Nullable<System.Int32> DestinationStorehouseId { get; set; } 
		public glassPeople.Model.Dictionaries.Storehouse DestinationStorehouse { get; set; } 
		public System.Nullable<System.Int32> ProductionPartId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionPart ProductionPart { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Documents.ProductionMovementDocumentItem> Items { get; set; } 
    }
}
namespace glassPeople.Model.Documents {
    
    public partial class ProductionMovementDocumentItem {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionMovementDocumentItemId { get; set; } 
		public System.Nullable<System.Int32> ProductionMovementDocumentId { get; set; } 
		public glassPeople.Model.Documents.ProductionMovementDocument ProductionMovementDocument { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Int32 ProductionItemId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionItem ProductionItem { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Qu { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class Agreement {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 AgreementId { get; set; } 
		public System.String Name { get; set; } 
		public System.DateTime Date { get; set; } 
		public glassPeople.Model.Dictionaries.ContragentItem ContragentItem { get; set; } 
		public System.Int32 ContragentItemId { get; set; } 
		public glassPeople.Model.Dictionaries.Currency Currency { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("Currency")]
		public System.String CurrencyCode { get; set; } 
		public glassPeople.Model.Dictionaries.ContragentType ContragentType { get; set; } 
		public System.String UseProductionPrices { get; set; } 
		public glassPeople.Model.Dictionaries.AccountingScheme AccountingScheme { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public abstract partial class AttributeValue {
		public System.Nullable<System.Int32> AttributeId { get; set; } 
		public glassPeople.Model.Core.Attribute Attribute { get; set; } 
		public System.String StringValue { get; set; } 
		public System.String StringValue1 { get; set; } 
		public System.String StringValue2 { get; set; } 
		public System.Nullable<System.Int32> IntValue { get; set; } 
		public System.Nullable<System.Int32> IntValue1 { get; set; } 
		public System.Nullable<System.Int32> IntValue2 { get; set; } 
		public System.Nullable<System.DateTime> DateTimeValue { get; set; } 
		public System.Nullable<System.DateTime> DateTimeValue1 { get; set; } 
		public System.Nullable<System.DateTime> DateTimeValue2 { get; set; } 
		public System.Nullable<System.Boolean> BoolValue { get; set; } 
		public System.Nullable<System.Boolean> BoolValue1 { get; set; } 
		public System.Nullable<System.Boolean> BoolValue2 { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Nullable<System.Decimal> DecimalValue { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Nullable<System.Decimal> DecimalValue1 { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Nullable<System.Decimal> DecimalValue2 { get; set; } 
		public System.Nullable<System.Int32> ParentId { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class BankAccount {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 BankAccountId { get; set; } 
		public System.String BIC { get; set; } 
		public System.String Name { get; set; } 
		public System.String CurrencyCode { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("CurrencyCode")]
		public glassPeople.Model.Dictionaries.Currency Currency { get; set; } 
		public System.String Address { get; set; } 
		public System.String AccountNumber { get; set; } 
		public System.String KAccountNumber { get; set; } 
		public System.Int32 ContragentItemId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("ContragentItemId")]
		public glassPeople.Model.Dictionaries.ContragentItem ContragentItem { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ContragentGroup {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ContragentGroupId { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Dictionaries.ContragentItem> ContragentItems { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ContragentItem {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ContragentItemId { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.Int32 ContragentGroupId { get; set; } 
		public glassPeople.Model.Dictionaries.ContragentGroup ContragentGroup { get; set; } 
		public System.String Name { get; set; } 
		public System.String LongName { get; set; } 
		public System.Nullable<System.Guid> Ident { get; set; } 
		public System.String OGRN { get; set; } 
		public System.String INN { get; set; } 
		public System.String KPP { get; set; } 
		public System.String Address { get; set; } 
		public System.String Comment { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Dictionaries.BankAccount> BankAccounts { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Dictionaries.ContragentItemAttributes> Attributes { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Dictionaries.Agreement> Agreements { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ContragentItemAttributes : glassPeople.Model.Dictionaries.AttributeValue {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ContragentItemAttributesId { get; set; } 
		public System.Int32 ContragentItemId { get; set; } 
		public glassPeople.Model.Dictionaries.ContragentItem ContragentItem { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class Currency {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.String Code { get; set; } 
		public System.String LongName { get; set; } 
		public System.String ShortName { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class DictionaryItem : glassPeople.Model.Dictionaries.AttributeValue {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 DictionaryItemId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class Equipment {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 EquipmentId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class Localization {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 LocalizationId { get; set; } 
		public System.String Source { get; set; } 
		public System.String Culture { get; set; } 
		public System.String Result { get; set; } 
		public System.Boolean IsUser { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class Measure {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 MeasureId { get; set; } 
		public System.String Name { get; set; } 
		public System.String ShortName { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class Operation {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 OperationId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ProductionGroup {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionGroupId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Dictionaries.ProductionItem> ProductionItems { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ProductionItem {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionItemId { get; set; } 
		public System.String Name { get; set; } 
		public System.String Article { get; set; } 
		public System.String ScanCode { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.Int32 ProductionGroupId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionGroup ProductionGroup { get; set; } 
		public System.Int32 ProductionTypeId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionType ProductionType { get; set; } 
		public System.Int32 MeasureId { get; set; } 
		public glassPeople.Model.Dictionaries.Measure Measure { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Dictionaries.ProductionItemAttributes> Attributes { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ProductionItemAttributes : glassPeople.Model.Dictionaries.AttributeValue {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionItemAttributesId { get; set; } 
		public System.Int32 ProductionItemId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionItem ProductionItem { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ProductionPart {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionPartId { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.String Name { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ProductionPrice {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionPriceId { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.String Name { get; set; } 
		public glassPeople.Model.Dictionaries.Currency Currency { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("Currency")]
		public System.String CurrencyCode { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Dictionaries.ProductionPriceDetail> Items { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ProductionPriceDetail {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionPriceItemId { get; set; } 
		public System.Int32 ProductionPriceId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionPrice ProductionPrice { get; set; } 
		public System.Int32 ProductionItemId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionItem ProductionItem { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Dictionaries.ProductionPriceValue> Values { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ProductionPriceValue : glassPeople.Model.Core.PeriodicDecimalValue {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionPriceValueId { get; set; } 
		public System.Int32 ProductionPriceDetailId { get; set; } 
		public glassPeople.Model.Dictionaries.ProductionPriceDetail ProductionPriceDetail { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class ProductionType {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ProductionTypeId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
		public glassPeople.Model.Dictionaries.Vat Vat { get; set; } 
		public System.Int32 VatId { get; set; } 
		public glassPeople.Model.Dictionaries.InventoryControlMode InventoryControlMode { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class Storehouse {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 StorehouseId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
		public System.String Address { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class Vat {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 VatId { get; set; } 
		public System.String DisplayValue { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Value { get; set; } 
    }
}
namespace glassPeople.Model.Dictionaries {
    
    public partial class WorkingPosition {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 WorkingPositionId { get; set; } 
		public System.String Name { get; set; } 
    }
}
namespace glassPeople.Model.Core {
    
    public partial class Attribute {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 AttributeId { get; set; } 
		public System.String Name { get; set; } 
		public System.String Image { get; set; } 
		public System.String Description { get; set; } 
		public System.Nullable<System.Boolean> InterfaceEditable { get; set; } 
    }
}
namespace glassPeople.Model.Core {
    
    public abstract partial class PeriodicValue<T> {
		public System.DateTime DateTime { get; set; } 
		public T Value { get; set; } 
    }
}
namespace glassPeople.Model.Core {
    
    public abstract partial class PeriodicDecimalValue : glassPeople.Model.Core.PeriodicValue<System.Decimal> {
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Value { get; set; } 
    }
}
namespace glassPeople.Model.Charts {
    
    public abstract partial class DataSource {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 DataSourceId { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
		public System.String Series { get; set; } 
		public System.Nullable<System.Int32> SourceId { get; set; } 
		public System.String SourceType { get; set; } 
    }
}
namespace glassPeople.Model.Charts {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("DateDataSource", Schema = "Charts")]
    public partial class DateDataSource : glassPeople.Model.Charts.DataSource {
		public System.DateTime Date { get; set; } 
		public System.String ArgumentName { get; set; } 
		public System.String ArgumentName1 { get; set; } 
		public System.String ArgumentName2 { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute(TypeName = "decimal(18,4)")]
		public System.Decimal Value { get; set; } 
    }
}
namespace glassPeople.Model.Account {
    
    public partial class Account {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 AccountId { get; set; } 
		public System.String Name { get; set; } 
		public System.String Code { get; set; } 
		public System.DateTime CreateDate { get; set; } 
		public glassPeople.Model.Account.Status Status { get; set; } 
		public System.Nullable<System.Int32> ContragentItemId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("ContragentItemId")]
		public glassPeople.Model.Dictionaries.ContragentItem ContragentItem { get; set; } 
    }
}
namespace glassPeople.Model.Account {
    
    public partial class AccountUserRoles {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 AccountUserRolesId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public glassPeople.Model.Account.AccountUsers AccountUsers { get; set; } 
		public System.Int32 AccountUsersId { get; set; } 
		public System.Int32 BusinessRoleId { get; set; } 
		public glassPeople.Model.BusinessRole BusinessRole { get; set; } 
		public System.Nullable<System.DateTime> StartPeriod { get; set; } 
		public System.Nullable<System.DateTime> EndPeriod { get; set; } 
    }
}
namespace glassPeople.Model.Account {
    
    public partial class AccountUsers {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 AccountUsersId { get; set; } 
		public glassPeople.Model.Account.Account Account { get; set; } 
		public System.Int32 AccountId { get; set; } 
		public glassPeople.Model.Account.User User { get; set; } 
		public System.String DisplayName { get; set; } 
		public System.DateTime Created { get; set; } 
		public glassPeople.Model.Account.Status Status { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Account.AccountUserRoles> Roles { get; set; } 
		public System.Collections.Generic.List<glassPeople.Model.Account.AccountUsersAttributes> Attributes { get; set; } 
    }
}
namespace glassPeople.Model.Account {
    
    public partial class AccountUsersAttributes : glassPeople.Model.Dictionaries.AttributeValue {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 AccountUsersAttributesId { get; set; } 
		public System.Int32 AccountUsersId { get; set; } 
		public glassPeople.Model.Account.AccountUsers AccountUsers { get; set; } 
    }
}
namespace glassPeople.Model.Account {
    
    public partial class User : Microsoft.AspNetCore.Identity.IdentityUser {
    }
}
namespace glassPeople.ActivityLibrary.Sql {
    
    public partial class Field {
		public System.String Name { get; set; } 
		public System.Object Value { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.Sql {
    [System.Reflection.DefaultMemberAttribute("Item")]
    public partial class Row : System.ValueType {
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.Sql.Field> Fields { get; set; } 
		public System.Object[] ItemArray { get; } 
		public System.Object Item { get; } 
    }
}
namespace glassPeople.ActivityLibrary.Sql {
    
    public abstract partial class Helper {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    
    public partial class TestQueryItem {
		public System.Int32 IDTestQuery { get; set; } 
		public System.String Name { get; set; } 
		public System.String Data { get; set; } 
		public System.String RepairCmd { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class Helper {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    
    public partial class Scancode {
		public System.String Code { get; set; } 
		public System.String Type { get; set; } 
		public System.Int32 Key { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Scanner.CodeInfoStatus Status { get; set; } 
		public System.String Info { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Scanner.ScancodeType ScancodeType { get; } 
		public System.Boolean IsUnknown { get; } 
		public System.Boolean IsPyramid { get; } 
		public System.Boolean IsShift { get; } 
		public System.Boolean IsStorehouse { get; } 
		public System.Boolean IsTransport { get; } 
		public System.Boolean IsCauseDefective { get; } 
		public System.Boolean IsGlasspack { get; } 
		public System.Boolean IsCommand { get; } 
		public System.Boolean IsScanActivity { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    
    public partial class ScanLog {
		public System.Int32 IDScanLog { get; set; } 
		public System.Int32 IDScanActivity { get; set; } 
		public System.String ActivityName { get; set; } 
		public System.Int32 IDPeople { get; set; } 
		public System.String EMail { get; set; } 
		public System.DateTime Dt { get; set; } 
		public System.String[] Roles { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    
    public partial class ScanLogProcessing {
		public System.Int32 IDScanProcessing { get; set; } 
		public System.String Name { get; set; } 
		public System.DateTime Dt { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Workers {
    
    public partial class ScannerWorkerException : System.Exception {
		public System.Nullable<System.Int32> IDScanProcessing { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Parser {
    
    public partial class DefaultParser {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Parser.SM {
    
    public partial class Parser : glassPeople.ActivityLibrary.glassCAD.Scanner.Parser.DefaultParser {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing {
    
    public abstract partial class DateTimeExtensions {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing {
    
    public abstract partial class Helper {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing {
    
    public partial class Period {
		public System.DateTime DateFrom { get; set; } 
		public System.DateTime DateTo { get; set; } 
		public System.Boolean IsFull { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Period Full { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing {
    
    public abstract partial class PeriodExtension {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("PlaningSettings")]
    public partial class Settings : glassPeople.Model.Dictionaries.AttributeValue {
		public System.Int32 IDPlaningSettings { get; set; } 
		public System.String Name { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union {
    
    public partial class Group {
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem> Items { get; set; } 
		public System.Object GroupObject { get; set; } 
		public System.Object Source { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Union.Group Parent { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class AddOrderTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32 IDOrder { get; set; } 
		public System.Nullable<System.DateTime> Date { get; set; } 
		public System.Nullable<System.DateTime> RestrictionDate { get; set; } 
		public System.String DeliverOrderStatus { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class BackToPreWorkInGroupCodeTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32 IDGroupCode { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class CanceledOrderItemsIdentTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Collections.Generic.List<System.Int32> IDOrderItemsIdentList { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class DisbandGroupCodesTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32[] IDGroupCodes { get; set; } 
		public System.Boolean ResetThreadPartName { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class DisbandOrderTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32 IDOrder { get; set; } 
		public System.Boolean SetSuspend { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class LinkGroupcodesTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32[] IDGroupCodes { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class MoveTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Nullable<System.Int32> IDCalendarSource { get; set; } 
		public System.Int32 IDCalendarDestination { get; set; } 
		public System.Int32[] IDGroupCodes { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class RefreshAppointmentItemsTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Collections.Generic.List<System.Int32> IDAppointmentsItems { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class RemoveOrderTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32 IDOrder { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class SetAcceptedGroupCodesTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32[] IDGroupCodes { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class SetNormalTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32 IDOrder { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class SetOptimizedGroupCodesTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32[] IDGroupCodes { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class SetPreWorkInTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.SetNormalTask {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class SetSuspendTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.SetNormalTask {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public abstract partial class Task {
		public System.Int32 Id { get; set; } 
		public System.String Command { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.TaskStatus Status { get; set; } 
		public System.String Result { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class UnionAppointmentItemsTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32[] IDAppointmnetItems { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class UnionArmSquareCuttingsTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32[] IDArmSquareCuttings { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Tasks {
    
    public partial class UnionGroupCodesTask : glassPeople.ActivityLibrary.glassCAD.Planing.Tasks.Task {
		public System.Int32[] IDGroupCodes { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class APyramid : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pyramid {
		public System.Int32 Bort1Id { get; set; } 
		public System.Int32 Bort2Id { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Bort Bort1 { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Bort Bort2 { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.APyramidSettings ASettings { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> PackingItems { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack> Packs { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class ArfaPyramid : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pyramid {
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> Items { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.ArfaSettings ArfaSettings { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> PackingItems { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack> Packs { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class ArmPacking {
		public System.Int32 Id { get; set; } 
		public System.String NmDoc { get; set; } 
		public System.String Comment { get; set; } 
		public System.Int32 IdExternal { get; set; } 
		public System.Int32 IdExternalType { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pyramid> Pyramids { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> PackingItems { get; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack> Packs { get; } 
		public System.Nullable<System.Int32> IDGrOptPacking { get; set; } 
		public System.Nullable<System.Int32> IDOptStrategy { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class Bort {
		public System.Int32 Id { get; set; } 
		public System.Int32 PyramidId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pyramid Pyramid { get; set; } 
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack> Items { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> PackingItems { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class Box : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pyramid {
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> Items { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.BoxSettings BoxSettings { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> PackingItems { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack> Packs { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class Buffer {
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacitySettings CapacitySettings { get; set; } 
		public System.Nullable<System.Int32> Qu { get; set; } 
		public System.Nullable<System.Int32> NumPos { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class Item {
		public System.Int32 Id { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack Pack { get; set; } 
		public System.Nullable<System.Int32> PackId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pyramid Pyramid { get; set; } 
		public System.Nullable<System.Int32> PyramidId { get; set; } 
		public System.Nullable<System.Int32> PosAlterPacking { get; set; } 
		public System.Nullable<System.Int32> IndexInPyramid { get; set; } 
		public System.Nullable<System.Int32> IndexInPack { get; set; } 
		public System.Int32 OrderItemsIdentId { get; set; } 
		public System.Decimal Width { get; set; } 
		public System.Decimal Height { get; set; } 
		public System.Decimal Weight { get; set; } 
		public System.Decimal Thickness { get; set; } 
		public System.Boolean Rotated { get; set; } 
		public System.Decimal WidthInStorage { get; } 
		public System.Decimal HeightInStorage { get; } 
		public System.String Comment { get; set; } 
		public System.String PrePackingGroup { get; set; } 
		public System.Nullable<System.Int32> PrePackingIndex { get; set; } 
		public System.Boolean IsRectangle { get; set; } 
		public System.Int32 OrderId { get; set; } 
		public System.Int32 OrderItemsId { get; set; } 
		public System.Nullable<System.Int32> CustomerId { get; set; } 
		public System.Nullable<System.Int32> MarshrutId { get; set; } 
		public System.String Address { get; set; } 
		public System.Nullable<System.Int32> AppointmentItemId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem AppointmentItem { get; set; } 
		public System.Int32 ArmPackingId { get; set; } 
		public System.String OrderItemComment { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item SideBySide { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class LPyramid : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pyramid {
		public System.Int32 BortId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Bort Bort { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.LPyramidSettings LSettings { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> PackingItems { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack> Packs { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class Pack {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public System.Int32 BortId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Bort Bort { get; set; } 
		public System.Int32 PackPileId { get; set; } 
		public System.Decimal Thickness { get; set; } 
		public System.Int32 Position { get; set; } 
		public System.Int32 Index { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Int32 OrderIndex { get; set; } 
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> Items { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> AllItems { get; } 
		public System.Nullable<System.Boolean> IsEqualSize { get; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack> Packs { get; } 
		public System.Int32 Count { get; } 
		public System.Decimal Weight { get; } 
		public System.Decimal WidthInStorage { get; } 
		public System.Decimal HeightInStorage { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public abstract partial class Pyramid {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public System.Int32 CapacitySettingsId { get; set; } 
		public System.Int32 ArmPackingId { get; set; } 
		public System.Byte[] Image { get; set; } 
		public System.Int32 Index { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.ArmPacking ArmPacking { get; set; } 
		public System.Nullable<System.Int32> Length { get; set; } 
		public System.Nullable<System.Int32> Height { get; set; } 
		public System.Nullable<System.Int32> Widht { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacitySettings CapacitySettings { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacityType CapacityType { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> PackingItems { get; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack> Packs { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing {
    
    public partial class Space : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pyramid {
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> Items { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.SpaceSettings SpaceSettings { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Item> PackingItems { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Pack> Packs { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy {
    
    public abstract partial class BaseStrategy {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy {
    
    public partial class Simple : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.BaseStrategy {
		public System.Collections.Generic.IDictionary<System.String, System.String> Parameters { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy {
    
    public partial class Simple2 : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Simple {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.SM {
    
    public partial class AStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Simple {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.SM {
    
    public partial class PackingStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Simple {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Harval {
    
    public partial class ItemComparer {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Harval {
    
    public partial class ItemViewComparer {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Harval {
    
    public partial class PackingStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Simple {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.glassTeam {
    
    public partial class PackingStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Simple {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.GGC {
    
    public partial class ArfaStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Simple {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.GGC {
    
    public partial class PackingStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Simple {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.MathPacksPosition {
    
    public abstract partial class IStrategy {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.MathPacksPosition {
    
    public partial class WithoutPillarsStrategy {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.MathPacksPosition {
    
    public partial class WithPillarsStrategy {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("Appointments")]
    public partial class Appointment {
		[System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute((System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption)0)]
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public System.Nullable<System.Int32> GroupCodeId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode GroupCode { get; set; } 
		public System.Int32 CalendarId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar Calendar { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentStatus Status { get; set; } 
		public System.String Subject { get; set; } 
		public System.DateTime StartDate { get; set; } 
		public System.DateTime EndDate { get; set; } 
		public System.Collections.Generic.ICollection<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem> AppointmentItems { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Appointment> Childs { get; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Appointment> Parents { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class AppointmentsItemsRelations {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 ID { get; set; } 
		public System.Int32 IDParentAppointmentItem { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("IDParentAppointmentItem")]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem Parent { get; set; } 
		public System.Int32 IDChildAppointmentItem { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("IDChildAppointmentItem")]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem Child { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("AppointmentsItems")]
    public partial class AppointmentItem {
		[System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute((System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption)0)]
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItemStatus Status { get; set; } 
		public System.Nullable<System.Boolean> IsCanceled { get; set; } 
		public System.Nullable<System.DateTime> ScanerDateTime { get; set; } 
		public System.Nullable<System.DateTime> StatusDateTimeChanged { get; set; } 
		public System.Nullable<System.Int32> AppointmentId { get; set; } 
		public System.Int32 Duration { get; set; } 
		public System.Int32 GroupCodeId { get; set; } 
		public System.Int32 OrderId { get; set; } 
		public System.Int32 OrderItemProductionModelId { get; set; } 
		public System.Int32 OrderItemsIdentId { get; set; } 
		public System.Nullable<System.Int32> CalendarId { get; set; } 
		public System.Nullable<System.Int32> Cart { get; set; } 
		public System.Nullable<System.Int32> Cell { get; set; } 
		public System.Nullable<System.Int32> CloneLinkId { get; set; } 
		public System.Nullable<System.Int32> NumPos { get; set; } 
		public System.Nullable<System.Int32> NumProductionLabel { get; set; } 
		public System.Nullable<System.Int32> ShiftId { get; set; } 
		public System.Nullable<System.Int32> TypePyramid { get; set; } 
		public System.String BufferSecondName { get; set; } 
		public System.String ObjectInfo { get; set; } 
		public System.String ScanerData { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Appointment Appointment { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar Calendar { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode GroupCode { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Order Order { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItemIdent OrderItemsIdent { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItemProductionModel OrderItemProductionModel { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Shift Shift { get; set; } 
		public System.String ThreadPartName { get; set; } 
		public System.Collections.Generic.ICollection<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentsItemsRelations> ChildsKeys { get; set; } 
		public System.Collections.Generic.ICollection<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentsItemsRelations> ParentsKeys { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem Child { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class Calendar {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute("IDCalendar")]
		public System.Int32 Id { get; set; } 
		public System.String Name { get; set; } 
		public System.String InternalLabelName { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute("IsInParallel")]
		public System.Boolean IsParallel { get; set; } 
		public System.Nullable<System.DateTime> Deleted { get; set; } 
		public System.Int32 Efficiency { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Direction AppointmentItemsOrderMode { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Direction HalfProductionOutDiraction { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.HashSet<glassPeople.ActivityLibrary.glassCAD.Planing.Model.CalendarIteration> CalendarIterations { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.HashSet<glassPeople.ActivityLibrary.glassCAD.Planing.Model.TimeReserve> TimeReserve { get; set; } 
		public System.Collections.Generic.ICollection<glassPeople.ActivityLibrary.glassCAD.Planing.Model.CalendarBufferDetail> CalendarBufferDetails { get; set; } 
		public System.Collections.Generic.ICollection<glassPeople.ActivityLibrary.glassCAD.Planing.Model.ShiftCalendarAccess> ShiftCalendarAccess { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("CalendarBufferDetail")]
    public partial class CalendarBufferDetail {
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute("IDCalendarBufferDetail")]
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute("IDCalendar")]
		public System.Int32 CalendarId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar Calendar { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute("IDGrOptPacking")]
		public System.Int32 CapacitySettingsId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacitySettings CapacitySettings { get; set; } 
		public System.Nullable<System.Int32> Qu { get; set; } 
		public System.Nullable<System.Int32> NumPos { get; set; } 
		public System.Nullable<System.Int32> SetIndex { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class CalendarIteration {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public System.Int32 CalendarId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar Calendar { get; set; } 
		public System.DateTime StartDate { get; set; } 
		public System.DateTime EndDate { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class CalendarScheduler {
		public System.Int32 IDCalendar { get; set; } 
		public System.Int32 IDScheduler { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class CalendarSchedulerInfo {
		public System.Int32 IDScheduler { get; set; } 
		public System.DateTime StartDate { get; set; } 
		public System.DateTime EndDate { get; set; } 
		public System.Boolean Monday { get; set; } 
		public System.Boolean Tuesday { get; set; } 
		public System.Boolean Wednesday { get; set; } 
		public System.Boolean Thursday { get; set; } 
		public System.Boolean Friday { get; set; } 
		public System.Boolean Saturday { get; set; } 
		public System.Boolean Sunday { get; set; } 
		public System.Boolean IsPause { get; set; } 
		public System.Boolean IsWork { get; set; } 
		public System.DateTime StartTime { get; set; } 
		public System.DateTime EndTime { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("GroupCode")]
    public partial class GroupCode {
		[System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute((System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption)0)]
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar Calendar { get; set; } 
		public System.Int32 CalendarId { get; set; } 
		public System.Nullable<System.Int32> ParentId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode Parent { get; set; } 
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Appointment> Appointments { get; set; } 
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem> AppointmentItems { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCodeStatus Status { get; set; } 
		public System.Nullable<System.Boolean> Prepared { get; set; } 
		public System.Nullable<System.Boolean> Optimized { get; set; } 
		public System.Nullable<System.Boolean> Accepted { get; set; } 
		public System.Nullable<System.Boolean> Processed { get; set; } 
		public System.Nullable<System.Int32> Duration { get; set; } 
		public System.Nullable<System.DateTime> PlanDate { get; set; } 
		public System.Nullable<System.DateTime> DeliveryGoodsDate { get; set; } 
		public System.Nullable<System.Int32> Priority { get; set; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Parents { get; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Childs { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("Operation")]
    public partial class Operation {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute("IDOperation")]
		public System.Int32 Id { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 OperationType { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class Order {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public System.DateTime DtDoc { get; set; } 
		public System.Int32 CustomerId { get; set; } 
		public System.Int32 Priority { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Boolean HasPriority { get; } 
		public System.Nullable<System.Int32> MarshrutId { get; set; } 
		public System.String Address { get; set; } 
		public System.String MarshrutExt { get; set; } 
		public System.String NmDoc { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Nullable<System.DateTime> DeliveryGoodsDate { get; set; } 
		public System.Collections.Generic.ICollection<glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItem> OrderItems { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class OrderItem {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public System.Int32 Count { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Int32 OrderId { get; set; } 
		public System.Nullable<System.Int32> PrePackingIndex { get; set; } 
		public System.String BarCode { get; set; } 
		public System.String Comment { get; set; } 
		public System.String Comment2 { get; set; } 
		public System.String OrderItemsInfo { get; set; } 
		public System.String PrePackingGroup { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Order Order { get; set; } 
		public System.Collections.Generic.ICollection<glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItemIdent> OrderItemIdents { get; set; } 
		public System.Collections.Generic.ICollection<glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItemProductionModel> Models { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    [System.ComponentModel.DataAnnotations.Schema.TableAttribute("OrderItemsIdent")]
    public partial class OrderItemIdent {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public System.Nullable<System.DateTime> PlanningCalendarDate { get; set; } 
		public System.Int32 OrderId { get; set; } 
		public System.Int32 OrderItemId { get; set; } 
		public System.Int32 Priority { get; set; } 
		public System.Nullable<System.Int32> Ident { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItem OrderItem { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class OrderItemProductionModelOperationParam {
		public System.Int32 Id { get; set; } 
		public System.Nullable<System.Boolean> BoolValue { get; set; } 
		public System.Nullable<System.DateTime> DateTimeValue { get; set; } 
		public System.Nullable<System.Decimal> DecimalValue { get; set; } 
		public System.Int32 IDOrderItemsProductionModel { get; set; } 
		public System.Int32 OperationParamValueType { get; set; } 
		public System.String Ident { get; set; } 
		public System.String Name { get; set; } 
		public System.String ParamValue { get; set; } 
		public System.String StringValue { get; set; } 
		public System.String Value { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class OrderItemProductionModel {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Nullable<System.Int32> ChildId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItemProductionModel Child { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItemProductionModel> TreeDown { get; } 
		public System.Int32 OrderItemId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItem OrderItem { get; set; } 
		public System.Int32 OperationId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Operation Operation { get; set; } 
		public System.Int32 Level { get; set; } 
		public System.Int32 NumposInLevel { get; set; } 
		public System.String Name { get; set; } 
		public System.Decimal Cost { get; set; } 
		public System.Decimal Duration { get; set; } 
		public System.Int32 HalfProductionId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.String HalfProductionName { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Decimal Square { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Decimal Width { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Decimal Height { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Decimal Thickness { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Decimal Weight { get; set; } 
		public System.String Calendars { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar> PossibleCalendars { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.OrderItemProductionModelOperationParam> OperationParams { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PropertyItem> Properties { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class PropertyItem {
		public System.String N { get; set; } 
		public System.String V { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    [System.Reflection.DefaultMemberAttribute("Item")]
    public partial class PropertyItemAdapter {
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PropertyItem> Items { get; set; } 
		public System.String Item { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class Pair<T> {
		public System.Int32 Id { get; set; } 
		public T Value { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class PlanningContext : Microsoft.EntityFrameworkCore.DbContext {
		public Microsoft.EntityFrameworkCore.DbSet<glassPeople.ActivityLibrary.glassCAD.Planing.Settings> Settings { get; set; } 
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.CalendarIteration> DefaultCalendarIterations { get; set; } 
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar> Calendars { get; set; } 
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacitySettings> CapacitySettings { get; set; } 
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Deliver.CalendarMovementDuration> CalendarMovementDurations { get; set; } 
		public System.String ConnectionString { get; set; } 
		public System.Boolean flagForSave { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class ShiftCalendarAccess {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 IDShiftCalendarAccess { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute("IDShift")]
		public System.Int32 ShiftId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Shift Shift { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute("IDCalendar")]
		public System.Int32 CalendarId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar Calendar { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class Shift {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		[System.ComponentModel.DataAnnotations.Schema.ColumnAttribute("IDShift")]
		public System.Int32 Id { get; set; } 
		public System.String Name { get; set; } 
		public System.Collections.Generic.ICollection<glassPeople.ActivityLibrary.glassCAD.Planing.Model.ShiftCalendarAccess> ShiftCalendarAccess { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar> Calendars { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    
    public partial class TimeReserve {
		[System.ComponentModel.DataAnnotations.KeyAttribute()]
		public System.Int32 Id { get; set; } 
		public System.Int32 CalendarId { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar Calendar { get; set; } 
		public System.DateTime StartDate { get; set; } 
		public System.DateTime EndDate { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity {
    
    public partial class APyramidSettings : glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.LPyramidSettings {
		public System.Int32 MaxOverweightMass { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity {
    
    public partial class ArfaSettings : glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacitySettings {
		public System.Int32 CellCount { get; set; } 
		public System.Int32 MaxSize1 { get; set; } 
		public System.Int32 MaxSize2 { get; set; } 
		public System.Int32 MaxMass { get; set; } 
		public System.Int32 MaxSizeVariant { get; set; } 
		public System.Int32 MaxThicknessCell { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity {
    
    public partial class BoxSettings : glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacitySettings {
		public System.Int32 Width { get; set; } 
		public System.Int32 Height { get; set; } 
		public System.Int32 Thickness { get; set; } 
		public System.Int32 MaxMass { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity {
    
    public abstract partial class CapacitySettings {
		public System.Int32 Id { get; set; } 
		public System.String Name { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacityType CapacityType { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity {
    
    public partial class LPyramidSettings : glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacitySettings {
		public System.Int32 BortLen { get; set; } 
		public System.Int32 BortDLen { get; set; } 
		public System.Boolean EnablePackOnPack { get; set; } 
		public System.Int32 ThicnessPackOnPack { get; set; } 
		public System.Int32 MaxGlassPackHeight { get; set; } 
		public System.Int32 MaxGlassPackDHeight { get; set; } 
		public System.Int32 WidthMiddlePack { get; set; } 
		public System.Int32 MaxThicknessPack { get; set; } 
		public System.Int32 MaxMassPyramid { get; set; } 
		public System.Int32 dmaxWidthPack { get; set; } 
		public System.Int32 dmaxHeightPack { get; set; } 
		public System.Int32 dmaxWidthPackM { get; set; } 
		public System.Int32 dmaxHeightPackM { get; set; } 
		public System.Boolean dmaxWidthPackProcent { get; set; } 
		public System.Boolean dmaxHeightPackProcent { get; set; } 
		public System.Boolean dmaxWidthPackMProcent { get; set; } 
		public System.Boolean dmaxHeightPackMProcent { get; set; } 
		public System.Int32 PrWidthMiddleStPack { get; set; } 
		public System.Nullable<System.Int32> PackOutBortValue { get; set; } 
		public System.Nullable<System.Int32> PackOutBortPercent { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.Pillar> Pillars { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity {
    
    public partial class Pillar {
		public System.Int32 SettingsId { get; set; } 
		public System.Int32 Offset { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity {
    
    public partial class SpaceSettings : glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.CapacitySettings {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    
    public partial class CalendarMovementDuration {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    
    public partial class DeliverTimeOutException : System.Exception {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    
    public partial class Command {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    
    public partial class DeliverItem {
		public glassPeople.ActivityLibrary.glassCAD.Planing.Deliver.DeliverItem Relation { get; set; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Deliver.DeliverItem> All { get; } 
		public System.Boolean IsValid { get; } 
		public System.Boolean IsValidProgress { get; } 
		public System.Boolean HasValue { get; } 
		public System.Boolean IsParentValid { get; } 
		public System.Boolean IsChildValid { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    
    public partial class DeliverSpace {
		public System.Int32 Duration { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    
    public partial class DeliverSpaceLine {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    
    public partial class Period {
		public System.DateTime DateFrom { get; set; } 
		public System.DateTime DateTo { get; set; } 
		public System.Boolean IsFull { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Deliver.Period Full { get; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    
    public abstract partial class PeriodExtension {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Cutting {
    
    public partial class ArmSquareCutting {
		public System.Int32 Id { get; set; } 
		public System.String NmDoc { get; set; } 
		public System.Int32 IdExternal { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.String Comment { get; set; } 
		public System.Nullable<System.Int32> IDOptStrategy { get; set; } 
		public System.String PyramidInfo { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Cutting.Item> Items { get; set; } 
		public System.Nullable<System.Int32> IDGlassStorehouseOstOut { get; set; } 
		public System.Nullable<System.Int32> IDGlassPackageOstOut { get; set; } 
		public System.Nullable<System.Int32> CellOstOut { get; set; } 
		public System.String PathInfo { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Cutting {
    
    public partial class Item {
		public System.Int32 Id { get; set; } 
		public System.Int32 ArmSquareCuttingId { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public glassPeople.ActivityLibrary.glassCAD.Planing.Cutting.ArmSquareCutting ArmSquareCutting { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 IDGood { get; set; } 
		public System.String Marking { get; set; } 
		public System.Decimal Width { get; set; } 
		public System.Decimal Height { get; set; } 
		public System.String OptData { get; set; } 
		public System.Int32 IDExternalObject { get; set; } 
		public System.Int32 IDExternalObject1 { get; set; } 
		public System.Decimal WorkSquare { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Orders {
    
    public partial class DeliverBuilder {
		public System.Linq.ILookup<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar, glassPeople.ActivityLibrary.glassCAD.Planing.Period> UnmovableItems { get; set; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.CalendarIteration> Iterations { get; set; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Appointment> Items { get; set; } 
		public System.DateTime StartDeliverDate { get; set; } 
		public System.DateTime RestrictionDeliverDate { get; set; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Deliver.CalendarMovementDuration> CalendarMovementDurations { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class DeliverBuilder {
		public System.Linq.ILookup<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Calendar, glassPeople.ActivityLibrary.glassCAD.Planing.Period> UnmovableItems { get; set; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.CalendarIteration> Iterations { get; set; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> Items { get; set; } 
		public System.Collections.Generic.IEnumerable<System.ValueTuple<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode, glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> ItemRelations { get; set; } 
		public System.Collections.Generic.IEnumerable<glassPeople.ActivityLibrary.glassCAD.Planing.Deliver.CalendarMovementDuration> CalendarMovementDurations { get; set; } 
		public System.Nullable<System.DateTime> ManualDateDeliver { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class InvokeInArgument {
		public System.String Name { get; set; } 
		public System.Activities.InArgument Value { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class InvokeOutArgument {
		public System.String Name { get; set; } 
		public System.Activities.OutArgument Value { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.Core {
    
    public partial class SwitchItem {
		public System.String Name { get; set; } 
		public System.String Group { get; set; } 
		public System.String Text { get; set; } 
		public System.String Image { get; set; } 
		public System.String HeaderText { get; set; } 
		public System.String HeaderDescription { get; set; } 
		public System.Collections.ObjectModel.ObservableCollection<glassPeople.ActivityLibrary.Core.SwitchItem> Items { get; set; } = new System.Collections.ObjectModel.ObservableCollection<glassPeople.ActivityLibrary.Core.SwitchItem>();
    }
}
namespace glassPeople.CRM {
    public partial class LogController {
    
    public partial class LogItem {
		public System.String From { get; set; } 
		public System.String Subj { get; set; } 
		public System.String Text { get; set; } 
    }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Utilites {
    public partial class Processing_OrderItemsIdentWorkStatus {
    
    public partial class OrderResult {
		public System.String OrderStatus { get; set; } 
		public System.Decimal PercentWorkIn { get; set; } 
		public System.Decimal PercentWorkDone { get; set; } 
		public System.Decimal PercentStorehouseIn { get; set; } 
		public System.Decimal PercentStorehouseOut { get; set; } 
		public System.Decimal PercentCanceled { get; set; } 
		public System.Decimal PercentStoreHouseDefective { get; set; } 
		public System.Decimal Paid { get; set; } 
		public System.Int32 OrderColor { get; set; } 
    }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public partial class IncomingToSGPModeActivity {
    
    public partial class Pyr {
    }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner {
    public partial class IncomingToSGPModeActivity {
    
    public partial class GPinfo {
		public System.Int32 IDOrder { get; set; } 
		public System.Int32 IDOrderItems { get; set; } 
		public System.Int32 IDMarshrut { get; set; } 
		public System.Int32 IDCustomer { get; set; } 
		public System.Int32 IDPyramid { get; set; } 
		public System.Int32 IDGlassPack { get; set; } 
		public System.Int32 IDOrderItemsIdent { get; set; } 
    }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Model {
    public partial class PlanningContext {
    
    public abstract partial class Status {
    }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    public partial class Command {
    
    public partial class FindResult {
    }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    public partial class DeliverSpace {
    
    public partial class DurationInfo {
		public System.DateTime EndDateTime { get; set; } 
    }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    public partial class StoreDate {
    
    public partial class DeliverItem {
    }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Deliver {
    public partial class StoreDate {
    
    public partial class DeliverSpaceLine {
    }
    }
}
