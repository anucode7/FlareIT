using FlareBattleship.Game;
using System;

namespace FlareABattle
{
    class Program
    {
        static void Main(string[] args)
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            Round round = new Round();
            round.PlayRound(player1, player2);
            Console.ReadKey();
        }
    }
}
