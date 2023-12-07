using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Building;

namespace RentServiceFront.domain.authentication.repository;

public interface IBuildingRepository
{
    Task<Building> getBuildingById(long id);

    Task<Building> createBuilding(CreateBuildingRequest request);

    Task<string> updateBuilding(UpdateBuildingRequest request);

    Task<string> deleteBuilding(long id);

    Task<List<Room>> getBuildingRooms(long id);

    Task<List<Building>> getBuildings();
}