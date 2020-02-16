using FlareABattle;
using System.Collections.Generic;
using System.Linq;

namespace FlareBattleship.Extensions
{
    public static class PointExtensions
    {
        /// <summary>
        /// Extension method to find precise point from list
        /// </summary>
        /// <param name="points"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static Point At(this List<Point> points, int row, int column)
        {
            return points.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).First();
        }
        /// <summary>
        /// Gets all points with the range(row and col)
        /// </summary>
        /// <param name="points"></param>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endRow"></param>
        /// <param name="endColumn"></param>
        /// <returns></returns>
        public static List<Point> Range(this List<Point> points, int startRow, int startColumn, int endRow, int endColumn)
        {
            return points.Where(x => x.Coordinates.Row >= startRow
                                     && x.Coordinates.Column >= startColumn
                                     && x.Coordinates.Row <= endRow
                                     && x.Coordinates.Column <= endColumn).ToList();
        }
    }
}
