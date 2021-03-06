using System;
using System.Collections.Generic;
using Improbable.Gdk.Core;

namespace Improbable.Gdk.Subscriptions
{
    // todo this should probably be an interface to be able to remove reflection via baking
    // or to reduce allocation on monobehaviours
    public class RequiredSubscriptionsInjector
    {
        private readonly SubscriptionAggregate subscriptions;
        private readonly RequiredSubscriptionsInfo info;
        private readonly object target;

        private readonly Action onEnable;
        private readonly Action onDisable;

        // todo should either special case monobehaviours or not use callbacks
        // for non monobehaviours we could use functors
        public RequiredSubscriptionsInjector(object target, EntityId entityId, SubscriptionSystem subscriptionSystem,
            Action onEnable = null, Action onDisable = null)
        {
            this.target = target;
            this.onEnable = onEnable;
            this.onDisable = onDisable;

            info = RequiredSubscriptionsDatabase.GetOrCreateRequiredSubscriptionsInfo(target.GetType());

            if (info == null || info.RequiredTypes.Length == 0)
            {
                onEnable?.Invoke();
                return;
            }

            subscriptions = subscriptionSystem.Subscribe(entityId, info.RequiredTypes);
            subscriptions.SetAvailabilityHandler(Handler.Pool.Rent(this));
        }

        // todo the disposal pattern for this is currently awful and needs to be improved
        public void CancelSubscriptions()
        {
            if (subscriptions == null)
            {
                onDisable?.Invoke();
                return;
            }

            Handler.Pool.Return((Handler) subscriptions.GetAvailabilityHandler());
            subscriptions.Cancel();

            onDisable?.Invoke();

            if (target == null)
            {
                return;
            }

            foreach (var field in info.RequiredFields)
            {
                if (!field.FieldType.IsValueType)
                {
                    field.SetValue(target, null);
                }
            }
        }

        private void HandleSubscriptionsSatisfied()
        {
            foreach (var field in info.RequiredFields)
            {
                field.SetValue(target, subscriptions.GetErasedValue(field.FieldType));
            }

            onEnable?.Invoke();
        }

        private void HandleSubscriptionsNoLongerSatisfied()
        {
            onDisable?.Invoke();
        }

        private class Handler : ISubscriptionAvailabilityHandler
        {
            private RequiredSubscriptionsInjector injector;

            public void OnAvailable()
            {
                if (injector == null)
                {
                    throw new InvalidOperationException("Not a valid subscription");
                }

                injector.HandleSubscriptionsSatisfied();
            }

            public void OnUnavailable()
            {
                if (injector == null)
                {
                    throw new InvalidOperationException("Not a valid subscription");
                }

                injector.HandleSubscriptionsNoLongerSatisfied();
            }

            public static class Pool
            {
                private static readonly Stack<Handler> HandlerPool = new Stack<Handler>();

                public static Handler Rent(RequiredSubscriptionsInjector injector)
                {
                    var handler = HandlerPool.Count == 0
                        ? new Handler()
                        : HandlerPool.Pop();

                    handler.injector = injector;
                    return handler;
                }

                public static void Return(Handler handler)
                {
                    // todo this should be bounded
                    handler.injector = null;
                    HandlerPool.Push(handler);
                }
            }
        }
    }
}
