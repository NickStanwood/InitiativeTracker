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
        private InitiativeModel _m;

        private int _rawRoll;
        public int RawRoll { get { return _rawRoll; } }

        public int Result
        {
            get { return _m.Result; }
            set
            {
                _m.Result = value;
                _rawRoll = value - _m.Modifier;
                Notify();
            }
        }
        public int Modifier
        {
            get { return _m.Modifier; }
            set
            {
                if(Result != 0)
                {
                    int delta = value - _m.Modifier;
                    _m.Modifier = value;
                    Result = Result + delta;
                }
                else
                {
                    _m.Modifier = value;
                }
                Notify();
            }
        }

        public bool IsCriticalFailure { get { return _rawRoll == 1; } }
        public bool IsCriticalSuccess { get { return _rawRoll == 20; } }

        public Initiative()
        {
            _m = new InitiativeModel
            {
                Result = 0,
                Modifier = 0,
            };
            _rawRoll = 0;
        }
        public Initiative(InitiativeModel model)
        {
            _m = model;
            _rawRoll = 0;
        }

        public int Roll()
        {
            Result = _m.Modifier + Dice.RollD20();
            return Result;
        }

        public Initiative Clone()
        {
            Initiative clone = new Initiative();
            clone.Modifier = Modifier;
            clone.Result = Result;
            return clone;
        }
    }
}
