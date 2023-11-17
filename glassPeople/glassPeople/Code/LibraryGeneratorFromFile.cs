// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;

namespace glassPeople.Code {
    public class LibraryGeneratorFromFile : LibraryGeneratorFromMetadata {
        private readonly string file;

        public LibraryGeneratorFromFile(string file) {
            this.file = file;
            json = File.ReadAllText(this.file);
        }

    }

}
