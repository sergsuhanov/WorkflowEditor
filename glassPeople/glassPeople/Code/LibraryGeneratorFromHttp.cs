// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net;

namespace glassPeople.Code {
    public class LibraryGeneratorFromHttp : LibraryGeneratorFromMetadata {
        private readonly string _webAppAddress;

        public LibraryGeneratorFromHttp(string webAppAddress) {
            _webAppAddress = webAppAddress;

            using (var wc = new WebClient()) {
                json = wc.DownloadString($@"{_webAppAddress}/Metadata");
            }
        }

    }

}
