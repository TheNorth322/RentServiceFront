using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RentServiceFront.domain.enums;

namespace RentServiceFront.domain.model.request;

public class RegisterRequest
{
    [JsonProperty("username")] public string Username { get; set; }

    [JsonProperty("email")] public string Email { get; set; }

    [JsonProperty("password")] public string Password { get; set; }

    [JsonProperty("phoneNumber")] public string PhoneNumber { get; set; }

    [JsonProperty("role")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Role Role { get; set; }

    public RegisterRequest(string username, string email, string password, string phoneNumber, Role role)
    {
        Username = username;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Role = role;
    }
}