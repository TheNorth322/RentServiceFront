using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class Bank
{
    public Bank(long id, string name)
    {
        Id = id;
        Name = name;
    }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }
}