using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class MigrationService
{
    public MigrationService(long id, string name, Address address)
    {
        Id = id;
        Name = name;
        Address = address;
    }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("address")] public Address Address { get; set; }
}