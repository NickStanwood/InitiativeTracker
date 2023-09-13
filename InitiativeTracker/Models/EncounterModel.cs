using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class EncounterModel
    {
        public CombatantModel? ActiveCombatant { get; set; }
        public List<CharacterModel> PlayerCharacters { get; set; } = new List<CharacterModel>();
        public List<CharacterModel> DMCharacters { get; set; } = new List<CharacterModel>();
        public List<CombatantModel> Combatants { get; set; } = new List<CombatantModel>();
    }
}
