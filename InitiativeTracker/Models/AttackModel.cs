using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class AttackModel
    {
        public string Name { get; set; }
        public string Damage { get; set; }
        public AttackModel Clone()
        {
            return new AttackModel
            {
                Name = Name,
                Damage = Damage,
            };
        }
    }
}
