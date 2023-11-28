using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RentServiceFront.domain.model.enums;

namespace RentServiceFront.domain.model.entity;

public class Agreement
{
    public Agreement(long id, long registrationNumber, PaymentFrequency paymentFrequency, string additionalConditions,
        int fine, DateTime startsFrom, DateTime lastsTo, List<AgreementRoom> rooms)
    {
        Id = id;
        RegistrationNumber = registrationNumber;
        PaymentFrequency = paymentFrequency;
        AdditionalConditions = additionalConditions;
        Fine = fine;
        StartsFrom = startsFrom;
        LastsTo = lastsTo;
        Rooms = rooms;
    }

    [JsonProperty("id")] public long Id { get; }

    [JsonProperty("registrationNumber")] public long RegistrationNumber { get; }

    [JsonProperty("paymentFrequency")] public PaymentFrequency PaymentFrequency { get; }

    [JsonProperty("additionalConditions")] public string AdditionalConditions { get; }

    [JsonProperty("fine")] public int Fine { get; }

    [JsonProperty("startsFrom")] public DateTime StartsFrom { get; }

    [JsonProperty("lastsTo")] public DateTime LastsTo { get; }

    [JsonProperty("rooms")] public List<AgreementRoom> Rooms { get; }
}