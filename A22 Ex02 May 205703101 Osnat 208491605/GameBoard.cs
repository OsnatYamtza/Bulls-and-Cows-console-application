using System;
using Ex02.ConsoleUtils;

namespace A22_Ex02_May_205703101_Osnat_208491605
{
    public class GameBoard
    {
        public char[,] m_Matrix;
        public int m_GuessesNumber;
        private const int k_MatrixCols = 13;
        private readonly int r_MatrixRows;

        public GameBoard()
        {
            m_GuessesNumber = 0;
            r_MatrixRows = m_GuessesNumber + 3;
        }

        // initiate the bord at first place
        public void InitiateBoard()
        {
            m_Matrix = new char[m_GuessesNumber + 3, k_MatrixCols];
            for (int i = 0; i < m_GuessesNumber + 3; i++)
            {
                for (int j = 0; j < k_MatrixCols; j++)
                {
                    m_Matrix[i, j] = ' ';
                }
            }

            m_Matrix[0, 0] = 'P';
            m_Matrix[0, 1] = 'i';
            m_Matrix[0, 2] = 'n';
            m_Matrix[0, 3] = 's';
            m_Matrix[0, 4] = ':';
            m_Matrix[0, 6] = 'R';
            m_Matrix[0, 7] = 'e';
            m_Matrix[0, 8] = 's';
            m_Matrix[0, 9] = 'u';
            m_Matrix[0, 10] = 'l';
            m_Matrix[0, 11] = 't';
            m_Matrix[0, 12] = ':';
            m_Matrix[1, 0] = '#';
            m_Matrix[1, 1] = '#';
            m_Matrix[1, 2] = '#';
            m_Matrix[1, 3] = '#';
        }

        public void PrintBoard()
        {
            Console.Write("Current board status:" + Environment.NewLine + Environment.NewLine);
            for (int i = 0; i < m_GuessesNumber + 2; i++)
            {
                Console.Write("|");
                for (int j = 0; j < k_MatrixCols; j++)
                {
                    if (j == 6)
                    {
                        Console.Write("|" + m_Matrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(m_Matrix[i, j] + " ");
                    }
                }

                Console.Write("|" + Environment.NewLine);
                for (int j = 0; j < k_MatrixCols + 1; j++)
                {
                    Console.Write("==");
                }

                Console.Write("=" + Environment.NewLine);
            }
        }

        // $G$ CSS-013 (-5) Bad parameter name (should be in the form of i_PascalCase).
        // put random computer guess on board
        public void ComputerRandomGuessOnBoard(string io_ComputerGuess)
        {
            int i = 0;
            foreach (char s in io_ComputerGuess)
            {
                m_Matrix[1, i] = s;
                i++;
            }

            Ex02.ConsoleUtils.Screen.Clear();
            PrintBoard();
        }
    }
}
