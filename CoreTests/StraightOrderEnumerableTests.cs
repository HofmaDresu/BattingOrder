using System;
using System.Collections.Generic;
using BattingOrder.Models;
using BattingOrder.Models.BattingOrderEnumerable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTests
{
    [TestClass]
    public class StraightOrderEnumerableTests
    {
        private List<Player> _players = new List<Player>
        {
            new Player("test 1", Gender.Male),
            new Player("test 2", Gender.Male),
            new Player("test 3", Gender.Male),
            new Player("test 4", Gender.Female),
            new Player("test 5", Gender.Male),
            new Player("test 6", Gender.Female),
            new Player("test 7", Gender.Female),
            new Player("test 8", Gender.Male),
            new Player("test 9", Gender.Female),
            new Player("test 10", Gender.Male),
        };

        [TestMethod]
        public void TestListMatches()
        {
            var straightOrderEnumerable = BaseBattingOrderEnumerable.GetBattingOrder(BattingOrderType.StraightOrder, _players, false);
            var index = 0;
            var stoppingPoint = _players.Count;

            foreach (var enumerablePlayer in straightOrderEnumerable)
            {
                if (index == stoppingPoint) break;

                Assert.AreEqual(enumerablePlayer.Name, _players[index].Name);
                Assert.AreEqual(enumerablePlayer.Gender, _players[index].Gender);
                index++;
            }
        }

        [TestMethod]
        public void TestListMatches_WithLoop()
        {
            var straightOrderEnumerable = BaseBattingOrderEnumerable.GetBattingOrder(BattingOrderType.StraightOrder, _players, false);
            var index = 0;
            var loopIndex = 0;
            var maxLoopIndex = 2;

            foreach (var enumerablePlayer in straightOrderEnumerable)
            {
                if (index == _players.Count)
                {
                    if (loopIndex == maxLoopIndex) break;

                    index = 0;
                    loopIndex++;
                }

                Assert.AreEqual(enumerablePlayer.Name, _players[index].Name);
                Assert.AreEqual(enumerablePlayer.Gender, _players[index].Gender);
                index++;
            }
        }
    }
}
