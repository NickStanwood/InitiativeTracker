using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace InitiativeTracker
{
    internal static class ListExtentions
    {
        public static List<AttackModel> Clone(this List<AttackModel> collection )
        {
            List<AttackModel> clone = new List<AttackModel>();
            foreach( AttackModel attack in collection )
            {
                clone.Add(attack.Clone());
            }
            return clone;
        }
    }
}
