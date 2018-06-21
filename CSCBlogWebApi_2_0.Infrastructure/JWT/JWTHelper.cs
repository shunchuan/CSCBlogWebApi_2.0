using CSCBlogWebApi_2_0.Model.TableModel;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CSCBlogWebApi_2_0.Model.ResponseModel;

namespace CSCBlogWebApi_2_0.Infrastructure.JWT
{
    public class JWTHelper
    {
        public static TokenResponseModel GenerateToken(User_Info user, IConfiguration Configuration)
        {
            TokenResponseModel response = new TokenResponseModel();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Jwt")["JwtKey"]));

            var claims = new Claim[]
            {
                new Claim("UserID",user.Id.ToString()),
                new Claim("Account",user.Account),
                new Claim("Name",user.Name),
                new Claim("Sex",user.Sex)
            };

            var expiresday = double.Parse(Configuration.GetSection("Jwt")["JwtExpireDays"]);

            var token = new JwtSecurityToken(
                issuer: Configuration.GetSection("Jwt")["JwtIssuer"],
                audience: Configuration.GetSection("Jwt")["JwtIssuer"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(expiresday),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            response.access_token = new JwtSecurityTokenHandler().WriteToken(token);

            response.type = JwtBearerDefaults.AuthenticationScheme; 

            response.expires = DateTime.Now.AddDays(expiresday);

            return response;
        }
    }
}
