using System.Threading.Tasks;
using Refit;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class MigrationServiceClient
{
    public IMigrationServiceService migrationServiceService;

    public MigrationServiceClient(string token)
    {
        migrationServiceService = RestService.For<IMigrationServiceService>("http://localhost:8080", new RefitSettings()
        {
            AuthorizationHeaderValueGetter = (message, cancelationToken) =>
                Task.FromResult(token)
        });
    }
}