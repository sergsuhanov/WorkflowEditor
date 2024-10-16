
using System;
using System.Linq;

namespace glassPeople.gen {
    internal class ActivityVisiter : ClassesVisiter {

        public ActivityVisiter() {
        }

        protected string getImplementation(LocalType source) {
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
                if (source.BaseType.GenericTypes?.Any() == true)
                    filterType = getTextTypeForProperty(source.BaseType.GenericTypes.First());

                implementation = $@"
        protected override {filterType} Execute(System.Activities.CodeActivityContext context) {{
            throw new System.NotImplementedException();
        }}";
            }
            if (source.BaseType.Namespace == "glassPeople.ActivityLibrary" && source.BaseType.Name.StartsWith("FilterActivity")) {
                var filterType = getTextTypeForProperty(source.BaseType.GenericTypes.First());
                implementation = $@"
        protected override System.Collections.Generic.List<{filterType}> Filter(System.Activities.NativeActivityContext context, System.Collections.Generic.IEnumerable<{filterType}> source) {{
            throw new System.NotImplementedException();
        }}

        protected override System.Linq.IQueryable<{filterType}> GetByDefault(System.Activities.NativeActivityContext context) {{
            throw new System.NotImplementedException();
        }}";
            }

            return implementation;
        }

        protected string getCasheMetadata(LocalType source) {
            var metadataText = source.Properties
                .Where(p => p.Type.Name.StartsWith("ActivityFunc") || p.Type.Name.StartsWith("ActivityAction"))
                .Select(p => "\t\t\t" + $"metadata.AddDelegate(this.{p.Name});")
                .DefaultIfEmpty<string>(string.Empty)
                .Aggregate((p1, p2) => p1 + Environment.NewLine + p2);

            if (metadataText == string.Empty)
                return string.Empty;

            var implementation = $@"
        protected override void CacheMetadata(System.Activities.NativeActivityMetadata metadata) {{
{metadataText}
            base.CacheMetadata(metadata);
        }}";
            return implementation;
        }

        public new void Visit(LocalType source) {
            Result = $@"
namespace {source.Namespace} {Op_Br}
    {string.Join(Environment.NewLine, getCustomAttributes(source))}
    {getModifer(source)} class {getTextTypeForClass(source)} {Op_Br}
{string.Join(Environment.NewLine, getProperties(source))}
{getCasheMetadata(source)}
{getImplementation(source)}
    {Cl_Br}
{Cl_Br}
";
        }
    }
}
