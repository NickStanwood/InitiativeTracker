using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class Character : INotifyPropertyChanged
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; Notify(nameof(Name)); } }

        private int _AC;
        public int AC { get { return _AC; } set { _AC = value; Notify(nameof(AC)); } }

        private int _HP;
        public int HP { get { return _HP; } set { _HP = value; Notify(nameof(HP)); } }

        private int _initiativeModifier;
        public int InitiativeModifier { get { return _initiativeModifier; } set { _initiativeModifier = value; Notify(nameof(InitiativeModifier)); } }

        private int _initiativeRoll;
        public int InitiativeRoll { get { return _initiativeRoll; } set { _initiativeRoll = value; Notify(nameof(InitiativeRoll)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
