using Hurriyet.Emlak.EventBus.RabbitMq;
using RabbitMQ.Client;
using Serilog;

namespace Template.Firm.Consumer.Infrastructure
{
    public class SimpleRabbitMQPersistentConnection : DefaultRabbitMqPersistentConnection
    {
        public SimpleRabbitMQPersistentConnection(IConnectionFactory connectionFactory, ILogger logger, int retryCount = 5) : base(
            connectionFactory, logger, retryCount)
        {
        }
    }
}