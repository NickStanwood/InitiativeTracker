﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class Character
    {
        public string Name { get; set; }  
        public int AC { get; set; }
        public int HP { get; set; }
        public int InitiativeBonus { get; set; }
        public int InitiativeRoll { get; set; }
    }
}
