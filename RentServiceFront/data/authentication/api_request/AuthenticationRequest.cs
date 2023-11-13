using System.Threading.Tasks;
using RentServiceFront.data.client;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.request;
using RentServiceFront.domain.model.response.authentication;

namespace RentServiceFront.data.authentication.api_request;

public class AuthenticationRequest : IAuthenticationRepository
{
    private AuthenticationClient _authenticationClient;
    private IAuthenticationService _api;

    public AuthenticationRequest()
    {
        _authenticationClient = new AuthenticationClient();
        _api = _authenticationClient.authenticationService;
    }

    public async Task<AuthenticationResponse> RegisterUser(RegisterRequest request)
    {
        AuthenticationResponse response = await _api.registerUser(request);
        return response;
    }

    public async Task<AuthenticationResponse> RegisterEntityUser(RegisterEntityRequest request)
    {
        AuthenticationResponse response = await _api.registerEntityUser(request);
        return response;
    }

    public async Task<AuthenticationResponse> RegisterIndividualUser(RegisterIndividualRequest request)
    {
        AuthenticationResponse response = await _api.registerIndividualUser(request);
        return response;
    }

    public async Task<AuthenticationResponse> LoginUser(domain.model.request.AuthenticationRequest request)
    {
        AuthenticationResponse response = await _api.login(request);
        return response;
    }

    public async Task<AuthenticationResponse> GetRefreshToken(string token)
    {
        AuthenticationResponse response = await _api.refreshJwt(token);
        return response;
    }

    public async Task<string> ForgotPassword(string email)
    {
        string response = await _api.forgotPassword(email);
        return response;
    }

    public async Task<string> ValidatePasswordToken(string token)
    {
        string response = await _api.validatePasswordToken(token);
        return response;
    }

    public async Task<string> ResetPassword(string password, string token)
    {
        string response = await _api.resetPassword(password, token);
        return response;
    }

    public async Task<string> VerifyEmail(string email)
    {
        string response = await _api.verifyEmail(email);
        return response;
    }

    public async Task<string> ValidateEmailVerificationToken(string token)
    {
        string response = await _api.validateEmailVerificationToken(token);
        return response;
    }
}