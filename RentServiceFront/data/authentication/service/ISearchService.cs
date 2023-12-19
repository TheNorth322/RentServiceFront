using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.search;

namespace RentServiceFront.data.service;

public interface ISearchService
{
    [Get("/search/building")]
    Task<Building> getBuildingByAddress([Body] Address address);

    [Get("/search/building/rooms/available")]
    Task<List<Room>> findAvailableRoomsInBuilding([Query] long id);

    [Get("/search/individual/pasport/in/migrationService")]
    Task<List<IndividualUser>> findAllInidivdualsByPassportInMigrationService([Query] long id);

    [Get("/search/migrationServices")]
    Task<List<MigrationService>> searchForMigrationServicesByName([Query] string name);

    [Get("/search/banks")]
    Task<List<Bank>> searchBanksByName([Query] string name);

    [Get("/search/addresses")]
    Task<List<Address>> searchAddresses([Query] string query, [Query] int count);

    [Get("/search/migrationServices/all")]
    Task<List<MigrationService>> searchMigrationServices();
}