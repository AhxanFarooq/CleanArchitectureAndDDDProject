using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dinner.Application.Common.Interface.Authentication;
using Dinner.Application.Common.Interface.Services;
using Dinner.Domain.Entities;
using Dinner.Infrastructure.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace Dinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSetting> jwtSetting) : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
        private readonly JwtSetting _jwtSetting = jwtSetting.Value;

        public Task<string> GenerateToken(User user, string role)
        {
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = _dateTimeProvider.UtcNow.AddMinutes(Convert.ToDouble(_jwtSetting.ExpireMinutes));

            var token = new JwtSecurityToken(
                _jwtSetting.Issuer,
                _jwtSetting.Audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}