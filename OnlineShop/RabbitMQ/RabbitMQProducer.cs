using RabbitMQ.Client;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineShop.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        private readonly ConfigurationManager _config;
        public RabbitMQProducer(ConfigurationManager config)
        {
            _config = config;   
        }
        public void SendProducerMessage<T>(T message)
        {
            var factory = new ConnectionFactory();
            _config.GetSection("RabbitMQConnection").Bind(factory);
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("at_product", exclusive: false, autoDelete: false);
            var json = JsonContent.Create(message).ToString();
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish("", "product", body: body);
        }
    }
}
