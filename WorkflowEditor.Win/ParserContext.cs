// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Activities;
using System.Activities.Presentation;
using System.Activities.Presentation.Hosting;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;
using System.Xaml;

namespace WorkflowEditor.Win {
    internal class ParserContext : LocationReferenceEnvironment, IValueSerializerContext, IXamlNameResolver, INamespacePrefixLookup, IXamlNamespaceResolver {
        private ModelItem _baseModelItem;
        private EditingContext _context;
        private IDictionary<string, string> _namespaceLookup;

        public ParserContext() {
        }

        public ParserContext(ModelItem modelItem) {
            _ = Initialize(modelItem);
        }

        public IContainer Container {
            get { return null; }
        }

        public object Instance {
            get;
            internal set;
        }

        public PropertyDescriptor PropertyDescriptor {
            get;
            internal set;
        }

        public override Activity Root {
            get { return null; }
        }

        private IDictionary<string, string> NamespaceLookup {
            get {
                if (_namespaceLookup == null) {
                    _namespaceLookup = new Dictionary<string, string>();
                }
                return _namespaceLookup;
            }
        }

        public bool Initialize(ModelItem modelItem) {
            _baseModelItem = modelItem;
            if (null != modelItem) {
                _context = modelItem.GetEditingContext();
            }
            return null != _baseModelItem;
        }

        public override bool IsVisible(LocationReference reference) {
            var other = Resolve(reference.Name);

            return object.ReferenceEquals(other, reference);
        }

        public override bool TryGetLocationReference(string name, out LocationReference result) {
            result = (LocationReference)Resolve(name);
            return result != null;
        }

        public string GetNamespace(string prefix) {
            var nameSpace = NamespaceLookup
                .Where(p => string.Equals(p.Value, prefix))
                .Select(p => p.Key)
                .FirstOrDefault();

            return nameSpace;
        }

        public IEnumerable<NamespaceDeclaration> GetNamespacePrefixes() {
            var namespacePrefixes = new List<NamespaceDeclaration>();
            LoadNameSpace(namespacePrefixes);
            return namespacePrefixes;
        }

        public override IEnumerable<LocationReference> GetLocationReferences() {
            var toReturn = new List<LocationReference>();
            if (_baseModelItem != null) {
                var declaredVariables = CSharpExpressionHelper.GetVariablesInScope(_baseModelItem);

                foreach (var modelItem in declaredVariables) {
                    toReturn.Add(modelItem.GetCurrentValue() as LocationReference);
                }
            }
            return toReturn;
        }

        public object Resolve(string name) {
            var variables = GetLocationReferences();
            return variables.FirstOrDefault<LocationReference>(p => {
                return p != null && p.Name != null && p.Name.Equals(name);
            });
        }

        public object Resolve(string name, out bool isFullyInitialized) {
            var result = Resolve(name);
            isFullyInitialized = result != null;
            return result;
        }

        public bool IsFixupTokenAvailable {
            get {

                return false;
            }
        }

        internal IEnumerable<string> Namespaces {
            get {
                var namespacesToReturn = new HashSet<string>();

                //with custom ones, defined in user provided assemblies
                if (null != _namespaceLookup) {
                    foreach (var nameSpace in _namespaceLookup.Keys) {
                        //out of full namespace declaration (i.e. "clr-namespace:<namespace>;assembly=<assembly>"
                        //get clear namespace name
                        var startIndex = nameSpace.IndexOf(":", StringComparison.Ordinal);
                        var endIndex = nameSpace.IndexOf(";", StringComparison.Ordinal);
                        if (startIndex >= 0 && endIndex >= 0) {
                            var clrNamespace = nameSpace.Substring(startIndex + 1, endIndex - startIndex - 1);
                            _ = namespacesToReturn.Add(clrNamespace);
                        }
                    }
                }

                var importedNamespaces = _context.Items.GetValue<ImportedNamespaceContextItem>();
                namespacesToReturn.UnionWith(importedNamespaces.ImportedNamespaces);
                //return all namespaces
                return namespacesToReturn;
            }
        }

        public object GetFixupToken(IEnumerable<string> names) {
            return null;
        }

        public object GetFixupToken(IEnumerable<string> names, bool canAssignDirectly) {
            return null;
        }

        public object GetService(Type serviceType) {
            return serviceType == typeof(IXamlNameResolver)
                || serviceType == typeof(INamespacePrefixLookup)
                || serviceType == typeof(IXamlNamespaceResolver)
                ? this
                : (object)null;
        }

        public ValueSerializer GetValueSerializerFor(Type type) {
            return null;
        }

        public ValueSerializer GetValueSerializerFor(PropertyDescriptor descriptor) {
            return null;
        }

        public string LookupPrefix(string ns) {
            //get reference to namespace lookup dictionary (create one if necessary)
            var lookupTable = NamespaceLookup;
            //check if given namespace is already registered
            if (!lookupTable.TryGetValue(ns, out var prefix)) {
                //no, create a unique prefix
                prefix = string.Format(CultureInfo.InvariantCulture, "__{0}", Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5));
                //and store value in the dictionary
                lookupTable[ns] = prefix;
            }
            //return prefix
            return prefix;
        }

        public void OnComponentChanged() {
            throw new NotSupportedException("Not Supported");
        }

        public bool OnComponentChanging() {
            throw new NotSupportedException("Not Supported");
        }

        private void LoadNameSpace(List<NamespaceDeclaration> result) {
            if (null == _context) {
                //Fx.Assert("EditingContext is null");
                return;
            }
            var assemblyContext = _context.Items.GetValue<AssemblyContextControlItem>();
            if (null == assemblyContext) {
                //Fx.Assert("AssemblyContextControlItem not defined in EditingContext.Items");
                return;
            }
            if (null != assemblyContext.LocalAssemblyName) {
                result.Add(GetEntry(assemblyContext.LocalAssemblyName));
            }
            if (null != assemblyContext.ReferencedAssemblyNames) {
                foreach (var name in assemblyContext.ReferencedAssemblyNames) {
                    result.Add(GetEntry(name));
                }
            }
        }

        private NamespaceDeclaration GetEntry(AssemblyName name) {
            var ns =
                string.Format(CultureInfo.InvariantCulture, "clr-namespace:{0};assembly={1}",
                Guid.NewGuid().ToString().Replace('-', '_'), name.Name);
            return new NamespaceDeclaration(ns, Guid.NewGuid().ToString());
        }

        IEnumerable<KeyValuePair<string, object>> IXamlNameResolver.GetAllNamesAndValuesInScope() {
            return null;
        }

        event EventHandler IXamlNameResolver.OnNameScopeInitializationComplete {
            add { }
            remove { }
        }
    }
}
