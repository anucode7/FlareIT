using FlareABattle;
using System;

namespace FlareBattleship.Game
{
    /// <summary>
    /// Each round has two players with one end result
    /// </summary>
    public class Round
    {
        public void PlayRound(Player player1, Player player2)
        {
            bool player1Win = false;
            bool player2Win = false;
            player1.PlaceShip();
            player2.PlaceShip();
            player1.DisplayBoard();
            player2.DisplayBoard();
            while (!player1Win && !player2Win)
            {
                Console.WriteLine("Player 1 attack");
                player1Win = Play(player1, player2);
                if (player1Win)
                {
                    break;
                }

                Console.WriteLine("Player 2 attack");
                player2Win = Play(player2, player1);
                if (player1Win)
                {
                    break;
                }

                Console.WriteLine("Enter Coords x & y to attack (number and between range only ) : ");
                Console.WriteLine();
            }
            Console.WriteLine("finally have a result");
            if (!player1.HasLost)
            {
                Console.WriteLine("Player 2 wins");
            }
            else
            {
                Console.WriteLine("Player 1 wins");
            }
        }
        private bool Play(Player playerAttacking, Player playerAttacked)
        {
            bool hasAttacked = false;
            while (!hasAttacked)
            {
                int row = PlayerInput(playerAttacked.GameBoard.Row);
                int col = PlayerInput(playerAttacked.GameBoard.Col);
                hasAttacked = playerAttacking.Attack(new Point(row, col), playerAttacked.GameBoard);
                if (!hasAttacked)
                {
                    Console.WriteLine("try new coords, you have done this already");
                }
            }
            playerAttacked.DisplayBoard();
            return playerAttacked.HasLost;
        }
        private int PlayerInput(int size)
        {
            int output = -1;
            bool isValid = false;
            while (!isValid)
            {
                if (int.TryParse(Console.ReadLine(), out output))
                {
                    if (output <= size && output > 0)
                    {
                        return output;
                    }
                }
                Console.WriteLine("Invalid input");
            }
            return output;
        }
    }
}


