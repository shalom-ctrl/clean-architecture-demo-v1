using Demo.Application.Events;
using Demo.Domain.Entities;
using Demo.Domain.Interface;
using MediatR;

namespace Demo.Application.Commands
{
    public record AddEmployeeCommand(Employee Employee) : IRequest<Employee>;

    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, IPublisher mediator)
        : IRequestHandler<AddEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
           var user = await employeeRepository.AddEmployeeAsync(request.Employee);
            await mediator.Publish(new UserCreatedEvent(user.Id));
           return user;
        }
    }
}
