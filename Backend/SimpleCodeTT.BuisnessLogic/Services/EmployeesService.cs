using Microsoft.EntityFrameworkCore;
using SimpleCodeTT.Contracts;
using SimpleCodeTT.Contracts.Models;
using SimpleCodeTT.DataAccess;
using SimpleCodeTT.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeTT.BusinessLogic.Services
{
    /// <summary>
    /// Сервис для работы с информацией о сотрудниках
    /// </summary>
    public class EmployeesService : IEmployeesService
    {
        private readonly ApplicationDbContext context;

        public EmployeesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ResultResponse<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            try
            {
                var employees = await context.Employees.ToListAsync();
                var employeesDto = employees.Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Birthday = x.Birthday,
                    Salary = x.Salary,
                    LastModifiedDate = x.LastModifiedDate
                });

                return ResultResponse<IEnumerable<EmployeeDto>>.GetSuccessResponse(employeesDto);
            }
            catch (Exception e)
            {
                // TODO: Add logging
                return ResultResponse<IEnumerable<EmployeeDto>>.GetFailResponse();
            }
        }

        public async Task<ResultResponse<bool>> AddEmployee(EmployeeDto employee)
        {
            try
            {
                var employeeEntity = new Employee
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Birthday = employee.Birthday,
                    Salary = employee.Salary,
                    // TODO: workaround
                    LastModifiedDate = DateTime.UtcNow
                };
                var result = context.Add(employeeEntity);
                await context.SaveChangesAsync();

                return ResultResponse<bool>.GetSuccessResponse();
            }
            catch (Exception e)
            {
                // TODO: Add logging
                return ResultResponse<bool>.GetFailResponse();
            }
        }

        public async Task<ResultResponse<int>> UpdateEmployee(int employeeId, EmployeeDto employeeDto)
        {
            try
            {
                var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

                employee.Name = employeeDto.Name;
                employee.Email = employeeDto.Email;
                employee.Birthday = employeeDto.Birthday;
                employee.Salary = employeeDto.Salary;
                // TODO: workaround
                employee.LastModifiedDate = DateTime.UtcNow;

                await context.SaveChangesAsync();

                return ResultResponse<int>.GetSuccessResponse(employee.Id);
            }
            catch (Exception e)
            {
                // TODO: Add logging
                return ResultResponse<int>.GetFailResponse();
            }
        }

        public async Task<ResultResponse<int>> DeleteEmployee(int employeeId)
        {
            try
            {
                var employee = await context.Employees.FirstAsync(x => x.Id == employeeId);
                context.Employees.Remove(employee);

                await context.SaveChangesAsync();

                return ResultResponse<int>.GetSuccessResponse(employeeId);
            }
            catch (Exception e)
            {
                // TODO: Add logging
                return ResultResponse<int>.GetFailResponse();
            }
        }
    }
}
