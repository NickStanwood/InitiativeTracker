using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InitiativeTracker
{
    public class Combatant : ViewModelBase<CombatantModel>
    {
        public int Health { get { return _m.Health; } set { _m.Health = value; Notify(); } }
        public Character Character { get; set; }

        public Combatant() : base()
        { }

        public Combatant(CombatantModel combatant) : base(combatant)
        { }

        public Combatant(CharacterModel character, int order) 
            : base(new CombatantModel { Health = character.HP, InitiativeOrder = order, Character = character})
        { }

        protected override void Initialize()
        {
            Character = new Character(_m.Character);
        }
    }
}
