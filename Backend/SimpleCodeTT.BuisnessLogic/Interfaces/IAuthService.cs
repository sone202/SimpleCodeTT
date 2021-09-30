using SimpleCodeTT.Contracts;
using SimpleCodeTT.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeTT.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        Task<ResultResponse<UserDto>> Login(UserDto loginDto);
        Task<ResultResponse<UserDto>> Register(UserDto registerDto);
    }
}
