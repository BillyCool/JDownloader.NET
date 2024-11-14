using System.Text.Json.Serialization;

namespace JDownloader.Model
{
    public class LinkVariant
    {
        public string IconKey { get; set; }

        [JsonPropertyName("id")]
        public LinkVariantDetail Details { get; set; }

        public string Name { get; set; }
    }
}