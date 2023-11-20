using System;
using System.Collections.Generic;
using RentServiceFront.domain.model.enums;

namespace RentServiceFront.domain.model.entity;

public class Agreement
{
    public long Id { get; }
    public long RegistrationNumber { get; }
    public PaymentFrequency PaymentFrequency { get; }
    public string AdditionalConditions { get; }
    public int Fine { get; }
    public DateTime StartsFrom { get; }
    public DateTime LastsTo { get; }
    public List<AgreementRoom> rooms;
}