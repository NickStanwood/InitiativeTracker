using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class InitiativeModel
    {
        public int Modifier { get; set; }
        public int Result { get; set; }

        public InitiativeModel Clone()
        {
            return new InitiativeModel
            {
                Modifier = Modifier,
                Result = Result,
            };
        }
    }
}
