using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class Address
{
    public Address(long id, string name, string fiasId)
    {
        Id = id;
        Name = name;
        FiasId = fiasId;
    }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("fias_id")] public string FiasId { get; set; }
}