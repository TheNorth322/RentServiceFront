using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class RoomType
{
    public RoomType(long id, string text)
    {
        Id = id;
        Text = text;
    }

    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("text")]
    public string Text { get; set; }
}