using System.Text.Json.Serialization;

namespace JDownloader.Model
{
    public class AccountQuery : GenericApiQuery
    {
        public AccountQuery(bool includeDetails = true) => IncludeDetails(includeDetails);

        public AccountQuery(long[] uuidList, bool includeDetails = true) : this(includeDetails) => UuidList = uuidList;

        public bool Enabled { get; set; }

        public bool Error { get; set; }

        public bool TrafficLeft { get; set; }

        public bool TrafficMax { get; set; }

        public bool UserName { get; set; }

        [JsonPropertyName("uuidlist")]
        public long[] UuidList { get; set; }

        public bool Valid { get; set; }

        public bool ValidUntil { get; set; }
    }
}