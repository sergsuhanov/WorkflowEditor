// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace glassPeople.Code {
    public abstract class LibraryGeneratorFromMetadata {
        protected string json;
        protected Metadata metadata;
        private const string outPath = @"C:\Dev\WorkflowEditor\glassPeople\glassPeople\";

        public LibraryGeneratorFromMetadata() {
        }

        public void Execute() {
            metadata = Newtonsoft.Json.JsonConvert.DeserializeObject<Metadata>(json);

            {
                var enumVisiter = new EnumVisiter();

                var text = new List<string>() {
                };

                metadata.Types.ToList().ForEach(p => {
                    enumVisiter.Visit(p);
                    text.AddRange(enumVisiter.Result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
                });

                File.WriteAllLines(outPath + "Enums.cs", text);
            }

            {
                var text = new List<string>() {
                    "using System;",
                    "using System.Collections.Generic;",
                    "using System.Linq;",
                    "using System.Text;",
                    "using System.Threading.Tasks;"
                };
            }
        }
    }
}
