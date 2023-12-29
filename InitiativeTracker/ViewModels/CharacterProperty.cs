using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class CharacterProperty : ViewModelBase<CharacterPropertyModel>
    {
        public string Name
        {
            get { return _m.Name; }
            set { _m.Name = value; Notify(); }
        }
        public string Value
        {
            get { return _m.Value; }
            set { _m.Value = value; Notify(); }
        }
        public CharacterProperty() : base(new CharacterPropertyModel()) { }
        public CharacterProperty(CharacterPropertyModel model) : base(model) { }

        protected override void Initialize()
        {
        }
    }
}
