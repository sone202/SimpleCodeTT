using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCodeTT.Contracts.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class EmployeeDto
    {
        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email сотрудника
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// День рождения 
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// День рождения 
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
    }
}
