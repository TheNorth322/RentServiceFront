using System;
using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class AgreementRoom
{
    public AgreementRoom(long id, Room room, string purposeOfRent, DateTime startOfRent, DateTime endOfRent,
        int rentAmount)
    {
        Id = id;
        Room = room;
        PurposeOfRent = purposeOfRent;
        StartOfRent = startOfRent;
        EndOfRent = endOfRent;
        RentAmount = rentAmount;
    }

    [JsonProperty("id")] public long Id { get; }

    [JsonProperty("room")] public Room Room { get; }

    [JsonProperty("purposeOfRent")] public string PurposeOfRent { get; }

    [JsonProperty("startOfRent")] public DateTime StartOfRent { get; }

    [JsonProperty("endOfRent")] public DateTime EndOfRent { get; }

    [JsonProperty("rentAmount")] public int RentAmount { get; }
}