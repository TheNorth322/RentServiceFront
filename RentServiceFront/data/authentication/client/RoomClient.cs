using Refit;
using RentServiceFront.data.service;

namespace RentServiceFront.data.client;

public class RoomClient
{
    public IRoomService roomService;

    public RoomClient()
    {
        roomService = RestService.For<IRoomService>("http://localhost:8080");
    }
}