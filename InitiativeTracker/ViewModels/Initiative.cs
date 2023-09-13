using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class Initiative : ViewModelBase<InitiativeModel>
    {
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

        public Initiative() : base()
        {}

        public Initiative(InitiativeModel model) : base(model)
        {}

        protected override void Initialize()
        {
            _rawRoll = 0;
        }

        public int Roll()
        {
            Result = Modifier + Dice.RollD20();
            return Result;
        }

    }
}
