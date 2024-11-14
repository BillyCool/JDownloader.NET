namespace JDownloader.Model
{
    public class APIQuery<T>
    {
        public bool Empty { get; set; }

        public T ForNullKey { get; set; }

        public int MaxResults { get; set; }

        public int StartAt { get; set; }
    }
}