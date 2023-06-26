using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountCreator.ViewModels.Modals
{
    public interface IModal
    {
        public void OnOpen(object args);
    }
}
