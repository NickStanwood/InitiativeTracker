using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public enum CharacterType
    {
        DMControlled,
        PlayerControlled
    }

    public class CharacterModel
    {
        public CharacterType Type { get; set; }
        public bool IsEnabled { get; set; } = true;
        public string Name { get; set; }
        public int AC { get; set; }
        public int HP { get; set; }
        public InitiativeModel Initiative { get; set; } = new InitiativeModel();
        public List<AttackModel> Attacks { get; set; } = new List<AttackModel>();
    }
}
