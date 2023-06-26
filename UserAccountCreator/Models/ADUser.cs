using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccountCreator.Models.Departments;

namespace UserAccountCreator.Models
{
    public class ADUser
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public DepartmentId DepartmentId { get; set; }

        public string JobTitle { get; set; }

        public string FullName => LastName + " " + Name + " " + MiddleName;

    }
}
