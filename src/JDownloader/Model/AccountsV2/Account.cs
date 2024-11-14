namespace JDownloader.Model
{
    public class Account
    {
        public bool Enabled { get; set; }

        public string ErrorString { get; set; }

        public AccountErrorType ErrorType { get; set; }

        public string Hostname { get; set; }

        public long TrafficLeft { get; set; }

        public long TrafficMax { get; set; }

        public string Username { get; set; }

        public long Uuid { get; set; }

        public bool Valid { get; set; }

        public long ValidUntil { get; set; }
    }
}