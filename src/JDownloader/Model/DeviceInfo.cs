namespace JDownloader.Model
{
    internal class DeviceInfo
    {
        public string DeviceId { get; set; }

        public string IP { get; set; }

        public int? Port { get; set; }

        public bool AutoFallback { get; set; }

        public bool HasDirectConnectionInfo => !string.IsNullOrEmpty(IP) && Port.HasValue;

        public string DirectConnectionUrl => $"http://{IP}:{Port}";
    }
}
