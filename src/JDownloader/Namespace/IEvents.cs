using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IEvents
    {
        /// <summary>
        /// Adds a subscription with the specified subscription ID, subscriptions, and exclusions.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription.</param>
        /// <param name="subscriptions">The subscriptions to add.</param>
        /// <param name="exclusions">The exclusions.</param>
        /// <returns>The added subscription.</returns>
        Task<Subscription> Addsubscription(long subscriptionId, string[] subscriptions, string[] exclusions);

        /// <summary>
        /// Changes the timeouts for a subscription with the specified subscription ID.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription.</param>
        /// <param name="pollTimeout">The new poll timeout value.</param>
        /// <param name="maxKeepAlive">The new max keep alive value.</param>
        /// <returns>The updated subscription.</returns>
        Task<Subscription> ChangeSubscriptionTimeouts(long subscriptionId, long pollTimeout, long maxKeepAlive);

        /// <summary>
        /// Gets the subscription with the specified subscription ID.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription.</param>
        /// <returns>The retrieved subscription.</returns>
        Task<Subscription> GetSubscription(long subscriptionId);

        /// <summary>
        /// Gets the status of the subscription with the specified subscription ID.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription.</param>
        /// <returns>The status of the subscription.</returns>
        Task<SubscriptionStatus> GetSubscriptionStatus(long subscriptionId);

        /// <summary>
        /// Listens for events on the subscription with the specified subscription ID.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription.</param>
        Task Listen(long subscriptionId);

        /// <summary>
        /// Lists all publishers.
        /// </summary>
        /// <returns>The list of publishers.</returns>
        Task<Publisher> ListPublisher();

        /// <summary>
        /// Removes a subscription with the specified subscription ID, subscriptions, and exclusions.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription.</param>
        /// <param name="subscriptions">The subscriptions to remove.</param>
        /// <param name="exclusions">The exclusions.</param>
        /// <returns>The removed subscription.</returns>
        Task<Subscription> RemoveSubscription(long subscriptionId, string[] subscriptions, string[] exclusions);

        /// <summary>
        /// Sets a subscription with the specified subscription ID, subscriptions, and exclusions.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription.</param>
        /// <param name="subscriptions">The subscriptions to set.</param>
        /// <param name="exclusions">The exclusions.</param>
        /// <returns>The set subscription.</returns>
        Task<Subscription> SetSubscription(long subscriptionId, string[] subscriptions, string[] exclusions);

        /// <summary>
        /// Subscribes to events with the specified subscriptions and exclusions.
        /// </summary>
        /// <param name="subscriptions">The subscriptions to subscribe to.</param>
        /// <param name="exclusions">The exclusions to subscribe to.</param>
        /// <returns>The subscribed subscription.</returns>
        Task<Subscription> Subscribe(string[] subscriptions, string[] exclusions);

        /// <summary>
        /// Unsubscribes from the subscription with the specified subscription ID.
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription.</param>
        /// <returns>The unsubscribed subscription.</returns>
        Task<Subscription> Unsubscribe(long subscriptionId);
    }
}
