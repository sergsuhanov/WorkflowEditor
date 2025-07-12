namespace ITAP.Components {
    
    public abstract partial class Calculator {
    }
}
namespace ITAP.Components {
    
    public partial class Useful {
    }
}
namespace ITAP.Components {
    
    public partial class Translit {
    }
}
namespace ITAP.Components.Enums.Attributes {
    
    public partial class ColorValueAttribute : System.Attribute {
		public System.Drawing.Color Value { get; } 
    }
}
namespace ITAP.Components.Enums.Attributes {
    
    public partial class StringEnum {
		public System.Type EnumType { get; } 
    }
}
namespace ITAP.Components.Enums.Attributes {
    
    public partial class StringValueAttribute : System.Attribute {
		public System.String Value { get; } 
    }
}
namespace ITAP.Components.Entities {
    
    public partial class LookUpItem {
		public System.Int32 ID { get; set; } 
		public System.Guid Guid { get; set; } 
		public System.String Name { get; set; } 
		public System.String Group { get; set; } 
		public ITAP.Components.Entities.ListLookUpItem Parent { get; set; } 
    }
}
namespace ITAP.Components.Entities {
    
    public partial class ListLookUpItem : System.Collections.Generic.List<ITAP.Components.Entities.LookUpItem> {
		public System.String ListName { get; set; } 
    }
}
namespace ITAP.Components.Entities {
    
    public partial class EqualType : ITAP.Components.Entities.LookUpItem {
		public ITAP.Components.Dialog.InputEditors.EditorType EditorType { get; set; } 
    }
}
namespace ITAP.Components.Entities {
    
    public partial class TimeMeasure : ITAP.Components.Entities.LookUpItem {
    }
}
namespace ITAP.Components.Entities {
    [System.Reflection.DefaultMemberAttribute("Item")]
    public partial class Attribute {
		public System.Int32 IDAttribute { get; set; } 
		public System.Object Item { get; set; } 
    }
}
namespace ITAP.Components.Delegates {
    
    public partial class DelegateAddLog : System.MulticastDelegate {
    }
}
namespace ITAP.Components.Delegates {
    
    public partial class DelegateEnabledLog : System.MulticastDelegate {
    }
}
namespace ITAP.Components.Delegates {
    
    public partial class DelegateExceptionLog : System.MulticastDelegate {
    }
}
namespace ITAP.Components.Delegates {
    
    public partial class DelegateExceptionLogData : System.MulticastDelegate {
    }
}
namespace ITAP.Components.Delegates {
    
    public partial class DelegateExceptionLogString : System.MulticastDelegate {
    }
}
namespace ITAP.Components.Data {
    
    public partial class DBConn {
		public System.Transactions.TransactionScope DefaultTransactionScope { get; } 
		public System.Transactions.TransactionScope IsolatedTransactionScope { get; } 
    }
}
namespace ITAP.glassCAD {
    
    public abstract partial class GlassTypeHelper {
    }
}
namespace ITAP.glassCAD {
    
    public partial class Criterion : ITAP.Components.Entities.LookUpItem {
		public System.String Code { get; set; } 
		public ITAP.glassCAD.CriterionGroupResultMode GroupResultMode { get; set; } 
		public ITAP.glassCAD.CriterionFilterMode CriterionFilterMode { get; set; } 
		public System.Boolean AllowSave { get; set; } 
		public System.Type TypeValue { get; set; } 
		public System.Type TypeOfEditor { get; set; } 
		public System.Boolean ConvertibleValueToKoef { get; set; } 
		public System.Collections.Generic.List<ITAP.Components.Entities.LookUpItem> LookUpItemList { get; set; } 
		public System.Boolean ShapeDependency { get; set; } 
		public System.Boolean IsDisabled { get; set; } 
    }
}
namespace ITAP.glassCAD {
    
    public abstract partial class OperationTypeIdent {
    }
}
namespace ITAP.glassCAD {
    
    public abstract partial class Program {
    }
}
namespace ITAP.glassCAD {
    
    public abstract partial class SqlHelper {
    }
}
namespace ITAP.glassCAD {
    
    public partial class WrapperDataRow<T> {
		public T DataRow { get; set; } 
    }
}
namespace ITAP.glassCAD {
    
    public partial class WrapperDataTable<T> : System.Collections.ObjectModel.ObservableCollection<ITAP.glassCAD.WrapperDataRow<T>> {
		public System.Data.DataTable DataTable { get; set; } 
    }
}
namespace ITAP.glassCAD.Workflow {
    
    public abstract partial class Helper {
    }
}
namespace ITAP.glassCAD.Workflow.Context {
    
    public abstract partial class Helper {
    }
}
namespace ITAP.glassCAD.Workflow.Context {
    [System.Reflection.DefaultMemberAttribute("Item")]
    public partial class PropertyAdapter<T> {
		public T Item { get; } 
    }
}
namespace ITAP.glassCAD.Workflow.Context {
    
    public partial class Property {
    }
}
namespace ITAP.glassCAD.Workflow.Context {
    
    public abstract partial class WFContext {
		public System.String Hint { get; set; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Data.DataLayer DataLayer { get; set; } 
		public System.Boolean IsAdminSession { get; } 
    }
}
namespace ITAP.glassCAD.Workflow.Components {
    
    public partial class AbortException : System.Exception {
		public ITAP.glassCAD.Workflow.WorkflowResult Reason { get; set; } 
    }
}
namespace ITAP.glassCAD.Workflow.Components {
    
    public partial class ActivityResult {
		public System.Type Type { get; set; } 
		public System.Object Value { get; set; } 
		public System.String ValueStr { get; set; } 
    }
}
namespace ITAP.glassCAD.Workflow.Components {
    [System.AttributeUsageAttribute((System.AttributeTargets)4, AllowMultiple = true)]
    public partial class ActivityResultAttribute : System.Attribute {
		public System.Type TypeResult { get; set; } 
		public System.Type TypeConverter { get; set; } 
    }
}
namespace ITAP.glassCAD.Workflow.Components {
    
    public partial class ActivityResultSetAttribute : System.Attribute {
		public System.Type InType { get; set; } 
		public System.String InProperty { get; set; } 
    }
}
namespace ITAP.glassCAD.Production {
    
    public partial class ViewModel {
		public System.String ViewBox { get; set; } 
		public System.Decimal Scale { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.Rect Box { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.Vector2 SunPosition { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.Vector2 SmilePosition { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.Vector2 AddGoodsPosition { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.ShowMode Mode { get; set; } 
    }
}
namespace ITAP.glassCAD.Production.Model {
    
    public partial class Good : ITAP.glassCAD.Production.Model.Item {
		public ITAP.glassCAD.GoodsType GoodsType { get; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsRow GoodsRow { get; set; } 
		public System.String Formula { get; set; } 
		public System.String Comment { get; set; } 
		public System.Boolean InvertInShape { get; set; } 
		public System.Int32 SideSputtering { get; set; } 
    }
}
namespace ITAP.glassCAD.Production.Model {
    
    public partial class HalfProduction : ITAP.glassCAD.Production.Model.Item {
		public System.Collections.Generic.List<ITAP.glassCAD.Production.Model.HalfProductionProperty> Properties { get; set; } 
		public System.Boolean IsCanceled { get; } 
		public System.Nullable<System.Int32> IDOrderItemsIdentCanceled { get; set; } 
		public System.Nullable<System.Int32> IDOrderItemsProductionModelCanceled { get; set; } 
		public ITAP.glassCAD.Production.Model.Operation Operation { get; } 
    }
}
namespace ITAP.glassCAD.Production.Model {
    [System.Xml.Serialization.XmlRootAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "P")]
    public partial class HalfProductionProperty {
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public System.Int32 ID { get; set; } 
		[System.Xml.Serialization.XmlElementAttribute(ElementName = "N")]
		public System.String Name { get; set; } 
		[System.Xml.Serialization.XmlElementAttribute(ElementName = "V")]
		public System.String Value { get; set; } 
		[System.Xml.Serialization.XmlElementAttribute(ElementName = "IC")]
		public System.Boolean IsCurrent { get; set; } 
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public System.String DisplayName { get; set; } 
    }
}
namespace ITAP.glassCAD.Production.Model {
    
    public abstract partial class IItemVisitor {
    }
}
namespace ITAP.glassCAD.Production.Model {
    
    public abstract partial class Item {
		public System.Int32 Id { get; set; } 
		public System.String Name { get; set; } 
		public System.String NameManual { get; set; } 
		public System.Boolean IsShapeManualSetting { get; set; } 
		public System.Byte[] ShapeData { get; set; } 
		public System.Int32 Level { get; } 
		public System.Nullable<System.Int32> NumPos { get; set; } 
		public System.Collections.Generic.List<ITAP.glassCAD.Production.Model.Item> Parents { get; set; } 
		public ITAP.glassCAD.Production.Model.Item Child { get; set; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Production.Model.Item> AllParents { get; } 
    }
}
namespace ITAP.glassCAD.Production.Model {
    
    public partial class MainModel {
		public ITAP.glassCAD.Production.Model.ViewSide ViewSide { get; set; } 
		public System.Collections.Generic.List<ITAP.glassCAD.Production.Model.Item> Items { get; set; } 
    }
}
namespace ITAP.glassCAD.Production.Model {
    
    public partial class Operation : ITAP.glassCAD.Production.Model.Item {
		public ITAP.glassCAD.OperationType OperationType { get; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationRow OperationRow { get; set; } 
		public System.Nullable<System.Decimal> Duration { get; set; } 
		public System.Nullable<System.Decimal> Cost { get; set; } 
		public System.Collections.Generic.List<ITAP.glassCAD.Production.Model.OperationParam> OperationParams { get; set; } 
		public ITAP.glassCAD.Production.Model.HalfProduction HalfProduction { get; } 
    }
}
namespace ITAP.glassCAD.Production.Model {
    
    public partial class OperationParam {
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationParamRow OperationParamRow { get; set; } 
		public System.String Value { get; set; } 
		public ITAP.glassCAD.OperationParamValueType ValueType { get; } 
    }
}
namespace ITAP.glassCAD.Production.Model {
    
    public partial class Production : ITAP.glassCAD.Production.Model.HalfProduction {
    }
}
namespace ITAP.glassCAD.Utilites {
    
    public partial class CriterionList {
    }
}
namespace ITAP.glassCAD.Helpers {
    
    public partial class FormParameters {
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button> ContextMenuItems { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button>();
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button> ToolBarItems { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button>();
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button> BottomBarItems { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button>();
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button> CustomItems { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button>();
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.InterfacePreset InterfacePreset { get; set; } 
		public ITAP.glassCAD.Helpers.FormParameters.FormMode Mode { get; set; } 
		public ITAP.glassCAD.Helpers.FormParameters.SelectedMode Selected { get; set; } 
		public System.String DoubleClickActionName { get; set; } 
		public System.Nullable<System.Int32> FocusedIdObject { get; set; } 
		public System.Action<System.String, System.Nullable<System.Int32>, System.Collections.Generic.List<System.Int32>> ButtonClick { get; set; } 
    }
}
namespace ITAP.glassCAD.Extensions {
    
    public abstract partial class DateTimeExtensions {
    }
}
namespace ITAP.glassCAD.Extensions {
    
    public abstract partial class DecimalExtensions {
    }
}
namespace ITAP.glassCAD.Extensions {
    
    public abstract partial class DictionaryExtensions {
    }
}
namespace ITAP.glassCAD.Extensions {
    
    public abstract partial class DoubleExtensions {
    }
}
namespace ITAP.glassCAD.Extensions {
    
    public abstract partial class IEnumerableExtensions {
    }
}
namespace ITAP.glassCAD.Extensions {
    
    public abstract partial class NullableExtensions {
    }
}
namespace ITAP.glassCAD.Extensions {
    
    public abstract partial class ObjectExtensions {
    }
}
namespace ITAP.glassCAD.Extensions {
    
    public abstract partial class StringExtensions {
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    
    public partial class OrdersDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderCalculationsDataTable OrderCalculations { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderCalculationVariablesDataTable OrderCalculationVariables { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderCuttingDataTable OrderCutting { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderGoodsDataTable OrderGoods { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsDataTable OrderItems { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelDataTable OrderItemsProductionModel { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelGoodDataTable OrderItemsProductionModelGood { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelHalfProductionDataTable OrderItemsProductionModelHalfProduction { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationDataTable OrderItemsProductionModelOperation { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationIdentValueDataTable OrderItemsProductionModelOperationIdentValue { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderPriceGoodsDataTable OrderPriceGoods { get; set; } 
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow HeaderRow { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersDataTable Orders { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderServicesDataTable OrderServices { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderSignDataTable OrderSign { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet CustomerDataSet { get; set; } 
		public System.Collections.Concurrent.ConcurrentDictionary<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelRow, System.Collections.Generic.List<ITAP.glassCAD.Documents.Orders.CriterionCasheItem>> CasheProperty { get; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    
    public partial class CriterionCasheItem {
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationRow OperationRow { get; } 
		public ITAP.glassCAD.Criterion Criterion { get; set; } 
		public System.String Code { get; set; } 
		public System.Object Value { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public abstract partial class BaseOrderCalculationContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.BaseOrderContext {
		public System.Decimal SmOrderItems { get; } 
		public System.Decimal SmOrderGoods { get; } 
		public System.Decimal SmOrderServices { get; } 
		public System.Decimal SmOrderServicesVisible { get; } 
		public System.Decimal SmOrderServicesOther { get; } 
		public System.Decimal SmWithoutNDSCalc { get; } 
		public System.Int32 NDSValue { get; set; } 
		public ITAP.glassCAD.Workflow.Components.NDSCalculationMode NDSCalculationMode { get; set; } 
		public System.Int32 RoundCountDigits { get; set; } 
		public System.Int32 RoundCountDigitsNDS { get; set; } 
		public ITAP.glassCAD.Workflow.Components.RoundMode RoundMode { get; set; } 
		public System.Nullable<System.Decimal> Markup { get; } 
		public System.Nullable<System.Decimal> Discount { get; } 
		public System.Decimal DiscountDifMarkup { get; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public abstract partial class BaseOrderContext : ITAP.glassCAD.Workflow.Context.WFContext {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow DocumentRow { get; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.AgreementRow AgreementRow { get; } 
		public System.Boolean IsDefective { get; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class Navigator {
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OperationCalendarContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderItemsProductionModelContext {
		public ITAP.glassCAD.Documents.Orders.WorkFlow.Context.AvaliableCalendarForOperationList AvaliableCalendars { get; set; } 
		public ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OperationConstraintMode Mode { get; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class AvaliableCalendarForOperation {
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class AvaliableCalendarForOperationList : System.Collections.Generic.List<ITAP.glassCAD.Documents.Orders.WorkFlow.Context.AvaliableCalendarForOperation> {
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OperationConstraintContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderItemsProductionModelContext {
		public System.Boolean HasConstraint { get; set; } 
		public ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OperationConstraintMode Mode { get; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OperationCostContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderItemsProductionModelContext {
		public System.Int32 IDCalendar { get; set; } 
		public System.Decimal OperationCost { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OperationDurationContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderItemsProductionModelContext {
		public System.Int32 IDCalendar { get; set; } 
		public System.String Calendars { get; set; } 
		public System.Decimal OperationDuration { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class GoodItem {
		public System.Decimal Qu { get; } 
		public System.Decimal QuWaste { get; } 
		public System.Decimal QuWithoutWaste { get; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OperationGoodsContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderItemsProductionModelContext {
		public System.Collections.Generic.List<ITAP.glassCAD.Documents.Orders.WorkFlow.Context.GoodItem> GoodItems { get; set; } 
		public System.Int32 IDCalendar { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OperationProcessingContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderItemsProductionModelContext {
		public System.Double IncreaseShapeValue { get; set; } 
		public System.Double IncreaseShapeBoundsValue { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class CostOfGoodsItem {
		public System.Decimal Value { get; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class CostOfGoodsAdapter {
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class CostOfWorkItem {
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class CostOfWorkAdapter {
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OrderCalculationContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.BaseOrderCalculationContext {
		public System.Decimal CostOfDelivery { get; set; } 
		public System.Decimal Sm { get; set; } 
		public System.Decimal SmWithoutNDS { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OrderGoodCalculationContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.BaseOrderCalculationContext {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderGoodsRow OrderGoodsRow { get; set; } 
		public System.Decimal Qu { get; } 
		public System.Nullable<System.Decimal> PriceManualSet { get; } 
		public System.Nullable<System.Decimal> GoodPrice { get; } 
		public System.Nullable<System.Decimal> InternalGoodPrice { get; } 
		public System.Decimal Price { get; set; } 
		public System.Decimal PriceWithoutNDS { get; set; } 
		public System.Decimal InternalPrice { get; set; } 
		public System.Decimal Sm { get; set; } 
		public System.Decimal SmWithoutNDS { get; set; } 
		public System.Decimal InternalSm { get; set; } 
		public System.Nullable<System.Decimal> CorrectPrice { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OrderItemCalculationContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.BaseOrderCalculationContext {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsRow OrderItemRow { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsRow DefectiveOrderItemRow { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelRow Model { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationRow OperationModel { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelRow ChildModel { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelHalfProductionRow ProductionModel { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.CriterionCasheItem> Properties { get; } 
		public System.Decimal Qu { get; } 
		public System.Decimal Square { get; } 
		public System.Decimal Price { get; set; } 
		public System.Decimal PriceWithoutNDS { get; set; } 
		public System.Decimal UnitPrice { get; set; } 
		public System.Decimal UnitPriceWithoutNDS { get; set; } 
		public System.Decimal Sm { get; set; } 
		public System.Decimal SmWithoutNDS { get; set; } 
		public System.Nullable<System.Decimal> CorrectPrice { get; set; } 
		public System.Nullable<System.Decimal> CorrectPriceService { get; set; } 
		public System.Nullable<System.Decimal> PriceManualSet { get; set; } 
		public System.Boolean IsDefective { get; set; } 
		public System.Decimal CostOfGoods { get; set; } 
		public ITAP.glassCAD.Documents.Orders.WorkFlow.Context.CostOfGoodsAdapter CostOfGoodsInfo { get; set; } 
		public System.Decimal CostOfDelivery { get; set; } 
		public System.Decimal CostOfWork { get; set; } 
		public ITAP.glassCAD.Documents.Orders.WorkFlow.Context.CostOfWorkAdapter CostOfWorkInfo { get; set; } 
		public System.Decimal CostOfCanceledHp { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OrderItemGroupCalculationContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.BaseOrderCalculationContext {
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsRow> Items { get; set; } 
		public System.Decimal S { get; } 
		public System.Decimal Sm { get; } 
		public System.Decimal SmWithoutNDS { get; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OrderItemNamesCalculationContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.BaseOrderContext {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsRow OrderItemRow { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsRow DefectiveOrderItemRow { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelRow Model { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationRow OperationModel { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelRow ChildModel { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelHalfProductionRow ProductionModel { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.CriterionCasheItem> Properties { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionRow ProductionRow { get; } 
		public System.Decimal Qu { get; } 
		public System.Decimal Square { get; } 
		public System.Boolean IsDefective { get; set; } 
		public System.String Name { get; set; } 
		public System.String ShortName { get; set; } 
		public System.String SellingName { get; set; } 
		public System.String Info { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public abstract partial class OrderItemsProductionModelContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.BaseOrderContext {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationRow OperationModel { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsRow OrderItemRow { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelRow Model { get; set; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.CriterionCasheItem> Properties { get; } 
		public System.Collections.Generic.List<ITAP.glassCAD.Workflow.Context.Property> Idents { get; set; } 
		public System.Int32 Level { get; } 
		public System.Int32 Index { get; } 
		public System.Decimal Duration { get; } 
		public System.Decimal Cost { get; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class OrderServiceCalculationContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.BaseOrderCalculationContext {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderServicesRow OrderServicesRow { get; set; } 
		public ITAP.glassCAD.Dictionary.Services.ServicesDataSet.ServicesRow ServicesRow { get; } 
		public System.Int32 IDServices { get; } 
		public System.Decimal Qu { get; } 
		public System.Nullable<System.Decimal> PriceManualSet { get; } 
		public System.Nullable<System.Decimal> ServicePrice { get; } 
		public System.String Name { get; } 
		public System.Decimal Price { get; set; } 
		public System.Decimal PriceWithoutNDS { get; set; } 
		public System.Decimal UnitPrice { get; set; } 
		public System.Decimal UnitPriceWithoutNDS { get; set; } 
		public System.Decimal InternalPrice { get; set; } 
		public System.Decimal InternalUnitPrice { get; set; } 
		public System.Nullable<System.Decimal> CorrectPrice { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.Orders.WorkFlow.Context {
    
    public partial class PriceCalculationContext : ITAP.glassCAD.Documents.Orders.WorkFlow.Context.BaseOrderContext {
		public System.Decimal Price { get; set; } 
		public System.Collections.Generic.Dictionary<System.String, System.Decimal> Results { get; set; } 
		public ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderItemCalculationContext OrderItemCalculationContext { get; set; } 
		public ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderServiceCalculationContext OrderServiceCalculationContext { get; set; } 
		public ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderGoodCalculationContext OrderGoodCalculationContext { get; set; } 
		public ITAP.glassCAD.Documents.Orders.WorkFlow.Context.OrderCalculationContext OrderCalculationContext { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction {
    
    public partial class BoxProductionDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionRow HeaderRow { get; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionDataTable BoxProduction { get; set; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionDiractionDataTable BoxProductionDiraction { get; set; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionItemsDataTable BoxProductionItems { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction.Workflow.Context {
    
    public abstract partial class BaseBoxProductionCalculationContext : ITAP.glassCAD.Workflow.Context.WFContext {
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet BoxProductionDataSet { get; set; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionRow DocumentRow { get; } 
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction.Workflow.Context {
    
    public partial class BoxProductionCalculationContext : ITAP.glassCAD.Documents.BoxProduction.Workflow.Context.BaseBoxProductionCalculationContext {
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction.Workflow.Context {
    
    public partial class BoxProductionItemCalculationContext : ITAP.glassCAD.Documents.BoxProduction.Workflow.Context.BaseBoxProductionCalculationContext {
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionItemsRow BoxProductionItemRow { get; set; } 
		public System.Int32 Width { get; } 
		public System.Int32 Height { get; } 
		public System.Int32 Lenght { get; } 
		public System.Collections.Generic.List<ITAP.glassCAD.Documents.BoxProduction.Workflow.Context.GoodItem> Goods { get; set; } 
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction.Workflow.Context {
    
    public partial class GoodItem {
		public System.Int32 IdGood { get; set; } 
		public System.Decimal Value { get; set; } 
		public System.String Marking { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Shape {
    
    public partial class ShapeDataSet {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkflowUserSettings {
    
    public partial class WorkflowUserSettingsDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.WorkflowUserSettings.WorkflowUserSettingsDataSet.WorkflowUserSettingsDataTable WorkflowUserSettings { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate {
    
    public partial class WorkFlowDocumentTemplateDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate.WorkFlowDocumentTemplateDataSet.WorkFlowDocumentTemplateDataTable WorkFlowDocumentTemplate { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Storehouse {
    
    public partial class StorehouseDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Storehouse.StorehouseDataSet.StorehouseDataTable Storehouse { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Sign {
    
    public partial class SignDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignRow HeaderRow { get; } 
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignDataTable Sign { get; set; } 
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignValueDataTable SignValue { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Services {
    
    public partial class ServicesDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Services.ServicesDataSet.ServicesDataTable Services { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.ScanRole {
    
    public partial class ScanRoleDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleActivityDataTable ScanRoleActivity { get; set; } 
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleRow HeaderRow { get; } 
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleDataTable ScanRole { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.ScanActivity {
    
    public partial class ScanActivityDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.ScanActivity.ScanActivityDataSet.ScanActivityDataTable ScanActivity { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    
    public partial class ProductionDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionRow HeaderRow { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionDataTable Production { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionGroupDataTable ProductionGroup { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelDataTable ProductionModel { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelGoodDataTable ProductionModelGood { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelHalfProductionDataTable ProductionModelHalfProduction { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelOperationDataTable ProductionModelOperation { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelOperationParamDataTable ProductionModelOperationParam { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.PriceForms {
    
    public partial class PriceFormsDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.PriceForms.PriceFormsDataSet.PriceFormsDataTable PriceForms { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.People {
    
    public partial class PeopleDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.People.PeopleDataSet.PeopleDataTable People { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.PaymentType {
    
    public partial class PaymentTypeDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.PaymentType.PaymentTypeDataSet.PaymentTypeDataTable PaymentType { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Operation {
    
    public partial class OperationDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationRow HeaderRow { get; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationDataTable Operation { get; set; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationIdentDataTable OperationIdent { get; set; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationParamDataTable OperationParam { get; set; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationParamValueDataTable OperationParamValue { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Measure {
    
    public partial class MeasureDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Measure.MeasureDataSet.MeasureDataTable Measure { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Marshrut {
    
    public partial class MarshrutDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Marshrut.MarshrutDataSet.MarshrutDataTable Marshrut { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.GrOpt {
    
    public partial class GrOptDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.GrOpt.GrOptDataSet.GrOptDataTable GrOpt { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.GrOptPacking {
    
    public partial class GrOptPackingDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.GrOptPacking.GrOptPackingDataSet.GrOptPackingDataTable GrOptPacking { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Goods {
    
    public partial class GoodsDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsRow HeaderRow { get; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsDataTable Goods { get; set; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsDetailDataTable GoodsDetail { get; set; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GroupGoodsDataTable GroupGoods { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.GoodParties {
    
    public partial class GoodPartiesDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.GoodParties.GoodPartiesDataSet.GoodPartiesDataTable GoodParties { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Equipment {
    
    public partial class EquipmentDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Equipment.EquipmentDataSet.EquipmentDataTable Equipment { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.DocOper {
    
    public partial class DocOperDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperRow HeaderRow { get; } 
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperDataTable DocOper { get; set; } 
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperItemsDataTable DocOperItems { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Diraction {
    
    public partial class DiractionDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Diraction.DiractionDataSet.DiractionDataTable Diraction { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Depart {
    
    public partial class DepartDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Depart.DepartDataSet.DepartDataTable Depart { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    
    public partial class CustomerDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.AgreementDataTable Agreement { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerAddressDataTable CustomerAddress { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerBankDataTable CustomerBank { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerContactsDataTable CustomerContacts { get; set; } 
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerRow HeaderRow { get; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerDataTable Customer { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerGroupDataTable CustomerGroup { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Currency {
    
    public partial class CurrencyDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyRow HeaderRow { get; } 
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyDataTable Currency { get; set; } 
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyHistoryDataTable CurrencyHistory { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Company {
    
    public partial class CompanyDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Company.CompanyDataSet.CompanyDataTable Company { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Calendar {
    
    public partial class CalendarDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Calendar.CalendarDataSet.CalendarRow HeaderRow { get; } 
		public ITAP.glassCAD.Dictionary.Calendar.CalendarDataSet.CalendarDataTable Calendar { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.Calculation {
    
    public partial class CalculationDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.Calculation.CalculationDataSet.CalculationDataTable Calculation { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.CalculationVariables {
    
    public partial class CalculationVariablesDataSet : System.Data.DataSet {
		public ITAP.glassCAD.Data.Metadata Metadata { get; } 
		public System.Boolean IsModify { get; } 
		public ITAP.glassCAD.Dictionary.CalculationVariables.CalculationVariablesDataSet.CalculationVariablesDataTable CalculationVariables { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Execution {
    
    public partial class Context {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Execution {
    
    public partial class SuccessException : System.Exception {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Execution {
    
    public partial class TerminateException : System.Exception {
		public System.Exception Reason { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class DGML {
		public System.String RegionText { get; set; } 
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML.Mode CurrentMode { get; set; } 
		public System.String Comment { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class TemplateInArg {
		public System.String Name { get; set; } 
		public System.Activities.InArgument Argument { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class TemplateOutArg {
		public System.String Name { get; set; } 
		public System.Activities.OutArgument Argument { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class InterfacePresetItem {
		public System.String Key { get; set; } 
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.InterfaceItemMode Value { get; set; } 
		public System.Object FilterValue { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class InterfacePreset : System.Collections.Generic.List<ITAP.glassCAD.Dictionary.WorkFlow.Activities.InterfacePresetItem> {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input {
    
    public partial class Button {
		public System.String Name { get; set; } 
		public System.String Text { get; set; } 
		public System.String Group { get; set; } 
		public System.String Description { get; set; } 
		public System.String ImageName { get; set; } 
		public System.Drawing.Image Image { get; } 
    }
}
namespace ITAP.glassCAD.Data {
    
    public partial class DataLayer {
		public Microsoft.Data.SqlClient.SqlConnection Connection { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.CalculationVariables.CalculationVariablesDataSet CalculationVariablesDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.CalculationVariables.CalculationVariablesDataSet.CalculationVariablesDataTable CalculationVariablesDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Calculation.CalculationDataSet CalculationDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Calculation.CalculationDataSet.CalculationDataTable CalculationDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Calendar.CalendarDataSet CalendarDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Calendar.CalendarDataSet.CalendarDataTable CalendarDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Company.CompanyDataSet CompanyDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Company.CompanyDataSet.CompanyDataTable CompanyDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet CurrencyDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyDataTable CurrencyDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyHistoryDataTable CurrencyHistoryDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.AgreementDataTable AgreementDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerAddressDataTable CustomerAddressDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerBankDataTable CustomerBankDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerContactsDataTable CustomerContactsDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet CustomerDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerDataTable CustomerDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerGroupDataTable CustomerGroupDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Depart.DepartDataSet DepartDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Depart.DepartDataSet.DepartDataTable DepartDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Diraction.DiractionDataSet DiractionDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Diraction.DiractionDataSet.DiractionDataTable DiractionDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet DocOperDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperDataTable DocOperDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperItemsDataTable DocOperItemsDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Equipment.EquipmentDataSet EquipmentDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Equipment.EquipmentDataSet.EquipmentDataTable EquipmentDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.GoodParties.GoodPartiesDataSet GoodPartiesDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.GoodParties.GoodPartiesDataSet.GoodPartiesDataTable GoodPartiesDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet GoodsDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsDataTable GoodsDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsDetailDataTable GoodsDetailDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GroupGoodsDataTable GroupGoodsDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.GrOptPacking.GrOptPackingDataSet GrOptPackingDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.GrOptPacking.GrOptPackingDataSet.GrOptPackingDataTable GrOptPackingDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.GrOpt.GrOptDataSet GrOptDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.GrOpt.GrOptDataSet.GrOptDataTable GrOptDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Marshrut.MarshrutDataSet MarshrutDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Marshrut.MarshrutDataSet.MarshrutDataTable MarshrutDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Measure.MeasureDataSet MeasureDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Measure.MeasureDataSet.MeasureDataTable MeasureDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet OperationDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationDataTable OperationDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationIdentDataTable OperationIdentDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationParamDataTable OperationParamDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationParamValueDataTable OperationParamValueDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.PaymentType.PaymentTypeDataSet PaymentTypeDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.PaymentType.PaymentTypeDataSet.PaymentTypeDataTable PaymentTypeDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.People.PeopleDataSet PeopleDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.People.PeopleDataSet.PeopleDataTable PeopleDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.PriceForms.PriceFormsDataSet PriceFormsDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.PriceForms.PriceFormsDataSet.PriceFormsDataTable PriceFormsDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet ProductionDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionDataTable ProductionDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionGroupDataTable ProductionGroupDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelDataTable ProductionModelDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelGoodDataTable ProductionModelGoodDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelHalfProductionDataTable ProductionModelHalfProductionDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelOperationDataTable ProductionModelOperationDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelOperationParamDataTable ProductionModelOperationParamDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.ScanActivity.ScanActivityDataSet ScanActivityDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.ScanActivity.ScanActivityDataSet.ScanActivityDataTable ScanActivityDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleActivityDataTable ScanRoleActivityDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet ScanRoleDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleDataTable ScanRoleDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Services.ServicesDataSet ServicesDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Services.ServicesDataSet.ServicesDataTable ServicesDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet SignDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignDataTable SignDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignValueDataTable SignValueDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Storehouse.StorehouseDataSet StorehouseDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.Storehouse.StorehouseDataSet.StorehouseDataTable StorehouseDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate.WorkFlowDocumentTemplateDataSet WorkFlowDocumentTemplateDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate.WorkFlowDocumentTemplateDataSet.WorkFlowDocumentTemplateDataTable WorkFlowDocumentTemplateDataTable { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.WorkflowUserSettings.WorkflowUserSettingsDataSet WorkflowUserSettingsDataSet { get; } 
		[Newtonsoft.Json.JsonIgnoreAttribute()]
		public ITAP.glassCAD.Dictionary.WorkflowUserSettings.WorkflowUserSettingsDataSet.WorkflowUserSettingsDataTable WorkflowUserSettingsDataTable { get; } 
    }
}
namespace ITAP.glassCAD.Data {
    
    public abstract partial class Helper {
    }
}
namespace ITAP.glassCAD.Data {
    
    public partial class ColumnMetadata {
		public System.String Name { get; set; } 
		public System.Type ColumnType { get; set; } 
		public System.String DbName { get; set; } 
		public System.Type DbColumnType { get; set; } 
		public System.Boolean ShowInList { get; set; } 
		public System.Boolean ShowInForm { get; set; } 
		public System.Boolean ShowInSelect { get; set; } 
		public System.Boolean ShowInReferenceMetadata { get; set; } 
		public System.Boolean AllowEdit { get; set; } 
		public System.Boolean IsUnbound { get; set; } 
		public System.String ListLookUpItem { get; set; } 
		public System.String MetadataReference { get; set; } 
		public System.Boolean CustomReference { get; set; } 
    }
}
namespace ITAP.glassCAD.Data {
    
    public abstract partial class Metadata {
		public System.Boolean EnabledSourceGenerator { get; set; } 
		public System.String Name { get; set; } 
		public System.Boolean IsDocument { get; set; } 
		public System.Boolean IsDictionary { get; set; } 
    }
}
namespace ITAP.glassCAD.Data {
    [System.Reflection.DefaultMemberAttribute("Item")]
    public partial class ColumnList : System.Collections.Generic.List<ITAP.glassCAD.Data.ColumnMetadata> {
		public ITAP.glassCAD.Data.ColumnMetadata Item { get; } 
    }
}
namespace ITAP.glassCAD.Data {
    
    public partial class DictionaryMetadata : ITAP.glassCAD.Data.Metadata {
		public ITAP.glassCAD.Data.Metadata Scope { get; set; } 
		public System.Type DataRowType { get; set; } 
		public System.String KeyColumnName { get; set; } 
		public System.String ParentKeyColumnName { get; set; } 
		public System.String TableName { get; set; } 
		public System.Boolean HasDeletedColumn { get; set; } 
		public System.Boolean LoadWithScope { get; set; } 
		public ITAP.glassCAD.Data.ColumnList Columns { get; set; } 
    }
}
namespace ITAP.glassCAD.Data {
    
    public partial class TreeDictionaryMetadata : ITAP.glassCAD.Data.Metadata {
		public ITAP.glassCAD.Data.DictionaryMetadata Group { get; set; } 
		public ITAP.glassCAD.Data.DictionaryMetadata Main { get; set; } 
		public ITAP.glassCAD.Data.DictionaryMetadata[] Childs { get; set; } 
    }
}
namespace ITAP.glassCAD.Data {
    
    public partial class DocumentMetadata : ITAP.glassCAD.Data.TreeDictionaryMetadata {
    }
}
namespace ITAP.glassCAD.Data {
    [System.Reflection.DefaultMemberAttribute("Item")]
    public partial class MetadataList : System.Collections.Generic.List<ITAP.glassCAD.Data.Metadata> {
		public ITAP.glassCAD.Data.Metadata Item { get; } 
    }
}
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
		public System.DateTime Timestamp { get; } 
		public System.Int32 Index { get; set; } 
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
		public glassPeople.ActivityLibrary.glassCAD.Scanner.Parser.CheckDublicateMode CheckDublicateMode { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Scanner.Parser.SM {
    
    public partial class Parser : glassPeople.ActivityLibrary.glassCAD.Scanner.Parser.DefaultParser {
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
		public System.Boolean CheckDOrderItemsIdentWorkStatus { get; set; } 
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
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.String VitrualPrePackingGroup { get; set; } 
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
		public System.Decimal MinWidthInStorage { get; } 
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
		public System.Collections.Generic.IDictionary<System.String, System.String> Parameters { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy {
    
    public partial class FrameStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.BaseStrategy {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy {
    
    public partial class Simple : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.BaseStrategy {
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
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.RSK {
    
    public partial class MixStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Simple {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.KPI {
    
    public partial class FullPackPackingStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.Simple {
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.Strategy.KPI {
    
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
    
    public partial class KPIPillarsStrategy : glassPeople.ActivityLibrary.glassCAD.Planing.Packing.MathPacksPosition.WithPillarsStrategy {
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
		public System.String DisallowGlassTypes { get; set; } 
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
		public System.Boolean MaxPackWidthDeltaProcent { get; set; } 
		public System.Nullable<System.Int32> MaxPackWidthDelta { get; set; } 
		public System.Boolean MaxPackHeightDeltaProcent { get; set; } 
		public System.Nullable<System.Int32> MaxPackHeightDelta { get; set; } 
		[System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute()]
		public System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.Capacity.Pillar> Pillars { get; set; } 
		public System.Nullable<System.Int32> MaxPackLengthToTopPack { get; set; } 
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
namespace ITAP.glassCAD {
    public partial class Program {
    
    public abstract partial class Enumerables {
    }
    }
}
namespace ITAP.glassCAD.Production {
    public partial class ViewModel {
    
    public partial class Vector2 : System.ValueType {
		public System.Int32 X { get; set; } 
		public System.Int32 Y { get; set; } 
    }
    }
}
namespace ITAP.glassCAD.Production {
    public partial class ViewModel {
    
    public partial class Rect : System.ValueType {
		public ITAP.glassCAD.Production.ViewModel.Vector2 Min { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.Vector2 Max { get; set; } 
		public System.Int32 Width { get; } 
		public System.Int32 Height { get; } 
		public ITAP.glassCAD.Production.ViewModel.Vector2 Left { get; } 
		public ITAP.glassCAD.Production.ViewModel.Vector2 Right { get; } 
    }
    }
}
namespace ITAP.glassCAD.Production {
    public partial class ViewModel {
    
    public partial class RectCommand {
		public ITAP.glassCAD.Production.ViewModel.Vector2 Center { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.Vector2 Size { get; set; } 
		public System.String Caption { get; set; } 
		public System.String Action { get; set; } 
    }
    }
}
namespace ITAP.glassCAD.Production {
    public partial class ViewModel {
    
    public partial class RectObject {
		public ITAP.glassCAD.Production.Model.Item Item { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.Vector2 Center { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.Vector2 Size { get; set; } 
		public System.String Color { get; } 
		public System.String Caption { get; } 
		public System.Collections.Generic.List<System.ValueTuple<System.String, System.String>> Details { get; } 
    }
    }
}
namespace ITAP.glassCAD.Production {
    public partial class ViewModel {
    
    public partial class LineObject {
		public ITAP.glassCAD.Production.ViewModel.RectObject Start { get; set; } 
		public ITAP.glassCAD.Production.ViewModel.RectObject End { get; set; } 
    }
    }
}
namespace ITAP.glassCAD.Extensions {
    public partial class IEnumerableExtensions {
    
    public partial class GroupResult {
		public System.Object Key { get; set; } 
		public System.Int32 Count { get; set; } 
		public System.Collections.IEnumerable Items { get; set; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Extensions.IEnumerableExtensions.GroupResult> SubGroups { get; set; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderCalculationsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderCalculationsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderCalculationsRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderCalculationsDataTable OrderCalculationsDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderCalculations { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Nullable<System.Int32> IDParent { get; set; } 
		public System.Nullable<System.Int32> IDOrderItem { get; set; } 
		public System.Nullable<System.Int32> IDOrderGood { get; set; } 
		public System.Nullable<System.Int32> IDOrderService { get; set; } 
		public System.Int32 IDCalculation { get; set; } 
		public System.Decimal DecimalValue1 { get; set; } 
		public System.Decimal DecimalValue2 { get; set; } 
		public System.String Comment { get; set; } 
		public System.String Comment2 { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
        protected internal OrderCalculationsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderCalculationVariablesDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderCalculationVariablesRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderCalculationVariablesRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderCalculationVariablesDataTable OrderCalculationVariablesDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderCalculationVariables { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDCalculationVariables { get; set; } 
		public System.Decimal Value { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
        protected internal OrderCalculationVariablesRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderCuttingDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderCuttingRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderCuttingRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderCuttingDataTable OrderCuttingDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderCutting { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDGood { get; set; } 
		public System.Decimal Waste { get; set; } 
		public System.Decimal WorkWaste { get; set; } 
		public System.Decimal TrashWaste { get; set; } 
		public System.Int32 FrameCount { get; set; } 
		public System.Boolean CuttingFromOneOrder { get; set; } 
		public System.Decimal Result { get; set; } 
		public System.Int32 IDArmSquareCutting { get; set; } 
		public System.Decimal CalculationWaste { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
        protected internal OrderCuttingRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderGoodsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderGoodsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderGoodsRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderGoodsDataTable OrderGoodsDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderGoods { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDGood { get; set; } 
		public System.Int32 IDMeasure { get; set; } 
		public System.Int32 IDCurrency { get; set; } 
		public System.Decimal Qu { get; set; } 
		public System.Decimal QuMeasure { get; set; } 
		public System.Decimal Price { get; set; } 
		public System.Decimal PriceWithoutNDS { get; set; } 
		public System.Nullable<System.Decimal> PriceManualSet { get; set; } 
		public System.Nullable<System.Decimal> CorrectPrice { get; set; } 
		public System.Decimal Sm { get; set; } 
		public System.Decimal SmWithoutNDS { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Int32 IDProduction { get; set; } 
		public System.Decimal InternalPrice { get; set; } 
		public System.Decimal InternalSm { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
        protected internal OrderGoodsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsDataTable OrderItemsDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderItems { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Nullable<System.Int32> IDProduction { get; set; } 
		public System.Decimal Qu { get; set; } 
		public System.Decimal Price { get; set; } 
		public System.Nullable<System.Decimal> PriceManualSet { get; set; } 
		public System.Decimal PriceWithoutNDS { get; set; } 
		public System.Decimal S { get; set; } 
		public System.Decimal SAll { get; set; } 
		public System.Decimal Sm { get; set; } 
		public System.Decimal SmWithoutNDS { get; set; } 
		public System.Decimal TotalSm { get; set; } 
		public System.Decimal TotalSmWithoutNDS { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow OrdersRow { get; } 
        protected internal OrderItemsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelDataTable OrderItemsProductionModelDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderItemsProductionModel { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDOrderItems { get; set; } 
		public System.Int32 IDProductionModelElement { get; set; } 
		public System.String Name { get; set; } 
		public System.String IDParentOrderItemsProductionModel { get; set; } 
		public System.String IDChildOrderItemsProductionModel { get; set; } 
		public System.Nullable<System.Int32> IDOrderItemsProductionModelHalfProduction { get; set; } 
		public System.Nullable<System.Int32> IDOrderItemsProductionModelOperation { get; set; } 
		public System.Nullable<System.Int32> IDOrderItemsProductionModelGood { get; set; } 
		public System.Int32 Level { get; set; } 
		public System.Int32 IDOrderItemsProductionModelShape { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Nullable<System.Boolean> IsShapeManualSetting { get; set; } 
		public System.String NameManual { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
		public ITAP.glassCAD.Documents.Orders.ProductionModelElementType ProductionModelElementType { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsRow OrderItemsRow { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationRow OrderItemsProductionModelOperationRow { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelHalfProductionRow OrderItemsProductionModelHalfProductionRow { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelGoodRow OrderItemsProductionModelGoodRow { get; } 
        protected internal OrderItemsProductionModelRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelGoodDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelGoodRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelGoodRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelGoodDataTable OrderItemsProductionModelGoodDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderItemsProductionModelGood { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDOrderItemsProductionModel { get; set; } 
		public System.Int32 IDOrderItems { get; set; } 
		public System.Int32 IDGood { get; set; } 
		public System.Boolean InvertInShape { get; set; } 
		public System.Int32 SideSputtering { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
        protected internal OrderItemsProductionModelGoodRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelHalfProductionDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelHalfProductionRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelHalfProductionRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelHalfProductionDataTable OrderItemsProductionModelHalfProductionDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderItemsProductionModelHalfProduction { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDOrderItemsProductionModel { get; set; } 
		public System.Int32 IDOrderItems { get; set; } 
		public System.String Properties { get; set; } 
		public System.Nullable<System.Int32> IDOrderItemsIdentCanceled { get; set; } 
		public System.Nullable<System.Int32> IDOrderItemsProductionModelCanceled { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelRow OrderItemsProductionModelRow { get; } 
        protected internal OrderItemsProductionModelHalfProductionRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelOperationDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelOperationRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationDataTable OrderItemsProductionModelOperationDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderItemsProductionModelOperation { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDOrderItemsProductionModel { get; set; } 
		public System.Int32 IDOrderItems { get; set; } 
		public System.Int32 IDOperation { get; set; } 
		public System.Nullable<System.Decimal> DurationKoef { get; set; } 
		public System.Nullable<System.Decimal> CostKoef { get; set; } 
		public System.String Calendars { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelRow OrderItemsProductionModelRow { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelHalfProductionRow HalfProduction { get; } 
        protected internal OrderItemsProductionModelOperationRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelOperationIdentValueDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationIdentValueRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderItemsProductionModelOperationIdentValueRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderItemsProductionModelOperationIdentValueDataTable OrderItemsProductionModelOperationIdentValueDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderItemsProductionModelOperationIdentValue { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDOrderItemsProductionModelOperation { get; set; } 
		public System.Int32 IDOrderItems { get; set; } 
		public System.Int32 IDOperationIdent { get; set; } 
		public System.String Ident { get; set; } 
		public System.String GroupName { get; set; } 
		public System.String IdentName { get; set; } 
		public System.Nullable<System.Decimal> Value { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
        protected internal OrderItemsProductionModelOperationIdentValueRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderPriceGoodsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderPriceGoodsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderPriceGoodsRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderPriceGoodsDataTable OrderPriceGoodsDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderPriceGoods { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDGood { get; set; } 
		public System.Nullable<System.Int32> IDGoodParties { get; set; } 
		public System.Nullable<System.Int32> IDCurrency { get; set; } 
		public System.Nullable<System.Decimal> Price { get; set; } 
		public System.Nullable<System.Decimal> Waste { get; set; } 
		public System.Nullable<System.Decimal> ScopeOfSupply { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
        protected internal OrderPriceGoodsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrdersDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrdersRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersDataTable OrdersDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrder { get; set; } 
		public System.Int32 IDDocOper { get; set; } 
		public System.Int32 IDDocOperItems { get; set; } 
		public System.String NmDoc { get; set; } 
		public System.DateTime DtDoc { get; set; } 
		public System.Nullable<System.DateTime> DtCalculation { get; set; } 
		public System.String NmDocExt { get; set; } 
		public System.Nullable<System.Int32> IDCustomer { get; set; } 
		public System.Nullable<System.Int32> IDAgreement { get; set; } 
		public System.Boolean IsDefective { get; set; } 
		public System.String Comment { get; set; } 
		public System.String OrderStatus { get; set; } 
		public System.Nullable<System.Int32> IDPeople { get; set; } 
		public System.Nullable<System.Int32> IDPaymentType { get; } 
		public System.Nullable<System.Int32> IDMarshrut { get; set; } 
		public System.Nullable<System.Int32> IDCustomerContacts { get; set; } 
		public System.String Address { get; set; } 
		public System.Int32 Qu { get; set; } 
		public System.Decimal S { get; set; } 
		public System.Nullable<System.Decimal> SmOrder { get; set; } 
		public System.Nullable<System.Decimal> SmWithoutNDS { get; set; } 
        protected internal OrdersRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderServicesDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderServicesRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderServicesRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderServicesDataTable OrderServicesDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderServices { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDServices { get; set; } 
		public System.Decimal Qu { get; set; } 
		public System.Decimal Price { get; set; } 
		public System.Decimal PriceWithoutNDS { get; set; } 
		public System.Decimal Sm { get; set; } 
		public System.Decimal SmWithoutNDS { get; set; } 
		public System.Nullable<System.Decimal> PriceManualSet { get; set; } 
		public System.Nullable<System.Decimal> CorrectPrice { get; set; } 
		public System.Int32 IDCurrency { get; set; } 
		public System.Decimal InternalPrice { get; set; } 
		public System.Decimal InternalSm { get; set; } 
		public System.String Comment { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
        protected internal OrderServicesRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderSignDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderSignRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.Orders {
    public partial class OrdersDataSet {
    
    public partial class OrderSignRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrderSignDataTable OrderSignDataTable { get; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet OrdersDataSet { get; } 
		public System.Int32 IDOrderSign { get; set; } 
		public System.Nullable<System.Int32> IDOrder { get; set; } 
		public System.Int32 IDSign { get; set; } 
		public System.Int32 IDSignValue { get; set; } 
		public ITAP.glassCAD.Documents.Orders.OrdersDataSet.OrdersRow Orders { get; } 
        protected internal OrderSignRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction {
    public partial class BoxProductionDataSet {
    
    public partial class BoxProductionDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction {
    public partial class BoxProductionDataSet {
    
    public partial class BoxProductionRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionDataTable BoxProductionDataTable { get; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet BoxProductionDataSet { get; } 
		public System.Int32 IDBoxProduction { get; set; } 
		public System.Int32 IDDocOper { get; set; } 
		public System.String NmDoc { get; set; } 
		public System.Int32 IDDocOperItems { get; set; } 
		public System.DateTime DtDoc { get; set; } 
		public System.String Comment { get; set; } 
		public System.String Status { get; set; } 
		public System.Nullable<System.Int32> IDPeople { get; set; } 
		public System.Nullable<System.Int32> IDCompany { get; set; } 
		public System.String CalculationResult { get; set; } 
		public System.Int32 IDArmPacking { get; set; } 
        protected internal BoxProductionRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction {
    public partial class BoxProductionDataSet {
    
    public partial class BoxProductionDiractionDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionDiractionRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction {
    public partial class BoxProductionDataSet {
    
    public partial class BoxProductionDiractionRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionDiractionDataTable BoxProductionDiractionDataTable { get; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet BoxProductionDataSet { get; } 
		public System.Int32 IDBoxProductionDiraction { get; set; } 
		public System.Nullable<System.Int32> IDBoxProduction { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Int32 IDDiraction { get; set; } 
		public System.DateTime PlanDate { get; set; } 
		public System.DateTime FactDate { get; set; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionRow BoxProduction { get; } 
        protected internal BoxProductionDiractionRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction {
    public partial class BoxProductionDataSet {
    
    public partial class BoxProductionItemsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionItemsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction {
    public partial class BoxProductionDataSet {
    
    public partial class BoxProductionItemsRow : System.Data.DataRow {
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionItemsDataTable BoxProductionItemsDataTable { get; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet BoxProductionDataSet { get; } 
		public System.Int32 IDBoxProductionItems { get; set; } 
		public System.Nullable<System.Int32> IDBoxProduction { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 Lenght { get; set; } 
		public System.Int32 Width { get; set; } 
		public System.Int32 Height { get; set; } 
		public System.String Comment { get; set; } 
		public System.String CalculationResult { get; set; } 
		public ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet.BoxProductionRow BoxProduction { get; } 
        protected internal BoxProductionItemsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Shape {
    public partial class ShapeDataSet {
    
    public partial class ShapeGroupRow : System.Data.DataRow {
        protected internal ShapeGroupRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkflowUserSettings {
    public partial class WorkflowUserSettingsDataSet {
    
    public partial class WorkflowUserSettingsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.WorkflowUserSettings.WorkflowUserSettingsDataSet.WorkflowUserSettingsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkflowUserSettings {
    public partial class WorkflowUserSettingsDataSet {
    
    public partial class WorkflowUserSettingsRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.WorkflowUserSettings.WorkflowUserSettingsDataSet.WorkflowUserSettingsDataTable WorkflowUserSettingsDataTable { get; } 
		public ITAP.glassCAD.Dictionary.WorkflowUserSettings.WorkflowUserSettingsDataSet WorkflowUserSettingsDataSet { get; } 
		public System.Int32 IDWorkflowUserSettings { get; set; } 
		public System.String Name { get; set; } 
		public System.String GroupName { get; set; } 
		public System.String Comment { get; set; } 
		public System.Nullable<System.Decimal> DoubleValue { get; set; } 
		public System.String StrValue { get; set; } 
		public System.DateTime DateValue { get; set; } 
		public System.Byte[] BinaryValue { get; set; } 
		public System.Boolean BitValue { get; set; } 
		public System.Guid GUID { get; set; } 
        protected internal WorkflowUserSettingsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate {
    public partial class WorkFlowDocumentTemplateDataSet {
    
    public partial class WorkFlowDocumentTemplateDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate.WorkFlowDocumentTemplateDataSet.WorkFlowDocumentTemplateRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate {
    public partial class WorkFlowDocumentTemplateDataSet {
    
    public partial class WorkFlowDocumentTemplateRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate.WorkFlowDocumentTemplateDataSet.WorkFlowDocumentTemplateDataTable WorkFlowDocumentTemplateDataTable { get; } 
		public ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate.WorkFlowDocumentTemplateDataSet WorkFlowDocumentTemplateDataSet { get; } 
		public System.Int32 IDWorkFlowDocumentTemplate { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 DocumentDocOper { get; set; } 
		public System.String Data { get; set; } 
		public System.Int32 Type { get; set; } 
		public System.Boolean IsDefault { get; set; } 
		public System.Guid GUID { get; set; } 
        protected internal WorkFlowDocumentTemplateRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Storehouse {
    public partial class StorehouseDataSet {
    
    public partial class StorehouseDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Storehouse.StorehouseDataSet.StorehouseRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Storehouse {
    public partial class StorehouseDataSet {
    
    public partial class StorehouseRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Storehouse.StorehouseDataSet.StorehouseDataTable StorehouseDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Storehouse.StorehouseDataSet StorehouseDataSet { get; } 
		public System.Int32 IDStorehouse { get; set; } 
		public System.String Name { get; set; } 
		public System.String Address { get; set; } 
		public System.Int32 IDCompany { get; set; } 
		public System.Int32 StorehouseType { get; set; } 
        protected internal StorehouseRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Sign {
    public partial class SignDataSet {
    
    public partial class SignDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Sign {
    public partial class SignDataSet {
    
    public partial class SignRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignDataTable SignDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet SignDataSet { get; } 
		public System.Int32 IDSign { get; set; } 
		public System.String Name { get; set; } 
		public System.String Comment { get; set; } 
		public System.Int32 SignType { get; set; } 
		public System.Nullable<System.Int32> IDDocOper { get; set; } 
        protected internal SignRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Sign {
    public partial class SignDataSet {
    
    public partial class SignValueDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignValueRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Sign {
    public partial class SignDataSet {
    
    public partial class SignValueRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignValueDataTable SignValueDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet SignDataSet { get; } 
		public System.Int32 IDSignValue { get; set; } 
		public System.Nullable<System.Int32> IDSign { get; set; } 
		public System.String Name { get; set; } 
		public System.String Comment { get; set; } 
		public System.Int32 Ident { get; set; } 
		public System.String Value_Str { get; set; } 
		public System.Nullable<System.Int32> Value_Int { get; set; } 
		public System.Nullable<System.DateTime> Value_DateTime { get; set; } 
		public ITAP.glassCAD.Dictionary.Sign.SignDataSet.SignRow Sign { get; } 
        protected internal SignValueRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Services {
    public partial class ServicesDataSet {
    
    public partial class ServicesDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Services.ServicesDataSet.ServicesRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Services {
    public partial class ServicesDataSet {
    
    public partial class ServicesRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Services.ServicesDataSet.ServicesDataTable ServicesDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Services.ServicesDataSet ServicesDataSet { get; } 
		public System.Int32 IDServices { get; set; } 
		public System.String Name { get; set; } 
		public System.String Comment { get; set; } 
		public System.Nullable<System.Decimal> Price { get; set; } 
		public System.Nullable<System.Int32> IDCurrency { get; set; } 
		public System.Nullable<System.Int32> ServicesVisibleType { get; set; } 
        protected internal ServicesRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.ScanRole {
    public partial class ScanRoleDataSet {
    
    public partial class ScanRoleActivityDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleActivityRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.ScanRole {
    public partial class ScanRoleDataSet {
    
    public partial class ScanRoleActivityRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleActivityDataTable ScanRoleActivityDataTable { get; } 
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet ScanRoleDataSet { get; } 
		public System.Int32 IDScanRoleActivity { get; set; } 
		public System.Nullable<System.Int32> IDScanRole { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Nullable<System.Int32> IDScanActivity { get; set; } 
		public System.Nullable<System.DateTime> DtStart { get; set; } 
		public System.Nullable<System.DateTime> DtEnd { get; set; } 
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleRow ScanRole { get; } 
        protected internal ScanRoleActivityRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.ScanRole {
    public partial class ScanRoleDataSet {
    
    public partial class ScanRoleDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.ScanRole {
    public partial class ScanRoleDataSet {
    
    public partial class ScanRoleRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet.ScanRoleDataTable ScanRoleDataTable { get; } 
		public ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet ScanRoleDataSet { get; } 
		public System.Int32 IDScanRole { get; set; } 
		public System.String Name { get; set; } 
        protected internal ScanRoleRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.ScanActivity {
    public partial class ScanActivityDataSet {
    
    public partial class ScanActivityDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.ScanActivity.ScanActivityDataSet.ScanActivityRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.ScanActivity {
    public partial class ScanActivityDataSet {
    
    public partial class ScanActivityRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.ScanActivity.ScanActivityDataSet.ScanActivityDataTable ScanActivityDataTable { get; } 
		public ITAP.glassCAD.Dictionary.ScanActivity.ScanActivityDataSet ScanActivityDataSet { get; } 
		public System.Int32 IDScanActivity { get; set; } 
		public System.String Name { get; set; } 
		public System.String GroupName { get; set; } 
        protected internal ScanActivityRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionDataTable ProductionDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet ProductionDataSet { get; } 
		public System.Int32 IDProduction { get; set; } 
		public System.Nullable<System.Int32> IDProductionGroup { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 IDMeasure { get; set; } 
		public System.Int32 ViewSide { get; set; } 
		public System.Boolean ProductionModelHasError { get; set; } 
		public System.Nullable<System.Int32> IDShapeDefault { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionGroupRow ProductionGroup { get; } 
        protected internal ProductionRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionGroupDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionGroupRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionGroupRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionGroupDataTable ProductionGroupDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet ProductionDataSet { get; } 
		public System.Int32 IDProductionGroup { get; set; } 
		public System.Nullable<System.Int32> IDParent { get; set; } 
		public System.String Name { get; set; } 
        protected internal ProductionGroupRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelDataTable ProductionModelDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet ProductionDataSet { get; } 
		public System.Int32 IDProductionModel { get; set; } 
		public System.Nullable<System.Int32> IDProduction { get; set; } 
		public System.Nullable<System.Int32> NumPos { get; set; } 
		public System.String Name { get; set; } 
		public System.Nullable<System.Int32> Level { get; set; } 
		public System.String NameManual { get; set; } 
		public System.String IDParentProductionModel { get; set; } 
		public System.String IDChildProductionModel { get; set; } 
		public System.Nullable<System.Int32> IDProductionModelHalfProduction { get; set; } 
		public System.Nullable<System.Int32> IDProductionModelOperation { get; set; } 
		public System.Nullable<System.Int32> IDProductionModelGood { get; set; } 
		public System.Boolean IsShapeManualSetting { get; set; } 
		public System.Nullable<System.Guid> GUID { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionRow Production { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelGoodRow ProductionModelGoodRow { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelHalfProductionRow ProductionModelHalfProductionRow { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelOperationRow ProductionModelOperationRow { get; } 
		public System.Boolean IsGood { get; } 
		public System.Boolean IsHalfProduction { get; } 
		public System.Boolean IsOperation { get; } 
        protected internal ProductionModelRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelGoodDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelGoodRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelGoodRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelGoodDataTable ProductionModelGoodDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet ProductionDataSet { get; } 
		public System.Int32 IDProductionModelGood { get; set; } 
		public System.Nullable<System.Int32> IDProduction { get; set; } 
		public System.Int32 IDGood { get; set; } 
		public System.String Formula { get; set; } 
		public System.Boolean InvertInShape { get; set; } 
		public System.Nullable<System.Guid> GUID { get; set; } 
		public System.String Comment { get; set; } 
		public System.Nullable<System.Int32> SideSputtering { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionRow Production { get; } 
        protected internal ProductionModelGoodRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelHalfProductionDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelHalfProductionRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelHalfProductionRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelHalfProductionDataTable ProductionModelHalfProductionDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet ProductionDataSet { get; } 
		public System.Int32 IDProductionModelHalfProduction { get; set; } 
		public System.Nullable<System.Int32> IDProduction { get; set; } 
		public System.Nullable<System.Guid> GUID { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionRow Production { get; } 
        protected internal ProductionModelHalfProductionRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelOperationDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelOperationRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelOperationRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelOperationDataTable ProductionModelOperationDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet ProductionDataSet { get; } 
		public System.Int32 IDProductionModelOperation { get; set; } 
		public System.Nullable<System.Int32> IDProduction { get; set; } 
		public System.Int32 IDOperation { get; set; } 
		public System.Nullable<System.Guid> GUID { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionRow Production { get; } 
        protected internal ProductionModelOperationRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelOperationParamDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelOperationParamRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Production {
    public partial class ProductionDataSet {
    
    public partial class ProductionModelOperationParamRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionModelOperationParamDataTable ProductionModelOperationParamDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet ProductionDataSet { get; } 
		public System.Int32 IDProductionModelOperationParam { get; set; } 
		public System.Nullable<System.Int32> IDProduction { get; set; } 
		public System.Int32 IDOperationParam { get; set; } 
		public System.Int32 IDOperationParamValue { get; set; } 
		public System.String Comment { get; set; } 
		public System.Nullable<System.Guid> GUID { get; set; } 
		public System.Byte[] BytesValue { get; set; } 
		public System.String StringValue { get; set; } 
		public System.Nullable<System.Decimal> DecimalValue { get; set; } 
		public System.Nullable<System.DateTime> DateTimeValue { get; set; } 
		public System.Nullable<System.Boolean> BoolValue { get; set; } 
		public ITAP.glassCAD.Dictionary.Production.ProductionDataSet.ProductionRow Production { get; } 
        protected internal ProductionModelOperationParamRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.PriceForms {
    public partial class PriceFormsDataSet {
    
    public partial class PriceFormsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.PriceForms.PriceFormsDataSet.PriceFormsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.PriceForms {
    public partial class PriceFormsDataSet {
    
    public partial class PriceFormsRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.PriceForms.PriceFormsDataSet.PriceFormsDataTable PriceFormsDataTable { get; } 
		public ITAP.glassCAD.Dictionary.PriceForms.PriceFormsDataSet PriceFormsDataSet { get; } 
		public System.Int32 IDPriceForms { get; set; } 
		public System.String Name { get; set; } 
		public System.Byte[] Data { get; set; } 
		public System.Boolean IsDefault { get; set; } 
        protected internal PriceFormsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.People {
    public partial class PeopleDataSet {
    
    public partial class PeopleDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.People.PeopleDataSet.PeopleRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.People {
    public partial class PeopleDataSet {
    
    public partial class PeopleRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.People.PeopleDataSet.PeopleDataTable PeopleDataTable { get; } 
		public ITAP.glassCAD.Dictionary.People.PeopleDataSet PeopleDataSet { get; } 
		public System.Int32 IDPeople { get; set; } 
		public System.String Name { get; set; } 
		public System.String MiddleName { get; set; } 
		public System.String LastName { get; set; } 
		public System.String Phone { get; set; } 
		public System.String Address { get; set; } 
		public System.String Passport { get; set; } 
		public System.String EMail { get; set; } 
		public System.String Comment { get; set; } 
		public System.Nullable<System.Int32> IDDepart { get; set; } 
		public System.String PeopleFullName { get; } 
		public System.String DepartName { get; } 
		public System.Nullable<System.Int32> IDJob { get; set; } 
        protected internal PeopleRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.PaymentType {
    public partial class PaymentTypeDataSet {
    
    public partial class PaymentTypeDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.PaymentType.PaymentTypeDataSet.PaymentTypeRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.PaymentType {
    public partial class PaymentTypeDataSet {
    
    public partial class PaymentTypeRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.PaymentType.PaymentTypeDataSet.PaymentTypeDataTable PaymentTypeDataTable { get; } 
		public ITAP.glassCAD.Dictionary.PaymentType.PaymentTypeDataSet PaymentTypeDataSet { get; } 
		public System.Int32 IDPaymentType { get; set; } 
		public System.String Name { get; set; } 
		public System.String Comment { get; set; } 
        protected internal PaymentTypeRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Operation {
    public partial class OperationDataSet {
    
    public partial class OperationDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Operation {
    public partial class OperationDataSet {
    
    public partial class OperationRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationDataTable OperationDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet OperationDataSet { get; } 
		public System.Int32 IDOperation { get; set; } 
		public System.Int32 NumOperation { get; set; } 
		public System.String Name { get; set; } 
		public System.String CodeOperation { get; set; } 
		public System.Nullable<System.Int32> IDCalendar { get; set; } 
		public System.Int32 OperationType { get; set; } 
		public System.String CostWorkFlow { get; set; } 
		public System.String DurationWorkFlow { get; set; } 
		public System.String ConstraintWorkFlow { get; set; } 
		public System.String ProcessingWorkFlow { get; set; } 
		public System.String CalendarWorkflow { get; set; } 
        protected internal OperationRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Operation {
    public partial class OperationDataSet {
    
    public partial class OperationIdentDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationIdentRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Operation {
    public partial class OperationDataSet {
    
    public partial class OperationIdentRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationIdentDataTable OperationIdentDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet OperationDataSet { get; } 
		public System.Int32 IDOperationIdent { get; set; } 
		public System.Nullable<System.Int32> IDOperation { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Int32 CalcType { get; set; } 
		public System.String DisplayName { get; set; } 
		public System.String GroupName { get; set; } 
		public System.String IdentName { get; set; } 
		public System.Nullable<System.Decimal> VAT { get; set; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationRow Operation { get; } 
        protected internal OperationIdentRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Operation {
    public partial class OperationDataSet {
    
    public partial class OperationParamDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationParamRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Operation {
    public partial class OperationDataSet {
    
    public partial class OperationParamRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationParamDataTable OperationParamDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet OperationDataSet { get; } 
		public System.Int32 IDOperationParam { get; set; } 
		public System.Nullable<System.Int32> IDOperation { get; set; } 
		public System.String Name { get; set; } 
		public System.String Comment { get; set; } 
		public System.String ShortName { get; set; } 
		public System.Int32 OperationParamValueType { get; set; } 
		public System.String DefaultValue { get; set; } 
		public System.String Ident { get; set; } 
		public System.Boolean AutoAdd { get; set; } 
		public System.Boolean IsPrinting { get; set; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationRow Operation { get; } 
        protected internal OperationParamRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Operation {
    public partial class OperationDataSet {
    
    public partial class OperationParamValueDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationParamValueRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Operation {
    public partial class OperationDataSet {
    
    public partial class OperationParamValueRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationParamValueDataTable OperationParamValueDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet OperationDataSet { get; } 
		public System.Int32 IDOperationParamValue { get; set; } 
		public System.Nullable<System.Int32> IDOperation { get; set; } 
		public System.Int32 IDOperationParam { get; set; } 
		public System.String Name { get; set; } 
		public System.String Comment { get; set; } 
		public ITAP.glassCAD.Dictionary.Operation.OperationDataSet.OperationRow Operation { get; } 
        protected internal OperationParamValueRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Measure {
    public partial class MeasureDataSet {
    
    public partial class MeasureDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Measure.MeasureDataSet.MeasureRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Measure {
    public partial class MeasureDataSet {
    
    public partial class MeasureRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Measure.MeasureDataSet.MeasureDataTable MeasureDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Measure.MeasureDataSet MeasureDataSet { get; } 
		public System.Int32 IDMeasure { get; set; } 
		public System.String Name { get; set; } 
		public System.String ShortName { get; set; } 
		public System.Decimal Rate { get; set; } 
		public System.Nullable<System.Int32> IDParent { get; set; } 
		public System.Nullable<System.Decimal> Width { get; set; } 
		public System.Nullable<System.Decimal> Height { get; set; } 
        protected internal MeasureRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Marshrut {
    public partial class MarshrutDataSet {
    
    public partial class MarshrutDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Marshrut.MarshrutDataSet.MarshrutRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Marshrut {
    public partial class MarshrutDataSet {
    
    public partial class MarshrutRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Marshrut.MarshrutDataSet.MarshrutDataTable MarshrutDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Marshrut.MarshrutDataSet MarshrutDataSet { get; } 
		public System.Int32 IDMarshrut { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 IDGrOptPacking { get; set; } 
        protected internal MarshrutRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.GrOpt {
    public partial class GrOptDataSet {
    
    public partial class GrOptDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.GrOpt.GrOptDataSet.GrOptRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.GrOpt {
    public partial class GrOptDataSet {
    
    public partial class GrOptRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.GrOpt.GrOptDataSet.GrOptDataTable GrOptDataTable { get; } 
		public ITAP.glassCAD.Dictionary.GrOpt.GrOptDataSet GrOptDataSet { get; } 
		public System.Int32 IDGrOpt { get; set; } 
        protected internal GrOptRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.GrOptPacking {
    public partial class GrOptPackingDataSet {
    
    public partial class GrOptPackingDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.GrOptPacking.GrOptPackingDataSet.GrOptPackingRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.GrOptPacking {
    public partial class GrOptPackingDataSet {
    
    public partial class GrOptPackingRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.GrOptPacking.GrOptPackingDataSet.GrOptPackingDataTable GrOptPackingDataTable { get; } 
		public ITAP.glassCAD.Dictionary.GrOptPacking.GrOptPackingDataSet GrOptPackingDataSet { get; } 
		public System.Int32 IDGrOptPacking { get; set; } 
		public System.String Name { get; set; } 
        protected internal GrOptPackingRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Goods {
    public partial class GoodsDataSet {
    
    public partial class GoodsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Goods {
    public partial class GoodsDataSet {
    
    public partial class GoodsRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsDataTable GoodsDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet GoodsDataSet { get; } 
		public System.Int32 IDGood { get; set; } 
		public System.Nullable<System.Int32> IDGroup { get; set; } 
		public System.String Name { get; set; } 
		public System.String Marking { get; set; } 
		public System.Int32 IDMeasure { get; set; } 
		public System.Nullable<System.Decimal> Waste { get; set; } 
		public System.Nullable<System.Decimal> Thick { get; set; } 
		public System.Nullable<System.Decimal> Weight { get; set; } 
		public System.Nullable<System.Decimal> Height { get; set; } 
		public System.Nullable<System.Decimal> Width { get; set; } 
		public System.Int32 Typ { get; set; } 
		public System.Nullable<System.Int32> TypGlass { get; set; } 
		public System.Nullable<System.Int32> TypRamka { get; set; } 
		public System.Nullable<System.Decimal> Thickness { get; set; } 
		public System.Nullable<System.Int32> IDGrOpt { get; set; } 
		public System.Nullable<System.Decimal> MinOst { get; set; } 
		public System.Nullable<System.Decimal> AlertOst { get; set; } 
		public System.String EquipmentName { get; set; } 
		public System.Boolean IsVirtual { get; set; } 
		public System.Boolean IsEnabled { get; set; } 
		public System.Int32 UseWasteModeForPlanCalc { get; set; } 
		public System.Nullable<System.Decimal> Price { get; set; } 
		public System.Nullable<System.Decimal> Price2 { get; set; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GroupGoodsRow GroupGoods { get; } 
        protected internal GoodsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Goods {
    public partial class GoodsDataSet {
    
    public partial class GoodsDetailDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsDetailRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Goods {
    public partial class GoodsDataSet {
    
    public partial class GoodsDetailRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsDetailDataTable GoodsDetailDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet GoodsDataSet { get; } 
		public System.Int32 IDGoodsDetail { get; set; } 
		public System.Nullable<System.Int32> IDGoods { get; set; } 
		public System.String FormulaDefault { get; set; } 
		public System.Int32 IDGoodsReference { get; set; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GoodsRow Goods { get; } 
        protected internal GoodsDetailRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Goods {
    public partial class GoodsDataSet {
    
    public partial class GroupGoodsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GroupGoodsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Goods {
    public partial class GoodsDataSet {
    
    public partial class GroupGoodsRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet.GroupGoodsDataTable GroupGoodsDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Goods.GoodsDataSet GoodsDataSet { get; } 
		public System.Int32 IDGroup { get; set; } 
		public System.Nullable<System.Int32> ParentID { get; set; } 
		public System.String Name { get; set; } 
		public System.Nullable<System.Int32> GroupGoodsExtKey { get; set; } 
        protected internal GroupGoodsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.GoodParties {
    public partial class GoodPartiesDataSet {
    
    public partial class GoodPartiesDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.GoodParties.GoodPartiesDataSet.GoodPartiesRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.GoodParties {
    public partial class GoodPartiesDataSet {
    
    public partial class GoodPartiesRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.GoodParties.GoodPartiesDataSet.GoodPartiesDataTable GoodPartiesDataTable { get; } 
		public ITAP.glassCAD.Dictionary.GoodParties.GoodPartiesDataSet GoodPartiesDataSet { get; } 
		public System.Int32 IDGoodParties { get; set; } 
		public System.String Name { get; set; } 
		public System.String GroupName { get; set; } 
        protected internal GoodPartiesRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Equipment {
    public partial class EquipmentDataSet {
    
    public partial class EquipmentDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Equipment.EquipmentDataSet.EquipmentRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Equipment {
    public partial class EquipmentDataSet {
    
    public partial class EquipmentRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Equipment.EquipmentDataSet.EquipmentDataTable EquipmentDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Equipment.EquipmentDataSet EquipmentDataSet { get; } 
		public System.Int32 IDEquipment { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 IDOperationType { get; set; } 
		public System.Int32 IDCalendar { get; set; } 
		public System.Nullable<System.Guid> GUID { get; set; } 
		public System.Nullable<System.Guid> Ident { get; set; } 
		public System.String Settings { get; set; } 
        protected internal EquipmentRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.DocOper {
    public partial class DocOperDataSet {
    
    public partial class DocOperDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.DocOper {
    public partial class DocOperDataSet {
    
    public partial class DocOperRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperDataTable DocOperDataTable { get; } 
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet DocOperDataSet { get; } 
		public System.Int32 IDDocOper { get; set; } 
		public System.String Name { get; set; } 
        protected internal DocOperRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.DocOper {
    public partial class DocOperDataSet {
    
    public partial class DocOperItemsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperItemsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.DocOper {
    public partial class DocOperDataSet {
    
    public partial class DocOperItemsRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperItemsDataTable DocOperItemsDataTable { get; } 
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet DocOperDataSet { get; } 
		public System.Int32 IDDocOperItems { get; set; } 
		public System.Nullable<System.Int32> IDDocOper { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 Typ { get; set; } 
		public System.String Prefix { get; set; } 
		public System.String Suffix { get; set; } 
		public System.String NumDocMask { get; set; } 
		public System.Nullable<System.DateTime> DtClose { get; set; } 
		public System.Nullable<System.DateTime> DtCloseRefreshed { get; } 
		public System.Int32 IDCompany { get; set; } 
		public ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet.DocOperRow DocOper { get; } 
        protected internal DocOperItemsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Diraction {
    public partial class DiractionDataSet {
    
    public partial class DiractionDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Diraction.DiractionDataSet.DiractionRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Diraction {
    public partial class DiractionDataSet {
    
    public partial class DiractionRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Diraction.DiractionDataSet.DiractionDataTable DiractionDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Diraction.DiractionDataSet DiractionDataSet { get; } 
		public System.Int32 IDDiraction { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.String Name { get; set; } 
		public System.String Comment { get; set; } 
		public System.Int32 DiractionType { get; set; } 
        protected internal DiractionRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Depart {
    public partial class DepartDataSet {
    
    public partial class DepartDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Depart.DepartDataSet.DepartRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Depart {
    public partial class DepartDataSet {
    
    public partial class DepartRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Depart.DepartDataSet.DepartDataTable DepartDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Depart.DepartDataSet DepartDataSet { get; } 
		public System.Int32 IDDepart { get; set; } 
		public System.String Name { get; set; } 
		public System.String Comment { get; set; } 
		public System.String EMail { get; set; } 
        protected internal DepartRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class AgreementDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.AgreementRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class AgreementRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.AgreementDataTable AgreementDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet CustomerDataSet { get; } 
		public System.Int32 IDAgreement { get; set; } 
		public System.Nullable<System.Int32> IDCustomer { get; set; } 
		public System.String Name { get; set; } 
		public System.Nullable<System.DateTime> Date { get; set; } 
		public System.Nullable<System.DateTime> DateClosed { get; set; } 
		public System.Nullable<System.Int32> IDPaymentType { get; set; } 
		public System.Nullable<System.Int32> State { get; set; } 
		public System.Byte[] Data { get; set; } 
		public System.String DataFileName { get; set; } 
		public System.Nullable<System.Guid> OrdersCalculationWorkflow { get; set; } 
		public System.Nullable<System.Guid> OrderItemCalculationWorkflow { get; set; } 
		public System.Nullable<System.Guid> OrderItemGroupCalculationWorkflow { get; set; } 
		public System.Nullable<System.Guid> OrderGoodCalculationWorkflow { get; set; } 
		public System.Nullable<System.Guid> OrderServicesCalculationWorkflow { get; set; } 
		public System.Nullable<System.Guid> SellingCalculationWorkflow { get; set; } 
		public System.Nullable<System.Guid> SellingItemCalculationWorkflow { get; set; } 
		public System.Nullable<System.Guid> SellingGoodCalculationWorkflow { get; set; } 
		public System.Nullable<System.Guid> SellingServicesCalculationWorkflow { get; set; } 
		public System.Nullable<System.Int32> IDPriceForms { get; set; } 
		public System.Nullable<System.Int32> IDCurrency { get; set; } 
		public System.Nullable<System.Int32> CustomerType { get; set; } 
		public System.String Comment { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerRow Customer { get; } 
        protected internal AgreementRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerAddressDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerAddressRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerAddressRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerAddressDataTable CustomerAddressDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet CustomerDataSet { get; } 
		public System.Int32 IDCustomerAddress { get; set; } 
		public System.Nullable<System.Int32> IDCustomer { get; set; } 
		public System.String LongAddress { get; set; } 
		public System.Nullable<System.Int32> IDMarshrut { get; set; } 
		public System.Int32 AddressType { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerRow Customer { get; } 
        protected internal CustomerAddressRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerBankDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerBankRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerBankRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerBankDataTable CustomerBankDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet CustomerDataSet { get; } 
		public System.Int32 IDCustomerBank { get; set; } 
		public System.Nullable<System.Int32> IDCustomer { get; set; } 
		public System.String Name { get; set; } 
		public System.Boolean IsMainBank { get; set; } 
		public System.String CurrensyCode { get; set; } 
		public System.String Address { get; set; } 
		public System.String BIK { get; set; } 
		public System.String Account { get; set; } 
		public System.String KAccount { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerRow Customer { get; } 
        protected internal CustomerBankRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerContactsDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerContactsRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerContactsRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerContactsDataTable CustomerContactsDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet CustomerDataSet { get; } 
		public System.Int32 IDCustomerContacts { get; set; } 
		public System.Nullable<System.Int32> IDCustomer { get; set; } 
		public System.String Name { get; set; } 
		public System.Nullable<System.Int32> IDJob { get; set; } 
		public System.String Comment { get; set; } 
		public System.String EMail { get; set; } 
		public System.String Phone { get; set; } 
		public System.String PhoneMobile1 { get; set; } 
		public System.String PhoneMobile2 { get; set; } 
		public System.String PhoneWork { get; set; } 
		public System.String PhoneHome { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerRow Customer { get; } 
        protected internal CustomerContactsRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerDataTable CustomerDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet CustomerDataSet { get; } 
		public System.Int32 IDCustomer { get; set; } 
		public System.Nullable<System.Int32> IDCustomerGroup { get; set; } 
		public System.String Name { get; set; } 
		public System.String FullName { get; set; } 
		public System.String ExternalName { get; set; } 
		public System.String Comment { get; set; } 
		public System.String BarCodeType { get; set; } 
		public System.Int32 State { get; set; } 
		public System.String Code { get; set; } 
		public System.Int32 Face { get; set; } 
		public System.Nullable<System.Int32> IDManager { get; set; } 
		public System.Nullable<System.DateTime> DtCreated { get; set; } 
		public System.String INN { get; set; } 
		public System.String KPP { get; set; } 
		public System.String RegInfo { get; set; } 
		public System.String OKPO { get; set; } 
		public System.String OGRN { get; set; } 
		public System.String WebSite { get; set; } 
		public System.String Phone { get; set; } 
		public System.String Email { get; set; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerGroupRow CustomerGroup { get; } 
        protected internal CustomerRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerGroupDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerGroupRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Customer {
    public partial class CustomerDataSet {
    
    public partial class CustomerGroupRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet.CustomerGroupDataTable CustomerGroupDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Customer.CustomerDataSet CustomerDataSet { get; } 
		public System.Int32 IDCustomerGroup { get; set; } 
		public System.Nullable<System.Int32> IDParent { get; set; } 
		public System.String Name { get; set; } 
        protected internal CustomerGroupRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Currency {
    public partial class CurrencyDataSet {
    
    public partial class CurrencyDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Currency {
    public partial class CurrencyDataSet {
    
    public partial class CurrencyRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyDataTable CurrencyDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet CurrencyDataSet { get; } 
		public System.Int32 IDCurrency { get; set; } 
		public System.String Name { get; set; } 
		public System.Boolean Basic { get; set; } 
		public System.Int32 Code { get; set; } 
        protected internal CurrencyRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Currency {
    public partial class CurrencyDataSet {
    
    public partial class CurrencyHistoryDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyHistoryRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Currency {
    public partial class CurrencyDataSet {
    
    public partial class CurrencyHistoryRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyHistoryDataTable CurrencyHistoryDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet CurrencyDataSet { get; } 
		public System.Int32 IDCurrencyHistory { get; set; } 
		public System.Nullable<System.Int32> IDCurrency { get; set; } 
		public System.DateTime Date { get; set; } 
		public System.Decimal Rate { get; set; } 
		public ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet.CurrencyRow Currency { get; } 
        protected internal CurrencyHistoryRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Company {
    public partial class CompanyDataSet {
    
    public partial class CompanyDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Company.CompanyDataSet.CompanyRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Company {
    public partial class CompanyDataSet {
    
    public partial class CompanyRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Company.CompanyDataSet.CompanyDataTable CompanyDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Company.CompanyDataSet CompanyDataSet { get; } 
		public System.Int32 IDCompany { get; set; } 
		public System.String Name { get; set; } 
        protected internal CompanyRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Calendar {
    public partial class CalendarDataSet {
    
    public partial class CalendarDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Calendar.CalendarDataSet.CalendarRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Calendar {
    public partial class CalendarDataSet {
    
    public partial class CalendarRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Calendar.CalendarDataSet.CalendarDataTable CalendarDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Calendar.CalendarDataSet CalendarDataSet { get; } 
		public System.Int32 IDCalendar { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.String Name { get; set; } 
		public System.Boolean IsInParallel { get; set; } 
		public System.Int32 IDStorehouse { get; set; } 
		public System.Int32 IDCompany { get; set; } 
		public System.Int32 Efficiency { get; set; } 
		public System.String InternalLabelName { get; set; } 
		public System.Boolean IsDefaultVisible { get; set; } 
		public System.Int32 ARMinterface { get; set; } 
		public System.Int32 HalfProductionOutDiraction { get; set; } 
		public System.Int32 AppointmentItemsOrderMode { get; set; } 
        protected internal CalendarRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Calculation {
    public partial class CalculationDataSet {
    
    public partial class CalculationDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.Calculation.CalculationDataSet.CalculationRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.Calculation {
    public partial class CalculationDataSet {
    
    public partial class CalculationRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.Calculation.CalculationDataSet.CalculationDataTable CalculationDataTable { get; } 
		public ITAP.glassCAD.Dictionary.Calculation.CalculationDataSet CalculationDataSet { get; } 
		public System.Int32 IDCalculation { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 NumPos { get; set; } 
        protected internal CalculationRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
    }
}
namespace ITAP.glassCAD.Dictionary.CalculationVariables {
    public partial class CalculationVariablesDataSet {
    
    public partial class CalculationVariablesDataTable : System.Data.DataTable {
		public ITAP.glassCAD.Data.DictionaryMetadata DictionaryMetadata { get; } 
		public System.Collections.Generic.IEnumerable<ITAP.glassCAD.Dictionary.CalculationVariables.CalculationVariablesDataSet.CalculationVariablesRow> DataRows { get; } 
		public System.Boolean IsModify { get; } 
    }
    }
}
namespace ITAP.glassCAD.Dictionary.CalculationVariables {
    public partial class CalculationVariablesDataSet {
    
    public partial class CalculationVariablesRow : System.Data.DataRow {
		public ITAP.glassCAD.Dictionary.CalculationVariables.CalculationVariablesDataSet.CalculationVariablesDataTable CalculationVariablesDataTable { get; } 
		public ITAP.glassCAD.Dictionary.CalculationVariables.CalculationVariablesDataSet CalculationVariablesDataSet { get; } 
		public System.Int32 IDCalculationVariables { get; set; } 
		public System.String Name { get; set; } 
		public System.Int32 NumPos { get; set; } 
		public System.Decimal Value { get; set; } 
        protected internal CalculationVariablesRow(System.Data.DataRowBuilder builder) : base(builder) {
            throw new System.NotImplementedException();
        }
    }
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
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Packing.MathPacksPosition {
    public partial class WithPillarsStrategy {
    
    public partial class _Pillar {
		public glassPeople.ActivityLibrary.glassCAD.Planing.Packing.MathPacksPosition.WithPillarsStrategy._Pillar NextPillar { get; set; } 
		public System.Int32 Offcet { get; set; } 
		public System.Int32 Value { get; set; } 
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
