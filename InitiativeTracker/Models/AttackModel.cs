using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InitiativeTracker
{
    public class AttackModel
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
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
