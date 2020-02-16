using FlareBattleship.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlareABattle
{
    public class ShipPosition
    {
        public bool isPlaced = false;
        /// <summary>
        /// Gets list of points where ship could be randomly placed on board
        /// </summary>
        public List<Point> affectedPoints = new List<Point>();
        /// <summary>
        /// Place a ship on the game board
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="gameBoard"></param>
        /// <returns></returns>
        public ShipPosition PlaceShip(Ship ship, GameBoard gameBoard)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int orientation = rand.Next(1, 101) % 2;
            var possibilities = PossiblePlacings(gameBoard, ship.Size, orientation);
            if (possibilities == null || possibilities.Count() < 1)
            {
                return null;
            }
            if (possibilities.Count() == 1)
            {
                affectedPoints = possibilities.FirstOrDefault();
            }
            else
            {
                var r = rand.Next(possibilities.Count);
                affectedPoints = possibilities[r];
            }
            foreach (var point in affectedPoints)
            {
                point.Status = StatusType.Ship;
                point.Ship = ship;
            }
            return new ShipPosition()
            {
                affectedPoints = affectedPoints,
                isPlaced = isPlaced
            };
        }
        /// <summary>
        /// Get all open spacings available based on ship size. Orientation is random.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="size"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public List<List<Point>> PossiblePlacings(GameBoard board, int size, int orientation)
        {
            if (orientation == 1)
            {
                return PlaceVertical(board, size);
            }

            return PlaceHorizontal(board, size);
        }
        /// <summary>
        /// Place ships horizontally 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private static List<List<Point>> PlaceHorizontal(GameBoard board, int size)
        {
            List<List<Point>> possibleList = new List<List<Point>>();

            for (int i = 1; i <= board.Row; i++)
            {
                int j = 1;
                while (j + (size - 1) <= board.Col)
                {
                    var p = board.Points.Range(i, j, i, j + (size - 1));
                    if (!(p.Count(x => x.IsOccupied) > 0))
                    {
                        possibleList.Add(p);
                    }
                    j++;
                }
            }

            return possibleList;
        }
        /// <summary>
        /// Place ship vertically
        /// </summary>
        /// <param name="board"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private static List<List<Point>> PlaceVertical(GameBoard board, int size)
        {
            List<List<Point>> possibleList = new List<List<Point>>();

            for (int i = 1; i <= board.Col; i++)
            {
                int j = 1;
                while (j + (size - 1) <= board.Row)
                {
                    var p = board.Points.Range(j, i, j + (size - 1), i);
                    if (!(p.Count(x => x.IsOccupied) > 0))
                    {
                        possibleList.Add(p);
                    }
                    j++;
                }
            }

            return possibleList;
        }
    }
}