using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class Initiative : ViewModelBase
    {

        private int _rawRoll;
        public int RawRoll { get { return _rawRoll; } }

        private int _result;
        public int Result
        {
            get { return _result; }
            set
            {
                _result = value;
                _rawRoll = value - _modifier;
                Notify();
            }
        }

        private int _modifier;
        public int Modifier
        {
            get { return _modifier; }
            set
            {
                if(Result != 0)
                {
                    int delta = value - _modifier;
                    _modifier = value;
                    Result = Result + delta;
                }
                else
                {
                    _modifier = value;
                }
                Notify();
            }
        }

        public bool IsCriticalFailure { get { return _rawRoll == 1; } }
        public bool IsCriticalSuccess { get { return _rawRoll == 20; } }

        public Initiative()
        {
            _result = 0;
            _modifier = 0;
            _rawRoll = 0;
        }

        public int Roll(int modifier)
        {
            _modifier = modifier;
            return Roll();
        }

        public int Roll()
        {
            Result = _modifier + Dice.RollD20();
            return Result;
        }
    }
}
