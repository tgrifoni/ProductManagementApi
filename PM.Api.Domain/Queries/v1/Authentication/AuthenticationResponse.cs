using PM.Api.Domain.Models.Enums;

namespace PM.Api.Domain.Queries.v1.Authentication
{
    public class AuthenticationResponse
    {
        public bool IsAuthenticated { get; private set; }
        public AuthenticationStatus AuthenticationStatus { get; private set; }
        public string Token { get; private set; }

        public AuthenticationResponse(bool isAuthenticated, AuthenticationStatus authenticationStatus, string token)
        {
            IsAuthenticated = isAuthenticated;
            AuthenticationStatus = authenticationStatus;
            Token = token;
        }
    }
}
