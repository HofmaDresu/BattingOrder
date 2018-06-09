using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattingOrder.Models.BattingOrderEnumerable
{
    public class AlternatingGenderBattingOrderEnumerable : BaseBattingOrderEnumerable
    {
        public List<Player> _players;

        public AlternatingGenderBattingOrderEnumerable(List<Player> players)
        {
            _players = players;
        }

        public override IEnumerator<Player> GetEnumerator()
        {
            return new AlternatingGenderPlayerEnumerator(_players);
        }
    }

    public class AlternatingGenderPlayerEnumerator : IEnumerator<Player>
    {
        private List<Player> _malePlayers;
        private int _malePosition = -1;
        private List<Player> _femalePlayers;
        private int _femalePosition = -1;
        private Gender _currentGender;


        public AlternatingGenderPlayerEnumerator(List<Player> players)
        {
            _malePlayers = players.Where(p => p.Gender == Gender.Male).ToList();
            _femalePlayers = players.Where(p => p.Gender == Gender.Female).ToList();

            _currentGender = new Random().Next(2) == 1 ? Gender.Male : Gender.Female;
        }

        public bool MoveNext()
        {
            if (_currentGender == Gender.Male)
            {
                _currentGender = Gender.Female;
                _femalePosition++;
            }
            else
            {
                _currentGender = Gender.Male;
                _malePosition++;
            }
            
            return true;
        }

        public void Reset()
        {
            _malePosition = -1;
            _femalePosition = -1;
        }

        object IEnumerator.Current => Current;

        public Player Current
        {
            get
            {
                try
                {
                    if (_currentGender == Gender.Male)
                    {
                        return _malePlayers[_malePosition % _malePlayers.Count];
                    }
                    else
                    {
                        return _femalePlayers[_femalePosition % _femalePlayers.Count];
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
            _malePlayers = null;
            _femalePlayers = null;
            _malePosition = -1;
            _femalePosition = -1;
        }
    }
}
