using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "10.254.0.70" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "at_hello",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    string message = "Hello";
    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: "",
                         routingKey: "at_hello",
                         basicProperties: null,
                         body: body);
    Console.WriteLine("[x] Sent {0}", message);
}