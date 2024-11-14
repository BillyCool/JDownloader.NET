using System.Collections.Generic;

namespace JDownloader.Model
{
    /// <summary>
    /// Click 'n' Load query
    /// </summary>
    public class CnlQuery
    {
        public string Comment { get; set; }

        public string Crypted { get; set; }

        public string Dir { get; set; }

        public string Jk { get; set; }

        public string Key { get; set; }

        public string OrgReferrer { get; set; }

        public string OrgSource { get; set; }

        public string PackageName { get; set; }

        public List<string> Passwords { get; set; }

        public bool Permission { get; set; }

        public string Referrer { get; set; }

        public string Source { get; set; }

        public string Urls { get; set; }
    }
}