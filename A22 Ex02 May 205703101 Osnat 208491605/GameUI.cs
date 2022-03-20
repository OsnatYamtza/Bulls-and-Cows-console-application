
using System;
using System.Text;

namespace A22_Ex02_May_205703101_Osnat_208491605
{
    public class GameUI
    {
        public void PrintEnterNumberOfGuesses()
        {
            Console.WriteLine("Hello, please enter number of Maximum guesses desired, between 4-10");
        }

        public void PrintEnterNextGuesses()
        {
            Console.WriteLine("Please type your next guess <ABCD> or 'Q' to quit");
        }

        // input is a number but not in range
        public void MessageWrongGuessesNumberInput()
        {
            Console.WriteLine("Wrong input. Please enter a valid number of guesses only between 4-10 or 'Q' to quit");
        }

        // input is not a number
        public void MessageWrongGuessesNotNumberInput()
        {
            Console.WriteLine("Wrong input. Please enter a valid number of guesses contains only numbers or 'Q' to quit");
        }

        // input is only char but not in range
        public void MessageWrongCharGuessInput()
        {
            Console.WriteLine("Wrong input. Please enter a valid guess between A-H or 'Q' to quit");
        }

        // input has spaces
        public void MessageWrongSpaceGuessInput()
        {
            Console.WriteLine("Wrong input. Please enter a valid guess without spaces or 'Q' to quit");
        }

        // input is not in correct length
        public void MessageWrongLengthGuessInput()
        {
            Console.WriteLine("Wrong input. Please enter a valid guess of exactly 4 characters, without spaces, or 'Q' to quit");
        }

        // input has identical characters
        public void MessageWrongDifferentGuessInput()
        {
            Console.WriteLine("Wrong input. Please enter a valid guess of different characters or 'Q' to quit");
        }

        // end of game, looking for Y/N/Q answers
        public void MessageWrongNewGameInput()
        {
            Console.WriteLine("Wrong input. Would you like to start a new game? (Y/N)");
        }

        public void PrintOverGameGuesses()
        {
            Console.WriteLine("No more guesses allowed. You lost." + Environment.NewLine + "Would you like to start a new game? (Y/N)");
        }

        public void PrintPlayerWin(int count)
        {
            Console.WriteLine("Yuu guessed after " + count + " steps!" + Environment.NewLine + "Would you like to start a new game? (Y/N)");
        }

        public void PrintGoodbye()
        {
            Console.WriteLine(Environment.NewLine + "Goodbye");
            Console.ReadLine();
        }
    }
}
