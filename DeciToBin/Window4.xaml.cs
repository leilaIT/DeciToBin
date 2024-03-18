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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public string name = "";
        public bool isSelected = false;
        public Window4()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AllWindows.isGameOver = false;
        }
        private void tbName_input(object sender, TextChangedEventArgs e)
        {
            tbNameInput.Foreground = new SolidColorBrush(Color.FromRgb(112, 41, 99));
        }
        private void tbNameInput_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                name = tbNameInput.Text;
                AllWindows._leaderBoard = new Window3();
                AllWindows.isLeaderBoard = true;
                AllWindows._leaderBoard.getLeaderboardInfo("Leaderboard.csv");
                this.Close();
            }
        }
        private void tbNameInput_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (isSelected)
            {
                tbNameInput.Text = "";
                isSelected = false;
            }
        }
    }
}
