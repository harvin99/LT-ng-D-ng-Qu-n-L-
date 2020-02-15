using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DA_LTUD
{
    class StatusInvoiceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result;
            if (int.Parse(value.ToString()) == 1)
            {
                result = "Chưa Giao";
            }
            else if (int.Parse(value.ToString()) == 2)
            {
                result = "Đã Giao";
            }
            else
            {
                result = "Đã Hủy";
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
