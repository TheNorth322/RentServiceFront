using Newtonsoft.Json;

namespace RentServiceFront.domain.model.request.bank;

public class CreateBankRequest
{
    public CreateBankRequest(string name)
    {
        Name = name;
    }

    [JsonProperty("name")]
    public string Name { get; set; } 
    
}