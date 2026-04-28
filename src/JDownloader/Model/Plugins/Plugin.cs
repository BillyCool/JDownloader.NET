namespace JDownloader.Model
{
    public class Plugin : AdvancedConfigAPIEntry
    {
        public string ClassName { get; set; }

        public string ConfigInterface { get; set; }

        public string DisplayName { get; set; }

        public string Pattern { get; set; }

        public string Version { get; set; }
    }
}
