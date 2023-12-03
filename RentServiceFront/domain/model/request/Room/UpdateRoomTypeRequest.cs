using Newtonsoft.Json;

namespace RentServiceFront.domain.model.request.Room;

public class UpdateRoomTypeRequest
{
    public UpdateRoomTypeRequest(long id, string text)
    {
        Id = id;
        Text = text;
    }

    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("text")]
    public string Text { get; set; }
}