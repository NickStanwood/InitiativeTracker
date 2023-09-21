using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class Status : ViewModelBase<StatusModel>
    {
        public string Name { get { return _m.Name; } set { _m.Name = value; Notify(); } }
        public int Rounds { get { return _m.Rounds; } set { _m.Rounds = value; Notify(); } }

        public Status() : base(new StatusModel()) { }
        public Status(StatusModel status) : base(status) { }
        protected override void Initialize()
        {
        }
    }
}
