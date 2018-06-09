using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BattingOrder.Models.BattingOrderEnumerable
{
    public abstract class BaseBattingOrderEnumerable : IEnumerable<Player>
    {
        protected BaseBattingOrderEnumerable() { }

        public static BaseBattingOrderEnumerable GetBattingOrder(BattingOrderType type, List<Player> players)
        {
            switch (type)
            {
                case BattingOrderType.AlternatingGender:
                    return new AlternatingGenderBattingOrderEnumerable(players);
                case BattingOrderType.StraightOrder:
                    return new StraightBattingOrderEnumerable(players);
                default:
                    throw new Exception($"{type} is not supported");
            }
        }

        public abstract IEnumerator<Player> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
