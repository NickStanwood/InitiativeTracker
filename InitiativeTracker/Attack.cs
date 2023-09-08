using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class Attack : ViewModelBase
    {
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; Notify(); }
        }

        private string _damage = "";
        public string Damage
        {
            get { return _damage; }
            set { _damage = value; Notify(); }
        }
    }
}
