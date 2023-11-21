using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace glassPeople.gen {
    public abstract class LibraryGeneratorFromMetadata {
        protected string json;
        protected Metadata metadata;
        private const string outPath = @"C:\Dev\WorkflowEditor\glassPeople\glassPeople\";

        public LibraryGeneratorFromMetadata() {
        }

        public void Execute() {
            metadata = Newtonsoft.Json.JsonConvert.DeserializeObject<Metadata>(json);


            //Enums
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

            //Classes
            {
                var classesVisiter = new ClassesVisiter();

                var text = new List<string>() {
                };

                metadata.Types.ToList().ForEach(p => {
                    classesVisiter.Visit(p);
                    text.AddRange(classesVisiter.Result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
                });

                File.WriteAllLines(outPath + "Classes.cs", text);

            }

            //Activities
            {
                var activityVisiter = new ActivityVisiter();

                var text = new List<string>() {
                };

                metadata.Activities.ToList().ForEach(p => {
                    activityVisiter.Visit(p);
                    text.AddRange(activityVisiter.Result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
                });

                File.WriteAllLines(outPath + "Activities.cs", text);

            }
        }
    }
}
