namespace OnlineShop.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendProducerMessage<T>(T message);
    }
}
