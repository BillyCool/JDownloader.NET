namespace JDownloader.Model
{
    internal class GetRequestArg
    {
        public string Action { get; set; }

        public byte[] Key { get; set; }

        public GetRequestArg(string action, byte[] key)
        {
            Action = action;
            Key = key;
        }
    }
}