using System.Security.Principal;

namespace RentServiceFront.data.secure;

public class SecureStore
{
   public string AccessToken { get; set; } 
   public string RefreshToken { get; set; }
   public string Username { get; set; }
}