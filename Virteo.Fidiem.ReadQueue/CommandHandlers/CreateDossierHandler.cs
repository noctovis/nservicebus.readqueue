using NServiceBus;
using NServiceBus.Logging;
using Virteo.Fidiem.IntegrationInfrastructure.Contracts.Commands;

namespace Virteo.Fidiem.ReadQueue.CommandHandlers
{
    public class CreateDossierHandler : IHandleMessages<CreateDossierCommand>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(CreateDossierHandler));

        public void Handle(CreateDossierCommand message)
        {
            _log.InfoFormat($"Read message with dossier {message.DossierData.TypeAbbreviation} from queue");
        }
    }
}