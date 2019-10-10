using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CleverbitSoftware.WebApi.Integration.Requests;
using CleverbitSoftware.WebApi.Integration.Responses;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CleverbitSoftware.WebApi.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration,
            ILogger<AuthenticationController> logger) : base(logger)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("google")]
        public async Task<IActionResult> Google([FromBody]AuthenticateGoogle request)
        {
            var response = new AuthenticateGoogleResponse();
            try
            {
                var result = GoogleJsonWebSignature.ValidateAsync(request.IdToken, new GoogleJsonWebSignature.ValidationSettings()).Result;

                if (result == null)
                    return BadRequest();

                var key = GetJwtKey();
                var securityTokenDescriptor = GetSecurityTokenDescriptor(result, key);
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(securityTokenDescriptor);
                response.Token = tokenHandler.WriteToken(token);
                return Ok(response);

            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
            return BadRequest();
        }

        private static SecurityTokenDescriptor GetSecurityTokenDescriptor(GoogleJsonWebSignature.Payload result, byte[] key)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, result.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }

        private byte[] GetJwtKey()
        {
            var jwtSecret = _configuration.GetSection("Authentication:JwtSecret").Value;
            var key = Encoding.ASCII.GetBytes(jwtSecret);
            return key;
        }
    }
}
