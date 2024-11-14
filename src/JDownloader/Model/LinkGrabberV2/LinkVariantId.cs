using System.Text.Json.Serialization;

namespace JDownloader.Model
{
    public class LinkVariantId
    {
        [JsonPropertyName("aCodec")]
        public string AudioCodec { get; set; }

        [JsonPropertyName("aBitrate")]
        public int Bitrate { get; set; }

        public int Fps { get; set; }

        public int Height { get; set; }

        public string Projection { get; set; }

        [JsonPropertyName("vCodec")]
        public string VideoCodec { get; set; }

        public int Width { get; set; }
    }
}