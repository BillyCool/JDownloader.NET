using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IUI
    {
        /// <summary>
        /// Gets the menu for the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The menu item for MyJDownloader.</returns>
        Task<MyJDMenuItem> GetMenu(Context context);

        /// <summary>
        /// Invokes an action for the specified context, ID, link IDs, and package IDs.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The ID of the action.</param>
        /// <param name="linkIds">The IDs of the links.</param>
        /// <param name="packageIds">The IDs of the packages.</param>
        /// <returns>The result of the action invocation.</returns>
        Task<object> InvokeAction(Context context, string id, long[] linkIds, long[] packageIds);
    }
}