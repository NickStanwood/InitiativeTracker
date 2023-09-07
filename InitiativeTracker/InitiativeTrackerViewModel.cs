﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class InitiativeTrackerViewModel : ViewModelBase
    {
        public ObservableCollection<Character> PlayerCharacters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Character> DMCharacters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Combatant> Combatants { get; set; } = new ObservableCollection<Combatant>();

        private Combatant _activeCombatant;
        public Combatant ActiveCombatant { get { return _activeCombatant; } set { _activeCombatant = value; Notify(); } }

        private bool _combatRunning = false;
        public bool CombatRunning
        {
            get { return _combatRunning; }
            set 
            {
                _combatRunning = value; 
                Notify();
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

            if (characters.Count == 0)
                return;

            characters.Sort((a,b) =>
            {
                //a rolled a nat 20
                if (a.Initiative.IsCriticalSuccess && !b.Initiative.IsCriticalSuccess)
                    return -1;

                //b rolled a nat 20
                if (b.Initiative.IsCriticalSuccess && !a.Initiative.IsCriticalSuccess)
                    return 1;

                //a had bettter initiative
                if (a.Initiative.Result > b.Initiative.Result)
                    return -1;

                //a and b had the same initiative, but a has a higher modifier
                if(a.Initiative.Result == b.Initiative.Result &&
                a.Initiative.Modifier > b.Initiative.Modifier)
                {
                    return -1;
                }

                //b had a higher initiative
                return 1;
            });

            Combatants.Clear();
            foreach (Character c in characters)
            {
                Combatants.Add(new Combatant(c));
            }
            CombatRunning = true;
            GoToNextCombatant();
        }

        public void GoToNextCombatant()
        {
            if (!CombatRunning)
                return;

            if(ActiveCombatant != null)
                Combatants.Add(ActiveCombatant);

            ActiveCombatant = Combatants[0];
            Combatants.RemoveAt(0);
        }

        public void EndCombat()
        {
            Combatants.Clear();
            ActiveCombatant = null;
            CombatRunning = false;
        }
    }
}
