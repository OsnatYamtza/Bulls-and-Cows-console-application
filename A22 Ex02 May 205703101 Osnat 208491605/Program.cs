using System;
using System.Text;
using Ex02.ConsoleUtils;

namespace A22_Ex02_May_205703101_Osnat_208491605
{
    // $G$ DSN-999 (-5) Sequence elements should be represented with an enum.
    // $G$ DSN-999 (-5) Feedback elements should be represented with an enum.
    // $G$ CSS-027 (-15) Spaces are not kept as required after defying variables in all the solution.
    public class Program
    {
        private static void startGame()
        {
            GameLogic gameLogic = new GameLogic();
            gameLogic.Start();
        }

        private static void Main()
        {
            startGame();
        }
    }
}
