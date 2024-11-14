using System.Text.Json.Serialization;

namespace JDownloader.Model
{
    public abstract class BaseApiModel
    {
        [JsonPropertyName("rid")]
        public long RequestId { get; set; }
    }
}