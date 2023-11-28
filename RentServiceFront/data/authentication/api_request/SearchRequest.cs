using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.search;

namespace RentServiceFront.data.authentication.api_request;

public class SearchRequest : ISearchRepository
{
    private ISearchService _api;
    private SearchClient _searchClient;
    private SecureDataStorage _secureDataStorage;

    public SearchRequest(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _searchClient = new SearchClient(_secureDataStorage.JwtToken);
        _api = _searchClient.searchService;
    }

    public async Task<List<Building>> searchForBuildings(string address)
    {
        return await _api.searchForBuildings(address);
    }

    public async Task<List<MigrationService>> searchForMigrationServicesByName(string name)
    {
        return await _api.searchForMigrationServicesByName(name);
    }

    public async Task<List<Bank>> searchBanksByName(string name)
    {
        return await _api.searchBanksByName(name);
    }

    public async Task<List<Address>> searchAddresses(SearchAddressesRequest request)
    {
        return await _api.searchAddresses(request);
    }
}