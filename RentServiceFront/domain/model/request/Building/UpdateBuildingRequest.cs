using System.Collections.Generic;
using Newtonsoft.Json;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.model.request.Building;

public class UpdateBuildingRequest
{
    public UpdateBuildingRequest(long id, string name, string address, List<AddressPart> addressParts, int floorCount, string telephone)
    {
        Id = id;
        Name = name;
        Address = address;
        AddressParts = addressParts;
        FloorCount = floorCount;
        Telephone = telephone;
    }

    [JsonProperty("id")] public long Id { get; set; }
    
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("address")] public string Address { get; set; }

    [JsonProperty("addressParts")] public List<AddressPart> AddressParts { get; set; }

    [JsonProperty("floorCount")] public int FloorCount { get; set; }

    [JsonProperty("telephone")] public string Telephone { get; set; }
}