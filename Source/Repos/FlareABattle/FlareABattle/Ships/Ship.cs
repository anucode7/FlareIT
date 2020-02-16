namespace FlareABattle
{
    public class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public StatusType Status { get; set; }
        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
        }
        public bool IsSunk
        {
            get
            {
                return Hits >= Size;
            }
        }
    }
}