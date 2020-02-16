using System.Collections.Generic;

namespace FlareABattle
{
    /// <summary>
    /// The game Board with all coordinates
    /// </summary>
    public class GameBoard
    {
        public int Row = 10; //ideally should be passed as input. But flare insists 10X10 
        public int Col = 10;
        public List<Point> Points { get; set; }
        public GameBoard()
        {
            Points = new List<Point>();
            for (int i = 1; i <= Row; i++)
            {
                for (int j = 1; j <= Col; j++)
                {
                    Points.Add(new Point(i, j));
                }
            }
        }
    }
}