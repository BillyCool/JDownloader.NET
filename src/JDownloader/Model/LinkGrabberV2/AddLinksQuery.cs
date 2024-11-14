using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JDownloader.Model
{
    public class AddLinksQuery
    {
        public bool? AssignJobID { get; set; }

        public bool? AutoExtract { get; set; }

        [JsonPropertyName("autostart")]
        public bool? AutoStart { get; set; }

        public List<string> DataURLs { get; set; }

        public bool? DeepDecrypt { get; set; }

        public string DestinationFolder { get; set; }

        public string DownloadPassword { get; set; }

        public string ExtractPassword { get; set; }

        public string Links { get; set; }

        public bool? OverwritePackagizerRules { get; set; }

        public string PackageName { get; set; }

        public Priority Priority { get; set; }

        public string SourceUrl { get; set; }
    }
}