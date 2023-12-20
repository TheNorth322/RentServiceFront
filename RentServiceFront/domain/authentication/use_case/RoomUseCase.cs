using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.authentication.repository;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.domain.authentication.use_case;

public class RoomUseCase
{
    private IRoomRepository _roomRepository;

    public RoomUseCase(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository ?? throw new ArgumentException("Room repository can't be null");
    }

    public async Task<List<Room>> GetAvailableRoomsInBuilding(long id)
    {
        return await _roomRepository.GetAvailableRoomsInBuilding(id);
    }

    public async Task<List<Room>> GetRoomInBuildingWithRentals()
    {
        return await _roomRepository.GetRoomInBuildingWithRentals();
    }

    public async Task<List<AgreementRoom>> GetAgreementRoomsByRoomId(long id)
    {
        return await _roomRepository.GetAgreementRoomsByRoomId(id);
    }

    public async Task<List<Room>> GetAvailableRooms()
    {
        return await _roomRepository.GetAvailableRooms();
    }

    public async Task<List<AgreementRoom>> GetAgreementRoomsByAgreementId(long id)
    {
        return await _roomRepository.GetAgreementRoomsByAgreementId(id);
    }

    public async Task<string> AddRoomToCart(AddRoomToCartRequest request)
    {
        return await _roomRepository.AddRoomToCart(request);
    }

    public async Task<List<Room>> GetRooms()
    {
        return await _roomRepository.GetRooms();
    }

    public async Task<Room> CreateRoom(CreateRoomRequest request)
    {
        return await _roomRepository.CreateRoom(request);
    }

    public async Task<string> UpdateRoom(UpdateRoomRequest request)
    {
        return await _roomRepository.UpdateRoom(request);
    }

    public async Task<string> DeleteRoom(long id)
    {
        return await _roomRepository.DeleteRoom(id);
    }

    public async Task<Room> GetRoomById(long id)
    {
        return await _roomRepository.GetRoomById(id);
    }

    public async Task<RoomType> CreateRoomType(CreateRoomTypeRequest request)
    {
        return await _roomRepository.CreateRoomType(request);
    }

    public async Task<string> UpdateRoomType(UpdateRoomTypeRequest request)
    {
        return await _roomRepository.UpdateRoomType(request);
    }

    public async Task<string> DeleteRoomType(long id)
    {
        return await _roomRepository.DeleteRoomType(id);
    }

    public async Task<string> AddRoomTypeToRoom(AddRoomTypeToRoomRequest request)
    {
        return await _roomRepository.AddRoomTypeToRoom(request);
    }

    public async Task<List<RoomType>> GetAllTypes()
    {
        return await _roomRepository.GetAllTypes();
    }
}