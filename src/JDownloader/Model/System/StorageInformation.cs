namespace JDownloader.Model
{
    public class StorageInformation
    {
        public string Error { get; set; }

        public long Free { get; set; } = -1;

        public string Path { get; set; }

        public long Size { get; set; } = -1;
    }
}
