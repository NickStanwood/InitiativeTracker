using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;

namespace InitiativeTracker
{
    public static class Dice
    {
        private static Random Rand = new Random();
        public static int RollD20()
        {
            return Rand.Next(1,21);
        }

        public static bool TryRoll(string diceString, ref int result)
        {
            //roll all the dice in the dicestring that are in the for 1d8 or {n}d{k}
            string dicePattern = "([0-9]+)[dD]([0-9]+)";
            string mathString = "";
            try
            {
                int lastMatchInedx = 0;
                var matches = Regex.Matches(diceString, dicePattern);
                foreach (Match m in matches)
                {
                    string rollString = m.Groups[0].Value;
                    string count = m.Groups[1].Value;
                    string sides = m.Groups[2].Value;
                    int diceRoll = Roll(int.Parse(count), int.Parse(sides));
                    mathString += diceString.Substring(lastMatchInedx, m.Index - lastMatchInedx);
                    mathString += diceRoll;
                    lastMatchInedx = m.Index + m.Length;
                }
                mathString += diceString.Substring(lastMatchInedx);

                //compute the string now that all the dice have been rolled
                DataTable dt = new DataTable();
                result = (int)dt.Compute(mathString, "");
                return true;
            }
            catch
            {
                return false;
            }

            
        }

        public static int Roll(int diceCount, int diceSides)
        {
            int result = 0;
            for(int i = 0; i < diceCount; i++)
                result += Rand.Next(1, diceSides+1);
            return result;
        }
    }
}
