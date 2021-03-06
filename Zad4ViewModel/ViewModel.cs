﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using TP.GraphicalData.ViewModel.MVVMLight;
using Zad4ViewModel.Interfaces;

namespace Zad4ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCategory { get; set; }
        public ICommand RemoveCategory { get; set; }
        public ICommand UpdateCategory { get; set; }
        public ICommand GetAllData { get; set; }
        public ICommand Info { get; set; }

        public IInfoWindow InfoWindow { get; set; }
        public IMessageBox MessageBox { get; set; }

        public bool disableAsync { get; set; }

        public ViewModel()
        {
            Model = new ModelWrapper();
            AddCategory = new RelayCommand(AddMyCategory);
            RemoveCategory = new RelayCommand(RemoveMyCategory);
            UpdateCategory = new RelayCommand(UpdateMyCategory);
            GetAllData = new RelayCommand(() => Model = new ModelWrapper());
            Info = new RelayCommand(GetInfo);
        }

        public ViewModel(IModelWrapper model) 
        {
            this.model = model;
            ProductCategories = new ObservableCollection<MyCategory>(model.GetAllProductCategories());
            AddCategory = new RelayCommand(AddMyCategory);
            RemoveCategory = new RelayCommand(RemoveMyCategory);
            UpdateCategory = new RelayCommand(UpdateMyCategory);
            GetAllData = new RelayCommand(() => ProductCategories = new ObservableCollection<MyCategory>(Model.GetAllProductCategories()));
            Info = new RelayCommand(GetInfo);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IModelWrapper Model 
        {
            get { return model; }
            set
            {
                model = value;

                handleAsync(() =>
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

        public ObservableCollection<MyCategory> ProductCategoriesInfo
        {
            get { return productCategoriesInfo; }
            set
            {
                productCategoriesInfo = value;
                RaisePropertyChanged();
            }
        }

        public MyCategory ProductCategoryInfo
        {
            get
            {
                return productCategoryInfo;
            }
            set
            {
                productCategoryInfo = value;
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
                MessageBox.Show("Name field incorrect value", "Error");
            }
            else
            {
                handleAsync(() =>
                {
                    model.AddProductCategory(productCategory.Name, productCategory.Date.ToString());
                });
            }
        }

        public void RemoveMyCategory()
        {
            if (productCategory.Id == 0)
            {
                MessageBox.Show("Id field incorrect value", "Error");
            }
            else
            {
                try
                {
                    handleAsync(() => model.DeleteProductCategory(productCategory.Id));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Sql forbidden operation");
                }
            }
        }

        public void UpdateMyCategory()
        {
            if (Name == null || Name == "" || productCategory.Id == 0)
            {
                MessageBox.Show("Name field incorrect value", "Error");
            }
            else
            {
                handleAsync(() =>
                {
                    model.UpdateProductCategory(Name, productCategory.Id);
                });
            }
        }

        public void GetInfo()
        {

            if (productCategory == null)
            {
                MessageBox.Show("Select any object!", "Error");

            }
            else
            {
                handleAsync(() =>
                {
                    ProductCategoriesInfo = new ObservableCollection<MyCategory>();
                    ProductCategoriesInfo.Add(model.GetMyProductCategoryById(productCategory.Id).First());
                    ProductCategoryInfo = model.GetMyProductCategoryById(productCategory.Id).First();
                });

            InfoWindow.ShowInfoWindow(this);
            }
        }
        private void handleAsync(Action a)
        {
            if (disableAsync)
            {
                a();
            }
            else
            {
                Task.Run(a);
            }
        }

        private IModelWrapper model;
        private MyCategory productCategory;
        private ObservableCollection<MyCategory> productCategories;
        private MyCategory productCategoryInfo;
        private ObservableCollection<MyCategory> productCategoriesInfo;
        public string Name { get; set; } 

    }
}
