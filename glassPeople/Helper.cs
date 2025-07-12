using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace glassPeople {
    public static class Helper {
        public static string PreLoadTemplateData(string xaml) {
            var _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

            if (xaml.StartsWith(_byteOrderMarkUtf8)) {
                xaml = xaml.Remove(0, _byteOrderMarkUtf8.Length);

                if (xaml.StartsWith("<") == false) {
                    xaml = "<" + xaml;
                }
            }

            xaml = xaml.Replace("assembly=glassPeople.ActivityLibrary", "assembly=glassPeople");
            xaml = xaml.Replace("assembly=glassPeople.Model", "assembly=glassPeople");
            xaml = xaml.Replace("assembly=ITAP.glassCAD", "assembly=glassPeople");
            xaml = xaml.Replace("assembly=ITAP.Database", "assembly=glassPeople");

            var doc = new System.Xml.XmlDocument();
            doc.LoadXml(xaml);
            var activityNode = doc?.FirstChild;

            if (activityNode != null) {
                //NamespacesForImplementation
                var namespacesForImplementation = activityNode.ChildNodes.OfType<System.Xml.XmlElement>().FirstOrDefault(p => p.Name.EndsWith("NamespacesForImplementation"))?.FirstChild;
                if (namespacesForImplementation != null) {
                    var childs = namespacesForImplementation?.ChildNodes.OfType<System.Xml.XmlElement>().ToList();
                    if (childs.Count() > 0 && childs.Any(p => p.InnerText == "Microsoft.VisualBasic") == false) {
                        var element = doc.CreateElement("x:String", @"http://schemas.microsoft.com/winfx/2006/xaml");
                        element.InnerText = "Microsoft.VisualBasic";

                        _ = namespacesForImplementation.AppendChild(element);
                        if (namespacesForImplementation.Attributes["Capacity"] != null) {
                            namespacesForImplementation.Attributes["Capacity"].Value = namespacesForImplementation.ChildNodes.Count.ToString();
                        }
                    }
                }

                //ReferencesForImplementation
                var referencesForImplementation = activityNode.ChildNodes.OfType<System.Xml.XmlElement>().FirstOrDefault(p => p.Name.EndsWith("ReferencesForImplementation"))?.FirstChild;
                if (referencesForImplementation != null) {

                    while (referencesForImplementation.ChildNodes.Count > 0) {
                        _ = referencesForImplementation.RemoveChild(referencesForImplementation.ChildNodes[0]);
                    }

                    void add(System.Xml.XmlNode parent, string name) {
                        var element = doc.CreateElement("AssemblyReference", @"http://schemas.microsoft.com/netfx/2009/xaml/activities");
                        element.InnerText = name;
                        _ = parent.AppendChild(element);
                    }

                    add(referencesForImplementation, "Microsoft.VisualBasic");
                    add(referencesForImplementation, "glassPeople");
                    add(referencesForImplementation, "System.Activities");
                    add(referencesForImplementation, "System");
                    add(referencesForImplementation, "System.Xaml");
                    add(referencesForImplementation, "Microsoft.EntityFrameworkCore");
                    //"Microsoft.EntityFrameworkCore.Abstractions"

                    //((System.Xml.XmlElement)referencesForImplementation).SetAttribute("Capacity", "6");
                    if (referencesForImplementation.Attributes["Capacity"] != null) {
                        referencesForImplementation.Attributes["Capacity"].Value = "6";
                    }
                }
            }

            return doc.InnerXml;
        }

        public static IEnumerable<Variable> GetVariables(ActivityBuilder activityBuilder) {

            var activity = activityBuilder.Implementation;
            var varProps = activity.GetType().GetProperty("Variables");
            if (varProps != null)
                return varProps.GetValue(activity, null) as System.Collections.ObjectModel.Collection<Variable>;
            return Enumerable.Empty<Variable>();
        }
    }
}
