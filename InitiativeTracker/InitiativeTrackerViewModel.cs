using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class InitiativeTrackerViewModel
    {
        public ObservableCollection<Character> PlayerCharacters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Character> DMCharacters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Combatant> Combatants { get; set; } = new ObservableCollection<Combatant>();

        public InitiativeTrackerViewModel()
        {
        }

        public void CreateCombatList()
        {
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
    }
}
