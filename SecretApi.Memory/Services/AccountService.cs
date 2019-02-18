using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SecretApi.Memory.DTO;

namespace SecretApi.Memory.Services
{
    public class AccountService
    {
        public const string AuthKey = @"fjbUK+qZeet3srRZ7yioed5x17dIp1NEwPtDGAB3b45n/wFtX3p8yfUF2LLfx/q5IdVudZfmzn+psXOjPqe12w==";

        public string GetToken(UserCredentials credentials)
        {
            //
            // TODO: Vaidate the `credentials`
            //
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(2),
                NotBefore = DateTime.UtcNow,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userid", credentials.UserName),
                    new Claim("role", "developer")
                }),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Convert.FromBase64String(AuthKey)), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(jwtToken);

            return token;
        }
    }
}