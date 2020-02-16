using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FlareABattle.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod]
        public void Player_Attack_PointHit()
        {
            var player1 = new Player("test1");
            var player2 = new Player("test2");
            player1.PlaceShip();
            var point = player1.GameBoard.Points.Where(x => x.Status == StatusType.Ship).FirstOrDefault();
            var status = player2.Attack(point, player1.GameBoard);
            Assert.AreEqual(StatusType.Hits, point.Status);
        }

        [TestMethod]
        public void Player_Attack_PointMiss()
        {
            var player1 = new Player("test1");
            var player2 = new Player("test2");
            player1.PlaceShip();
            var point = player1.GameBoard.Points.Where(x => x.Status == StatusType.None).FirstOrDefault();
            var status = player2.Attack(point, player1.GameBoard);
            Assert.AreEqual(StatusType.Miss, point.Status);
        }

        //All ship sunk -> winner
        //Not all ship placedo on board and all sunk on board -> winner
        //Ship placement out of range
        //Ship placement vertical and horizontal.
    }
}