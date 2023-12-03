using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.migrationService;

namespace RentServiceFront.domain.authentication.use_case;

public class MigrationServiceUseCase
{
    private IMigrationServiceRepository _migrationServiceRepository;

    public MigrationServiceUseCase(IMigrationServiceRepository migrationServiceRepository)
    {
        _migrationServiceRepository =
            migrationServiceRepository ?? throw new ArgumentException("Migration service can't be null");
    }

    public async Task<List<MigrationService>> getMigrationServices()
    {
        return await _migrationServiceRepository.getMigrationServices();
    }
    
    public async Task<MigrationService> createMigrationService(CreateMigrationServiceRequest request)
    {
        return await _migrationServiceRepository.createMigrationService(request);
    }

    public async Task<string> updateMigrationService(UpdateMigrationServiceRequest request)
    {
        return await _migrationServiceRepository.updateMigrationService(request);
    }

    public async Task<string> deleteMigrationService(long id)
    {
        return await _migrationServiceRepository.deleteMigrationService(id);
    }
}