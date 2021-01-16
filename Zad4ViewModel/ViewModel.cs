﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad4Model;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using TP.GraphicalData.ViewModel.MVVMLight;

namespace Zad4ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCategory { get; set; }
        public ICommand RemoveCategory { get; set; }
        public ICommand UpdateCategory { get; set; }
        public ICommand GetAllData { get; set; }

        public ViewModel()
        {
            Model = new Model();
            AddCategory = new RelayCommand(AddMyCategory);
            RemoveCategory = new RelayCommand(RemoveMyCategory);
            UpdateCategory = new RelayCommand(UpdateMyCategory);
            GetAllData = new RelayCommand(() => Model = new Model());
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IModel Model 
        {
            get { return model; }
            set
            {
                model = value;

                Task.Run(() =>
                {
                    ProductCategories = new ObservableCollection<MyCategory>(value.GetAllProductCategories());
                });

            }
        }

        public ObservableCollection<MyCategory> ProductCategories
        {
            get { return productCategories; }
            set
            {
                productCategories = value;
                RaisePropertyChanged();
            }
        }

        public MyCategory ProductCategory
        {
            get
            {
                return productCategory;
            }
            set
            {
                productCategory = value;
                RaisePropertyChanged();
            }
        }

        public void AddMyCategory()
        {
            MyCategory productCategory = new MyCategory(0, Name, DateTime.Today);

            if (productCategory.Name == null || productCategory.Name == "")
            {
                // TODO coś
            }
            else
            {
                Task.Run(() =>
                {
                    model.AddProductCategory(productCategory.Name, productCategory.Date.ToString());
                });
            }
        }

        public void RemoveMyCategory()
        {

            Task.Run(() =>
            {
                if (productCategory.Id == 0)
                {
                    // TODO
                }
                else
                {
                    model.DeleteProductCategory(productCategory.Id);
                }
            });
        }

        public void UpdateMyCategory()
        {
            if (Name == null || Name == "" || productCategory.Id == 0)
            {
                // TODO
            }
            else
            {
                Task.Run(() =>
                { 
                    model.UpdateProductCategory(Name, productCategory.Id);
                });
            }
        }

        private IModel model;
        private MyCategory productCategory;
        private ObservableCollection<MyCategory> productCategories;

        public string Name { get; set; } 

    }
}