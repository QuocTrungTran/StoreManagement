using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StoreManagement.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }

        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }

        #endregion

        //Constructor
        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false:true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                // if w is not the type window, it could be other type
                if (w  != null)
                {
                    w.Close();
                }
            });

            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                // if w is not the type window, it could be other type
                if (w != null)
                {
                    if (w.WindowState != WindowState.Minimized)
                    {
                        w.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        w.WindowState = WindowState.Maximized;
                    }
                }
            });

            MaximizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                // if w is not the type window, it could be other type
                if (w != null)
                {
                    if (w.WindowState != WindowState.Maximized)
                    {
                        w.WindowState = WindowState.Maximized;
                    } else
                    {
                        w.WindowState = WindowState.Normal;
                    }
                    
                }
            });

            MouseMoveWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                // if w is not the type window, it could be other type
                if (w != null)
                {
                    w.DragMove();
                }
            });

        }

        /// <summary>
        /// Function to get the window of a xaml file
        /// </summary>
        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement t = p as FrameworkElement;
            while (t.Parent != null)
            {
                t = t.Parent as FrameworkElement;
            }
            return t;
        }

    }
}
