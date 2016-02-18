using NServiceBus;

namespace Virteo.Fidiem.ReadQueue
{
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration cfg)
        {
            // Unobstrusive mode
            ConventionsBuilder conventions = cfg.Conventions();
            conventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith("Commands"));
            conventions.DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith("Events"));
            conventions.DefiningMessagesAs(t => t.Namespace != null && t.Namespace.EndsWith("Messages"));

            // Choose assemblies to scan
            IIncludesBuilder includesBuilder = AllAssemblies
                .Matching("NServiceBus")
                .And("Virteo.Fidiem.IntegrationInfrastructure.")
                .And("Virteo.Fidiem.ReadQueue");
            cfg.AssembliesToScan(includesBuilder);

            cfg.EndpointName("Virteo.Fidiem.NServiceBus");

            cfg.UseTransport<AzureServiceBusTransport>();
            cfg.UsePersistence<InMemoryPersistence>();
            cfg.ScaleOut().UseSingleBrokerQueue();
        }
    }
}