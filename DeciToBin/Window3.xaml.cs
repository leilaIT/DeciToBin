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
using System.Windows.Shapes;

namespace DeciToBin
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private List<string[]> sortedlb = new List<string[]>();
        public Window3()
        {
            InitializeComponent();
            if (Application.Current.Windows.Count > 2)
                AllWindows._mainwindowMenu.closeUnnecessary();
        }
        public void getLeaderboardInfo(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine($"{AllWindows._gameOver.name}, " +
                             $"{AllWindows._startGame.roundCount}, " +
                             $"{AllWindows._startGame.playTimeMin}, " +
                             $"{AllWindows._startGame.playTimeSec}, " +
                             $"{AllWindows._startGame.modeChosen}");
            }
        }
        public void readFromCSV(string fileName)
        {
            string[] tempArr = new string[] { };
            string tempWord = "";
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    tempArr = line.Split(',');
                    for (int x = 0; x < tempArr.Length; x++)
                    {
                        if (tempArr[x][0] == ' ') //if first letter is space
                        {
                            tempWord = tempArr[x];
                            tempArr[x] = "";
                            for (int i = 1; i < tempWord.Length; i++)
                                tempArr[x] += tempWord[i];
                        }
                    }
                    sortedlb.Add(tempArr);
                }
                sortInfo();
            }
        }
        private void sortInfo()
        {
            string[] tempSort = new string[] { };

            for (int x = 0; x < sortedlb.Count; x++)
            {
                for (int y = 0; y < sortedlb.Count - 1; y++)
                {
                    if (int.Parse(sortedlb[y][1]) < int.Parse(sortedlb[y + 1][1]))
                        sort(tempSort, y);
                }
            }

            for (int x = 0; x < sortedlb.Count; x++)
            {
                for (int y = 0; y < sortedlb.Count - 1; y++)
                {
                    if (int.Parse(sortedlb[y][1]) == int.Parse(sortedlb[y + 1][1]))
                    {
                        if (int.Parse(sortedlb[y][2]) == int.Parse(sortedlb[y + 1][2]))
                        {
                            if (int.Parse(sortedlb[y][3]) < int.Parse(sortedlb[y + 1][3]))
                                sort(tempSort, y);
                        }
                        else
                        {
                            if (int.Parse(sortedlb[y][2]) < int.Parse(sortedlb[y + 1][2]))
                            sort(tempSort, y);
                        }
                    }
                }
            }

            for (int x = 0; x < sortedlb.Count; x++)
            {
                if (lbPlayer.Items.Count < 10 && lbScore.Items.Count < 10 && lbPlayTime.Items.Count < 10)
                {
                    lbPlayer.Items.Add(sortedlb[x][0]);
                    lbScore.Items.Add(sortedlb[x][1]);
                    lbPlayTime.Items.Add($"{sortedlb[x][2]}:{sortedlb[x][3]}");
                    lbMode.Items.Add($"{sortedlb[x][4]}");
                }
                else
                    break;
            }
        }
        private List<string[]> sort(string[] tempSort, int y)
        {
            tempSort = sortedlb[y];
            sortedlb[y] = sortedlb[y + 1];
            sortedlb[y + 1] = tempSort;

            return sortedlb;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AllWindows.isLeaderBoard = false;
        }
    }
}
