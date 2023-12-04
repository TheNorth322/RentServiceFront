using System.Collections.Generic;
using Newtonsoft.Json;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.model.request.Building;

public class UpdateBuildingRequest
{
    [JsonProperty("id")] public long Id { get; set; }
    
    [JsonProperty("address")] public string Address { get; set; }

    [JsonProperty("addressParts")] public List<AddressPart> AddressParts { get; set; }

    [JsonProperty("floorCount")] public int FloorCount { get; set; }

    [JsonProperty("telephone")] public string Telephone { get; set; }
}