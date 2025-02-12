
namespace glassPeople.gen {

    public class Metadata {
        public LocalType[] Activities { get; set; }
        public LocalType[] Types { get; set; }
    }

    internal interface ILocalTypeVisiter {
        void Visit(LocalType source);
    }

    public class LocalType {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public bool IsAbstract { get; set; } = false;
        public bool IsGenericParameter { get; set; } = false;
        public LocalType[] GenericTypes { get; set; }
        public LocalType BaseType { get; set; }
        public LocalProperty[] Properties { get; set; }
        public string[] EnumNames { get; set; }
        public LocalType DeclaringType { get; set; }
        public string[] CustomAttributes { get; set; }

        public bool IsEnum => (this?.EnumNames?.Length ?? 0) > 0;
        public bool IsClass => !IsEnum;
        public bool IsNestedClass => IsClass && DeclaringType != null;

        public string FullName => $"{Namespace}.{Name}";
    }

    public class LocalProperty {
        public string Name { get; set; }
        public LocalType Type { get; set; }
        public bool CanWrite { get; set; } = true;
        public bool CanRead { get; set; } = true;
        public string[] CustomAttributes { get; set; }
    }
}
