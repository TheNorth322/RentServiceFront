using System;

namespace RentServiceFront.domain.model.entity;

public class AgreementRoom
{
    public long Id { get; }
    public Room Room { get; }
    public string PurposeOfRent { get; }
    public DateTime StartOfRent { get; }
    public DateTime EndOfRent { get; }
    public int RentAmount { get; }  
}