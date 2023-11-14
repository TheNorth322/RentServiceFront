using System.Collections.Generic;

namespace RentServiceFront.domain.model.request.Room;

public class AddRoomTypeToRoomRequest
{
    public long RoomId { get; set; }
    public List<long> TypesIds { get; set; }
}