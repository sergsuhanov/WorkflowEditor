
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;

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

        protected string[] getCustomAttributes(LocalType source) {
            var result = (source.CustomAttributes ?? Array.Empty<string>()).ToList();

            result.Remove("[System.Runtime.CompilerServices.ExtensionAttribute()]");
            result.Remove("[System.SerializableAttribute()]");
            result.RemoveAll(p => p.Contains("DebuggerDisplayAttribute"));
    
            return result.ToArray();
        }

        protected string[] getCustomAttributes(LocalProperty source) {
            void replace(List<string> data, string testSource, string textDest) {
                if (data.Contains(testSource)) { 
                    data.Remove(testSource);
                    data.Add(textDest);
                }
            }

            var result = (source.CustomAttributes ?? Array.Empty<string>()).ToList();

            result.RemoveAll(p => p.Contains("TupleElementNamesAttribute"));

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
         
            return result.ToArray();
        }


        public void Visit(LocalType source) {
            Result = $@"
namespace {source.Namespace} {Op_Br}
    {string.Join(Environment.NewLine, getCustomAttributes(source))}
    {getModifer(source)} class {getTextTypeForClass(source)} {Op_Br}
{string.Join(Environment.NewLine, getProperties(source))}
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
    {Cl_Br}
    {Cl_Br}
{Cl_Br}
";
        }
    }
}
