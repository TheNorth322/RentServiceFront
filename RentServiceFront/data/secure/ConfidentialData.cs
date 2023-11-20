using RentServiceFront.domain.enums;

namespace RentServiceFront.data.secure;

public class ConfidentialData
{
    public byte[] _jwtToken;
    public byte[] _refreshToken;
    public byte[] _username;
    public Role _role;
}