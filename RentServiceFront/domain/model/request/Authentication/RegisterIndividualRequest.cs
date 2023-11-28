using System;
using Newtonsoft.Json;
using RentServiceFront.domain.model.request.passport;

namespace RentServiceFront.domain.model.request;

public class RegisterIndividualRequest
{
    
    [JsonProperty("registerRequest")]
    public RegisterRequest RegisterRequest { get; }
    
    [JsonProperty("addPassportRequest")]
    public AddPassportRequest AddPassportRequest { get; }

    public RegisterIndividualRequest(RegisterRequest registerRequest, AddPassportRequest addPassportRequest)
    {
        RegisterRequest = registerRequest ?? throw new ArgumentException("Register request can't be null");
        AddPassportRequest = addPassportRequest ?? throw new ArgumentException("Add passport request can't be null");
    }
}