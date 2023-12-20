using System.Collections.Generic;
using Newtonsoft.Json;
using Refit;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.domain.model.request;

public class RegisterEntityRequest
{
    [JsonProperty("registerRequest")] public RegisterRequest RegisterRequest { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("supervisorFirstName")] public string SupervisorFirstName { get; set; }

    [JsonProperty("supervisorLastName")] public string SupervisorLastName { get; set; }

    [JsonProperty("supervisorSurname")] public string SupervisorSurname { get; set; }

    [JsonProperty("address")] public string Address { get; set; }

    [JsonProperty("addressParts")] public List<AddressPart> AddressParts { get; set; }

    [JsonProperty("bankId")] public long BankId { get; set; }

    [JsonProperty("checkingAccount")] public string CheckingAccount { get; set; }

    [JsonProperty("itnNumber")] public string ItnNumber { get; set; }

    public RegisterEntityRequest(RegisterRequest registerRequest, string name, string supervisorFirstName,
        string supervisorLastName, string supervisorSurname, string address,List<AddressPart> addressParts, long bankId, string checkingAccount,
        string itnNumber)
    {
        RegisterRequest = registerRequest;
        Name = name;
        SupervisorFirstName = supervisorFirstName;
        SupervisorLastName = supervisorLastName;
        SupervisorSurname = supervisorSurname;
        Address = address;
        AddressParts = addressParts;
        BankId = bankId;
        CheckingAccount = checkingAccount;
        ItnNumber = itnNumber;
    }
}