using GreenValley.Models;
using GreenValley.Services.Contracters;
using GreenValley.Utility;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GreenValley.Services.Implimentation
{
    public class UserLogin : IUserLogin
    {
        private readonly VegetableHubContext _context;
        private readonly IConfiguration _configuration;

        public UserLogin (VegetableHubContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public LoginResponse AddNewOne(LoginResponse loginResponse)
        {
            try
            {
                var hasedpassword = BCrypt.Net.BCrypt.HashPassword(loginResponse.UserPassword);
                var newUser = new Login
                {
                    UserPassword = hasedpassword,
                    UserName = loginResponse.UserName,
                };
                _context.Logins.Add(newUser);
                _context.SaveChanges();
                loginResponse.UserPassword = hasedpassword;
                return loginResponse;   

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public string ValidUser(LoginResponse loginResponse)
        {
            var storedcustomer=_context.Logins.Where(x=>x.UserName==loginResponse.UserName).FirstOrDefault();
            if(storedcustomer == null) {
                return "User Not Fount";
            }
            if(!BCrypt.Net.BCrypt.Verify(loginResponse.UserPassword, storedcustomer.UserPassword)) 
            {
                return "Password is wrong";
                    
            }
            var toke = CreatToken(loginResponse);
            return toke;
        }

        public string CreatToken(LoginResponse login)
        {
            List<Claim> claims = new List<Claim>
         {
             new Claim(ClaimTypes.Name,login.UserName),
         };
            var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: cred);
              var jwt =new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
