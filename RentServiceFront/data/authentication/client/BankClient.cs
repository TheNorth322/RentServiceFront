using System.Threading.Tasks;
using Refit;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class BankClient
{
    public IBankService bankService;

    public BankClient(string token)
    {
        bankService = RestService.For<IBankService>("http://localhost:8080", new RefitSettings()
        {
            AuthorizationHeaderValueGetter = (message, cancelationToken) =>
                Task.FromResult(token)
        });
    }
}