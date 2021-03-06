using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantBL;
using RestaurantModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantAPI.JWTRepo
{
    public class JWTRepo : IJWTRepo
    {
        private IConfiguration config;
        private IAccountLogic logic;
        public JWTRepo(IConfiguration config, IAccountLogic logic)
        {
            this.config = config;
            this.logic = logic;
        }
        /*public Tokens Auth(UserAcc user)
        {
            var tokenhander = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(config["JWT:Key"]);
            if (logic.AuthenticateUser(user).Result == false)
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        //new Claim(ClaimTypes.Role, Convert.ToString(user.Username))
                    }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenhander.CreateToken(tokenDescriptor);
            return new Tokens { Validation = tokenhander.WriteToken(token) };
        }*/
        /// <summary>
        /// Bearer Token System to build token for us
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Tokens AuthUser(UserAcc user)
        {
            var tokenhander = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(config["JWT:Key"]);
            if (logic.AuthUser(user) == false)
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Access)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenhander.CreateToken(tokenDescriptor);
            return new Tokens { Validation = tokenhander.WriteToken(token) };
        }
    }
}
