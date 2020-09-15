using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kafka.Masstransit.Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(bus =>
                    {
                        bus.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));

                        bus.AddRider(rider =>
                        {
                            rider.AddConsumer<KafkaMessageConsumer>();

                            rider.UsingKafka((context, kafka) =>
                            {
                                kafka.Host("localhost:9092");

                                kafka.TopicEndpoint<IKafkaMessage>("topic-name", "consumer-group-name",
                                    e => { e.ConfigureConsumer<KafkaMessageConsumer>(context); });
                            });
                        });
                    });

                    services.AddMassTransitHostedService();
                });
    }
}