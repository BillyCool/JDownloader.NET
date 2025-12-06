using JDownloader.Model;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JDownloader.Converters
{
    public class LinkVariantDetailOrStringConverter : JsonConverter<LinkVariantDetailOrString>
    {
        public override LinkVariantDetailOrString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    var stringValue = reader.GetString();
                    return new LinkVariantDetailOrString(stringValue);
                }

                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var jsoNValue = JsonSerializer.Deserialize<LinkVariantDetail>(ref reader, options);
                    return new LinkVariantDetailOrString(jsoNValue);
                }

                if (reader.TokenType == JsonTokenType.Null)
                {
                    return null;
                }
            }
            catch
            {
                // Fall through to fallback
            }

            // Fallback: Capture raw JSON as string
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                return new LinkVariantDetailOrString(doc.RootElement.GetRawText());
            }
        }

        public override void Write(Utf8JsonWriter writer, LinkVariantDetailOrString value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            if (value.IsString)
            {
                writer.WriteStringValue(value.Raw);
                return;
            }

            JsonSerializer.Serialize(writer, value.Detail, options);
        }
    }
}
