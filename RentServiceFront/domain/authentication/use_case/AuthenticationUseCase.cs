using System;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.request;
using RentServiceFront.domain.model.response.authentication;

namespace RentServiceFront.domain.authentication.use_case;

public class AuthenticationUseCase
{
    private IAuthenticationRepository _authenticationRepository;

    public AuthenticationUseCase(IAuthenticationRepository authenticationRepository)
    {
        _authenticationRepository = authenticationRepository
                                    ?? throw new ArgumentException("Authentication repository can't be null");
    }

    public async Task<AuthenticationResponse> RegisterUser(RegisterRequest request)
    {
        return await _authenticationRepository.RegisterUser(request);
    }

    public async Task<AuthenticationResponse> RegisterIndividualUser(RegisterIndividualRequest request)
    {
        return await _authenticationRepository.RegisterIndividualUser(request);
    }

    public async Task<AuthenticationResponse> RegisterEntityUser(RegisterEntityRequest request)
    {
        return await _authenticationRepository.RegisterEntityUser(request);
    }

    public async Task<AuthenticationResponse> LoginUser(AuthenticationRequest request)
    {
        return await _authenticationRepository.LoginUser(request);
    }

    public async Task<AuthenticationResponse> GetRefreshToken(string token)
    {
        return await _authenticationRepository.GetRefreshToken(token);
    }

    public async Task<string> ForgotPassword(string email)
    {
        return await _authenticationRepository.ForgotPassword(email);
    }

    public async Task<string> ValidatePasswordToken(string token)
    {
        return await _authenticationRepository.ValidatePasswordToken(token);
    }

    public async Task<string> ResetPassword(string password, string token)
    {
        return await _authenticationRepository.ResetPassword(password, token);
    }

    public async Task<string> VerifyEmail(string email)
    {
        return await _authenticationRepository.VerifyEmail(email);
    }

    public async Task<string> ValidateEmailVerificationToken(string token)
    {
        return await _authenticationRepository.ValidateEmailVerificationToken(token);
    }
}