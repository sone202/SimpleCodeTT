using Microsoft.EntityFrameworkCore;
using SimpleCodeTT.BusinessLogic.Interfaces;
using SimpleCodeTT.Contracts;
using SimpleCodeTT.Contracts.Models;
using SimpleCodeTT.DataAccess;
using SimpleCodeTT.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeTT.BusinessLogic.Services
{
    /// <summary>
    /// Сервис авторизации пользователей
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext context;
        public AuthService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ResultResponse<UserDto>> Login(UserDto userDto)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => Convert.ToString(x.Username) == userDto.Username);

                if (user?.Password == userDto.Password)
                {
                    return ResultResponse<UserDto>.GetSuccessResponse(userDto);
                }
                else
                {
                    return ResultResponse<UserDto>.GetFailResponse();
                }    
            }
            catch (Exception e)
            {
                // TODO: Add logging
                return ResultResponse<UserDto>.GetFailResponse();
            }
        }

        public async Task<ResultResponse<UserDto>> Register(UserDto userDto)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => Convert.ToString(x.Username) == userDto.Username.ToString());

                if (user != null)
                {
                    return ResultResponse<UserDto>.GetFailResponse();
                }

                var newUser = new User
                {
                    Username = userDto.Username,
                    Password = userDto.Password
                };

                var result = context.Add(newUser).Entity;
                await context.SaveChangesAsync();

                return ResultResponse<UserDto>.GetSuccessResponse(userDto);
            }
            catch (Exception e)
            {
                // TODO: Add logging
                return ResultResponse<UserDto>.GetFailResponse();
            }
        }
    }
}
