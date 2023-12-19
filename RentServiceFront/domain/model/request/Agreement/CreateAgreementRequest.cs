using Newtonsoft.Json;
using RentServiceFront.domain.model.enums;

namespace RentServiceFront.domain.model.request.Agreement;

public class CreateAgreementRequest
{
    public CreateAgreementRequest(string username, PaymentFrequency paymentFrequency, string additionalConditions)
    {
        Username = username;
        PaymentFrequency = paymentFrequency;
        AdditionalConditions = additionalConditions;
    }

    [JsonProperty("username")] public string Username { get; set; }
    [JsonProperty("paymentFrequency")] public PaymentFrequency PaymentFrequency { get; set; }
    [JsonProperty("additionalConditions")] public string AdditionalConditions { get; set; }
    
}