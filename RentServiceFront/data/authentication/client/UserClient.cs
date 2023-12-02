using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class UserClient
{
    public IUserService userService;

    public UserClient(string token)
    {
        userService = RestService.For<IUserService>("http://localhost:8080", new RefitSettings()
        {
            AuthorizationHeaderValueGetter = (message, cancelationToken) =>
                Task.FromResult(token)
        });
    }
}