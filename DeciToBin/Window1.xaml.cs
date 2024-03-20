using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DeciToBin
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DispatcherTimer _timer = null;
        public DispatcherTimer _playTime = null;
        private Stack<string> bits = new Stack<string>();
        private Random rnd = new Random();
        public TextBox[] txtbox = new TextBox[] { };
        private int deciNum = 0;
        private int tempVal = 0;
        private int roundTime = 0;
        private int maxNum = 0;
        private int maxTime = 0;
        public int playTimeMin = 0;
        public int playTimeSec = 0;
        public string modeChosen = "";
        private int reduction = 0;
        public int roundCount = 0;
        public Window1(int time, int maxRange, string mode)
        {
            InitializeComponent();
           
            if(Application.Current.Windows.Count > 2)
                AllWindows._mainwindowMenu.closeUnnecessary();

            txtbox = new TextBox[] { tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8 };
            
            _timer = new DispatcherTimer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            
            _playTime = new DispatcherTimer();
            _playTime.Tick += _playTime_Tick;
            _playTime.Interval = new TimeSpan(0, 0, 0, 1, 0);
            
            modeChosen = mode;
            maxNum = maxRange;
            maxTime = time;
            roundTime = time;
            reduction = (int)Math.Ceiling(maxTime * 0.066); //reduc each round
            gameStart();
        }
        #region game_functions
        private void gameStart()
        {
            tblRound.Text = $"Round {roundCount + 1}";
            if (roundCount > 0)
                timerReduction();
            generateRandom();
            convertDecToBinary();
            for (int i = 0; i < txtbox.Length; i++)
                txtbox[i].Text = "0";
            _playTime.Start();
            _timer.Start();
        }
        private void checkAns()
        {
            bool isCorrect = true;
            string[] ansArr = new string[] { };
            string answer = "";

            for (int i = 0; i < txtbox.Length; i++)
                answer += txtbox[i].Text;

            ansArr = bits.ToArray();
            for (int x = 0; x < answer.Length; x++)
            {
                if (answer[x].ToString() != ansArr[x])
                {
                    soundWrong.Position = new TimeSpan(0, 0, 0);
                    soundWrong.Play();
                    isCorrect = false;
                    break;
                }
            }
            if (isCorrect)
            {
                _timer.Stop();
                soundCorrect.Position = new TimeSpan(0, 0, 0);
                soundCorrect.Play();
                roundCount++;
                gameStart();
            }
        }
        #endregion

        #region timer_stuff
        private void _playTime_Tick(object sender, EventArgs e)
        {
            playTimeSec++;

            if(playTimeSec > 59)
            {
                playTimeMin++;
                playTimeSec = 0;
            }

            if (roundTime < -1)
            {
                _playTime.Stop();
            }
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Content = roundTime;

            if(roundTime > 10)
            {
                soundTick.Position = new TimeSpan(0, 0, 0);
                soundTick.Play();
            }
            else
            {
                sound10left.Play();
            }
            roundTime--;

            if (roundTime < 0)
            {
                sound10left.Stop();
                soundTimesup.Play();
                _timer.Stop();
                sound10left.Position = new TimeSpan(0, 0, 0);
                soundTimesup.Position = new TimeSpan(0, 0, 0);
                AllWindows._gameOver = new Window4();
                AllWindows.isGameOver = true;
                AllWindows._gameOver.Show();
                roundTime = 0;
                this.Close();
                AllWindows._gameOver.isSelected = true;
            }
        }
        private void timerReduction()
        {
            if(roundCount < 11)
                maxTime = maxTime - reduction;
            roundTime = maxTime;
        }
        #endregion

        #region deci_to_bin
        private void generateRandom()
        {
            deciNum = rnd.Next(0, maxNum) + 1;
            tblDecimal.Text = deciNum.ToString();
        }
        private void convertDecToBinary()
        {
            bits = new Stack<string>();

            while (deciNum > 0)
            {
                if (deciNum % 2 == 1)
                {
                    bits.Push("1");
                    deciNum--;
                }
                else
                    bits.Push("0");

                deciNum = deciNum / 2;
            }

            while (bits.Count != 8)
                bits.Push("0");
        }
        #endregion

        #region input_events
        private void tb1_input(object sender, TextChangedEventArgs e)
        {

        }

        private void tb2_input(object sender, TextChangedEventArgs e)
        {

        }

        private void tb3_input(object sender, TextChangedEventArgs e)
        {

        }

        private void tb4_input(object sender, TextChangedEventArgs e)
        {

        }

        private void tb5_input(object sender, TextChangedEventArgs e)
        {

        }

        private void tb6_input(object sender, TextChangedEventArgs e)
        {

        }

        private void tb7_input(object sender, TextChangedEventArgs e)
        {

        }

        private void tb8_input(object sender, TextChangedEventArgs e)
        {

        }
        #endregion

        #region keyUp_events
        private void changeValues(string value)
        {
            tempVal = int.Parse(value);
            if (tempVal == 0)
                tempVal = 1;
            else if (tempVal == 1)
                tempVal = 0;
        }
        private void tb1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                changeValues(txtbox[0].Text);
                txtbox[0].Text = tempVal.ToString();
            }

            if (e.Key == Key.Right)
                txtbox[1].Focus();
            if (e.Key == Key.Left)
                btnCheck.Focus();
        }

        private void tb2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                changeValues(txtbox[1].Text);
                txtbox[1].Text = tempVal.ToString();
            }

            if (e.Key == Key.Right)
                txtbox[2].Focus();
            else if (e.Key == Key.Left)
                txtbox[0].Focus();
        }

        private void tb3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                changeValues(txtbox[2].Text);
                txtbox[2].Text = tempVal.ToString();
            }

            if (e.Key == Key.Right)
                txtbox[3].Focus();
            else if (e.Key == Key.Left)
                txtbox[1].Focus();
        }

        private void tb4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                changeValues(txtbox[3].Text);
                txtbox[3].Text = tempVal.ToString();
            }

            if (e.Key == Key.Right)
                txtbox[4].Focus();
            else if (e.Key == Key.Left)
                txtbox[2].Focus();
        }

        private void tb5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                changeValues(txtbox[4].Text);
                txtbox[4].Text = tempVal.ToString();
            }

            if (e.Key == Key.Right)
                txtbox[5].Focus();
            else if (e.Key == Key.Left)
                txtbox[3].Focus();
        }

        private void tb6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                changeValues(txtbox[5].Text);
                txtbox[5].Text = tempVal.ToString();
            }

            if (e.Key == Key.Right)
                txtbox[6].Focus();
            else if (e.Key == Key.Left)
                txtbox[4].Focus();
        }

        private void tb7_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                changeValues(txtbox[6].Text);
                txtbox[6].Text = tempVal.ToString();
            }

            if (e.Key == Key.Right)
                txtbox[7].Focus();
            else if (e.Key == Key.Left)
                txtbox[5].Focus();
        }

        private void tb8_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                changeValues(txtbox[7].Text);
                txtbox[7].Text = tempVal.ToString();
            }

            if (e.Key == Key.Left)
                txtbox[6].Focus();

            if (e.Key == Key.Down)
                btnCheck.Focus();
        }
        #endregion
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            checkAns();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AllWindows.isStartGame = false;
            _timer.Stop();
        }
    }
}