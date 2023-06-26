using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountCreator.Models
{
    public class Config
    {
        [Key]
        public int Id { get; set; }
        public List<string> DCs { get; set; }

        public string Login { get; set; }

        public string DefaultUserPasswordAD { get; set; }

        public string SharedDriveLocation { get; set; }

        public string AdminsGroupName { get; set; }

        public string UserNameTemplate { get; set; }

        public string EmailTemplate { get; set; }

    }
}
