using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class CombatantModel : IEquatable<CombatantModel>
    {
        public Guid Id { get; } = new Guid();
        public int Health { get; set; }
        public CharacterModel Character { get; set; } = new CharacterModel();

        public static bool operator==(CombatantModel? a, CombatantModel? b )
        {
            if (a is null && b is null)
                return true;

            if(a is not null)
                return a.Equals(b);

            return false;
        }
        public static bool operator!=(CombatantModel? a, CombatantModel? b)
        {
            return !(a == b);
        }
        public bool Equals(CombatantModel? other)
        {
            if(other is null) return false;
            return Id == other.Id;
        }
    }
}
