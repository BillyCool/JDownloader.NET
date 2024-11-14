using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JDownloader.Model
{
    public class DeviceList : BaseApiModel
    {
        [JsonPropertyName("list")]
        public List<DeviceData> Devices { get; set; }
    }
}