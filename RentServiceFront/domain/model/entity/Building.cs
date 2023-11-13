using System.Collections.Generic;

namespace RentServiceFront.domain.model.entity;

public class Building
{
    public long Id { get; set; }
    //TODO ADD FIAS
    public string Address { get; set; }
    public int FloorCount { get; set; }
    public string Telephone { get; set; }
    public List<Room> Rooms;
}