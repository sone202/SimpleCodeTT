using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCodeTT.Contracts.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
