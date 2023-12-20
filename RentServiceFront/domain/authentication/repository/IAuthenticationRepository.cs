using System.Threading.Tasks;
using RentServiceFront.domain.model.request;
using RentServiceFront.domain.model.response.authentication;

namespace RentServiceFront.domain.authentication.repository;

public interface IAuthenticationRepository
{
    public Task<AuthenticationResponse> RegisterUser(RegisterRequest request);

    public Task<AuthenticationResponse> RegisterEntityUser(RegisterEntityRequest request);

    public Task<AuthenticationResponse> RegisterIndividualUser(RegisterIndividualRequest request);
    public Task<AuthenticationResponse> LoginUser(AuthenticationRequest request);
    public Task<AuthenticationResponse> GetRefreshToken(string token);
    public Task<string> ForgotPassword(string email, string password);
    public Task<string> ValidatePasswordToken(string token);
    public Task<string> ResetPassword(string password, string token);
    public Task<string> VerifyEmail(string email);
    public Task<string> ValidateEmailVerificationToken(string token);
}