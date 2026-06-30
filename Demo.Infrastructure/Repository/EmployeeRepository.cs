using Demo.Domain.Entities;
using Demo.Domain.Interface;
using Demo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repository
{
    public class EmployeeRepository(ApplicationDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeesByIdAsync(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            employee.Id = Guid.NewGuid();

            dbContext.Employees.Add(employee);

            await dbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Guid employeeId, Employee employee)
        {
            var employeeentity = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employeeentity is not null)
            {
                employeeentity.Name = employee.Name;
                employeeentity.Email = employee.Email;
                employeeentity.Phone = employee.Phone;

                await dbContext.SaveChangesAsync();

                return employeeentity;
            }

            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employeeentity = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employeeentity is not null)
            {
                dbContext.Employees.Remove(employeeentity);

                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
