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
        public static ObservableCollection<Attack> Clone(this ObservableCollection<Attack> collection )
        {
            ObservableCollection<Attack> clone = new ObservableCollection<Attack>();
            foreach( Attack attack in collection )
            {
                clone.Add( new Attack { Name=attack.Name, Damage=attack.Damage});
            }
            return clone;
        }
    }
}
