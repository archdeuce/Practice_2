using _2020_01_04_cw.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace _2020_01_04_cw.Tools
{
    public class LanguageToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new SolidColorBrush(Colors.White);

            switch (value.ToString())
            {
                case "English":
                    return new SolidColorBrush(Colors.Aqua);
                case "Russian":
                    return new SolidColorBrush(Colors.Pink);
                case "German":
                    return new SolidColorBrush(Colors.LightGreen);
                case "Franch":
                    return new SolidColorBrush(Colors.LightYellow);
                default:
                    return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}