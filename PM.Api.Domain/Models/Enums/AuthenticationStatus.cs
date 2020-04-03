namespace PM.Api.Domain.Models.Enums
{
    public enum AuthenticationStatus
    {
        NotAuthenticated = 0,
        UserNotFound = 1,
        InvalidCredentials = 2,
        Authenticated = 4
    }
}
