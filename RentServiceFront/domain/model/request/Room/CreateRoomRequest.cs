using System.Collections.Generic;

namespace RentServiceFront.domain.model.request.Room;

public class CreateRoomRequest
{
    public long BuildingId { get; set; }
    public bool Telephone { get; set; }
    public double Area { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public List<long> TypesIds { get; set; }
}