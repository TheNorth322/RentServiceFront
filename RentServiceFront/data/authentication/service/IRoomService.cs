using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Room;

namespace RentServiceFront.data.service;

public interface IRoomService
{
    [Post("/room/create")]
    [Headers("Authorization: Bearer")]
    Task<Room> createRoom([Body] CreateRoomRequest request);

    [Get("/room/{id}")]
    [Headers("Authorization: Bearer")]
    Task<Room> getRoomById(long id);

    [Post("/room/type/create")]
    [Headers("Authorization: Bearer")]
    Task<RoomType> createRoomType([Body] CreateRoomTypeRequest request);

    [Post("/room/type/add")]
    [Headers("Authorization: Bearer")]
    Task<string> addRoomTypes([Body] AddRoomTypeToRoomRequest request);

    [Get("/room/types")]
    [Headers("Authorization: Bearer")]
    Task<List<RoomType>> getAllTypes();
}