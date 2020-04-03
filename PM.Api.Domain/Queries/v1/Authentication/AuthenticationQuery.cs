namespace PM.Api.Domain.Queries.v1.Authentication
{
    public class AuthenticationQuery : AbstractQuery<AuthenticationResponse>
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public AuthenticationQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
