using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class Address
{
    public Address(string name, string fiasId)
    {
        Name = name;
        FiasId = fiasId;
    }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("fias_id")] public string FiasId { get; set; }
}