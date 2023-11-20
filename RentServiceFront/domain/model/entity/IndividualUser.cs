using System.Collections.Generic;

namespace RentServiceFront.domain.model.entity;

public class IndividualUser
{
    public Passport ActivePassport { get; set; }
    public List<Passport> Passports { get; set; }
}