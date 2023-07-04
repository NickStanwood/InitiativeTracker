using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class Character
    {
        public string Name { get; set; }  
        public int AC { get; set; }
        public int HP { get; set; }
        public int InitiativeModifier { get; set; }
        public int InitiativeRoll { get; set; }
    }
}
