using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace InitiativeTracker
{
    internal static class ObservableCollectionExtentions
    {
        public static ObservableCollection<AttackModel> Clone(this ObservableCollection<AttackModel> collection )
        {
            ObservableCollection<AttackModel> clone = new ObservableCollection<AttackModel>();
            foreach( AttackModel attack in collection )
            {
                clone.Add( new AttackModel { Name=attack.Name, Damage=attack.Damage});
            }
            return clone;
        }
    }
}
