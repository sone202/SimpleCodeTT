using SimpleCodeTT.Contracts;
using SimpleCodeTT.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeTT.BusinessLogic.Services
{
    /// <summary>
    /// Сервис для работы с информацией о сотрудниках
    /// </summary>
    public interface IEmployeesService
    {
        Task<ResultResponse<IEnumerable<EmployeeDto>>> GetEmployees();
        Task<ResultResponse<bool>> AddEmployee(EmployeeDto employee);
        Task<ResultResponse<int>> UpdateEmployee(int employeeId, EmployeeDto employee);
        Task<ResultResponse<int>> DeleteEmployee(int employeeId);
    }
}
