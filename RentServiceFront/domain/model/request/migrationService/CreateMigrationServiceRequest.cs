using System.Collections.Generic;
using Newtonsoft.Json;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.model.request.migrationService;

public class CreateMigrationServiceRequest
{
    public CreateMigrationServiceRequest(string name, string addressName, List<AddressPart> addressParts)
    {
        Name = name;
        AddressName = addressName;
        AddressParts = addressParts;
    }

    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("addressName")] public string AddressName { get; set; }
    [JsonProperty("addressParts")] public List<AddressPart> AddressParts { get; set; }
}