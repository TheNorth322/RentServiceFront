using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.migrationService;

namespace RentServiceFront.domain.authentication.repository;

public interface IMigrationServiceRepository
{
    Task<List<MigrationService>> getMigrationServices();
    Task<MigrationService> createMigrationService(CreateMigrationServiceRequest request);

    Task<string> updateMigrationService(UpdateMigrationServiceRequest request);
    
    Task<string> deleteMigrationService(long id);
}