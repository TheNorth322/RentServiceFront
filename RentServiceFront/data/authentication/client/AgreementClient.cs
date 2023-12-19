using System.Threading.Tasks;
using Refit;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class AgreementClient
{
    public IAgreementService _agreementService;

    public AgreementClient(string token)
    {
        _agreementService = RestService.For<IAgreementService>("http://localhost:8080", new RefitSettings()
        {
            AuthorizationHeaderValueGetter = (message, cancelationToken) =>
                Task.FromResult(token)
        });
    }
}