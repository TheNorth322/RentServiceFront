﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.domain.authentication.repository;

public interface IRoomRepository
{
    Task<List<Room>> GetRooms();
    Task<List<Room>> GetAvailableRooms();
    Task<List<AgreementRoom>> GetAgreementRoomsByAgreementId(long id);
    Task<List<AgreementRoom>> GetAgreementRoomsByRoomId(long id);
    Task<List<Room>> GetAvailableRoomsInBuilding(long id);
    Task<List<Room>> GetRoomInBuildingWithRentals();
    Task<string> AddRoomToCart(AddRoomToCartRequest request);
    Task<Room> CreateRoom(CreateRoomRequest request);
    Task<string> UpdateRoom(UpdateRoomRequest request);
    Task<string> DeleteRoom(long id);
    Task<Room> GetRoomById(long id);
    Task<RoomType> CreateRoomType(CreateRoomTypeRequest request);
    Task<string> UpdateRoomType(UpdateRoomTypeRequest request);
    Task<string> DeleteRoomType(long id);
    Task<string> AddRoomTypeToRoom(AddRoomTypeToRoomRequest request);
    Task<List<RoomType>> GetAllTypes();
}