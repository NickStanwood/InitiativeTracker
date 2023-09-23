﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InitiativeTracker
{
    public class CombatantModel : IEquatable<CombatantModel>
    {
        [XmlAttribute]
        public Guid Id { get; } = Guid.NewGuid();

        [XmlAttribute]
        public int Health { get; set; }

        [XmlAttribute]
        public int InitiativeOrder { get; set; }
        public CharacterModel Character { get; set; } = new CharacterModel();

        public List<StatusModel> Statuses = new List<StatusModel>();

        public void DecreaseStatusRounds()
        {
            for(int i = Statuses.Count - 1; i >= 0; i--)
            {
                Statuses[i].Rounds--;
                if(Statuses[i].Rounds <= 0)
                    Statuses.RemoveAt(i);
            }
        }

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
