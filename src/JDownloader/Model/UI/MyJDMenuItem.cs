using System.Collections.Generic;

namespace JDownloader.Model
{
    public class MyJDMenuItem
    {
        public List<MenuStructure> Children { get; set; }

        public string Icon { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public MenuType Type { get; set; }
    }
}