using System.Collections.Generic;
using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class Room
{
    public Room(long id, bool isTelephone, string description, int floor, int price, int number, double area, List<RoomImage>? images, List<RoomType>? types, Building building)
    {
        Id = id;
        IsTelephone = isTelephone;
        Description = description;
        Floor = floor;
        Price = price;
        Number = number;
        Area = area;
        Images = images;
        Types = types;
        Building = building;
    }

    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("isTelephone")]
    public bool IsTelephone { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("floor")]
    public int Floor { get; set; }
    
    [JsonProperty("price")]
    public int Price { get; set; }
    
    [JsonProperty("fine")]
    public int Fine { get; set; }
    
    [JsonProperty("number")]
    public int Number { get; set; }
    
    [JsonProperty("area")]
    public double Area { get; set; }
    
    [JsonProperty("images")]
    public List<RoomImage>? Images { get; set; }
    
    [JsonProperty("types")]
    public List<RoomType>? Types { get; set; }
    
    [JsonProperty("building")]
    public Building Building { get; set; }
}