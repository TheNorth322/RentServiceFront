using Newtonsoft.Json;

namespace RentServiceFront.domain.model.entity;

public class EntityUser
{
    public EntityUser(string name, string supervisorFirstName, string supervisorLastName, string supervisorSurname,
        Address address, Bank bank, string checkingAccount, string itnNumber)
    {
        Name = name;
        SupervisorFirstName = supervisorFirstName;
        SupervisorLastName = supervisorLastName;
        SupervisorSurname = supervisorSurname;
        Address = address;
        Bank = bank;
        CheckingAccount = checkingAccount;
        ItnNumber = itnNumber;
    }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("supervisorFirstName")] public string SupervisorFirstName { get; set; }

    [JsonProperty("supervisorLastName")] public string SupervisorLastName { get; set; }

    [JsonProperty("supervisorSurname")] public string SupervisorSurname { get; set; }

    [JsonProperty("address")] public Address Address { get; set; }

    [JsonProperty("bank")] public Bank Bank { get; set; }

    [JsonProperty("checkingAccount")] public string CheckingAccount { get; set; }

    [JsonProperty("itnNumber")] public string ItnNumber { get; set; }
}