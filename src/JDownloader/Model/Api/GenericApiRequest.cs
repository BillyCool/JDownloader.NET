namespace JDownloader.Model
{
    public class GenericApiRequest : BaseApiModel
    {
        public string Url { get; set; }

        public object Params { get; set; }

        public int ApiVer { get; } = ApiConstants.API_VERSION;
    }
}