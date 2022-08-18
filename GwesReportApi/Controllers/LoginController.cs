using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GwesReportApi.Inventory;
using GwesReportApi.Models;
using Microsoft.EntityFrameworkCore;
using GwesReportApi.Helpers;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace GwesReportApi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public LoginController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();            
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            
            return response;
            
            
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("AppSettings:Secret")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),                
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {           
            UserModel user = null;
            
            try 
            {                
                string userName = login.Username;
                string password = login.Password;
                if (password != "SSO") 
                { 
                    var securityLayer = new SecurityLayer(); 
                    password = securityLayer.SHA256Encrypt(password);
                    
                }
                else
                {
                    password = null;
                }

                
                var emailAddressParam = new SqlParameter("@EmailAdrs", userName);
                var passwordParam = new SqlParameter("@Password", password);
               

                var users = _context
                    .DbUsers
                    .FromSqlRaw("exec Rt_ValidateUser @EmailAdrs, @Password", emailAddressParam, passwordParam)
                    .ToList();

                
                user = new UserModel();
                
                foreach (var item in users)
                {
                    if (item.Username==null)
                    { users = null; }
                    else { 
                    try
                    {
                        user.Username = item.Username;
                        user.Password = item.Password;
                    }
                    catch { users = null; }
                    }

                }
                
            }
            catch 
            {
                user = null;
            }
                                       
           
            return user;
        }
    }
}
