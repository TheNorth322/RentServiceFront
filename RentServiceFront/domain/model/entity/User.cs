using RentServiceFront.domain.enums;

namespace RentServiceFront.domain.model.entity;

public class User
{
    public long Id { get; }
    public string Username { get; }
    public string Email { get; }
    public bool EmailVerified { get; }
    public string PhoneNumber { get; } 
    public Role Role { get; }
}