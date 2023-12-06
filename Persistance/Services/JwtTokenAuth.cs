using Event_System.Core.Entity.UserModel;
using Event_System.Persistance.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Event_System.Persistance.Services
{
    public class JwtTokenAuth : IJwtTokenAuth
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IConfiguration _configuration;
        private readonly ILogger<JwtTokenAuth> _logger;
        public JwtTokenAuth(IOptions<JwtIssuerOptions> jwtOptions, IConfiguration configuration , ILogger<JwtTokenAuth> logger)
        {

            _configuration = configuration;
            _jwtOptions = jwtOptions.Value;
            _logger = logger;
        }
        public string GenerateEncodedToken(User user)
        {
            var claims = new[]
          {
                 new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                 new Claim(JwtRegisteredClaimNames.Name, user.Full_Name),
                 new Claim(JwtRegisteredClaimNames.Jti,  _jwtOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(),
                 ClaimValueTypes.Integer64),
           };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));
            var _TokenExpiryTimeInHour = Convert.ToInt64(_configuration["Jwt:ExpiresInMinutes"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                //Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

            
        }
        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - DateTime.Now.AddMinutes(30).ToUniversalTime())
                              .TotalSeconds);
    }
}
