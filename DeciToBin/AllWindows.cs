using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeciToBin
{
    internal static class AllWindows
    {
        public static MainWindow _mainwindowMenu = null;
        public static Window1 _startGame = null;
        public static Window2 _howToPlay = null;
        public static Window3 _leaderBoard = null;
        public static Window4 _gameOver = null;

        public static bool ismwMenu = false;
        public static bool isStartGame = false;
        public static bool ishowToPlay = false;
        public static bool isLeaderBoard = false;
        public static bool isGameOver = false;
    }
}
