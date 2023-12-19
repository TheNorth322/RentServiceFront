using System.Collections.Generic;
using Newtonsoft.Json;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.model.request.Room;

public class CreateRoomRequest
{
    public CreateRoomRequest(long buildingId, bool telephone, double area, int number, int floor, int price, int fine, string description, List<RoomType> types,
        List<RoomImage> roomImages)
    {
        BuildingId = buildingId;
        Telephone = telephone;
        Area = area;
        Number = number;
        Floor = floor;
        Price = price;
        Fine = fine;
        Description = description;
        Types = types;
        RoomImages = roomImages;
    }

    [JsonProperty("buildingId")] public long BuildingId { get; set; }
    [JsonProperty("telephone")] public bool Telephone { get; set; }
    [JsonProperty("area")] public double Area { get; set; }
    [JsonProperty("number")] public int Number { get; set; }
    [JsonProperty("floor")] public int Floor { get; set; }
    
    [JsonProperty("price")] public int Price { get; set; }
    
    [JsonProperty("fine")] public int Fine { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("types")] public List<RoomType> Types { get; set; }
    [JsonProperty("roomImages")] public List<RoomImage> RoomImages { get; set; }
}