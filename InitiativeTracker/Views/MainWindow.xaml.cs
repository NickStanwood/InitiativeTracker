﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Encounter Model;
        public MainWindow()
        {
            InitializeComponent();
            Model = new Encounter();
            this.DataContext = Model;
        }

        private void BtnAddCharacter_Click(object sender, RoutedEventArgs e)
        {
            NewCharacterWindow newCharWin = new NewCharacterWindow(CharacterType.PlayerControlled);
            bool? result = newCharWin.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Model.PlayerCharacters.Add(newCharWin.Character);
            }
        }

        private void BtnAddDMCharacter_Click(object sender, RoutedEventArgs e)
        {
            NewCharacterWindow newCharWin = new NewCharacterWindow(CharacterType.DMControlled);
            bool? result = newCharWin.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Model.DMCharacters.Add(newCharWin.Character);
            }

        }

        private void CharacterBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CharacterBox cb = (CharacterBox)sender;
            Character? original = cb.GetViewModel();
            if (original != null)
            {
                Character modified = original.Clone();
                NewCharacterWindow newCharWin = new NewCharacterWindow(modified);
                bool? result = newCharWin.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    //new character dialog was saved
                    original.CopyFrom(modified);
                
                }
            }
        }
        private void CharacterBox_Copied(object sender, CharacterCopyEventArgs e)
        {
            if (e.CopiedCharacter == null)
                return;

            string name = e.CopiedCharacter.Name;

            //check if names ends with a digit. increase it by 1 if it does
            Regex reg = new Regex(@"(.*)\s+(\d+)$");
            Match match = reg.Match(e.CopiedCharacter.Name);
            if (match.Success)
                name = match.Groups[1].Value;

            int copyNum = 1;
            //check all player characters for the same name
            foreach (Character c in Model.PlayerCharacters)
            {
                Match m = reg.Match(c.Name);
                if (m.Success && m.Groups[1].Value == name)
                {
                    //of all the matching characters. largest number and increase it by 1
                    int num = int.Parse(m.Groups[2].Value);
                    if(num >= copyNum)
                        copyNum = num + 1;
                }
            }

            e.CopiedCharacter.Name = name + " " + copyNum.ToString();
            Model.PlayerCharacters.Add(new Character(e.CopiedCharacter));
        }

        private void BtnRollInit_Click(object sender, RoutedEventArgs e)
        {
            foreach(Character c in Model.DMCharacters)
            {
                c.Initiative.Roll();
            }
        }

        private void BtnStartCombat_Click(object sender, RoutedEventArgs e)
        {
            Model.CreateCombatList();
        }

        private void BtnNextTurn_Click(object sender, RoutedEventArgs e)
        {
            Model.GoToNextCombatant();
        }

        private void BtnEndCombat_Click(object sender, RoutedEventArgs e)
        {
            Model.EndCombat();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML file (*.xml)|*.xml";

            if (ofd.ShowDialog() == true)
            {
                EncounterModel? model = XmlSerializer.Deserialize(ofd.FileName);
                if (model != null)
                {
                    Model = new Encounter(model);
                    this.DataContext = Model;
                    Model.FilePath = ofd.FileName;
                }
            }
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            if(Model.FilePath.EndsWith(".xml"))
            {
                XmlSerializer.Serialize(Model.FilePath, Model.GetModel());
            }
            else
            {
                MenuItemSaveAs_Click(sender, e);
            }
        }

        private void MenuItemSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML file (*.xml)|*.xml";

            if(sfd.ShowDialog() == true)
            {
                Model.FilePath = sfd.FileName;
                XmlSerializer.Serialize(Model.FilePath, Model.GetModel());
            }
        }

    }
}
