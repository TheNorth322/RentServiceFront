using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.search;

namespace RentServiceFront.data.service;

public interface ISearchService
{
    [Get("/search/buildings")]
    [Headers("Authorization: Bearer")]
    Task<List<Building>> searchForBuildings([Query] string address);

    [Get("/search/migrationServices")]
    [Headers("Authorization: Bearer")]
    Task<List<MigrationService>> searchForMigrationServicesByName([Query] string name);

    [Get("/search/banks")]
    [Headers("Authorization: Bearer")]
    Task<List<Bank>> searchBanksByName([Query] string name);

    [Get("/search/addresses")]
    [Headers("Authorization: Bearer")]
    Task<List<Address>> searchAddresses([Body] SearchAddressesRequest request);
}