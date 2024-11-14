namespace JDownloader.Model
{
    public class ExtensionQuery : GenericApiQuery
    {
        public ExtensionQuery(bool includeDetails = true) => IncludeDetails(includeDetails);

        public ExtensionQuery(string pattern, bool includeDetails = true) : this(includeDetails) => Pattern = pattern;

        public bool ConfigInterface { get; set; }

        public bool Description { get; set; }

        public bool Enabled { get; set; }

        public bool IconKey { get; set; }

        public bool Installed { get; set; }

        public bool Name { get; set; }

        public string Pattern { get; set; }
    }
}