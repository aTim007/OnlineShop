using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineShop.RabbitMQ.Producer
{
    public class RabbitMQProducer : IMessage
    {
        private readonly ConfigurationManager _config;
        public RabbitMQProducer(ConfigurationManager config)
        {
            _config = config;
        }

        //todo: product send
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory();
            _config.GetSection("RabbitMQConnection").Bind(factory);
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("at_products", exclusive: false);

            var json = JsonConvert.SerializeObject(message); //JsonContent.Create(message).ToString();
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish("", "products", body: body);
        }
    }
}
