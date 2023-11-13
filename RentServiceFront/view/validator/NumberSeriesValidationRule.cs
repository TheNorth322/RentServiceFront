using System.Globalization;
using System.Windows.Controls;

namespace RentServiceFront.view.validator;

public class NumberSeriesValidationRule : ValidationRule
{
    public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
    {
        if (value == null) return ValidationResult.ValidResult;
        if (value.ToString().Length < 11) return new ValidationResult(false, "Неверный формат");
        
        return ((value ?? "").ToString()![4] != ' ')
            ? new ValidationResult(false, "Неверный формат")
            : ValidationResult.ValidResult;
    }
}