using Newtonsoft.Json;
using RentServiceFront.domain.enums;

namespace RentServiceFront.domain.model.response.authentication;

public class AuthenticationResponse
{
    public AuthenticationResponse(string accessToken, string refreshToken, string username, Role role)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        Username = username;
        Role = role;
    }

    [JsonProperty("accessToken")]
    public string AccessToken { get; set; }
    
    [JsonProperty("refreshToken")]
    public string RefreshToken { get; set; }
    
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("role")]
    public Role Role { get; set; }
}