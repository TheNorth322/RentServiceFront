using Newtonsoft.Json;

namespace RentServiceFront.domain.model.request.Address;

public class CreateAddressRequest
{
    public CreateAddressRequest(string name, string fiasId)
    {
        Name = name;
        FiasId = fiasId;
    }

    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("fiasId")]
    public string FiasId { get; set; }
}