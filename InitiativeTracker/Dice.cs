using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public static class Dice
    {
        private static Random Rand = new Random();
        public static int RollD20()
        {
            return Rand.Next(1,21);
        }
    }
}
