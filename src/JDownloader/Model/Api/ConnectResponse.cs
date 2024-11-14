namespace JDownloader.Model
{
    public class ConnectResponse : BaseApiModel
    {
        public string SessionToken { get; set; }

        public string RegainToken { get; set; }
    }
}