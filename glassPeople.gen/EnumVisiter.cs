
namespace glassPeople.gen {
    internal class EnumVisiter : ILocalTypeVisiter {
        private const char Op_Br = '{';
        private const char Cl_Br = '}';
        private const string Sp = ", ";

        public string Result { get; set; }

        public EnumVisiter() {
        }

        public void Visit(LocalType source) {
            Result = string.Empty;

            if ((source?.EnumNames?.Length ?? 0) == 0) {
                return;
            }

            Result = $@"
namespace {source.Namespace} {Op_Br}
    public enum {source.Name} {Op_Br}
        {string.Join(Sp, source.EnumNames)}
    {Cl_Br}
{Cl_Br}
";
        }
    }
}
