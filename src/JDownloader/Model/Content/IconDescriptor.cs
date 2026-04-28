using System.Collections.Generic;

namespace JDownloader.Model
{
    public class IconDescriptor
    {
        public string Cls { get; set; }

        public string Key { get; set; }

        public Dictionary<string, object> Prps { get; set; }

        public List<IconDescriptor> Rsc { get; set; }
    }
}
