using Demo.Domain.Entities;
using Demo.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Queries
{
    public record GetEmployeeByIdQuery(Guid id) : IRequest<Employee>;

    internal class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeByIdQuery,
        Employee>
    {
        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeesByIdAsync(request.id);
        }
    }
}
