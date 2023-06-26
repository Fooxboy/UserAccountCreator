using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UserAccountCreator.Models.Departments;

namespace UserAccountCreator.Converters
{
    public class DepartmentInfoToDeparmentDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is IEnumerable<DepartmentInfo> depInfos)
            {
                return depInfos.Select(x=> x.DisplayName).ToList();
            }

            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
