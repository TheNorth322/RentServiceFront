using System.ComponentModel;

namespace RentServiceFront.domain.enums;

public enum Role
{
    [Description("Физическое лицо")] INVIDIDUAL,
    [Description("Юридическое лицо")] ENTITY,
    [Description("Администратор")] ADMIN
}