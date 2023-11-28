using System.ComponentModel;

namespace RentServiceFront.domain.enums;

public enum Role
{
    [Description("Физическое лицо")] INDIVIDUAL,
    [Description("Юридическое лицо")] ENTITY,
    [Description("Администратор")] ADMIN
}