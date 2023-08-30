using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InitiativeTracker
{
    public  class CombatStats : INotifyPropertyChanged
    {
        private int _health;
        public int Health { get { return _health; } set { _health = value; Notify(nameof(Health)); } }

        public Character Character { get; set; }
        public CombatStats(Character character)
        {
            Character = character;
            Health = character.HP;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
