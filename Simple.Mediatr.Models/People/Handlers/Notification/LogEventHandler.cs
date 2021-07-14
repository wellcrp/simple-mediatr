using MediatR;
using Microsoft.Extensions.Logging;
using Simple.Mediatr.Model.People.Notification.People;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Mediatr.Model.People.Handlers.Notification
{
    public class LogEventHandler : INotificationHandler<CreatePeopleNotification>
    {
        private readonly ILogger _logger;
        public LogEventHandler(ILogger<string> logger)
        {
            _logger = logger;
        }
        public Task Handle(CreatePeopleNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation($"Pessoa Adicionado com Sucesso");
            });
        }
    }
}
