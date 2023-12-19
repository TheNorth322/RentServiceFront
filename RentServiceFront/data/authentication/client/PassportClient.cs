using System.Threading.Tasks;
using Refit;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class PassportClient
{
    public IPassportService _passportService;

    public PassportClient(string token)
    {
        _passportService = RestService.For<IPassportService>("http://localhost:8080", new RefitSettings()
        {
            AuthorizationHeaderValueGetter = (message, cancelationToken) =>
                Task.FromResult(token)
        });
    }
}