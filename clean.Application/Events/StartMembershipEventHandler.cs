using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Events
{
    public class StartMembershipEventHandler
     (ILogger<StartMembershipEventHandler> logger)
     : INotificationHandler<UserCreatedEvent>
    {
        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("User created: membership start {UserId}", notification.UserId);

            await Task.Delay(2000, cancellationToken);

            logger.LogInformation("User created: membership {UserId}", notification.UserId);
        }
    }
}
