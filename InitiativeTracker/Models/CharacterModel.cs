using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InitiativeTracker
{
    public enum CharacterType
    {
        DMControlled,
        PlayerControlled
    }

    public class CharacterModel: IEquatable<CharacterModel>
    {
        [XmlAttribute]
        public Guid Id { get; set; } = Guid.NewGuid();

        [XmlAttribute]
        public CharacterType Type { get; set; }

        [XmlAttribute]
        public bool IsEnabled { get; set; } = true;

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public int AC { get; set; }

        [XmlAttribute]
        public int HP { get; set; }

        public InitiativeModel Initiative { get; set; } = new InitiativeModel();
        public List<AttackModel> Attacks { get; set; } = new List<AttackModel>();

        public CharacterModel Clone()
        {
            return new CharacterModel
            {
                Type = Type,
                Name = Name,
                AC = AC,
                HP = HP,
                Initiative = Initiative.Clone(),
                Attacks = Attacks.Clone()
            };
        }

        public void CopyFrom(CharacterModel source)
        {
            Name = source.Name;
            AC = source.AC;
            HP = source.HP;
            Initiative = source.Initiative.Clone();
            Attacks = source.Attacks.Clone();
        }


        public static bool operator ==(CharacterModel? a, CharacterModel? b)
        {
            if (a is null && b is null)
                return true;

            if (a is not null)
                return a.Equals(b);

            return false;
        }
        public static bool operator !=(CharacterModel? a, CharacterModel? b)
        {
            return !(a == b);
        }
        public bool Equals(CharacterModel? other)
        {
            if (other is null) return false;
            return Id == other.Id;
        }
    }
}
