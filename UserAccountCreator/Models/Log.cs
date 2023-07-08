using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountCreator.Models
{
    public class Log
    {
        public DateTime CreationTime { get; set; }

        public string Message { get; set; }

        public string? Owner { get; set; }
    }
}
