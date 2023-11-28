using Newtonsoft.Json;

namespace RentServiceFront.domain.model.request.search;

public class SearchAddressesRequest
{
    public SearchAddressesRequest(string query, int count)
    {
        Query = query;
        Count = count;
    }
    
    [JsonProperty("query")]
    public string Query { get; set; }
    
    [JsonProperty("count")]
    public int Count { get; set; }
}