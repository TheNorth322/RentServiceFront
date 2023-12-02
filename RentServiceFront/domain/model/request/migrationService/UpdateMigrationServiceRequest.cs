using System.Collections.Generic;
using Newtonsoft.Json;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.model.request.migrationService;

public class UpdateMigrationServiceRequest
{
    public UpdateMigrationServiceRequest(long id, string name, string addressName, List<AddressPart> addressParts)
    {
        Id = id;
        Name = name;
        AddressName = addressName;
        AddressParts = addressParts;
    }
    
    [JsonProperty("id")] public long Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("addressName")] public string AddressName { get; set; }

    [JsonProperty("addressParts")] public List<AddressPart> AddressParts { get; set; }
}