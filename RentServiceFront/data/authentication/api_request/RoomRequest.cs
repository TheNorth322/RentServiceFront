using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.data.client;
using RentServiceFront.data.secure;
using RentServiceFront.data.service;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.data.authentication.api_request;

public class RoomRequest : IRoomRepository
{
    private RoomClient _roomClient;  
    private IRoomService _api;
    private SecureDataStorage _secureDataStorage;
    public RoomRequest(SecureDataStorage secureDataStorage)
    {
        _secureDataStorage = secureDataStorage;
        _roomClient = new RoomClient(_secureDataStorage.JwtToken);
        _api = _roomClient.roomService;
    }
    public async Task<Room> CreateRoom(CreateRoomRequest request)
    {
        return await _api.createRoom(request);
    }

    public async Task<Room> GetRoomById(long id)
    {
        return await _api.getRoomById(id);
    }

    public async  Task<RoomType> CreateRoomType(CreateRoomTypeRequest request)
    {
        return await _api.createRoomType(request);
    }

    public async Task<string> AddRoomTypeToRoom(AddRoomTypeToRoomRequest request)
    {
        return await _api.addRoomTypes(request);
    }

    public async Task<List<RoomType>> GetAllTypes()
    {
        return await _api.getAllTypes();
    }
}