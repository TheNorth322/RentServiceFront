using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.migrationService;

namespace RentServiceFront.data.authentication.api_request;

public class MigrationServiceRequest : IMigrationServiceRepository
{
    private MigrationServiceClient _migrationServiceClient;
    private IMigrationServiceService _api;
    private SecureDataStorage _secureDataStorage;

    public MigrationServiceRequest(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _migrationServiceClient = new MigrationServiceClient(_secureDataStorage.JwtToken);
        _api = _migrationServiceClient.migrationServiceService;
    }

    public async Task<List<MigrationService>> getMigrationServices()
    {
        return await _api.getMigrationServices();
    }

    public async Task<MigrationService> createMigrationService(CreateMigrationServiceRequest request)
    {
        return await _api.createMigrationService(request);
    }

    public async Task<List<Passport>> getMigrationServicePassports(long id)
    {
        return await _api.getMigrationServicePassports(id);
    }

    public async Task<string> updateMigrationService(UpdateMigrationServiceRequest request)
    {
        return await _api.updateMigrationService(request);
    }

    public async Task<string> deleteMigrationService(long id)
    {
        return await _api.deleteMigrationService(id);
    }
}