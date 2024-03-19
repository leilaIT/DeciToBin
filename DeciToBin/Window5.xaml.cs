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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
            if (Application.Current.Windows.Count > 2)
                AllWindows._mainwindowMenu.closeUnnecessary();
        }
        private void btnEasy_Click(object sender, RoutedEventArgs e)
        {
            afterModeSelection(60, 32);
        }

        private void btnAdv_Click(object sender, RoutedEventArgs e)
        {
            afterModeSelection(45, 128);
        }

        private void btnHard_Click(object sender, RoutedEventArgs e)
        {
            afterModeSelection(30, 255);
        }
        private void afterModeSelection(int time, int maxRange)
        {
            if (!AllWindows.isStartGame)
            {
                AllWindows._startGame = new Window1(time, maxRange);
                if(time == 30)
                {
                    AllWindows._startGame.tbl128.Text = "?";
                    AllWindows._startGame.tbl64.Text = "?";
                    AllWindows._startGame.tbl32.Text = "?";
                    AllWindows._startGame.tbl16.Text = "?";
                    AllWindows._startGame.tbl8.Text = "?";
                    AllWindows._startGame.tbl4.Text = "?";
                    AllWindows._startGame.tbl2.Text = "?";
                    AllWindows._startGame.tbl1.Text = "?";
                }
                AllWindows.isStartGame = true;
                AllWindows._startGame.Show();
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AllWindows.isGameMode = false;
        }
    }
}
