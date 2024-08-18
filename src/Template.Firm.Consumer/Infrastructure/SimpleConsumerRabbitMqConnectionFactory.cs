using Template.Firm.Consumer.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Template.Firm.Consumer.Infrastructure
{
    public class SimpleConsumerRabbitMqConnectionFactory : ConnectionFactory
    {
        public SimpleConsumerRabbitMqConnectionFactory(IOptions<EventBusConnectionConfig> eventBusConfig)
        {
            var busConfig = eventBusConfig.Value;
            HostName = busConfig.ConnectionString;
            UserName = busConfig.UserName;
            Password = busConfig.Password;
            Port = busConfig.Port;
        }
    }
}