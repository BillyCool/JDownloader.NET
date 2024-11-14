namespace JDownloader.Model
{
    internal class PostRequestArg
    {
        public string Action { get; set; }

        public object Param { get; set; }

        public bool DoubleJsonDecode { get; set; }

        public bool SkipDeserialization { get; set; }
    }
}