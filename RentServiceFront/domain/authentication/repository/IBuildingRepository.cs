using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Building;

namespace RentServiceFront.domain.authentication.repository;

public interface IBuildingRepository
{
    Task<Building> getBuildingById(long id);

    Task<string> createBuilding(CreateBuildingRequest request);

    Task<Building> updateBuilding(UpdateBuildingRequest request);

    Task<string> deleteBuilding(long id);

    Task<List<Room>> getBuildingRooms(long id);

    Task<List<Building>> getBuildings();
}