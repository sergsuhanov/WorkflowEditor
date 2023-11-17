using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glassPeople.gen {
    internal class Program {
        static void Main(string[] args) {
            if (args.Length == 0)
                return;

            Code.LibraryGeneratorFromMetadata generator = null;

            if (args[0].Contains(".json"))
                generator = new glassPeople.Code.LibraryGeneratorFromFile(args[0]);
            if (args[0].Contains("http"))
                generator = new glassPeople.Code.LibraryGeneratorFromHttp(args[0]);

            generator.Execute();

        }
    }
}
