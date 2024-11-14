using System.Collections.Generic;

namespace JDownloader.Model
{
    public class MenuStructure
    {
        public List<MenuStructure> Childred { get; set; }

        public string Icon { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public MenuType Type { get; set; }
    }
}