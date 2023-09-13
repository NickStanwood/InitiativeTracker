using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class Attack : ViewModelBase<AttackModel>
    {
        public Attack() : base()
        {
        }

        public Attack(AttackModel model) : base(model)
        {
        }

        public string Name
        {
            get { return _m.Name; }
            set { _m.Name = value; Notify(); }
        }

        public string Damage
        {
            get { return _m.Damage; }
            set { _m.Damage = value; Notify(); }
        }

        protected override void Initialize()
        {
            
        }
    }
}
