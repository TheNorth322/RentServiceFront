﻿using System.Collections.Generic;
using Newtonsoft.Json;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.model.request.Room;

public class UpdateRoomRequest
{
    public UpdateRoomRequest(long id, long buildingId, bool telephone, double area, int number, int floor, int price, string description, List<RoomType> types, List<RoomImage> roomImages)
    {
        Id = id;
        BuildingId = buildingId;
        Telephone = telephone;
        Area = area;
        Number = number;
        Floor = floor;
        Price = price;
        Description = description;
        Types = types;
        RoomImages = roomImages;
    }

    [JsonProperty("id")] public long Id { get; set; }
    [JsonProperty("buildingId")] public long BuildingId { get; set; }
    [JsonProperty("telephone")] public bool Telephone { get; set; }
    [JsonProperty("area")] public double Area { get; set; }
    [JsonProperty("number")] public int Number { get; set; }
    [JsonProperty("floor")] public int Floor { get; set; }
    [JsonProperty("price")] public int Price { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("types")] public List<RoomType> Types { get; set; }
    [JsonProperty("roomImages")] public List<RoomImage> RoomImages { get; set; }
}