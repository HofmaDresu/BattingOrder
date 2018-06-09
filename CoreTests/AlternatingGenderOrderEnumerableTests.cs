using System;
using System.Collections.Generic;
using BattingOrder.Models;
using BattingOrder.Models.BattingOrderEnumerable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTests
{
    [TestClass]
    public class AlternatingGenderOrderEnumerableTests
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
            var straightOrderEnumerable = BaseBattingOrderEnumerable.GetBattingOrder(BattingOrderType.AlternatingGender, _players);
            var index = 0;
            var stoppingPoint = _players.Count;
            Gender? currentGender = null;

            foreach (var enumerablePlayer in straightOrderEnumerable)
            {
                if (index == stoppingPoint) break;

                if(currentGender == null)
                {
                    // First gender is randomly assigned
                    currentGender = enumerablePlayer.Gender;
                }
                else
                {
                    currentGender = currentGender == Gender.Male ? Gender.Female : Gender.Male;
                }

                Assert.AreEqual(enumerablePlayer.Gender, currentGender);
                index++;
            }
        }

        [TestMethod]
        public void TestListMatches_WithLoop()
        {
            var straightOrderEnumerable = BaseBattingOrderEnumerable.GetBattingOrder(BattingOrderType.AlternatingGender, _players);
            var index = 0;
            var loopIndex = 0;
            var maxLoopIndex = 2;
            Gender? currentGender = null;

            foreach (var enumerablePlayer in straightOrderEnumerable)
            {
                if (index == _players.Count)
                {
                    if (loopIndex == maxLoopIndex) break;

                    index = 0;
                    loopIndex++;
                }

                if (currentGender == null)
                {
                    // First gender is randomly assigned
                    currentGender = enumerablePlayer.Gender;
                }
                else
                {
                    currentGender = currentGender == Gender.Male ? Gender.Female : Gender.Male;
                }

                Assert.AreEqual(enumerablePlayer.Gender, currentGender);
                index++;
            }
        }
    }
}
