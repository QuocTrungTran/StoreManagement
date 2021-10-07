using StoreManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StoreManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        private ObservableCollection<UnitInStock> _UnitInStockList;
        public ObservableCollection<UnitInStock> UnitInStockList { get => _UnitInStockList; set { _UnitInStockList = value; OnPropertyChanged(); } }

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
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                // hide main window
                IsLoaded = true;
                if (p == null)
                {
                    return;
                }
                p.Hide();
                // after loging in, show main window
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null) return;
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsLogin)
                {
                    p.Show();
                    LoadUnitInStock();
                } 
                else
                {
                    p.Close();
                }

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


            var a = DataProvider.Ins.DB.Users.ToList();
        }

        void LoadUnitInStock()
        {
            UnitInStockList = new ObservableCollection<UnitInStock>();
            var materialList = DataProvider.Ins.DB.Materials;
            int i = 1;
            foreach (var item in materialList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(p=>p.IdMaterial == item.Id);
                var outputList = DataProvider.Ins.DB.OutputInfoes.Where(p => p.IdMaterial == item.Id);

                var sumInput = 0;
                var sumOutput = 0;

                if (inputList != null)
                {
                    sumInput = (int)inputList.Sum(p => p.Count);
                }
                if (outputList != null)
                {
                    sumOutput = (int)outputList.Sum(p => p.Count);
                }

                UnitInStock unitInStock = new UnitInStock();
                unitInStock.Number = i;
                unitInStock.Count = sumInput - sumOutput;
                unitInStock.Material = item;

                UnitInStockList.Add(unitInStock);

                i++;
            }
        }
    }
}
