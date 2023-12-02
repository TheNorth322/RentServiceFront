using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.migrationService;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.data.service;

public interface IMigrationServiceService
{
    
    [Headers("Authorization: Bearer")]
    [Get("/migration_service/all")]
    Task<List<MigrationService>> getMigrationServices();
    
    [Headers("Authorization: Bearer")]
    [Post("/migration_service/create")]
    Task<string> createMigrationService([Body] CreateMigrationServiceRequest request);

    [Headers("Authorization: Bearer")]
    [Put("/migration_service/update")]
    Task<string> updateMigrationService([Body] UpdateMigrationServiceRequest request);

    [Headers("Authorization: Bearer")]
    [Delete("/migration_service/delete")]
    Task<string> deleteMigrationService([Query] long id);
}