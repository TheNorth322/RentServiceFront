﻿using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.request;
using RentServiceFront.domain.model.response.authentication;

namespace RentServiceFront.data.service;

public interface IAuthenticationService
{
    [Post("/auth/login")]
    Task<AuthenticationResponse> login([Body] AuthenticationRequest request);

    [Post("/auth/register/user")]
    Task<AuthenticationResponse> registerUser([Body] RegisterRequest request);

    [Post("/auth/register/individual")]
    Task<AuthenticationResponse> registerIndividualUser([Body] RegisterIndividualRequest request);

    [Post("/auth/register/entity")]
    Task<AuthenticationResponse> registerEntityUser([Body] RegisterEntityRequest request);

    [Post("/auth/refresh/")]
    Task<AuthenticationResponse> refreshJwt([Query] string token);

    [Post("/auth/forgot/password")]
    Task<string> forgotPassword([Query] string email, [Query] string password);

    [Post("/auth/validate/password/token/")]
    Task<string> validatePasswordToken([Query] string token);

    [Post("/auth/reset/password/")]
    Task<string> resetPassword([Query] string password, [Query] string token);

    [Post("/auth/verify/email/")]
    Task<string> verifyEmail([Query] string email);

    [Post("/auth/validate/email/token")]
    Task<string> validateEmailVerificationToken([Query] string token);
}