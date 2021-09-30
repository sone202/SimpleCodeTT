using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SimpleCodeTT.BusinessLogic.Interfaces;
using SimpleCodeTT.Contracts;
using SimpleCodeTT.Contracts.Auth;
using SimpleCodeTT.Contracts.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeTT.Controllers
{
    [Route("api/")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService service)
        {
            authService = service;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [Route("signin")]
        [HttpPost]
        public async Task<ResultResponse<object>> SignIn(UserDto userDto)
        {
            var result = await authService.Login(userDto);
            if (!result.IsSuccess)
            {
                return ResultResponse<object>.GetFailResponse();
            }

            var encodedJwt = GetJwtSecurityToken(result.Result.Username);
            var response = new
            {
                accessToken = encodedJwt,
                user = result.Result
            };

            return ResultResponse<object>.GetSuccessResponse(response);
        }

        /// <summary>
        /// Регистрация пользователя (клиента)
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [Route("signup")]
        [HttpPost]
        public async Task<ResultResponse<object>> SignUp(UserDto userDto)
        {
            var result = await authService.Register(userDto);

            if (!result.IsSuccess)
            {
                return ResultResponse<object>.GetFailResponse();
            }

            var encodedJwt = GetJwtSecurityToken(result.Result.Username);
            var response = new
            {
                accessToken = encodedJwt,
                user = result.Result
            };

            return ResultResponse<object>.GetSuccessResponse(response);
        }

        private ClaimsIdentity GetClaims(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            return claimsIdentity;
        }

        private string GetJwtSecurityToken(string username)
        {
            var identity = GetClaims(username);
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                   issuer: AuthParams.ISSUER,
                   audience: AuthParams.AUDIENCE,
                   notBefore: now,
                   claims: identity.Claims,
                   expires: now.Add(TimeSpan.FromHours(AuthParams.LIFETIME)),
                   signingCredentials: new SigningCredentials(AuthParams.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
