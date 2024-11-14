using JDownloader.Model;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class AccountsV2 : BaseNamespace, IAccountsV2
    {
        public override string Endpoint => "accountsV2";

        public AccountsV2(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        #region Account Management

        public async Task<IEnumerable<Account>> ListAccounts(AccountQuery query) =>
            await PostRequestAsync<IEnumerable<Account>>(ApiConstants.AccountsV2.ListAccounts, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public async Task AddAccount(string premiumHosterUrl, string username, string password) =>
            await PostRequestAsync(ApiConstants.AccountsV2.AddAccount, new object[] { premiumHosterUrl, username, password });

        public async Task RemoveAccounts(long[] accountIds) =>
            await PostRequestAsync(ApiConstants.AccountsV2.RemoveAccounts, new object[] { accountIds });

        public async Task RefreshAccounts(long[] accountIds, bool forceRefresh = false) =>
            await PostRequestAsync(ApiConstants.AccountsV2.RefreshAccounts, new object[] { accountIds, forceRefresh });

        public async Task<bool> SetUsernameAndPassword(long accountId, string username, string password) =>
            await PostRequestAsync<bool>(ApiConstants.AccountsV2.SetUsernameAndPassword, new object[] { accountId.ToString(), username, password });

        #endregion

        #region Account State Management

        public async Task EnableAccounts(long[] accountIds) =>
            await PostRequestAsync(ApiConstants.AccountsV2.EnableAccounts, new object[] { accountIds });

        public async Task DisableAccounts(long[] accountIds) =>
            await PostRequestAsync(ApiConstants.AccountsV2.DisableAccounts, new object[] { accountIds });

        #endregion

        #region Premium Hoster Management

        public async Task<string> GetPremiumHosterUrl(string hosterUrl) =>
            await PostRequestAsync<string>(ApiConstants.AccountsV2.GetPremiumHosterUrl, new object[] { hosterUrl });

        public async Task<IEnumerable<string>> ListPremiumHoster() =>
            await PostRequestAsync<IEnumerable<string>>(ApiConstants.AccountsV2.ListPremiumHoster);

        public async Task<Dictionary<string, string>> ListPremiumHosterUrls() =>
            await PostRequestAsync<Dictionary<string, string>>(ApiConstants.AccountsV2.ListPremiumHosterUrls);

        #endregion

        #region Basic Authentication Management

        public async Task<IEnumerable<ListBasicAuthResponse>> ListBasicAuth() =>
            await PostRequestAsync<IEnumerable<ListBasicAuthResponse>>(ApiConstants.AccountsV2.ListBasicAuth);

        public async Task<long> AddBasicAuth(HostType hostType, string hostmask, string username, string password) =>
            await PostRequestAsync<long>(ApiConstants.AccountsV2.AddBasicAuth, new object[] { hostType.ToString(), hostmask, username, password });

        public async Task<bool> UpdateBasicAuth(ListBasicAuthResponse updatedEntry) =>
            await PostRequestAsync<bool>(ApiConstants.AccountsV2.UpdateBasicAuth, new object[] { JsonSerializer.Serialize(updatedEntry, JsonSerializerOptions) });

        public async Task<bool> RemoveBasicAuths(long[] authenticationIds) =>
            await PostRequestAsync<bool>(ApiConstants.AccountsV2.RemoveBasicAuths, new object[] { authenticationIds });

        #endregion
    }
}