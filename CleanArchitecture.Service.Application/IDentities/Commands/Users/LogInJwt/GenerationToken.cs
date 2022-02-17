using CleanArchitecture.Domain.Contract.Constants;
using CleanArchitecture.Domain.Contract.Interfaces.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInJwt
{
    public class GenerationToken
    {
        public string Genration(IUsers users)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(ApplicationConstants.Secret);
            var Identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, users.Email)
            });
            
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = Identity,
                Expires = DateTime.Now.AddMinutes(300),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };

            var Token = TokenHandler.CreateToken(TokenDescriptor);
            var Result = TokenHandler.WriteToken(Token);

           

            return Result;


        }
    }
}
