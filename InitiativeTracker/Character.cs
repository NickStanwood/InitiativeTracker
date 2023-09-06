﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public enum CharacterType
    {
        DMControlled,
        PlayerControlled
    }

    public class Character : ViewModelBase
    {
        private CharacterType _type;
        public CharacterType Type { get { return _type; } set { _type = value; Notify(); } }

        private bool _isEnabled = true;
        public bool IsEnabled { get { return _isEnabled; } set { _isEnabled = value; Notify(); } }

        private string _name;
        public string Name { get { return _name; } set { _name = value; Notify(); } }

        private int _AC;
        public int AC { get { return _AC; } set { _AC = value; Notify(); } }

        private int _HP;
        public int HP { get { return _HP; } set { _HP = value; Notify(); } }

        private Initiative _initiative = new Initiative();
        public Initiative Initiative { get { return _initiative; } set { _initiative = value; Notify(); } }

        public Character(CharacterType type)
        {
            Type = type;
            _initiative.PropertyChanged += (sender, e) => Notify(nameof(Initiative));
        }

        public Character Clone()
        {
            Character c = new Character(Type);
            c.Name = Name;
            c.AC = AC;
            c.HP = HP;
            c.Initiative = Initiative;

            return c;
        }

        public void CopyFrom(Character source)
        {
            Name = source.Name;
            AC = source.AC;
            HP = source.HP;
            Initiative = source.Initiative;
        }
    }
}
