using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InitiativeTracker
{
    [XmlRootAttribute("Encounter", Namespace = "http://www.cpandl.com", IsNullable = false)]
    public class EncounterModel
    {
        public bool CombatRunning { get; set; } = false;
        public CombatantModel? ActiveCombatant { get; set; }
        public List<CharacterModel> PlayerCharacters { get; set; } = new List<CharacterModel>();
        public List<CharacterModel> DMCharacters { get; set; } = new List<CharacterModel>();
        public List<CombatantModel> Combatants { get; set; } = new List<CombatantModel>();
    }
}
