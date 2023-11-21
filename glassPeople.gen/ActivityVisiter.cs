
using System;
using System.Collections.Generic;
using System.Linq;

namespace glassPeople.gen {
    internal class ActivityVisiter : ClassesVisiter {
 
        public ActivityVisiter() {
        }

        public new void Visit(LocalType source) {
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
                if (property.Name == "SetMarkingMode") { 
                }

                var get_set = "get;";
                if (property.CanWrite)
                    get_set += " set;";
                properties.Add("\t\t" + $@"public {getTextTypeForProperty(property.Type)} {property.Name} {Op_Br} {get_set} {Cl_Br}");
            }

            var implementation = string.Empty;

            if (source.BaseType.Name.StartsWith("NativeActivity") || 
                source.BaseType.Name.StartsWith("ListActivity") ||
                source.BaseType.Name.StartsWith("AttributesActivity")) {
                implementation = @"
        protected override void Execute(System.Activities.NativeActivityContext context) {
            throw new System.NotImplementedException();
        }";
            }


            if (source.BaseType.Name.StartsWith("CodeActivity")) {
                var filterType = "void";
                if(source.BaseType.GenericTypes?.Any() == true)
                    filterType = getTextTypeForProperty(source.BaseType.GenericTypes.First());

                implementation = $@"
        protected override {filterType} Execute(System.Activities.CodeActivityContext context) {{
            throw new System.NotImplementedException();
        }}";
            }

            if (source.BaseType.Name.StartsWith("FilterActivity")) {
                var filterType = getTextTypeForProperty(source.BaseType.GenericTypes.First());
                implementation = $@"
        protected override System.Collections.Generic.List<{filterType}> Filter(System.Activities.NativeActivityContext context, System.Collections.Generic.IEnumerable<{filterType}> source) {{
            throw new System.NotImplementedException();
        }}

        protected override System.Linq.IQueryable<{filterType}> GetByDefault(System.Activities.NativeActivityContext context) {{
            throw new System.NotImplementedException();
        }}";
            }


            Result = $@"
namespace {source.Namespace} {Op_Br}
    {modifer} class {getTextTypeForClass(source)} {Op_Br}
{string.Join(Environment.NewLine, properties)}
{implementation}
    {Cl_Br}
{Cl_Br}
";
        }
    }
}
