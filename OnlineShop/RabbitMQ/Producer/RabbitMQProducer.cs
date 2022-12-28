using Newtonsoft.Json;
using OnlineShop.RabbitMQ.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace OnlineShop.RabbitMQ.Producer
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        //private ConfigurationManager _config;
        private IConfiguration _config;

        public RabbitMQProducer(IConfiguration config)
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

            channel.BasicPublish("", "at_products", body: body);
        }
    }
}
