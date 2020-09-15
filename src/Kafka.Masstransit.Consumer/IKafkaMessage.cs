namespace Kafka.Masstransit.Consumer
{
    public interface IKafkaMessage
    {
        string Text { get; }
    }
}