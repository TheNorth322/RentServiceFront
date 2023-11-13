using Refit;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class AuthenticationClient
{
    public IAuthenticationService authenticationService;

    public AuthenticationClient()
    {
        authenticationService = RestService.For<IAuthenticationService>("http://localhost:8080");
    }
}