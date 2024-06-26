﻿
using System;
using System.Activities.Presentation.Hosting;
using System.Activities.Presentation.Model;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.CodeAnalysis;

namespace WorkflowEditor.Win {

    public class RoslynExpressionEditorService : IExpressionEditorService {
        private static MetadataReference[] s_baseAssemblies = new MetadataReference[0];

        public static RoslynExpressionEditorService Instance { get; } = new RoslynExpressionEditorService();

        internal string UsingNamespaces { get; private set; } = string.Empty;

        internal MetadataReference[] BaseAssemblies {
            get { return s_baseAssemblies; }
        }

        public void CloseExpressionEditors() {

        }

        public IExpressionEditorInstance CreateExpressionEditor(AssemblyContextControlItem assemblies, ImportedNamespaceContextItem importedNamespaces, List<ModelItem> variables, string text) {
            return CreateExpressionEditor(assemblies, importedNamespaces, variables, text, null, Size.Empty);
        }

        public IExpressionEditorInstance CreateExpressionEditor(AssemblyContextControlItem assemblies, ImportedNamespaceContextItem importedNamespaces, List<ModelItem> variables, string text, Size initialSize) {
            return CreateExpressionEditor(assemblies, importedNamespaces, variables, text, null, initialSize);
        }

        public IExpressionEditorInstance CreateExpressionEditor(AssemblyContextControlItem assemblies, ImportedNamespaceContextItem importedNamespaces, List<ModelItem> variables, string text, Type expressionType) {
            return CreateExpressionEditor(assemblies, importedNamespaces, variables, text, expressionType, Size.Empty);
        }

        public IExpressionEditorInstance CreateExpressionEditor(AssemblyContextControlItem assemblies, ImportedNamespaceContextItem importedNamespaces, List<ModelItem> variables, string text, Type expressionType, Size initialSize) {
            UpdateContext(assemblies, importedNamespaces);
            var editor = new RoslynExpressionEditorInstance(initialSize);
            editor.UpdateInstance(variables, text);
            return editor;
        }

        public void UpdateContext(AssemblyContextControlItem assemblies, ImportedNamespaceContextItem importedNamespaces) {
            if (s_baseAssemblies.Length != 0) {
                return;
            }

            var references = new List<MetadataReference>();

            var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
            references.Add(mscorlib);

            var model = MetadataReference.CreateFromFile(typeof(glassPeople.Model.Context).Assembly.Location);
            references.Add(model);

            s_baseAssemblies = references.ToArray();
            UsingNamespaces = string.Join("", importedNamespaces.ImportedNamespaces.Select(ns => "using " + ns + ";\n").ToArray());
        }
    }
}
