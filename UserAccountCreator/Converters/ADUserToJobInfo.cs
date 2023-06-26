using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UserAccountCreator.Models;
using UserAccountCreator.Views;

namespace UserAccountCreator.Converters
{
    public class ADUserToJobInfo : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is ADUser user)
            {
                var department = ContainerView.DepartmentsFactory.GetDepartmentById(user.DepartmentId);

                return department.DisplayName + " (" + user.JobTitle + ")";
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
