using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.search;

namespace RentServiceFront.domain.authentication.repository;

public interface ISearchRepository
{
    Task<Building> getBuildingByAddress(Address address);

    Task<List<Room>> findAvailableRoomsInBuilding(long id);
    Task<List<IndividualUser>> findAllInidivdualsByPassportInMigrationService(long id);

    Task<List<MigrationService>> searchForMigrationServicesByName(string name);

    Task<List<Bank>> searchBanksByName(string name);

    Task<List<Address>> searchAddresses(string query, int count);

    Task<List<MigrationService>> searchMigrationServices();
}