using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Building;

namespace RentServiceFront.data.service;

[Headers("Authorization: Bearer")]
public interface IBuildingService
{
    [Get("/building/get")]
    Task<Building> getBuildingById([Query] long id);

    [Post("/building/create")]
    Task<Building> createBuilding([Body] CreateBuildingRequest request);

    [Put("/building/update")]
    Task<string> updateBuilding([Body] UpdateBuildingRequest request);

    [Delete("/building/delete")]
    Task<string> deleteBuilding([Query] long id);

    [Get("/building/rooms")]
    Task<List<Room>> getBuildingRooms([Query] long id);
    
    [Get("/building/all")]
    Task<List<Building>> getBuildings();
}