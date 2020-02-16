namespace FlareABattle
{
    /// <summary>
    /// Point on board with Status, Coordinates and Ship details
    /// </summary>
    public class Point
    {
        public Coordinates Coordinates { get; set; }
        public StatusType Status { get; set; }
        public Ship Ship { get; set; }
        public Point(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            Status = StatusType.None;
        }
        public bool IsOccupied
        {
            get
            {
                return Status == StatusType.Ship;
            }
        }
    }
}