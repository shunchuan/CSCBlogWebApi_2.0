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
using CSCBlogWebApi_2_0.Model.Authentication;

namespace CSCBlogWebApi_2_0.Infrastructure.JWT
{
    public class JWTHelper
    {
        public static TokenResponseModel GenerateToken(User_Info user, JwtTokenModel jwtToken)
        {
            TokenResponseModel response = new TokenResponseModel();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken.JwtKey));

            var claims = new Claim[]
            {
                new Claim("UserID",user.Id.ToString()),
                new Claim("Account",user.Account),
                new Claim("Name",user.Name)
            };
            

            var token = new JwtSecurityToken(
                issuer: jwtToken.JwtIssuer,
                audience: jwtToken.JwtAudience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(jwtToken.JwtExpireDays),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            response.access_token = new JwtSecurityTokenHandler().WriteToken(token);

            response.type = JwtBearerDefaults.AuthenticationScheme; 

            response.expires = DateTime.Now.AddDays(jwtToken.JwtExpireDays);

            return response;
        }
    }
}
