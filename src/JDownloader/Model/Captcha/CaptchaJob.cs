namespace JDownloader.Model
{
    public class CaptchaJob
    {
        public string CaptchaCategory { get; set; }

        public long Created { get; set; }

        public string Explain { get; set; }

        public string Hoster { get; set; }

        public long Id { get; set; }

        public long Link { get; set; }

        public int Remaining { get; set; }

        public int Timeout { get; set; }

        public string Type { get; set; }
    }
}