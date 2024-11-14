namespace JDownloader.Model
{
    public class PluginsQuery : GenericApiQuery
    {
        public PluginsQuery(bool includeDetails = true) => IncludeDetails(includeDetails);

        public bool Pattern { get; set; }

        public bool Version { get; set; }
    }
}