﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4ViewModel.Interfaces
{
    public interface IInfoWindow
    {
        void ShowInfoWindow<T>(T viewModel) where T : INotifyPropertyChanged;
    }
}
