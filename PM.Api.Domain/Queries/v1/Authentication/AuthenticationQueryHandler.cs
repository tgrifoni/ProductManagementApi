using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PM.Api.Domain.Models.Enums;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PM.Api.Domain.Queries.v1.Authentication
{
    public class AuthenticationQueryHandler : IRequestHandler<AuthenticationQuery, AuthenticationResponse>
    {
        private readonly IConfiguration _configuration;

        public AuthenticationQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // TODO: For now, any attempt to login will be authenticated. Need to develop a more sophisticated authentication
        public Task<AuthenticationResponse> Handle(AuthenticationQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(new AuthenticationResponse(isAuthenticated: true,
                authenticationStatus: AuthenticationStatus.Authenticated,
                token: GetJwtToken(request.Username)));

        private string GetJwtToken(string username)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var hoursToExpire = Convert.ToInt32(_configuration["Jwt:HoursToExpire"]);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = issuer,
                Issuer = issuer,
                Expires = DateTime.Now.AddHours(hoursToExpire),
                NotBefore = DateTime.Now,
                SigningCredentials = signingCredentials,
                Subject = claims
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
