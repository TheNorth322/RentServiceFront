using System.Threading.Tasks;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.request;
using RentServiceFront.domain.model.response.authentication;

namespace RentServiceFront.data.authentication.api_request;

public class AuthenticationRequest : IAuthenticationRepository
{
    private AuthenticationClient _authenticationClient;
    private IAuthenticationService _api;
    private SecureDataStorage _secureDataStorage;
    
    public AuthenticationRequest(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _authenticationClient = new AuthenticationClient();
        _api = _authenticationClient.authenticationService;
    }

    public async Task<AuthenticationResponse> RegisterUser(RegisterRequest request)
    {
        AuthenticationResponse response = await _api.registerUser(request);
        UpdateSecureStorage(response);
        return response;
    }

    public async Task<AuthenticationResponse> RegisterEntityUser(RegisterEntityRequest request)
    {
        AuthenticationResponse response = await _api.registerEntityUser(request);
        UpdateSecureStorage(response);
        return response;
    }

    public async Task<AuthenticationResponse> RegisterIndividualUser(RegisterIndividualRequest request)
    {
        AuthenticationResponse response = await _api.registerIndividualUser(request);
        UpdateSecureStorage(response);
        return response;
    }

    public async Task<AuthenticationResponse> LoginUser(domain.model.request.AuthenticationRequest request)
    {
        AuthenticationResponse response = await _api.login(request);
        UpdateSecureStorage(response);
        return response;
    }

    public async Task<AuthenticationResponse> GetRefreshToken(string token)
    {
        AuthenticationResponse response = await _api.refreshJwt(token);
        UpdateSecureStorage(response);
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

    private void UpdateSecureStorage(AuthenticationResponse response)
    {
        _secureDataStorage.Role = response.Role;
        _secureDataStorage.JwtToken = response.AccessToken;
        _secureDataStorage.RefreshToken = response.RefreshToken;
        _secureDataStorage.Username = response.Username;
    }
}