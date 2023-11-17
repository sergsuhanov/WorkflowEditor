// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.ComponentModel;

namespace WorkflowEditor.Win {
    internal static class XamlUtilities {
        private static Hashtable converterCache;
        private static readonly object converterCacheSyncObject = new object();

        public static TypeConverter GetConverter(Type itemType) {
            var converter = TypeDescriptor.GetConverter(itemType);

            if (converter == null || converter.GetType() == typeof(TypeConverter)) {
                // We got an invalid converter.  WPF will do this if the converter
                // is internal, but we use internal converters all over the place
                // at design time.  Detect this and build the converter ourselves.

                if (converterCache != null) {
                    converter = (TypeConverter)converterCache[itemType];
                    if (converter != null) {
                        return converter;
                    }
                }

                var attrs = TypeDescriptor.GetAttributes(itemType);
                if (attrs[typeof(TypeConverterAttribute)] is TypeConverterAttribute tca && tca.ConverterTypeName != null) {
                    var type = Type.GetType(tca.ConverterTypeName);
                    if (type != null && !type.IsPublic && typeof(TypeConverter).IsAssignableFrom(type)) {
                        var ctor = type.GetConstructor(new Type[] { typeof(Type) });
                        converter = ctor != null ? (TypeConverter)ctor.Invoke(new object[] { itemType }) : (TypeConverter)Activator.CreateInstance(type);

                        lock (converterCacheSyncObject) {
                            if (converterCache == null) {
                                converterCache = new Hashtable();

                                // Listen to type changes and clear the cache.
                                // This allows new metadata tables to be installed

                                TypeDescriptor.Refreshed += delegate (RefreshEventArgs args) {
                                    converterCache.Remove(args.TypeChanged);
                                };
                            }

                            converterCache[itemType] = converter;
                        }
                    }
                }
            }

            return converter;
        }
    }
}
