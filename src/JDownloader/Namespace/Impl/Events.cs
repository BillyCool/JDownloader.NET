using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Events : BaseNamespace, IEvents
    {
        public override string Endpoint => "events";

        public Events(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<Subscription> Addsubscription(long subscriptionId, string[] subscriptions, string[] exclusions) =>
            PostRequestAsync<Subscription>(ApiConstants.Events.AddSubscription, new object[] { subscriptionId, subscriptions, exclusions });

        public Task<Subscription> ChangeSubscriptionTimeouts(long subscriptionId, long pollTimeout, long maxKeepAlive) =>
            PostRequestAsync<Subscription>(ApiConstants.Events.ChangeSubscriptionTimeouts, new object[] { subscriptionId, pollTimeout, maxKeepAlive });

        public Task<Subscription> GetSubscription(long subscriptionId) =>
            PostRequestAsync<Subscription>(ApiConstants.Events.GetSubscription, new object[] { subscriptionId });

        public Task<SubscriptionStatus> GetSubscriptionStatus(long subscriptionId) =>
            PostRequestAsync<SubscriptionStatus>(ApiConstants.Events.GetSubscriptionStatus, new object[] { subscriptionId });

        public Task Listen(long subscriptionId) =>
            PostRequestAsync<SubscriptionStatus>(ApiConstants.Events.Listen, new object[] { subscriptionId });

        public Task<Publisher> ListPublisher() =>
            PostRequestAsync<Publisher>(ApiConstants.Events.ListPublisher);

        public Task<Subscription> RemoveSubscription(long subscriptionId, string[] subscriptions, string[] exclusions) =>
            PostRequestAsync<Subscription>(ApiConstants.Events.RemoveSubscription, new object[] { subscriptionId, subscriptions, exclusions });

        public Task<Subscription> SetSubscription(long subscriptionId, string[] subscriptions, string[] exclusions) =>
            PostRequestAsync<Subscription>(ApiConstants.Events.SetSubscription, new object[] { subscriptionId, subscriptions, exclusions });

        public Task<Subscription> Subscribe(string[] subscriptions, string[] exclusions) =>
            PostRequestAsync<Subscription>(ApiConstants.Events.Subscribe, new object[] { subscriptions, exclusions });

        public Task<Subscription> Unsubscribe(long subscriptionId) =>
            PostRequestAsync<Subscription>(ApiConstants.Events.Unsubscribe, new object[] { subscriptionId });
    }
}