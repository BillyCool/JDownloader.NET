using JDownloader.Converters;
using System.Text.Json.Serialization;

namespace JDownloader.Model
{
    public class LinkVariant
    {
        public string IconKey { get; set; }

        [JsonPropertyName("id")]
        [JsonConverter(typeof(LinkVariantDetailOrStringConverter))]
        public LinkVariantDetailOrString Id { get; set; }

        public string Name { get; set; }
    }

    public class LinkVariantDetailOrString
    {
        public LinkVariantDetail Detail { get; }

        public string Raw { get; }

        public bool IsString => Raw != null;

        public bool IsObject => Detail != null;

        public LinkVariantDetailOrString(string raw)
        {
            Raw = raw;
        }

        public LinkVariantDetailOrString(LinkVariantDetail detail)
        {
            Detail = detail;
        }

        public override string ToString() => IsString ? Raw : Detail?.Id;

        public static implicit operator string(LinkVariantDetailOrString value) => value?.Raw ?? value?.Detail?.Id;

        public static implicit operator LinkVariantDetail(LinkVariantDetailOrString value) => value?.Detail;
    }
}