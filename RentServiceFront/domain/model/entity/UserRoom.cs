using System;
using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class UserRoom
{
    public UserRoom(long roomId, DateTime startOfRent, DateTime endOfRent)
    {
        RoomId = roomId;
        StartOfRent = startOfRent;
        EndOfRent = endOfRent;
    }
    
    [JsonProperty("roomId")] public long RoomId { get; set; }
    [JsonProperty("startOfRent")] public DateTime StartOfRent { get; set; } 
    [JsonProperty("endOfRent")] public DateTime EndOfRent { get; set; } 
}