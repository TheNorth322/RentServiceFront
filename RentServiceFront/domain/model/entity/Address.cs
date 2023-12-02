using System.Collections.Generic;
using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class Address
{
    public Address(string value, List<AddressPart> addressParts)
    {
        Value = value;
        AddressParts = addressParts;
    }

    [JsonProperty("value")] public string Value { get; set; }
    [JsonProperty("addressParts")] public List<AddressPart> AddressParts { get; set; }

}