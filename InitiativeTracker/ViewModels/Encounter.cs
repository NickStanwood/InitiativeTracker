using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class Encounter : ViewModelBase<EncounterModel>
    {
        public ObservableCollection<Character> PlayerCharacters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Character> DMCharacters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Combatant> Combatants { get; set; } = new ObservableCollection<Combatant>();
        public CombatantModel? ActiveCombatant { get { return _m.ActiveCombatant; } set { _m.ActiveCombatant = value; Notify(); } }

        public bool CombatRunning
        {
            get { return _m.CombatRunning; }
            set 
            {
                _m.CombatRunning = value; 
                Notify();
                Notify(nameof(CharacterWidth));
                Notify(nameof(CombatWidth));
            }
        }


        private static readonly int _defaultCharacterWidth = 2;
        private string _characterWidth = _defaultCharacterWidth.ToString() + "*";
        public string CharacterWidth 
        { 
            get 
            { 
                return _characterWidth; 
            }
            set
            {
                _characterWidth = value;
                Notify();
            }
        }

        public string CombatWidth { get { return "*"; } }

        private string _filePath = "";
        public string FilePath { get { return _filePath; } set { _filePath = value; Notify(); } }
        public Encounter() 
            : base(new EncounterModel())
        {}

        public Encounter(EncounterModel model)
            : base(model)
        { }
        
        protected override void Initialize()
        {
            TieModelListToViewModelList(_m.PlayerCharacters, PlayerCharacters);
            TieModelListToViewModelList(_m.DMCharacters, DMCharacters);
            TieModelListToViewModelList(_m.Combatants, Combatants);
        }

        public void StartCombat(int milliseconds)
        {
            if (CombatRunning || !CreateCombatList())
                return;

            Thread t = new Thread(() =>
            {
                float start = _defaultCharacterWidth;
                float end = 0;
                float deltaVal = 0.05f;

                int deltaTime = (int)(milliseconds * deltaVal / (start - end));
                if (deltaTime <= 0)
                    deltaTime = 1;

                float width = start;
                while (width > end)
                {
                    width -= deltaVal;
                    if(width < end)
                        width = end;
                    CharacterWidth = width + "*";
                    Thread.Sleep(deltaTime);
                }
            });

            t.Start();
        }

        public bool CreateCombatList()
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
                return false;

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
            int i = 1;
            foreach (Character c in characters)
            {
                Combatants.Add(new Combatant(c.GetModel(), i++));
            }
            CombatRunning = true;
            GoToNextCombatant();
            return true;
        }

        public void GoToNextCombatant()
        {
            if (!CombatRunning)
                return;

            //put previously active combatant at bottom of initiative order
            if(ActiveCombatant != null)
            {
                ActiveCombatant.DecreaseStatusRounds();
                Combatants.Add(new Combatant(ActiveCombatant));
            }

            ActiveCombatant = Combatants[0].GetModel();
            Combatants.RemoveAt(0);
        }

        public void EndCombat()
        {
            Combatants.Clear();
            ActiveCombatant = null;
            CombatRunning = false;
            CharacterWidth = _defaultCharacterWidth.ToString() + "*";
        }
    }
}
