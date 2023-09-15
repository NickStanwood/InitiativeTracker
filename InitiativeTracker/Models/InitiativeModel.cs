using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InitiativeTracker
{
    public class InitiativeModel
    {
        [XmlAttribute]
        public int Modifier { get; set; }
        [XmlAttribute]
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
