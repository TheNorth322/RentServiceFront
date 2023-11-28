using System.Collections.Generic;
using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class IndividualUser
{
    public IndividualUser(Passport activePassport, List<Passport> passports)
    {
        ActivePassport = activePassport;
        Passports = passports;
    }

    [JsonProperty("activePassport")] public Passport ActivePassport { get; set; }

    [JsonProperty("passports")] public List<Passport> Passports { get; set; }
}