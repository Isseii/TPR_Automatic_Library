using System;
using System.ComponentModel;
using Zad4ViewModel.Interfaces;

namespace Zad4MVVMTest
{
    public class WindowManager : IMessageBox, IInfoWindow
    {
        public void Show(string err, string errMessage)
        {
            throw new Exception(err);
        }

        public void ShowInfoWindow<T>(T viewModel) where T : INotifyPropertyChanged
        { }
    }
}
