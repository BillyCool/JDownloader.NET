namespace JDownloader.Model
{
    public class AdvancedConfigQuery : GenericApiQuery
    {
        public AdvancedConfigQuery(bool includeDetails = true) => IncludeDetails(includeDetails);

        public string ConfigInterface { get; set; }

        public bool DefaultValues { get; set; }

        public bool Description { get; set; }

        public bool EnumInfo { get; set; }

        public bool IncludeExtensions { get; set; }

        public string Pattern { get; set; }

        public bool Values { get; set; }
    }
}