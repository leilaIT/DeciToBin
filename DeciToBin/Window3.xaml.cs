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
        private string[] tempArr = new string[] { };
        private List<string[]> sortedlb = new List<string[]>();
        public Window3()
        {
            InitializeComponent();
            readFromCSV("Leaderboard.csv");
        }
        public void getLeaderboardInfo(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine($"{AllWindows._gameOver.name}, " +
                             $"{AllWindows._startGame.roundCount}");
            }
        }
        private void readFromCSV(string fileName)
        {
            string[] tempSort = new string[] { };
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
                for(int x = 0; x < sortedlb.Count; x++)
                {
                    for(int y = 0; y < sortedlb.Count - 1; y++)
                    {
                        if (int.Parse(sortedlb[y][1]) < int.Parse(sortedlb[y + 1][1]))
                        {
                            tempSort = sortedlb[y];
                            sortedlb[y] = sortedlb[y + 1];
                            sortedlb[y + 1] = tempSort;
                        }
                    }
                }

                for(int x = 0; x < sortedlb.Count; x++)
                {
                    if (lbPlayer.Items.Count < 10 && lbScore.Items.Count < 10)
                    {
                        lbPlayer.Items.Add(sortedlb[x][0]);
                        lbScore.Items.Add(sortedlb[x][1]);
                    }
                    else
                        break;
                }
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AllWindows.isLeaderBoard = false;
        }
    }
}
