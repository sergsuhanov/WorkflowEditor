// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;

namespace glassPeople.Code {
    class EnumVisiter : ILocalTypeVisiter {
        private const char op_Br = '{';
        private const char cl_Br = '}';
        private const string sp = ",";

        public string Result { get; set; }

        public EnumVisiter() {
        }

        public void Visit(LocalType source) {
            Result = string.Empty;

            if ((source?.EnumNames?.Length ?? 0) == 0)
                return;

            Result = $@"
namespace {source.Namespace} {op_Br}
public enum {source.Name} {op_Br}
    {string.Join(sp, source.EnumNames)}
{cl_Br} 
{cl_Br}
";

        }
    }

}
