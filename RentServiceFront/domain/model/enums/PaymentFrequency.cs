using System.ComponentModel;

namespace RentServiceFront.domain.model.enums;

public enum PaymentFrequency
{
    [Description("Ежемесячная")] MONTHLY,
    [Description("Поквартальная")] QUARTERLY
}