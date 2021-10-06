using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StoreManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region prop for window loaded
        public ICommand LoadedWindowCommand { get; set; }
        public bool IsLoaded = false;
        #endregion

        public ICommand UnitCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand MaterialCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand StockInCommand { get; set; }
        public ICommand StockOutCommand { get; set; }




        public MainViewModel()
        {
            // display once
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {

                
                IsLoaded = true;
                LoginWindow login = new LoginWindow();
                login.ShowDialog();
                
            });

            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                // when true or the user has permission to do so, go into the unit window
                UnitWindow unitWindow = new UnitWindow();
                unitWindow.ShowDialog();

            });

            SupplierCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                // when true or the user has permission to do so, go into the supplier window
                SupplierWindow supplier= new SupplierWindow();
                supplier.ShowDialog();

            });

            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                // when true or the user has permission to do so, go into the customer window
                CustomerWindow customer = new CustomerWindow();
                customer.ShowDialog();

            });

            MaterialCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                // when true or the user has permission to do so, go into the customer window
                MaterialWindow wd = new MaterialWindow();
                wd.ShowDialog();

            });

            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                // when true or the user has permission to do so, go into the customer window
                UserWindow wd = new UserWindow();
                wd.ShowDialog();

            });

            StockInCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                // when true or the user has permission to do so, go into the customer window
                InputWindow wd = new InputWindow();
                wd.ShowDialog();

            });

            StockOutCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                // when true or the user has permission to do so, go into the customer window
                OutputWindow wd = new OutputWindow();
                wd.ShowDialog();

            });



        }
    }
}
