using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class InitiativeTrackerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Character> PlayerCharacters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Character> DMCharacters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Combatant> Combatants { get; set; } = new ObservableCollection<Combatant>();

        private bool _combatRunning = false;
        public bool CombatRunning
        {
            get { return _combatRunning; }
            set 
            {
                _combatRunning = value; 
                Notify(nameof(CombatRunning));
                Notify(nameof(CharacterWidth));
                Notify(nameof(CombatWidth));
            }
        }

        public string CharacterWidth { get { return CombatRunning ? "*" : "2*"; } }
        public string CombatWidth { get { return CombatRunning ? "2*" : "*"; } }
        public InitiativeTrackerViewModel()
        {
        }

        public void CreateCombatList()
        {
            CombatRunning = true;
            List<Character> characters = new List<Character>();
            foreach(Character c in DMCharacters)
            {
                if(c.IsEnabled)
                    characters.Add(c);
            }
            foreach(Character c in PlayerCharacters)
            {
                if (c.IsEnabled)
                    characters.Add(c);
            }

            characters.Sort((a,b) =>
            {
                //a had bettter initiative
                if(a.Initiative.Result > b.Initiative.Result)
                    return -1;

                //a and b had the same initiative, but a has a higher modifier
                if(a.Initiative.Result == b.Initiative.Result &&
                a.Initiative.Modifier > b.Initiative.Modifier)
                {
                    return -1;
                }

                return 1;
            });

            Combatants.Clear();
            foreach (Character c in characters)
            {
                Combatants.Add(new Combatant(c));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
