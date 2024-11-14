using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IDialogs
    {
        /// <summary>
        /// Answers a dialog with the specified dialog ID and dialog answer.
        /// </summary>
        /// <param name="dialogId">The ID of the dialog to answer.</param>
        /// <param name="dialogAnswer">The answer to the dialog.</param>
        Task Answer(long dialogId, Dictionary<string, object> dialogAnswer);

        /// <summary>
        /// Retrieves information about a dialog with the specified dialog ID.
        /// </summary>
        /// <param name="dialogId">The ID of the dialog to retrieve information for.</param>
        /// <param name="icon">A flag indicating whether to include the dialog icon in the response.</param>
        /// <param name="properties">A flag indicating whether to include the dialog properties in the response.</param>
        /// <returns>The dialog information.</returns>
        Task<DialogInfo> Get(long dialogId, bool icon, bool properties);

        /// <summary>
        /// Retrieves information about the dialog type with the specified dialog type name.
        /// </summary>
        /// <param name="dialogType">The name of the dialog type to retrieve information for.</param>
        /// <returns>The dialog type information.</returns>
        Task<DialogTypeInfo> GetTypeInfo(string dialogType);

        /// <summary>
        /// Lists all dialog IDs.
        /// </summary>
        /// <returns>An array of dialog IDs.</returns>
        Task<long[]> List();
    }
}
