using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Solution
    {

        public void Play()
        {
            char[,] board = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 'n';
                }
            }
            while (true)
            {
                if(Step(board, "player1", 'X') == true)
                {
                    Display(board);
                    Console.WriteLine("player 1 won");
                    break;
                }
                Display(board);
                if (Step(board, "player2", 'O') == true)
                {
                    Display(board);
                    Console.WriteLine("player 2 won");
                    break;
                }
                Display(board);
            }
        }

        public bool Step(char[,] board, string player, char value)
        {
            Console.WriteLine($"{player}'s turn:");
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            if (board[x1, x2] == 'n')
            {
                board[x1, x2] = value;
                if (CheckWin(board, x1, x2, value) == true)
                {
                    Console.WriteLine($"{player} won");
                    return true;
                }
                return false;
            }
            else
            {
                Console.WriteLine("place is already taken or is invalid");
                Step(board, player, value);
                return false;
            }

        }

        public bool CheckWin(char[,] board, int cordinate1, int cordinate2, char value)
        {
            var newplay = board[cordinate1, cordinate2];
            if((newplay == board[cordinate1, 0] && newplay == board[cordinate1, 1] && newplay == board[cordinate1, 2]) || (newplay == board[0, cordinate2] && newplay == board[1, cordinate2] && newplay == board[2, cordinate2]))
            {
                return true;
            }
            else if ((value == board[0,0] && board[0, 0] == board[1,1] && board[1,1] == board[2,2]))
            {
                return true;
            }
            else if ((value == board[0, 2] && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Display(char[,] board)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(board[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
