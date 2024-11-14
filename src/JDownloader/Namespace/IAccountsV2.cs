using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IAccountsV2
    {
        #region Account Management

        /// <summary>
        /// Lists all accounts matching the given query.
        /// </summary>
        /// <param name="query">The account query</param>
        /// <returns></returns>
        Task<IEnumerable<Account>> ListAccounts(AccountQuery query);

        /// <summary>
        /// Adds a new account
        /// </summary>
        /// <param name="premiumHosterUrl">The premium hoster URL</param>
        /// <param name="username">The account username/email</param>
        /// <param name="password">The account password</param>
        /// <returns></returns>
        Task AddAccount(string premiumHosterUrl, string username, string password);

        /// <summary>
        /// Removes one or more accounts
        /// </summary>
        /// <param name="accountIds">The IDs of the accounts to remove</param>
        /// <returns></returns>
        Task RemoveAccounts(long[] accountIds);

        /// <summary>
        /// Refreshes one or more accounts
        /// </summary>
        /// <param name="accountIds">The IDs of the accounts to refresh</param>
        /// <param name="forceRefresh">True to force a refresh, otherwise false. When false, recently checked accounts, invalid accounts and expired accoutns are skipped.</param>
        /// <returns></returns>
        Task RefreshAccounts(long[] accountIds, bool forceRefresh = false);

        /// <summary>
        /// Sets the username and password of an account
        /// </summary>
        /// <param name="accountId">The ID of the account to update</param>
        /// <param name="username">The account username/email</param>
        /// <param name="password">The account password</param>
        /// <returns></returns>
        Task<bool> SetUsernameAndPassword(long accountId, string username, string password);

        #endregion

        #region Account State Management

        Task EnableAccounts(long[] accountIds);

        Task DisableAccounts(long[] accountIds);

        #endregion

        #region Premium Hoster Management

        Task<string> GetPremiumHosterUrl(string hosterUrl);

        Task<IEnumerable<string>> ListPremiumHoster();

        Task<Dictionary<string, string>> ListPremiumHosterUrls();

        #endregion

        #region Basic Authentication Management

        Task<IEnumerable<ListBasicAuthResponse>> ListBasicAuth();

        Task<long> AddBasicAuth(HostType hostType, string hostmask, string username, string password);

        Task<bool> UpdateBasicAuth(ListBasicAuthResponse updatedEntry);

        Task<bool> RemoveBasicAuths(long[] authenticationIds);

        #endregion

    }
}
