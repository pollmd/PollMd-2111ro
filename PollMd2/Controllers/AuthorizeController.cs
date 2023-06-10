using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollMd2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        // GET: api/<AuthorizeController>
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthorizeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthorizeController>
        [HttpPost]
        public string Post([FromBody]User user)
        {
            string stringToken = "";

            if (user.UserName=="radu" && user.Password == "123")
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    Issuer = "apiWithAuthBackend",
                    Audience = "apiWithAuthBackend",
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("!SomethingSecret!")), SecurityAlgorithms.HmacSha512Signature)

                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                stringToken = tokenHandler.WriteToken(token);
            }
            return stringToken;
        }

        // PUT api/<AuthorizeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<AuthorizeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class User 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
