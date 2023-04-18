using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITicTacToe
{
        public class TicTacToe
        {
            private string[,] board;
            int result;


            public TicTacToe()
            {
                this.board = new string[3, 3]
                {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
                };

                this.result = 0;
            }
            private int CheckBoard()
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    string firstEntry = board[i, i];
                    if (!firstEntry.Equals("X") && !firstEntry.Equals("O"))
                    {
                        continue;
                    }
                    int horiznotalCount = 0, verticalCount = 0, mainDiagonalCount = 0, sideDiagonalCount = 0;
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j].Equals(firstEntry))
                        {
                            horiznotalCount++;
                        }
                        if (board[j, i].Equals(firstEntry))
                        {
                            verticalCount++;
                        }
                        if (i == 1 && board[j, j].Equals(firstEntry))
                        {
                            mainDiagonalCount++;

                        }
                        if (i == 1 && board[j, 2 - j].Equals(firstEntry))
                        {
                            sideDiagonalCount++;
                        }
                    }
                    if (horiznotalCount == 3 || verticalCount == 3 || mainDiagonalCount == 3 || sideDiagonalCount == 3)
                    {
                        if (firstEntry.Equals("O"))
                            return 1;
                        else
                            return 2;
                    }

                }
                return 0;
            }
            private void DrawBoard()
            {
                for (int i = 0; i < 3 * 3 + 2; i++)
                {
                    for (int j = 0; j < 3 * 3 + 2; j++)
                    {
                        if (i % 4 == 1 && j % 4 == 1)
                            Console.Write(board[i / 4, j / 4]);

                        else if ((j + 1) % 4 == 0)
                            Console.Write("|");

                        else if ((i + 1) % 4 == 0)
                            Console.Write("\u2014");

                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
            private bool InputValidation(string input)
            {
                if (input.Length > 1 || !char.IsDigit(char.Parse(input)))
                    Console.WriteLine("Please enter a number!");

                else
                {
                    foreach (string field in board)
                    {
                        if (field.Equals(input))
                            return true;
                    }
                }
                Console.WriteLine("Incorrect input! Please use another field!");
                return false;
            }
            private void UpdateValue(string order, string fieldValue)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j].Equals(order))
                            board[i, j] = fieldValue;
                    }
                }
            }
            private void PlayGame()
            {
                for (int i = 0; i < 9; i++)
                {
                    this.DrawBoard();
                    string input;

                    do
                    {
                        if (i % 2 == 0)
                            Console.Write("Player 1: ");
                        else
                            Console.Write("Player 2: ");

                        Console.Write("Choose your field!");
                        input = Console.ReadLine();

                    } while (!this.InputValidation(input));

                    string fieldValue;

                    if (i % 2 == 0)
                        fieldValue = "O";
                    else
                        fieldValue = "X";

                    this.UpdateValue(input, fieldValue);
                    Console.Clear();
                    result = this.CheckBoard();
                    if (result != 0)
                        break;
                }
            }
            private void EndGame()
            {
                this.DrawBoard();
                switch (result)
                {
                    case 0:
                        Console.WriteLine("It's a draw!");
                        break;
                    case 1:
                        Console.WriteLine("Player 1 has won!");
                        break;
                    case 2:
                        Console.WriteLine("Player 2 has won!");
                        break;
                }

            }
            private void Reset()
            {

                Console.WriteLine("Press any Key to Reset The Game");
                Console.ReadKey();
                Console.Clear();
                this.board = new string[3, 3]
                {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
                };
                this.result = 0;
            }
            public void Play()
            {
                while (true)
                {
                    this.PlayGame();
                    this.EndGame();
                    this.Reset();
                }
            }

        }
    

}
