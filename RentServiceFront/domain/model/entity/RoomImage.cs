using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class RoomImage
{
    public RoomImage(long id, string url)
    {
        Id = id;
        Url = url;
    }

    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("url")]
    public string Url { get; set; } 
}