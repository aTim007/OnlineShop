namespace OnlineShop.RabbitMQ.Interfaces
{
    public interface IRabbitMQProducer
    {
        public void SendMessage<T>(T message);
    }
}
