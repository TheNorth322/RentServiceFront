using System.Collections.Generic;

namespace RentServiceFront.domain.model.entity;

public class Room
{
    public long Id { get; set; }
    public bool IsTelephone { get; set; }
    public string Description { get; set; }
    public int Floor { get; set; }
    public int Price { get; set; }
    public int Views { get; set; }
    public int Number { get; set; }
    public int Area { get; set; }
    public List<RoomImage>? Images { get; set; }
    public List<RoomType>? Types { get; set; }
    public Building Building { get; set; }
}