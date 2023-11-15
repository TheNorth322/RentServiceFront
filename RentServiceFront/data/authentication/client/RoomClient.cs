using System.Threading.Tasks;
using Refit;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class RoomClient
{
    public IRoomService roomService;

    public RoomClient(string token)
    {
        roomService = RestService.For<IRoomService>("http://localhost:8080", new RefitSettings()
        {
            AuthorizationHeaderValueGetter = (message, cancelationToken) =>
                Task.FromResult($"Bearer {token}")
        });
    }
}