// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glassPeople.Code {

    public class Metadata {
        public LocalType[] Activities { get; set; }
        public LocalType[] Types { get; set; }
    }

    interface ILocalTypeVisiter {
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
    }

    public class LocalProperty {
        public string Name { get; set; }
        public LocalType Type { get; set; }
        public bool CanWrite { get; set; } = true;
        public bool CanRead { get; set; } = true;
    }

}
