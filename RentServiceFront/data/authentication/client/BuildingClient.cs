using System.Threading.Tasks;
using Refit;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class BuildingClient
{
    
    public IBuildingService buildingService;

    public BuildingClient(string token)
    {
        buildingService = RestService.For<IBuildingService>("http://localhost:8080", new RefitSettings()
        {
            AuthorizationHeaderValueGetter = (message, cancelationToken) =>
                Task.FromResult(token)
        });
    }}