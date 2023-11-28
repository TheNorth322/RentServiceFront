using Newtonsoft.Json;
using RentServiceFront.domain.enums;

namespace RentServiceFront.domain.model.entity;

public class User
{
    public User(long id, string username, string email, bool emailVerified, string phoneNumber, Role role)
    {
        Id = id;
        Username = username;
        Email = email;
        EmailVerified = emailVerified;
        PhoneNumber = phoneNumber;
        Role = role;
    }

    [JsonProperty("id")]
    public long Id { get; }
    
    [JsonProperty("username")]
    public string Username { get; }
    
    [JsonProperty("email")]
    public string Email { get; }
    
    [JsonProperty("emailVerified")]
    public bool EmailVerified { get; }
    
    [JsonProperty("phoneNumber")]
    public string PhoneNumber { get; } 
    
    [JsonProperty("role")]
    public Role Role { get; }
}