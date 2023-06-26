using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountCreator.Models.Departments
{
    public class DepartmentsFactory
    {
        private readonly Dictionary<DepartmentId, Department> _departments = new Dictionary<DepartmentId, Department>()
        {
            { DepartmentId.Sales, new Department(){ DisplayName = "Отдел продаж", GroupName = "Отдел продаж", OUName = "Отдел продаж", SharedFolderName = "Отдел продаж"} },
        };

        public Department GetDepartmentById(DepartmentId departmentId) => _departments[departmentId];

        public Dictionary<DepartmentId, Department> GetAll() => _departments;
    }
}
