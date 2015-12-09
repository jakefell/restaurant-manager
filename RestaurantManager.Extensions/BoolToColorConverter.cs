using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; }

        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color result = Colors.Transparent;

            if (value is bool)
            {
                result = (bool)value ? TrueColor : FalseColor;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool? result = null;

            if (value is Color)
            {
                if ((Color)value == TrueColor)
                    result = true;
                else if ((Color)value == FalseColor)
                    result = false;
            }

            return result;
        }
    }
}
