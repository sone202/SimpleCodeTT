using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCodeTT.BusinessLogic.Services;
using SimpleCodeTT.Contracts;
using SimpleCodeTT.Contracts.Models;
using SimpleCodeTT.DataAccess;
using SimpleCodeTT.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCodeTT.Controllers
{
    /// <summary>
    /// Контроллер для работы с сотрудниками
    /// </summary>
    [Route("api/employees")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService employeeService;

        public EmployeeController(IEmployeesService service)
        {
            employeeService = service;
        }

        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultResponse<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            return await employeeService.GetEmployees();
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultResponse<bool>> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            return await employeeService.AddEmployee(employeeDto);
        }

        /// <summary>
        /// Обновление информации о сторуднике
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id}")]
        public async Task<ResultResponse<int>> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            return await employeeService.UpdateEmployee(id, employeeDto);
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResultResponse<int>> DeleteEmployee(int id)
        {
            return await employeeService.DeleteEmployee(id);
        }
    }
}