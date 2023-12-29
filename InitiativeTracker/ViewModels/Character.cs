using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace InitiativeTracker
{
    public class Character : ViewModelBase<CharacterModel>
    {
        public CharacterType Type { get { return _m.Type; } set { _m.Type = value; Notify(); } }
        public bool IsEnabled { get { return _m.IsEnabled; } set { _m.IsEnabled = value; Notify(); } }
        public string Name { get { return _m.Name; } set { _m.Name = value; Notify(); } }
        public int AC { get { return _m.AC; } set { _m.AC = value; Notify(); } }
        public int HP { get { return _m.HP; } set { _m.HP = value; Notify(); } }
        public string Notes { get { return _m.Notes; } set { _m.Notes = value; Notify(); } }

        private Initiative _initiative;
        public Initiative Initiative { get { return _initiative; } set { _initiative = value; Notify(); } }

        public ObservableCollection<Attack> Attacks { get; set; } = new ObservableCollection<Attack>();

        public Character() : base()
        { }

        public Character(CharacterType type) : base(new CharacterModel { Type = type})
        {}

        public Character(CharacterModel character) : base(character)
        {}

        protected override void Initialize()
        {
            _initiative = new Initiative(_m.Initiative);
            _initiative.PropertyChanged += (sender, e) => Notify(nameof(Initiative));

            TieModelListToViewModelList(_m.Attacks, Attacks);
        }

        public Character Clone()
        {
            return new Character(_m.Clone());
        }
        public void CopyFrom(Character source)
        {
            _m.CopyFrom(source.GetModel());
        }
    }
}
