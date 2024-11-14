namespace JDownloader.Model
{
    public class SystemInformation
    {
        public bool Arch64Bit { get; set; }

        public string ArchFamily { get; set; }

        public string ArchString { get; set; }

        public long HeapCommitted { get; set; } = -1;

        public long HeapMax { get; set; } = -1;

        public long HeapUsed { get; set; } = -1;

        public bool IsHeadless { get; set; }

        public string JavaName { get; set; }

        public string JavaVendor { get; set; }

        public long JavaVersion { get; set; } = -1;

        public string JavaVersionString { get; set; }

        public bool Jvm64Bit { get; set; }

        public string OperatingSystem { get; set; }

        public bool Os64Bit { get; set; }

        public string OsFamily { get; set; }

        public string OsString { get; set; }

        public long StartupTimeStamp { get; set; } = -1;
    }
}