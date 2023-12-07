using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Building;

namespace RentServiceFront.domain.authentication.use_case;

public class BuildingUseCase
{
    private IBuildingRepository _buildingRepository;

    public BuildingUseCase(IBuildingRepository buildingRepository)
    {
        _buildingRepository = buildingRepository ?? throw new ArgumentException("Building repository can't be null");
    }

    public async Task<Building> getBuildingById(long id)
    {
        return await _buildingRepository.getBuildingById(id);
    }

    public async Task<Building> createBuilding(CreateBuildingRequest request)
    {
        return await _buildingRepository.createBuilding(request);
    }

    public async Task<string> updateBuilding(UpdateBuildingRequest request)
    {
        return await _buildingRepository.updateBuilding(request);
    }

    public async Task<string> deleteBuilding(long id)
    {
        return await _buildingRepository.deleteBuilding(id);
    }

    public async Task<List<Room>> getBuildingRooms(long id)
    {
        return await _buildingRepository.getBuildingRooms(id);
    }

    public async Task<List<Building>> getBuildings()
    {
        return await _buildingRepository.getBuildings();
    }
}