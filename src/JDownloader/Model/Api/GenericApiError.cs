using System.Text.Json.Serialization;

namespace JDownloader.Model
{
    public class GenericApiError
    {
        public string Type { get; set; }

        public object Data { get; set; }

        [JsonPropertyName("src")]
        public ErrorSource Source { get; set; }

        public override string ToString() => $"Source: {Source} | Type: {Type} | Data: {Data ?? "<null>"}";
    }
}