using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using RentServiceFront.domain.enums;

namespace RentServiceFront.viewmodel;

public class RoleToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Role role && parameter is Role targetRole)
        {
            return role == targetRole ? Visibility.Visible : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}