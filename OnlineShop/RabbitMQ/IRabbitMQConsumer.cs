namespace OnlineShop.RabbitMQ
{
    public interface IRabbitMQConsumer
    {
        public void SendConsumerMessage<T>(T message);
    }
}
