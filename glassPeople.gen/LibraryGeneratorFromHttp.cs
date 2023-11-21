
using System.Net;

namespace glassPeople.gen {
    public class LibraryGeneratorFromHttp : LibraryGeneratorFromMetadata {
        private readonly string webAppAddress;

        public LibraryGeneratorFromHttp(string webAppAddress) {
            this.webAppAddress = webAppAddress;

            using (var wc = new WebClient()) {
                json = wc.DownloadString($@"{this.webAppAddress}/Metadata");
            }
        }

    }

}
