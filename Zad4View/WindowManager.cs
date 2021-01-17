using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void ShowInfoWindow<T>(T viewModel) where T : INotifyPropertyChanged
        {
            var window = new InfoWindow();
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
