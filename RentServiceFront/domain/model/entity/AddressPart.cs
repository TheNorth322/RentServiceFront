using System.Text.Json;
using Newtonsoft.Json;
using RentServiceFront.domain.model.enums;

namespace RentServiceFront.domain.model.entity;

public class AddressPart
{
    public AddressPart(string objectGuid, string name, string typeName, string fullTypeName, AddressLevel level)
    {
        ObjectGuid = objectGuid;
        Name = name;
        TypeName = typeName;
        FullTypeName = fullTypeName;
        Level = level;
    }
    [JsonProperty("objectGuid")]
    public string ObjectGuid { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("typeName")]
    public string TypeName { get; set; }
    
    [JsonProperty("fullTypeName")]
    public string FullTypeName { get; set; }
    
    [JsonProperty("level")]
    public AddressLevel Level { get; set; }
}