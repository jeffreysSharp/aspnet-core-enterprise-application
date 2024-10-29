
using EasyNetQ;
using JSE.Core.Integration;
using Polly;
using RabbitMQ.Client.Exceptions;

namespace JSE.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private IBus _bus;
        private readonly string _connectionString;

        public MessageBus(string connectionString)
        {
            _connectionString = connectionString;
            TryConnect();
        }
        
        public bool IsConnected => _bus?.IsConnected ?? false;
        
        public void Publish<T>(T message) where T : IntegrationEvent
        {
            TryConnect();
            _bus.PubSub.Publish(message);
        }

        public async Task PublishAsync<T>(T message) where T : IntegrationEvent
        {
            TryConnect();
            await _bus.PubSub.PublishAsync(message);
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            TryConnect();
            _bus.PubSub.Subscribe(subscriptionId, onMessage);
        }

        public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            TryConnect();
            _bus.PubSub.SubscribeAsync(subscriptionId, onMessage);
        }

        //TODO
        public TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            // return _bus.Request<TRequest, TResponse>(request);
            throw new NotImplementedException();
        }

        //TODO
        public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            // return await _bus.RequestAsync<TRequest, TResponse>(request);
            throw new NotImplementedException();
        }

        //TODO
        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            // return _bus.Respond(responder);
            throw new NotImplementedException();
        }

        //TODO
        public IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            // return _bus.RespondAsync(responder);
            throw new NotImplementedException();
        }

        private void TryConnect()
        {
            if (IsConnected) return;

            var policy = Policy.Handle<EasyNetQException>()
                .Or<BrokerUnreachableException>().WaitAndRetry(3, retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() => { _bus = RabbitHutch.CreateBus(_connectionString); });
        }

        public void Dispose()
        {
            _bus.Dispose();
        }
    }
}
