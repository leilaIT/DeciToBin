using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeciToBin
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            if (Application.Current.Windows.Count > 2)
                AllWindows._mainwindowMenu.closeUnnecessary();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AllWindows.ishowToPlay = false;
        }
    }
}
