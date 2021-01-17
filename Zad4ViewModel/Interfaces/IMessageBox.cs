using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4ViewModel.Interfaces
{
    public interface IMessageBox
    {
        void Show(string err, string errMessage);
    }
}
