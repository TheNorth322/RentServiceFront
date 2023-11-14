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
   Task<Room> createRoom([Body] CreateRoomRequest request);

   [Get("/room/{id}")]
   Task<Room> getRoomById(long id);

   [Post("/room/type/create")]
   Task<RoomType> createRoomType([Body] CreateRoomTypeRequest request);

   [Post("/room/type/add")]
   Task<string> addRoomTypes([Body] AddRoomTypeToRoomRequest request);
   
   [Get("/room/types")]
   Task<List<RoomType>> getAllTypes();
}