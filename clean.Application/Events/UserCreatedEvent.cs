using MediatR;

namespace Demo.Application.Events
{
    public record UserCreatedEvent(Guid UserId) : INotification;
}
