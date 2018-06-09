using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BattingOrder.Models.BattingOrderEnumerable
{
    public class StraightBattingOrderEnumerable : BaseBattingOrderEnumerable
    {
        public List<Player> _players;

        public StraightBattingOrderEnumerable(List<Player> players)
        {
            _players = players;
        }

        public override IEnumerator<Player> GetEnumerator()
        {
            return new StraightPlayerEnumerator(_players);
        }
    }

    public class StraightPlayerEnumerator : IEnumerator<Player>
    {
        private List<Player> _players;
        private int _position = -1;

        public StraightPlayerEnumerator(List<Player> players)
        {
            _players = players;
        }

        public bool MoveNext()
        {
            _position++;
            return true;
        }

        public void Reset() => _position = -1;

        object IEnumerator.Current => Current;

        public Player Current
        {
            get
            {
                try
                {
                    return _players[_position % _players.Count];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
            _players = null;
            _position = -1;
        }
    }
}
