namespace ITAP.glassCAD.Production {
    
    public partial class TestActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.EditFormNativeActivity {
    }
}
namespace ITAP.glassCAD.Documents.BoxProduction.Workflow.Activities {
    
    public partial class BoxProductionItemAddGoodActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDGood { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Decimal> Expression { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> Qu { get; set; } 
		public System.Activities.InArgument<System.String> Marking { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class SelectDateTimeActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.EditFormNativeActivity {
		[System.ComponentModel.DisplayNameAttribute("Отображать диалог")]
		public System.Boolean Show { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Заголовок формы выбора")]
		public System.String Caption { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Int32 TypePeriod { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Дата С")]
		public System.Activities.OutArgument<System.DateTime> DateFrom { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Дата По")]
		public System.Activities.OutArgument<System.DateTime> DateTo { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Период выбран")]
		[System.ComponentModel.Browsable(false)]
		public System.Activities.OutArgument<System.Boolean> PeriodSelected { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; } 
		[System.ComponentModel.CategoryAttribute("Scheme")]
		[System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
		[System.ComponentModel.RefreshPropertiesAttribute((System.ComponentModel.RefreshProperties)1)]
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML Dgml { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class ShowMessageActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.EditFormNativeActivity {
		public System.Activities.InArgument<System.String> Caption { get; set; } 
		public System.Activities.InArgument<System.String> Message { get; set; } 
		public System.Boolean ShowInLog { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML Dgml { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public abstract partial class CustomActionsActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.EditFormNativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button> Buttons { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button>();
		[System.ComponentModel.Browsable(false)]
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button> ToolBar { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button>();
		[System.ComponentModel.Browsable(false)]
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button> BottomBar { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button>();
		[System.ComponentModel.Browsable(false)]
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button> Custom { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input.Button>();
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.WorkFlow.Activities.InterfacePreset> InterfacePreset { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> Action { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Int32> ActionKey { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public abstract partial class DataLayerNativeActivity : System.Activities.NativeActivity {
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public abstract partial class DataLayerNativeActivity<T> : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		public System.Activities.OutArgument<T> Result { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public abstract partial class EditFormNativeActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML Dgml { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class ExecuteTemplateActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.ComponentModel.DisplayNameAttribute("ИД шаблона")]
		public System.Nullable<System.Int32> IDWorkFlowTemplate { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Guid шаблона")]
		public System.Guid GuidWorkFlowTemplate { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Входные параметры")]
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.TemplateInArg> InArguments { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.TemplateInArg>();
		[System.ComponentModel.DisplayNameAttribute("Выходные параметры")]
		public System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.TemplateOutArg> OutArguments { get; set; } = new System.Collections.ObjectModel.Collection<ITAP.glassCAD.Dictionary.WorkFlow.Activities.TemplateOutArg>();
		[System.ComponentModel.DefaultValue(true)]
		public System.Boolean WaitForExecute { get; set; } 
		[System.ComponentModel.CategoryAttribute("Scheme")]
		[System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
		[System.ComponentModel.RefreshPropertiesAttribute((System.ComponentModel.RefreshProperties)1)]
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML Dgml { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public abstract partial class FilterActivity<T> : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.ComponentModel.CategoryAttribute("Source")]
		public System.Activities.InArgument<System.Collections.Generic.List<T>> Source { get; set; } 
		[System.ComponentModel.CategoryAttribute("Result")]
		public System.Activities.OutArgument<System.Collections.Generic.List<T>> Result { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public abstract partial class FilterDataSetActivity<T> : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity<T> {
		public System.Activities.InArgument<T> Source { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class InterfacePresetAddActivity : System.Activities.NativeActivity {
		public System.Activities.InOutArgument<ITAP.glassCAD.Dictionary.WorkFlow.Activities.InterfacePreset> Source { get; set; } 
		public System.String Name { get; set; } 
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.InterfaceItemMode Mode { get; set; } 
		public System.Activities.InArgument<System.Object> FilterValue { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public abstract partial class ListActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.CustomActionsActivity {
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.InOutArgument<System.Nullable<System.Int32>> IdObject { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Collections.Generic.List<System.Int32>> IdObjects { get; set; } 
		public ITAP.glassCAD.Helpers.FormParameters.FormMode FormMode { get; set; } 
		public ITAP.glassCAD.Helpers.FormParameters.SelectedMode SelectedMode { get; set; } 
		public System.String DoubleClickActionName { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class ReturnActivity : System.Activities.NativeActivity {
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML Dgml { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class EditOrderActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders.EditOrderActivity {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class FilterByDatesActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders.FilterByDatesActivity {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class LoadOrderActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders.LoadOrderActivity {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities {
    
    public partial class OrdersActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders.EditActivity {
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> Filter { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Documents.Orders.OrdersDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders {
    
    public partial class EditOrderActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.CustomActionsActivity {
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
		public System.Activities.InArgument<ITAP.glassCAD.Documents.Orders.OrdersDataSet> OrdersDataSet { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Права доступа")]
		[System.ComponentModel.DescriptionAttribute("0 = Нет доступа, 2 = Полный доступ")]
		public System.Nullable<System.Int32> RightAccessMode { get; set; } 
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML Dgml { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders {
    
    public partial class FilterByDatesActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.FilterActivity<System.Int32> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.DateTime> StartDate { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.DateTime> EndDate { get; set; } 
		public System.Boolean IncludeOrderLink { get; set; } 
		public System.Boolean IncludeOrderDefective { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders {
    
    public partial class LoadOrderActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
		public System.Activities.InArgument<ITAP.glassCAD.Documents.Orders.OrdersDataSet> OrdersDataSet { get; set; } 
		public System.Activities.OutArgument<ITAP.glassCAD.Documents.Orders.OrdersDataSet> Result { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders {
    
    public partial class RefreshOrderActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.EditFormNativeActivity {
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
		public System.Activities.InArgument<ITAP.glassCAD.Documents.Orders.OrdersDataSet> OrdersDataSet { get; set; } 
		public System.Boolean PriceRefreshOnly { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.Orders {
    
    public partial class SaveOrdersDataSet : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.ComponentModel.Browsable(false)]
		public System.Boolean EnabledEntry { get; set; } 
		public System.Activities.InArgument<ITAP.glassCAD.Documents.Orders.OrdersDataSet> OrdersDataSet { get; set; } 
		public System.Boolean ForcedSave { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class CalculationBoxProductionActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class CompareBoxProductionActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> PrevDataSet { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> DataSet { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Есть изменение данных")]
		public System.Activities.OutArgument<System.Boolean> HasChanges { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class CreateBoxProductionActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.ComponentModel.DisplayNameAttribute("ИД документа")]
		public System.Activities.OutArgument<System.Int32> IDBoxProduction { get; set; } 
		public System.Activities.OutArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> BoxProductionDataSet { get; set; } 
		[System.ComponentModel.CategoryAttribute("Scheme")]
		[System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
		[System.ComponentModel.RefreshPropertiesAttribute((System.ComponentModel.RefreshProperties)1)]
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML Dgml { get; set; } 
		public System.Boolean SaveToBase { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class CreateBoxProductionByOrderActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDOrder { get; set; } 
		public System.Boolean SaveToBase { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("ИД документа")]
		public System.Activities.OutArgument<System.Int32> IDBoxProduction { get; set; } 
		public System.Activities.OutArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> BoxProductionDataSet { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class DeleteBoxProductionActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		public System.Activities.InArgument<System.Int32> IDBoxProduction { get; set; } 
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> BoxProductionDataSet { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class DublicateBoxProductionActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.ComponentModel.DisplayNameAttribute("ИД исходного документa")]
		public System.Activities.InArgument<System.Int32> IDBoxProduction { get; set; } 
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> BoxProductionDataSetIn { get; set; } 
		public System.Boolean SetNewNmDoc { get; set; } 
		public System.Boolean SetCurrentDtDoc { get; set; } 
		public System.Boolean SetCurrentUser { get; set; } 
		public System.Activities.OutArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> BoxProductionDataSetOut { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML Dgml { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class EditBoxProductionActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.CustomActionsActivity {
		[System.ComponentModel.DisplayNameAttribute("ИД документа ")]
		public System.Activities.InArgument<System.Int32> IDBoxProduction { get; set; } 
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> BoxProductionDataSet { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Права доступа")]
		[System.ComponentModel.DescriptionAttribute("0 = Нет доступа, 1 = Только для чтения, 2 = Полный доступ")]
		public System.Nullable<System.Int32> RightAccessMode { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class FilterByDatesActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.FilterDataSetActivity<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.DateTime> StartDate { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.DateTime> EndDate { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class LoadBoxProductionActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		public System.Activities.InArgument<System.Int32> IDBoxProduction { get; set; } 
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> BoxProductionDataSet { get; set; } 
		public System.Activities.OutArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> Result { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class SaveBoxProductionDataSet : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> BoxProductionDataSet { get; set; } 
		public System.Boolean ForcedSave { get; set; } 
		[System.ComponentModel.Browsable(false)]
		public System.Boolean EnabledEntry { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Documents.BoxProduction {
    
    public partial class SetStatusActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<ITAP.glassCAD.Documents.BoxProduction.BoxProductionDataSet> BoxProductionDataSet { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Status { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.User {
    
    public partial class GetUserBusinessLogicRightAccessActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		public System.Activities.InArgument<System.Int32> UserID { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_SuperAdmin { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_DublMessage { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_REKL { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_REKL_ALTERATION { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_Constructor { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_Tehnolog { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OPP { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_PRO_CEO { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_REKL_CEO2 { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_SGP_ALTERATION_ACCESS { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_SGP_CEO { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_PlanTransport { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_Logist { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_ZakupkiGlass { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_ZakupkiRows { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_SkladRowOperator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_SkladGlass { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_SkladRow { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_SkladGlassOperator { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OptDefective { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_Opt { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_PRO { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_REKL_ALTERATION_ACCESS { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_REKL_CEO { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_SGP { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_OTK_SGP_ALTERATION { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_BuhSelling { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_Analist { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_BuhZakupki { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_Sales_Dir { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_CEO { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_TehAdmin { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUsers_Transport { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUser_NachPro { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUsers_Orders { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUsers_GoodsCatalog { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUsers_BuhControlSklad { get; set; } 
		public System.Activities.OutArgument<System.Boolean> IsUsers_Customers { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.User {
    
    public partial class GetUserInfoActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.People.GetPeopleInfoActivity {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class ReLoadDictionaryActivity : System.Activities.NativeActivity {
		public System.Activities.InArgument<System.String> TypeName { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class SqlSelectActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> SelectText { get; set; } 
		public System.Activities.OutArgument<System.Data.DataTable> Result { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasResult { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class SqlExecActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> SelectText { get; set; } 
		public System.Int32 CommandTimeout { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasResult { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class ObjectAddHistoryActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDoc { get; set; } 
		public System.Activities.InArgument<System.Int32> IDPeople { get; set; } 
		public System.Activities.InArgument<System.String> Name { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Text { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class SetObjectAttributesActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.ComponentModel.CategoryAttribute("Mode")]
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites.SetObjectAttributesMode Mode { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDAttributes { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDoc { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Int32> ReferenceIDDoc { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Int32> ReferenceIDDocOper { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Int32> IntValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Int32> IntValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Int32> IntValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Decimal> DecimalValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Decimal> DecimalValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Decimal> DecimalValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> StringValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> StringValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> StringValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.DateTime> DateTimeValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.DateTime> DateTimeValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.DateTime> DateTimeValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Boolean> BitValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Boolean> BitValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Boolean> BitValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> TextValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> TextValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.String> TextValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Byte[]> BytesValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Byte[]> BytesValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.InArgument<System.Byte[]> BytesValue3 { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class GetObjectAttributesActivity : System.Activities.NativeActivity {
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDAttributes { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDoc { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Int32> ReferenceIDDoc { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Int32> ReferenceIDDocOper { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Int32> IntValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Int32> IntValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Int32> IntValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Decimal> DecimalValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Decimal> DecimalValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Decimal> DecimalValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> StringValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> StringValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.String> StringValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.OutArgument<System.String> TextValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.OutArgument<System.String> TextValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Property")]
		public System.Activities.OutArgument<System.String> TextValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.DateTime> DateTimeValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.DateTime> DateTimeValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.DateTime> DateTimeValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> BitValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> BitValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> BitValue3 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Byte[]> BytesValue1 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Byte[]> BytesValue2 { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Byte[]> BytesValue3 { get; set; } 
		public System.Activities.OutArgument<System.Boolean> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class SetObjectAttributeListActivity : System.Activities.NativeActivity {
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<ITAP.Components.Entities.Attribute>> Attributes { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
		[System.ComponentModel.CategoryAttribute("In")]
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDoc { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class CopyObjectAttributesActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocFrom { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocTo { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class GetObjectAttributeActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity<ITAP.Components.Entities.Attribute> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDoc { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDAttributes { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class FindObjectsByAttribute : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDAttributes { get; set; } 
		public System.Activities.OutArgument<System.Collections.Generic.List<System.Int32>> IDObjectList { get; set; } 
		public System.Activities.OutArgument<System.Collections.Generic.List<System.Int32>> IDObjectAttributesList { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class ObjectGetEditModeActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDoc { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.OutArgument<System.Int32> Mode { get; set; } 
		public System.Activities.OutArgument<System.Nullable<System.DateTime>> DateTime { get; set; } 
		public System.Activities.OutArgument<System.String> UserName { get; set; } 
		public System.Activities.OutArgument<System.Nullable<System.Int32>> IDUser { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class ObjectSetEditModeActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDDoc { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> Mode { get; set; } 
		public System.Activities.InArgument<System.Nullable<System.DateTime>> DateTime { get; set; } 
		public System.Activities.InArgument<System.String> UserName { get; set; } 
		public System.Activities.InArgument<System.Int32> IDUser { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Utilites {
    
    public partial class SelectObjectAttributesActivity<T> : ITAP.glassCAD.Dictionary.WorkFlow.Activities.EditFormNativeActivity {
		public ITAP.Components.Dialog.SelectViewType SelectViewType { get; set; } 
		public System.Boolean AllowAddRow { get; set; } 
		public System.Boolean MultiSelect { get; set; } 
		public System.Activities.InArgument<System.Int32> IDDoc { get; set; } 
		public System.Activities.InArgument<System.Int32> IDDocOper { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDAttributes { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.String PropertyName { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> Selected { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<T> Result { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Collections.Generic.List<T>> ResultList { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.WorkflowUserSettings {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.WorkflowUserSettings.WorkflowUserSettingsDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.WorkFlowDocumentTemplate {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.WorkFlowDocumentTemplate.WorkFlowDocumentTemplateDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Storehouse {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Storehouse.StorehouseDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Sign {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Sign.SignDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Services {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Services.ServicesDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.ScanRole {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.ScanRole.ScanRoleDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.ScanActivity {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.ScanActivity.ScanActivityDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Production {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Production.ProductionDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.PriceForms {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.PriceForms.PriceFormsDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.People {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.People.PeopleDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.People {
    
    public partial class FilterByEmptyActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.FilterDataSetActivity<ITAP.glassCAD.Dictionary.People.PeopleDataSet> {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.People {
    
    public partial class FilterByListActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.FilterDataSetActivity<ITAP.glassCAD.Dictionary.People.PeopleDataSet> {
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> Ids { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.People {
    
    public partial class FilterByGlassTypeActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.FilterDataSetActivity<ITAP.glassCAD.Dictionary.People.PeopleDataSet> {
		public System.Activities.InArgument<System.Int32> IDDepart { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.People {
    
    public partial class FilterByPhoneActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.FilterDataSetActivity<ITAP.glassCAD.Dictionary.People.PeopleDataSet> {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Phone { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.People {
    
    public partial class GetPeopleInfoActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		public System.Activities.InArgument<System.Int32> IDPeople { get; set; } 
		public System.Activities.OutArgument<System.Int32> IDUser { get; set; } 
		public System.Activities.OutArgument<System.String> FullName { get; set; } 
		public System.Activities.OutArgument<System.String> EMail { get; set; } 
		public System.Activities.OutArgument<System.Nullable<System.Int32>> IDJob { get; set; } 
		public System.Activities.OutArgument<System.String> Comment { get; set; } 
		public System.Activities.OutArgument<System.String> Name { get; set; } 
		public System.Activities.OutArgument<System.String> MiddleName { get; set; } 
		public System.Activities.OutArgument<System.String> LastName { get; set; } 
		public System.Activities.OutArgument<System.Nullable<System.Int32>> IDDepart { get; set; } 
		public System.Activities.OutArgument<System.Boolean> HasResult { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.PaymentType {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.PaymentType.PaymentTypeDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Operation {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Operation.OperationDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Measure {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Measure.MeasureDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Marshrut {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Marshrut.MarshrutDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.GrOpt {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.GrOpt.GrOptDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.GrOptPacking {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.GrOptPacking.GrOptPackingDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Goods {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Goods.GoodsDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.GoodParties {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.GoodParties.GoodPartiesDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Equipment {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Equipment.EquipmentDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Equipment {
    
    public partial class EditExportParametersActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.EditFormNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDEquipment { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.DocOper {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.DocOper.DocOperDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Diraction {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Diraction.DiractionDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Depart {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Depart.DepartDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Customer {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Customer.CustomerDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Customer {
    
    public partial class EditItemActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.CustomActionsActivity {
		public System.Activities.InArgument<System.Int32> IDCustomer { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Customer {
    
    public abstract partial class Filter : ITAP.glassCAD.Dictionary.WorkFlow.Activities.FilterDataSetActivity<ITAP.glassCAD.Dictionary.Customer.CustomerDataSet> {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Customer {
    
    public partial class FilterByEmptyActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Customer.Filter {
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Currency {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class CurrencyCourceActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDCurrency { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Currency {
    
    public partial class CurrencyCourceGetActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.DataLayerNativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32> IDCurrency { get; set; } 
		public System.Activities.InArgument<System.DateTime> Date { get; set; } 
		public System.Activities.OutArgument<System.Decimal> Value { get; set; } 
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Currency {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Currency.CurrencyDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Company {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Company.CompanyDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Calendar {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Calendar.CalendarDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.Calculation {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.Calculation.CalculationDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Dictionaries.CalculationVariables {
    [System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]
    public partial class EditActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity {
		public System.Activities.InArgument<ITAP.glassCAD.Dictionary.CalculationVariables.CalculationVariablesDataSet> Source { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITAP.glassCAD.Dictionary.WorkFlow.Activities.Input {
    
    public partial class GetStringActivity : ITAP.glassCAD.Dictionary.WorkFlow.Activities.EditFormNativeActivity {
		public ITAP.glassCAD.Dictionary.WorkFlow.Activities.DGML Dgml { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Заголовок")]
		public System.Activities.InArgument<System.String> Caption { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Строка по-умолчанию")]
		public System.Activities.InArgument<System.String> DefaultString { get; set; } 
		public System.Activities.InArgument<System.String> Mask { get; set; } 
		public System.Boolean Multiline { get; set; } 
		public System.Boolean IsPassword { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		[System.ComponentModel.DisplayNameAttribute("Строка")]
		public System.Activities.OutArgument<System.String> String { get; set; } 
		[System.ComponentModel.CategoryAttribute("Out")]
		public System.Activities.OutArgument<System.Boolean> IsCanceled { get; set; } 
    }
}
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
    
    public partial class ExecProcedureActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Procedure { get; set; } 
		public System.Int32 TimeOut { get; set; } 
		public System.Activities.InArgument<System.String> AdminEmail { get; set; } 
		public System.Activities.InArgument<System.String> Subject { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
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
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Parser.DefaultParser> Parser { get; set; } 
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
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Parser.DefaultParser> Parser { get; set; } 
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
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Parser.DefaultParser> Parser { get; set; } 
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
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Scanner.Parser.DefaultParser> Parser { get; set; } 
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
		[System.ComponentModel.CategoryAttribute("Flags")]
		public System.Boolean DefectiveToMainGroupCode { get; set; } 
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
		public System.Activities.InArgument<System.Int32> IDOptStartegy { get; set; } 
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
    
    public partial class ByChildGroupcodeState : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsPrepared { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsOptimazied { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsAccepted { get; set; } 
		[System.ComponentModel.CategoryAttribute("State")]
		public System.Activities.InArgument<System.Nullable<System.Boolean>> IsProcessed { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByCustomer : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy {
    
    public partial class ByExpression : glassPeople.ActivityLibrary.glassCAD.Planing.Union.TwoGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> schedulerContext { get; set; } 
		public System.Activities.InArgument<System.Func<glassPeople.ActivityLibrary.glassCAD.Planing.Model.AppointmentItem, System.Boolean>> Expression { get; set; } 
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
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Union.Strategy.SM {
    
    public partial class ByPackingInfo : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
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
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring.SM {
    
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
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Coloring.KPI {
    
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
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<System.Int32>> IDOrderItemsIdentList { get; set; } 
		public System.Activities.InArgument<System.Boolean> CheckDOrderItemsIdentWorkStatus { get; set; } 
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
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Helpers {
    
    public partial class GetGroupCodesByIdsActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Int32[]> GroupCodeIds { get; set; } 
		public System.Activities.OutArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> Result { get; set; } 
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }
    }
}
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Helpers {
    
    public partial class GetMissingArmSquareCuttingByGroupCode : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
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
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.CreateArmSquareCuttingActivity.MarkingMode SetMarkingMode { get; set; } 
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.CreateArmSquareCuttingActivity.RemoveCoatingVariant SetRemoveCoatingVariant { get; set; } 
		public System.String StringTemplateForAPyramid { get; set; } 
		public System.String StringTemplateForLPyramid { get; set; } 
		public System.String StringTemplateForArfa { get; set; } 
		public System.String StringTemplateForBox { get; set; } 
		public System.String StringTemplateForSpace { get; set; } 
		[System.ComponentModel.DisplayNameAttribute("Не использовать - Отключить правило разделения по флагу снятия покрытия")]
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
		public glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation.GroupCodesFilterByChildsStateActivityMode Mode { get; set; } 
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
    
    public partial class GroupCodesFilterByNoChildsActivity : glassPeople.ActivityLibrary.FilterActivity<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode> {
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
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class UnionGroupCodesByParentUnionActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> PlanningContext { get; set; } 
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.Collections.Generic.List<glassPeople.ActivityLibrary.glassCAD.Planing.Model.GroupCode>> GroupCodes { get; set; } 
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
    
    public partial class BuildReportActivity : System.Activities.NativeActivity {
		[System.Activities.RequiredArgumentAttribute()]
		public System.Activities.InArgument<System.String> Name { get; set; } 
		public System.Activities.InArgument<System.String> ConnectionString { get; set; } 
		public System.Activities.InArgument<System.Collections.Generic.Dictionary<System.String, System.Object>> Variables { get; set; } 
		public System.Activities.OutArgument<Stimulsoft.Report.StiReport> Result { get; set; } 
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
namespace glassPeople.ActivityLibrary.glassCAD.Planing.Activity.Actualisation {
    
    public partial class ByChildOrCalendar : glassPeople.ActivityLibrary.glassCAD.Planing.Union.MultiGroupActivity {
		public System.Activities.InArgument<glassPeople.ActivityLibrary.glassCAD.Planing.Model.PlanningContext> SchedulerContext { get; set; } 
    }
}
