using System.Collections.Generic;
using Newtonsoft.Json;

namespace RentServiceFront.domain.model.request.Room;

public class CreateRoomTypeRequest
{
    public CreateRoomTypeRequest(string text)
    {
        Text = text;
    }

    [JsonProperty("text")]
    public string Text { get; set; }  
}