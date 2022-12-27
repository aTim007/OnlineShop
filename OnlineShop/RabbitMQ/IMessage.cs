namespace OnlineShop.RabbitMQ
{
    public interface IMessage
    {
        public void SendMessage<T>(T message);
    }
}
