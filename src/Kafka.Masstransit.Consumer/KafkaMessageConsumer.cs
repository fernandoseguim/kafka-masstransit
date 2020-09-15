using System;
using System.Threading.Tasks;
using MassTransit;

namespace Kafka.Masstransit.Consumer
{
    public class KafkaMessageConsumer : IConsumer<IKafkaMessage>
    {
        public async Task Consume(ConsumeContext<IKafkaMessage> context)
        {
            await Console.Out.WriteLineAsync(context.Message.Text);
        }
    }
}