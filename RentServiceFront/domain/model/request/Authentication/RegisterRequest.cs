using RentServiceFront.domain.enums;

namespace RentServiceFront.domain.model.request;

public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
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
    