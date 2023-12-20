using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.data.service;

[Headers("Authorization: Bearer")]
public interface IRoomService
{
    [Get("/room/all")]
    Task<List<Room>> GetRooms();

    [Get("/room/available")]
    Task<List<Room>> GetAvailableRooms();

    [Get("/room/available/in/building")]
    Task<List<Room>> GetAvailableRoomsInBuilding(long id);

    [Get("/room/rentals/in/building")]
    Task<List<Room>> GetRoomInBuildingWithRentals();

    [Get("/room/agreement")]
    Task<List<AgreementRoom>> GetAgreementRoomsByAgreementId(long id);

    [Get("/room/agreementRooms")]
    Task<List<AgreementRoom>> GetAgreementRoomsByRoomId(long id);

    [Post("/room/addToCart")]
    Task<string> addRoomToCart([Body] AddRoomToCartRequest request);

    [Post("/room/create")]
    Task<Room> createRoom([Body] CreateRoomRequest request);

    [Put("/room/update")]
    Task<string> updateRoom([Body] UpdateRoomRequest request);

    [Delete("/room/delete")]
    Task<string> deleteRoom([Query] long id);

    [Get("/room/{id}")]
    Task<Room> getRoomById(long id);

    [Post("/room/type/create")]
    Task<RoomType> createRoomType([Body] CreateRoomTypeRequest request);

    [Put("/room/type/update")]
    Task<string> updateRoomType([Body] UpdateRoomTypeRequest request);

    [Delete("/room/type/delete")]
    Task<string> deleteRoomType([Query] long id);

    [Post("/room/type/add")]
    Task<string> addRoomTypes([Body] AddRoomTypeToRoomRequest request);

    [Get("/room/types")]
    Task<List<RoomType>> getAllTypes();
}