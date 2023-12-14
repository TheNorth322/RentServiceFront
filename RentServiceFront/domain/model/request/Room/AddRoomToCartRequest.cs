using System;
using Newtonsoft.Json;

namespace RentServiceFront.domain.model.request.Room;

public class AddRoomToCartRequest
{
    public AddRoomToCartRequest(string username, long roomId, DateTime startOfRent, DateTime endOfRent, string purposeOfRent)
    {
        Username = username;
        RoomId = roomId;
        StartOfRent = startOfRent;
        EndOfRent = endOfRent;
        PurposeOfRent = purposeOfRent;
    }

    [JsonProperty("username")] public string Username { get; set; }
    [JsonProperty("roomId")] public long RoomId { get; set; } 
    [JsonProperty("startOfRent")] public DateTime StartOfRent { get; set; }
    [JsonProperty("endOfRent")] public DateTime EndOfRent { get; set; }
    [JsonProperty("purposeOfRent")] public string PurposeOfRent { get; set; } 
}