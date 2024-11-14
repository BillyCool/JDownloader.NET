namespace JDownloader.Model
{
    public class GenericApiResponse<T> : BaseApiModel
    {
        public T Data { get; set; }

        public object DiffType { get; set; }

        public object DiffId { get; set; }

        public bool IsValidRequest(long requestId) => RequestId == -1 || RequestId == requestId;
    }
}