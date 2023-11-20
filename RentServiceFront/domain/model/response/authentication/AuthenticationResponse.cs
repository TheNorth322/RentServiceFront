using RentServiceFront.domain.enums;

namespace RentServiceFront.domain.model.response.authentication;

public class AuthenticationResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
}