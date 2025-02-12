
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace glassPeople.gen {
    internal class ClassesVisiter : ILocalTypeVisiter {
        protected const char Op_Br = '{';
        protected const char Cl_Br = '}';

        public string Result { get; set; }

        protected string getTextTypeForProperty(LocalType localType) {
            if (localType.IsGenericParameter) {
                return localType.Name;
            }

            var result = $"{localType.Namespace}.{localType.Name}";
            if (localType.DeclaringType != null)
                result = $"{localType.DeclaringType.Namespace}.{localType.DeclaringType.Name}.{localType.Name}";

            if (localType.GenericTypes?.Any() == true) {
                result += "<" + string.Join(", ", localType.GenericTypes.Select(p => getTextTypeForProperty(p))) + ">";
            }

            return result;
        }

        protected string getTextTypeForClass(LocalType localType) {
            if (localType.IsGenericParameter) {
                return localType.Name;
            }

            var result = localType.Name;

            if (localType.GenericTypes?.Any() == true) {
                result += "<" + string.Join(", ", localType.GenericTypes.Select(p => getTextTypeForProperty(p))) + ">";
            }

            if (localType.BaseType != null) {
                result += " : " + getTextTypeForProperty(localType.BaseType);
            }

            return result;
        }

        protected string getModifer(LocalType source) {
            var modifer = "public";
            if (source.IsAbstract) {
                modifer += " abstract";
            }
            modifer += " partial";
            return modifer;
        }

        protected string[] getProperties(LocalType source) {
            var properties = new List<string>();
            foreach (var property in source.Properties ?? Enumerable.Empty<LocalProperty>()) {
                var get_set = "get;";
                if (property.CanWrite) {
                    get_set += " set;";
                }

                var initial = string.Empty;
                if (property.Type.Name == "Collection" || property.Type.Name == "ObservableCollection") {
                    initial = $@"= new {getTextTypeForProperty(property.Type)}();";
                }

                foreach (var item in getCustomAttributes(property)) {
                    properties.Add("\t\t" + item);
                }

                properties.Add("\t\t" + $@"public {getTextTypeForProperty(property.Type)} {property.Name} {Op_Br} {get_set} {Cl_Br} {initial}");
            }
            return properties.ToArray();
        }

        private void replace(List<string> data, string testSource, string textDest) {
            if (data.Contains(testSource)) {
                data.Remove(testSource);
                data.Add(textDest);
            }
        }

        private void getCustomAttributesReplace(List<string> result) {
            replace(result,
                "[System.ComponentModel.BrowsableAttribute((Boolean)False)]",
                "[System.ComponentModel.Browsable(false)]"
            );
            replace(result,
                "[System.ComponentModel.DefaultValueAttribute((String)null)]",
                "[System.ComponentModel.DefaultValue(null)]"
            );
            replace(result,
                "[System.ComponentModel.DefaultValueAttribute((Boolean)False)]",
                "[System.ComponentModel.DefaultValue(false)]"
            );
            replace(result,
                "[System.ComponentModel.DefaultValueAttribute((Boolean)True)]",
                "[System.ComponentModel.DefaultValue(true)]"
            );
            replace(result,
                "[System.ComponentModel.ToolboxItemAttribute((Boolean)True)]",
                "[System.ComponentModel.ToolboxItemAttribute(true)]"
            );
            replace(result,
                "[System.AttributeUsageAttribute((System.AttributeTargets)4, AllowMultiple = True)]",
                "[System.AttributeUsageAttribute((System.AttributeTargets)4, AllowMultiple = true)]"
            );
        }

        protected string[] getDesignerAttribute(LocalType localType) {
            if (localType?.BaseType?.FullName == "ITAP.glassCAD.Dictionary.WorkFlow.Activities.ListActivity") {
                return new[] { "[System.ComponentModel.Designer(typeof(glassPeople.Designers.ButtonsActivityDesigner))]" };
            }
            return Array.Empty<string>();
        }

        protected string[] getCustomAttributes(LocalType source) {
            var result = (source.CustomAttributes ?? Array.Empty<string>()).ToList();

            result.Remove("[System.Runtime.CompilerServices.ExtensionAttribute()]");
            result.Remove("[System.SerializableAttribute()]");
            result.RemoveAll(p => p.Contains("DebuggerDisplayAttribute"));
            getCustomAttributesReplace(result);

            result.AddRange(getDesignerAttribute(source));

            return result.ToArray();
        }

        protected string[] getCustomAttributes(LocalProperty source) {
            var result = (source.CustomAttributes ?? Array.Empty<string>()).ToList();
            result.RemoveAll(p => p.Contains("TupleElementNamesAttribute"));
            getCustomAttributesReplace(result);
            return result.ToArray();
        }

        protected string getImplementation(LocalType source) {
            var implementation = string.Empty;

            if (source.BaseType != null && source.BaseType.Name == "DataRow") {
                implementation = $@"
        protected internal {source.Name}(System.Data.DataRowBuilder builder) : base(builder) {Op_Br}
            throw new System.NotImplementedException();
        {Cl_Br}";
            }

            return implementation;
        }

        public void Visit(LocalType source) {
            Result = $@"
namespace {source.Namespace} {Op_Br}
    {string.Join(Environment.NewLine, getCustomAttributes(source))}
    {getModifer(source)} class {getTextTypeForClass(source)} {Op_Br}
{string.Join(Environment.NewLine, getProperties(source))}
{string.Join(Environment.NewLine, getImplementation(source))}
    {Cl_Br}
{Cl_Br}
";
        }
    }

    internal class NestedClassesVisiter : ClassesVisiter {
        public new void Visit(LocalType source) {
            Result = $@"
namespace {source.Namespace} {Op_Br}
    {getModifer(source.DeclaringType)} class {getTextTypeForClass(source.DeclaringType)} {Op_Br}
    {string.Join(Environment.NewLine, getCustomAttributes(source))}
    {getModifer(source)} class {getTextTypeForClass(source)} {Op_Br}
{string.Join(Environment.NewLine, getProperties(source))}
{string.Join(Environment.NewLine, getImplementation(source))}
    {Cl_Br}
    {Cl_Br}
{Cl_Br}
";
        }
    }
}
