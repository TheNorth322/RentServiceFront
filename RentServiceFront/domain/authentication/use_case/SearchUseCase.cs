using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.search;

namespace RentServiceFront.domain.authentication.use_case;

public class SearchUseCase
{
    private ISearchRepository _searchRepository;

    public SearchUseCase(ISearchRepository searchRepository)
    {
        _searchRepository = searchRepository ?? throw new ArgumentException("Search repository can't be null");
    }


    public async Task<Building> getBuildingByAddress(Address address)
    {
        return await _searchRepository.getBuildingByAddress(address);
    }

    public async Task<List<MigrationService>> searchForMigrationServicesByName(string name)
    {
        return await _searchRepository.searchForMigrationServicesByName(name);
    }

    public async Task<List<Bank>> searchBanksByName(string name)
    {
        return await _searchRepository.searchBanksByName(name);
    }

    public async Task<List<Address>> searchAddresses(string query, int count)
    {
        return await _searchRepository.searchAddresses(query, count);
    }


    public async Task<List<MigrationService>> searchForMigrationServices()
    {
        return await _searchRepository.searchMigrationServices();
    }
}