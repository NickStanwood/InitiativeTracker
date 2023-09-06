using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InitiativeTracker
{
    public  class Combatant : ViewModelBase
    {
        private int _health;
        public int Health { get { return _health; } set { _health = value; Notify(); } }

        public Character Character { get; set; }
        public Combatant(Character character)
        {
            Character = character;
            Health = character.HP;
        }
    }
}
