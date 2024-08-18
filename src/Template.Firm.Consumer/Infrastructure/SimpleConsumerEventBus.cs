using System.Diagnostics.CodeAnalysis;
using Hurriyet.Emlak.EventBus.RabbitMq;
using Hurriyet.Emlak.EventBus.RabbitMq.Settings;
using Microsoft.Extensions.Options;
using Serilog;

namespace Template.Firm.Consumer.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class SimpleConsumerEventBus : EventBusRabbitMq
    {
        public SimpleConsumerEventBus(IRabbitMQPersistentConnection persistentConnection, IOptions<RabbitMqSettings>  settings, ILogger logger) :
            base(persistentConnection, settings.Value, logger)
        {
        }
    }
}