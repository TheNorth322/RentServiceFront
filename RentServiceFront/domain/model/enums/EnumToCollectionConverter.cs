using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace RentServiceFront.domain.enums;

public class EnumToCollectionConverter : MarkupExtension, IValueConverter
{
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return EnumHelper.GetAllValuesAndDescriptions(value.GetType());
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return EnumHelper.
    }
}