using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.domain.authentication.repository;

public interface IRoomRepository
{
    Task<Room> CreateRoom(CreateRoomRequest request);
    Task<Room> GetRoomById(long id);
    Task<RoomType> CreateRoomType(CreateRoomTypeRequest request);
    Task<string> AddRoomTypeToRoom(AddRoomTypeToRoomRequest request);

    Task<List<RoomType>> GetAllTypes();
}