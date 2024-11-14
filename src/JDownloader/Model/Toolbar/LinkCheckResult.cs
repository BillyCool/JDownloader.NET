using System.Collections.Generic;

namespace JDownloader.Model
{
    public class LinkCheckResult
    {
        public List<LinkStatus> Links { get; set; }

        public LinkCheckStatus Status { get; set; }
    }
}