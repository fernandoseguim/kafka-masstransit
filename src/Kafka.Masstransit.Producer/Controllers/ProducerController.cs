using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Mvc;

namespace Kafka.Masstransit.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly ITopicProducer<IKafkaMessage> _producer;

        public ProducerController(ITopicProducer<IKafkaMessage> producer)
        {
            _producer = producer;
        }

        [HttpPost]
        public IActionResult Get([FromBody] KafkaMessage message)
        {
            _producer.Produce(message);
            return Ok();
        }
    }
}