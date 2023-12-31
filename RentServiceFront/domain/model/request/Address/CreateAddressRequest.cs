﻿using System.Collections.Generic;
using Newtonsoft.Json;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.model.request.Address;

public class CreateAddressRequest
{
    public CreateAddressRequest(string name, List<AddressPart> addressParts)
    {
        Name = name;
        AddressParts = addressParts;
    }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("addressParts")] public List<AddressPart> AddressParts { get; set; }
}