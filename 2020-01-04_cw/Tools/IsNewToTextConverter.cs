using _2020_01_04_cw.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _2020_01_04_cw.Tools
{
    public class IsNewToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var tmpEntity = value as EntityBase;

            string s = string.Empty;

            if (value is Author)
                s = "Author";
            
            if (value is Book)
                s = "Book";

            if ((bool)tmpEntity.IsNew)
                return $"New {s}";
            else
                return $"Edit {s}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}