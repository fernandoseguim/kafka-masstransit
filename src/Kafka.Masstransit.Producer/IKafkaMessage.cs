namespace Kafka.Masstransit.Producer
{
    public interface IKafkaMessage
    {
        string Text { get; }
    }

    public class KafkaMessage : IKafkaMessage
    {
        public string Text { get; set; }
    }
}