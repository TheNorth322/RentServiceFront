using System.Threading.Tasks;
using Refit;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class SearchClient
{
    public ISearchService searchService;

    public SearchClient(string token)
    {
        searchService = RestService.For<ISearchService>("http://localhost:8080", new RefitSettings()
        {
            AuthorizationHeaderValueGetter = (message, cancelationToken) =>
                Task.FromResult($"Bearer {token}")
        });
    }
}