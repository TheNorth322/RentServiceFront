using System.Collections.Generic;
using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class Building
{
    public Building(long id, string name, Address address, int floorCount, string telephone)
    {
        Id = id;
        Name = name;
        Address = address;
        FloorCount = floorCount;
        Telephone = telephone;
    }

    [JsonProperty("id")] public long Id { get; set; }
    
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("address")] public Address Address { get; set; }

    [JsonProperty("floorCount")] public int FloorCount { get; set; }

    [JsonProperty("telephone")] public string Telephone { get; set; }
}