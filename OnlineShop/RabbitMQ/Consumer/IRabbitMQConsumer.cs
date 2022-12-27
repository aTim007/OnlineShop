namespace OnlineShop.RabbitMQ.Consumer
{
    public interface IRabbitMQConsumer
    {
        public void SendConsumerMessage<T>(T message);
    }
}
