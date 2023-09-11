using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace InitiativeTracker
{

    public class Character : ViewModelBase
    {
        private CharacterModel _m = new CharacterModel();
        public CharacterType Type { get { return _m.Type; } set { _m.Type = value; Notify(); } }
        public bool IsEnabled { get { return _m.IsEnabled; } set { _m.IsEnabled = value; Notify(); } }
        public string Name { get { return _m.Name; } set { _m.Name = value; Notify(); } }
        public int AC { get { return _m.AC; } set { _m.AC = value; Notify(); } }
        public int HP { get { return _m.HP; } set { _m.HP = value; Notify(); } }

        private Initiative _initiative;
        public Initiative Initiative { get { return _initiative; } set { _initiative = value; Notify(); } }

        public ObservableCollection<AttackModel> Attacks { get; set; }
        public Character(CharacterType type)
        {
            Type = type;
            _initiative = new Initiative(_m.Initiative);
            Attacks = new ObservableCollection<AttackModel>(_m.Attacks);
            _initiative.PropertyChanged += (sender, e) => Notify(nameof(Initiative));
        }

        public Character Clone()
        {
            Character c = new Character(Type);
            c.Name = Name;
            c.AC = AC;
            c.HP = HP;
            c.Initiative = Initiative.Clone();
            c.Attacks = Attacks.Clone();
            return c;
        }

        public void CopyFrom(Character source)
        {
            Name = source.Name;
            AC = source.AC;
            HP = source.HP;
            Initiative = source.Initiative.Clone();
            Attacks = source.Attacks.Clone();
        }
    }
}
