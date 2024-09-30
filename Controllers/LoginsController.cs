using AssetManagementSystem_WebApi_MidExam.Models;
using AssetManagementSystem_WebApi_MidExam.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagementSystem_WebApi_MidExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        //Get Configuration from appsettings - SecretKey
        private IConfiguration _config;

        //Repository DI
        //call repository
        private readonly ILoginRepository _loginRepository;

        //DI
        public LoginsController(IConfiguration config, ILoginRepository loginRepository)
        {
            _config = config;
            _loginRepository = loginRepository;
        }
        #region Valid Credentials - Username and Password

        // GET: api/Logins/username/password
        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> LoginIn(string username, string password)
        {
            // Variables for tracking unauthorized
            IActionResult response = Unauthorized(); // 401
            Login dbUser = null;

            // 1. Authenticate the user by passing username and password
            dbUser = await _loginRepository.ValidateUser(username, password);

            // 2. Generate JWT Token if user is found
            if (dbUser != null)
            {
                // Custom Method for generating token
                var tokenString = GenerateJWTToken(dbUser);

                response = Ok(new
                {
                    uName = dbUser.Username,
                    // Assuming roleId and userId correspond to Usertype and LId in Login model
                    roleId = dbUser.Usertype,
                    userId = dbUser.LId,
                    token = tokenString
                });
            }

            return response;
        }

        #endregion


        #region GenerateJWTToken - Custom
        private object GenerateJWTToken(Login dbUser)
        {
            //1.Secret Security Key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //2.Pass Algorithm-Header
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //3.JWTToken-Payload
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);

            //4.Writing Token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
