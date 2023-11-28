using Newtonsoft.Json;

namespace RentServiceFront.domain.model.request.search;

public class SearchAddressesRequest
{
    public SearchAddressesRequest(string query, string count)
    {
        Query = query;
        Count = count;
    }
    
    [JsonProperty("query")]
    public string Query { get; set; }
    
    [JsonProperty("count")]
    public string Count { get; set; }
}