using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InitiativeTracker
{
    public class StatusModel
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Rounds { get; set; }
    }
}
