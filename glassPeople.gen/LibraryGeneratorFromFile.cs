
using System.IO;

namespace glassPeople.gen {
    public class LibraryGeneratorFromFile : LibraryGeneratorFromMetadata {
        private readonly string file;

        public LibraryGeneratorFromFile(string file) {
            this.file = file;
            json = File.ReadAllText(this.file);
        }

    }

}
