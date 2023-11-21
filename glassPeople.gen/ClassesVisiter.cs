
using System;
using System.Collections.Generic;
using System.Linq;

namespace glassPeople.gen {
    internal class ClassesVisiter : ILocalTypeVisiter {
        protected const char Op_Br = '{';
        protected const char Cl_Br = '}';

        public string Result { get; set; }

        public ClassesVisiter() {
        }

        protected string getTextTypeForProperty(LocalType localType) {
            if (localType.IsGenericParameter)
                return localType.Name;

            var result = $"{localType.Namespace}.{localType.Name}";

            if (localType.GenericTypes?.Any() == true) {
                result += "<" + string.Join(", ", localType.GenericTypes.Select(p => getTextTypeForProperty(p))) + ">";
            }

            return result;
        }

        protected string getTextTypeForClass(LocalType localType) {
            if (localType.IsGenericParameter)
                return localType.Name;

            var result = localType.Name;

            if (localType.GenericTypes?.Any() == true) {
                result += "<" + string.Join(", ", localType.GenericTypes.Select(p => getTextTypeForProperty(p))) + ">";
            }

            if (localType.BaseType != null) {
                result += " : " + getTextTypeForProperty(localType.BaseType);
            }

            return result;
        }

        public void Visit(LocalType source) {
            Result = string.Empty;

            if ((source?.EnumNames?.Length ?? 0) > 0) {
                return;
            }

            var modifer = "public";
            if (source.IsAbstract) {
                modifer += " abstract";
            }

            var properties = new List<string>();
            foreach (var property in source.Properties ?? Enumerable.Empty<LocalProperty>()) {
                var get_set = "get;";
                if (property.CanWrite)
                    get_set += " set;";
                properties.Add("\t\t" + $@"public {getTextTypeForProperty(property.Type)} {property.Name} {Op_Br} {get_set} {Cl_Br}");
            }

            Result = $@"
namespace {source.Namespace} {Op_Br}
    {modifer} class {getTextTypeForClass(source)} {Op_Br}
{string.Join(Environment.NewLine, properties)}
    {Cl_Br}
{Cl_Br}
";
        }
    }
}
