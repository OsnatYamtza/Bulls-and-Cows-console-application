using System;
using System.Text;
using Ex02.ConsoleUtils;

namespace A22_Ex02_May_205703101_Osnat_208491605
{
    public class GameLogic
    {
        // $G$ NTT-999 (-5) This memmber should be readonly.
        private GameBoard m_Board;
        // $G$ NTT-999 (-5) This memmber should be readonly.
        private GameUI m_GameUI;
        private int m_CountMovesOfGame;
        private bool isIfEndGame;
        private char[] m_ComputerRandomGuessWord;

        public GameLogic()
        {
            m_Board = new GameBoard();
            m_GameUI = new GameUI();
            m_ComputerRandomGuessWord = new char[4];
            isIfEndGame = false;
        }

        public void Start()
        {
            startGame();
        }

        // $G$ DSN-002 (-7) You should not make UI calls from your logic classes.
        private void startGame()
        {
            // first row
            int numberOfRows = 2;
            string playerGuess;
            getGuessesNumberFromUser();

            // first print empty board game
            if (!isIfEndGame)
            {
                initiateGame();
                printBoard();
            }

            // get the random guess of the computer
            m_ComputerRandomGuessWord = computerRandomGuess();

            // As long as we have another game
            while (!isIfEndGame)
            {
                string computerRandomGuessWordString = new string(m_ComputerRandomGuessWord);

                // get the player guess
                playerGuess = getPlayerGuess();

                // case end og game - input is Q
                if (isIfEndGame == true)
                {
                    break;
                }

                copyUserGuessToBoard(playerGuess, numberOfRows);
                checkUserGuessRight(playerGuess, computerRandomGuessWordString, numberOfRows, m_CountMovesOfGame);

                // case end of game
                if (isIfEndGame == true)
                {
                    break;
                }

                numberOfRows++;
                m_CountMovesOfGame++;

                // end of guesses number
                if (m_CountMovesOfGame > m_Board.m_GuessesNumber)
                {
                    m_Board.ComputerRandomGuessOnBoard(computerRandomGuessWordString);
                    m_GameUI.PrintOverGameGuesses();
                    getInputGameOverIsValid();
                    if (isIfEndGame == true)
                    {
                        break;
                    }

                    // start a new game
                    Start();
                }
            }

            // end of game
            m_GameUI.PrintGoodbye();
        }

        private void copyUserGuessToBoard(string io_playerGuess, int io_NumberOfRows)
        {
            int colNumbers = 0;
            int userGuessChar = 0;
            foreach (char c in io_playerGuess)
            {
                m_Board.m_Matrix[io_NumberOfRows, colNumbers] = io_playerGuess.ToCharArray()[userGuessChar];
                colNumbers++;
                userGuessChar++;
            }
        }

        // $G$ NTT-007 (-10) There's no need to re-instantiate the Random instance each time it is used.
        // computer's random guess
        private char[] computerRandomGuess()
        {
            int i = 0, j;
            while (i < 4)
            {
                Random rnd = new Random();
                char randomChar = (char)rnd.Next('A', 'H');
                if (i == 0)
                {
                    m_ComputerRandomGuessWord[i] = (char)randomChar;
                    i++;
                }
                else
                {
                    for (j = i; j > 0; j--)
                    {
                        if ((char)randomChar == (char)m_ComputerRandomGuessWord[j - 1])
                        {
                            break;
                        }
                    }

                    if (j == 0)
                    {
                        m_ComputerRandomGuessWord[i] = randomChar;
                        i++;
                    }
                }
            }

            return m_ComputerRandomGuessWord;
        }

        // $G$ CSS-999 (-1) The using of the word "true" here is redundant.
        // $G$ CSS-999 (-1) Use ! operator instead of == false.
        // case game is over - new game or not
        private void getInputGameOverIsValid()
        {
            string userInput;
            bool resulty, resultY, resultN, resultn;
            userInput = getUserInput();

            resulty = userInput.Equals("y");
            resultY = userInput.Equals("Y");
            resultN = userInput.Equals("N");
            resultn = userInput.Equals("n");

            while (!(userInput == "q") && !(userInput == "Q") && resulty == false && resultY == false && resultN == false && resultn == false)
            {
                m_GameUI.MessageWrongNewGameInput();
                m_GameUI.PrintOverGameGuesses();
                userInput = getUserInput();
            }

            if (userInput == "q" || userInput == "Q" || resultN == true || resultn == true)
            {
                isIfEndGame = true;
            }
            else
            {
                isIfEndGame = false;
            }

            // case input was Y/y - new game
            Ex02.ConsoleUtils.Screen.Clear();
        }

        // $G$ CSS-999 (-1) Use ! operator instead of == false.
        // the check of the user guess
        private void checkUserGuessRight(string io_PlayerGuess, string i_ComputerGuess, int i_Rownumber, int i_CountSteps)
        {
            int colNumbers = 6;

            // case the user win
            if (io_PlayerGuess == i_ComputerGuess)
            {
                userWin(i_Rownumber, colNumbers, i_CountSteps);
                getInputGameOverIsValid();
                if (isIfEndGame == false)
                {
                    Start();
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (io_PlayerGuess.ToCharArray()[i] == i_ComputerGuess.ToCharArray()[i])
                    {
                        m_Board.m_Matrix[i_Rownumber, colNumbers] = 'V';
                        colNumbers++;
                        StringBuilder playerGuessnew = new StringBuilder(io_PlayerGuess);
                        playerGuessnew[i] = '0';
                        io_PlayerGuess = playerGuessnew.ToString();
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (io_PlayerGuess.ToCharArray()[i] == i_ComputerGuess.ToCharArray()[j])
                        {
                            m_Board.m_Matrix[i_Rownumber, colNumbers] = 'X';
                            colNumbers++;
                        }
                    }
                }

                printBoard();
            }
        }

        private void userWin(int i_RowNumber, int i_ColNumber, int i_CountGame)
        {
            while (i_ColNumber < 10)
            {
                m_Board.m_Matrix[i_RowNumber, i_ColNumber] = 'V';
                i_ColNumber++;
            }

            printBoard();
            printPlayerWin(i_CountGame);
        }

        private void printPlayerWin(int io_CountSteps)
        {
            m_GameUI.PrintPlayerWin(io_CountSteps);
        }

        // $G$ CSS-999 (-1) The using of the word "true" here is redundant.
        // $G$ CSS-999 (-1) Use ! operator instead of == false.
        // $G$ CSS-999 (-5) You should use constant vars and not constant values.
        private string getPlayerGuess()
        {
            string userInput;
            bool checkIfValidGuess = true;
            m_GameUI.PrintEnterNextGuesses();
            userInput = getUserInput();

            while (checkIfValidGuess)
            {
                if (userInput == "q" || userInput == "Q")
                {
                    isIfEndGame = true;
                    break;
                }

                foreach (char c in userInput)
                {
                    if ((int)c > 72 || (int)c < 65)
                    {
                        // check if only the right characters include
                       m_GameUI.MessageWrongCharGuessInput();
                       checkIfValidGuess = true;
                       break;
                    }

                    // check the size is 4
                    if (userInput.Length != 4)
                    {
                        m_GameUI.MessageWrongLengthGuessInput();
                        checkIfValidGuess = true;
                        break;
                    }

                    checkIfValidGuess = false;
                }

                if (checkIfValidGuess == true)
                {
                    userInput = getUserInput();
                }
            }

            if (checkIfValidGuess == false)
            {
                for (int i = 0; i <= userInput.Length; i++)
                {
                    for (int j = i + 1; j < userInput.Length; j++)
                    {
                        if (userInput.ToCharArray()[i] == userInput.ToCharArray()[j])
                        {
                            // check different characters
                            m_GameUI.MessageWrongDifferentGuessInput();
                            userInput = getUserInput();
                            break;
                        }
                    }
                }
            }

            return userInput;
        }

        private void printBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            m_Board.PrintBoard();
        }
        
        // $G$ CSS-999 (-1) Use ! operator instead of == false.
        private void getGuessesNumberFromUser()
        {
            string userInput;
            int isGuessNumber;
            bool isUserEnteredNumber;

            m_GameUI.PrintEnterNumberOfGuesses();
            userInput = getUserInput();
            isUserEnteredNumber = int.TryParse(userInput, out isGuessNumber);

            while ((!isUserEnteredNumber) || isGuessNumber < 4 || isGuessNumber > 10)
            {
                if (userInput == "q" || userInput == "Q")
                {
                    isIfEndGame = true;
                    break;
                }

                // case not a number
                if (!isUserEnteredNumber)
                {
                    m_GameUI.MessageWrongGuessesNotNumberInput();
                    userInput = getUserInput();
                    isUserEnteredNumber = int.TryParse(userInput, out isGuessNumber);
                }

                // case number not in range
                else if (isGuessNumber < 4 || isGuessNumber > 10)
                {
                    m_GameUI.MessageWrongGuessesNumberInput();
                    userInput = getUserInput();
                    isUserEnteredNumber = int.TryParse(userInput, out isGuessNumber);
                }
            }

            if (isIfEndGame == false)
            {
                m_Board.m_GuessesNumber = int.Parse(userInput);
            }
        }

        // $G$ CSS-027 (-3) Spaces are not kept as required before return statement
        private string getUserInput()
        {
            string userInput;

            userInput = Console.ReadLine();
            return userInput;
        }

        private void initiateGame()
        {
            m_Board.InitiateBoard();
            m_CountMovesOfGame = 1;
        }
    }
}
