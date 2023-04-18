using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUITicTacToe
{
    public sealed class TicTacToe
    {
        private string[,] board;
        int result;
        int round;
        private static TicTacToe instance = null;
        public bool IsActive { get; set; }


        private TicTacToe()
        {
            this.board = new string[3, 3]
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            };

            this.result = 0;
            this.round = 0;
            this.IsActive = true;
        }

        public static TicTacToe Game
        {
            get
            {
                if(instance == null)
                {
                    instance = new TicTacToe();
                }
                return instance;
            }
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
        private void UpdateValue(string fieldNumber, string fieldValue)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].Equals(fieldNumber))
                        board[i, j] = fieldValue;
                }
            }
        }
        public string ReadInput(string fieldNumber)
        {
            string fieldValue;

            if (round % 2 == 0)
                fieldValue = "O";
            else
                fieldValue = "X";

            this.UpdateValue(fieldNumber, fieldValue);

            if(round > 2)
                result = this.CheckBoard();

            if (result != 0 || round == 8)
                IsActive = false;

            round++;

            return fieldValue;
                
        }
        public string EndGame()
        { 
            switch (result)
            {
                case 0:
                    return "It's a draw!";
                    
                case 1:
                    return "Player 1 has won!";
                 
                case 2:
                    return "Player 2 has won!";

                default:
                    return "";
            }

        }
        public void Reset()
        {
            this.board = new string[3, 3]
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            };
            this.result = 0;
            this.round = 0;
            this.IsActive = true;
        }
    }

}
