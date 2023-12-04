using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Building;

namespace RentServiceFront.data.authentication.api_request;

public class BuildingRequest : IBuildingRepository
{
    private BuildingClient _buildingClient;
    private IBuildingService _api;
    private SecureDataStorage _secureDataStorage;

    public BuildingRequest(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _buildingClient = new BuildingClient(_secureDataStorage.JwtToken);
        _api = _buildingClient.buildingService;
    }

    public async Task<Building> getBuildingById(long id)
    {
        return await _api.getBuildingById(id);
    }

    public async Task<string> createBuilding(CreateBuildingRequest request)
    {
        return await _api.createBuilding(request);
    }

    public async Task<Building> updateBuilding(UpdateBuildingRequest request)
    {
        return await _api.updateBuilding(request);
    }

    public async Task<string> deleteBuilding(long id)
    {
        return await _api.deleteBuilding(id);
    }

    public async Task<List<Room>> getBuildingRooms(long id)
    {
        return await _api.getBuildingRooms(id);
    }

    public async Task<List<Building>> getBuildings()
    {
        return await _api.getBuildings();
    }
}