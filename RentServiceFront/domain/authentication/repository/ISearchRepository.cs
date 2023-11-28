using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.search;

namespace RentServiceFront.domain.authentication.repository;

public interface ISearchRepository
{
    Task<List<Building>> searchForBuildings(string address);

    Task<List<MigrationService>> searchForMigrationServicesByName(string name);

    Task<List<Bank>> searchBanksByName(string name);

    Task<List<Address>> searchAddresses(SearchAddressesRequest request);
}