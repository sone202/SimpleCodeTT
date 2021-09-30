using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCodeTT.Contracts.Auth
{
    public static class AuthParams
    {
        public const string ISSUER = "SimpleCodeTT"; 
        public const string AUDIENCE = "SimpleCodeTT";
        const string KEY = "qazwsxedc_!_cdexswzaq"; 
        public const int LIFETIME = 12;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
