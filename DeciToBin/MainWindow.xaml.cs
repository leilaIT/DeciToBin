using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeciToBin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!AllWindows.ismwMenu)
            {
                AllWindows._mainwindowMenu = this;
                AllWindows.ismwMenu = true;
            }
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!AllWindows.isGameMode)
            {
                AllWindows._gameMode = new Window5();
                AllWindows.isGameMode = true;
                AllWindows._gameMode.Show();
            }
        }

        private void btnHowToPlay_Click(object sender, RoutedEventArgs e)
        {
            if (!AllWindows.ishowToPlay)
            {
                AllWindows._howToPlay = new Window2();
                AllWindows.ishowToPlay = true;
                AllWindows._howToPlay.Show();
            }
        }

        private void btnLB_Click(object sender, RoutedEventArgs e)
        {
            if (!AllWindows.isLeaderBoard)
            {
                AllWindows._leaderBoard = new Window3();
                AllWindows.isLeaderBoard = true;
                AllWindows._leaderBoard.Show();
            }
        }
    }
}
