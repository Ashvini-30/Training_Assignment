﻿#region usings

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

#endregion


namespace WebApplication3.Models
{
    public class Authentication
    {
        public static string GenerateJwtToken(string emailId, List<string> roles)
        {
            var Claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,emailId),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,emailId)
           };
            roles.ForEach(role =>
            {
                Claims.Add(new Claim(ClaimTypes.Role,role));


            });
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Convert.ToString(ConfigurationManager.AppSettings["config:JwtKey"])));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(Convert.ToString(ConfigurationManager.AppSettings["config:JwtExpireDays"])));

            var token = new JwtSecurityToken(
                Convert.ToString(ConfigurationManager.AppSettings["config:JwtIssuer"]),
                Convert.ToString(ConfigurationManager.AppSettings["config:JwtAudience"]),
                Claims,
                expires : expires,
                signingCredentials : creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}