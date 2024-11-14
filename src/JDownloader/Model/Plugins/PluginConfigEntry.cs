using System.Text.Json.Serialization;

namespace JDownloader.Model
{
    public class PluginConfigEntry
    {
        public AbstractType AbstractType { get; set; }

        public object DefaultValue { get; set; }

        [JsonPropertyName("docs")]
        public string Description { get; set; }

        public string EnumLabel { get; set; }

        public string[][] EnumOptions { get; set; }

        public string InterfaceName { get; set; }

        public string Key { get; set; }

        public string Storage { get; set; }

        public string Type { get; set; }

        public object Value { get; set; }
    }
}