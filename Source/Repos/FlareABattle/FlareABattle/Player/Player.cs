using FlareBattleship.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlareABattle
{
    /// <summary>
    /// Players's details and actions
    /// </summary>
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            GameBoard = new GameBoard();
        }
        public string Name { get; set; }
        public GameBoard GameBoard { get; set; }
        /// <summary>
        /// Gets all ships on  board for the player
        /// </summary>
        public List<Ship> Ships { get; set; }
        /// <summary>
        /// If all ships have sunk the player looses
        /// </summary>
        public bool HasLost
        {
            get
            {
                return Ships != null && Ships.All(x => x.IsSunk) ? true : false;
            }
        }
        /// <summary>
        /// Displays the status of each point on the board for a player
        /// </summary>
        public void DisplayBoard()
        {
            Console.Write(this.Name + " Board so far..\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int col = 1; col <= this.GameBoard.Col; col++)
            {
                Console.Write(string.Concat(col, "    "));
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int row = 1; row <= this.GameBoard.Row; row++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (row < 10)
                {
                    Console.Write(string.Concat(row, "    "));
                }
                else
                {
                    Console.Write(string.Concat(row, "   "));
                }

                Console.ForegroundColor = ConsoleColor.White;
                for (int col = 1; col <= this.GameBoard.Row; col++)
                {
                    //if (GameBoard.Points.At(row, col).Status == StatusType.None || GameBoard.Points.At(row, col).Status == StatusType.Ship)
                    //{
                    //    Console.Write("   " + " ");
                    //}
                    //else
                    //{
                    //    Console.Write(GameBoard.Points.At(row, col).Status.ToString() + " ");

                    //}

                    Console.Write(GameBoard.Points.At(row, col).Status.ToString() + " ");
                    //}
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// Place ships coordinates which can be on the board
        /// </summary>
        public void PlaceShip()
        {
            Ships = new List<Ship>()
            {
                new Ship("ship1", 2),
                new Ship("ship2", 3),
                new Ship("ship3" ,4)
            };
            var removeShips = new List<Ship>();
            foreach (var ship in Ships)
            {
                try
                {
                    var position = new ShipPosition();
                    if (position.PlaceShip(ship, GameBoard) == null)
                    {
                        removeShips.Add(ship);
                        Console.WriteLine("some ship not placed");
                    }
                }
                catch (Exception)
                {
                    removeShips.Add(ship);
                    Console.WriteLine("some ship not placed");
                }
            }
            Ships.RemoveAll(x => removeShips.Any(y => y.Name == x.Name));
        }
        public List<Ship> GetShips()
        {
            return new List<Ship>()
            {
                new Ship("ship1", 2),
                new Ship("ship2", 3),
                new Ship("ship3" ,4)
            };
        }
        /// <summary>
        /// Pass attack point to hit opponent's board
        /// </summary>
        /// <param name="attackPoint"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool Attack(Point attackPoint, GameBoard board)
        {
            var point = board.Points.FirstOrDefault(p => p.Coordinates.Row == attackPoint.Coordinates.Row && p.Coordinates.Column == attackPoint.Coordinates.Column);
            if (point != null)
            {
                if (point.Status == StatusType.Hits || point.Status == StatusType.Miss)
                {
                    return false;
                }
                if (point.Status == StatusType.Ship)
                {
                    point.Status = StatusType.Hits;
                    point.Ship.Hits += 1;
                    if (point.Ship.Hits == point.Ship.Size)
                    {
                        var shipPoints = board.Points.Where(p => p.Ship != null && p.Ship.Name == point.Ship.Name).ToList();
                        foreach (var shipPoint in shipPoints)
                        {
                            shipPoint.Status = StatusType.Sunk;
                        }
                    }
                }
                if (point.Status == StatusType.None)
                {
                    point.Status = StatusType.Miss;
                }
                Console.WriteLine(point.Status.ToString());
            }
            return true;
        }
    }
}