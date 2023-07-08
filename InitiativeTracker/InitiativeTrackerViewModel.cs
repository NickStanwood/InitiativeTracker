using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class InitiativeTrackerViewModel
    {
        public ObservableCollection<Character> PlayerCharacters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Character> DMCharacters { get; set; } = new ObservableCollection<Character>();

        public InitiativeTrackerViewModel()
        {
        }
    }
}
