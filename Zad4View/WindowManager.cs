using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zad4ViewModel.Interfaces;

namespace Zad4View
{
    public class WindowManager : IMessageBox, IInfoWindow
    {
        public void Show(string err, string errMessage)
        {
            MessageBox.Show(err, errMessage, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowInfoWindow()
        {
            new InfoWindow().Show();
        }
    }
}
