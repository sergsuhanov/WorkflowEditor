namespace glassPeople.gen {
    internal class Program {
        private static void Main(string[] args) {
            if (args.Length == 0) {
                return;
            }

            LibraryGeneratorFromMetadata generator = null;

            if (args[0].Contains(".json")) {
                generator = new LibraryGeneratorFromFile(args[0]);
            }

            if (args[0].Contains("http")) {
                generator = new LibraryGeneratorFromHttp(args[0]);
            }

            generator.Execute();
        }
    }
}
