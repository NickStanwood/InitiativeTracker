﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitiativeTracker
{
    /// <summary>
    /// Interaction logic for CharacterBox.xaml
    /// </summary>
    public partial class CharacterBox : UserControl
    {        
        public CharacterBox()
        {
            InitializeComponent();
        }

        public Character? GetViewModel()
        {
            return DataContext as Character;
        }
    }
}