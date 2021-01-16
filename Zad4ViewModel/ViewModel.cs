using System;
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

        public ViewModel()
        {
            AddCategory = new RelayCommand(AddMyCategory);
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
            MyCategory productCategory = new MyCategory(ID, Name, DateTime.Today);

            if (productCategory.Name == null || productCategory.Name == "")
            {
                // TODO coś
            }
            else
            {
                model.AddProductCategory(productCategory.Name, productCategory.Date.ToString());
            }
        }

        private IModel model;
        private MyCategory productCategory;
        private ObservableCollection<MyCategory> productCategories;

        public string Name { get; set; }
        public int ID { get; set; }
    }
}
