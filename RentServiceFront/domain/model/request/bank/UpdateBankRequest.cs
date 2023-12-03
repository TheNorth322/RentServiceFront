using Newtonsoft.Json;

namespace RentServiceFront.domain.model.request.bank;

public class UpdateBankRequest
{
    public UpdateBankRequest(long id, string name)
    {
        Id = id;
        Name = name;
    }

    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; } 
}