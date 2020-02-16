using System.ComponentModel;

namespace FlareABattle
{
    /// <summary>
    /// Status of Ship on Game Board
    /// </summary>
    public enum StatusType
    {
        [Description("N")]
        None,
        [Description("S")]
        Ship,
        [Description("X")]
        Hits,
        [Description("M")]
        Miss,
        [Description("Z")]
        Sunk
    }
}