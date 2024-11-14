namespace JDownloader.Model
{
    public class DeviceData
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DeviceStatus Status { get; set; }

        public override string ToString() => $"{Id} - {Name} - {Type} - {Status}";
    }
}