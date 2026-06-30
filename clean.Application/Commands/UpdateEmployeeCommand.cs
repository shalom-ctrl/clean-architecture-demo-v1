using Demo.Domain.Entities;
using Demo.Domain.Interface;
using MediatR;

namespace Demo.Application.Commands
{
    public record UpdateEmployeeCommand(Guid id, Employee Employee) : IRequest<Employee>;

    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.UpdateEmployeeAsync(request.id, request.Employee);
        }
    }
}
