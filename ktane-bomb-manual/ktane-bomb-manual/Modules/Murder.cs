using System;
using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Murder: Module
    {
        public int MurdererRow = 0;
        public int WeaponRow = 0;
        public string Murderer;
        public string Weapon;
        public string LocationBody;
        public string LocationCrime;
        public List<string> Suspects = new List<string>();
        public List<string> Weapons = new List<string>();

        public Dictionary<string, List<string>> PossibleSuspects = new Dictionary<string, List<string>>() { { "Scarlett", new List<string>() { "Dining Room", "Study", "Kitchen", "Lounge", "Billiard Room", "Conservatory", "Ballroom", "Hall", "Library", } }, { "Plum", new List<string>() { "Library", "Hall", "Billiard Room", "Ballroom", "Kitchen", "Lounge", "Conservatory", "Study", "Dining Room", } }, { "Peacock", new List<string>() { "Lounge", "Billiard Room", "Ballroom", "Dining Room", "Study", "Library", "Kitchen", "Conservatory", "Hall", } }, { "Green", new List<string>() { "Kitchen", "Lounge", "Library", "Conservatory", "Ballroom", "Study", "Hall", "Dining Room", "Billiard Room", } }, { "Mustard", new List<string>() { "Study", "Kitchen", "Conservatory", "Hall", "Dining Room", "Billiard Room", "Library", "Lounge", "Ballroom", } }, { "White", new List<string>() { "Conservatory", "Library", "Dining Room", "Kitchen", "Hall", "Ballroom", "Study", "Billiard Room", "Lounge", } } };
        public Dictionary<string, List<string>> PossibleWeapons = new Dictionary<string, List<string>>() { { "Candlestick", new List<string>() { "Dining Room", "Study", "Kitchen", "Lounge", "Billiard Room", "Conservatory", "Ballroom", "Hall", "Library", } }, { "Dagger", new List<string>() { "Library", "Hall", "Billiard Room", "Ballroom", "Kitchen", "Lounge", "Conservatory", "Study", "Dining Room", } }, { "Lead Pipe", new List<string>() { "Lounge", "Billiard Room", "Ballroom", "Dining Room", "Study", "Library", "Kitchen", "Conservatory", "Hall", } }, { "Revolver", new List<string>() { "Kitchen", "Lounge", "Library", "Conservatory", "Ballroom", "Study", "Hall", "Dining Room", "Billiard Room", } }, { "Rope", new List<string>() { "Study", "Kitchen", "Conservatory", "Hall", "Dining Room", "Billiard Room", "Library", "Lounge", "Ballroom", } }, { "Spanner", new List<string>() { "Conservatory", "Library", "Dining Room", "Kitchen", "Hall", "Ballroom", "Study", "Billiard Room", "Lounge", } } };

        public override string Command(Bomb bomb, string command)
        {
            foreach(var word in command.Split(' '))
            {
                if(PossibleSuspects.Keys.Where(x => x.StartsWith(InternalFunctions.ToPascalCase(word))).Count() > 0)
                {
                    Suspects.Add(PossibleSuspects.Keys.Where(x => x.StartsWith(InternalFunctions.ToPascalCase(word))).First());
                    continue;
                }

                if(PossibleWeapons.Keys.Where(x => x.StartsWith(InternalFunctions.ToPascalCase(word))).Count() > 0)
                {
                    Weapons.Add(PossibleWeapons.Keys.Where(x => x.StartsWith(InternalFunctions.ToPascalCase(word))).First());
                    continue;
                }

                if(PossibleSuspects["Scarlett"].Where(x => x.StartsWith(InternalFunctions.ToPascalCase(word))).Count() > 0)
                {
                    LocationBody = PossibleSuspects["Scarlett"].Where(x => x.StartsWith(InternalFunctions.ToPascalCase(word))).First();
                    continue;
                }
            }

            if(Suspects.Count > 0 && Weapons.Count > 0 && !string.IsNullOrEmpty(LocationBody))
                return Solve(bomb);

            return "Not enought information.";
        }
        public override string Solve(Bomb bomb)
        {
            SetRowNumbers(bomb);

            foreach(var suspect in Suspects)
            {
                foreach(var weapon in Weapons)
                {
                    if(PossibleSuspects[suspect].ElementAt(MurdererRow) == PossibleWeapons[weapon].ElementAt(WeaponRow))
                    {
                        Solved = true;
                        return suspect + ", with " + weapon + ", in " + PossibleSuspects[suspect].ElementAt(MurdererRow) + ".";
                    }
                }
            }

            return "Cannot solve.";
        }

        public void SetRowNumbers(Bomb bomb)
        {
            if(MurdererRow == 0 && bomb.HasLitIndicator("TNR"))
                MurdererRow = 5;
            if(MurdererRow == 0 && LocationBody == "Dining Room")
                MurdererRow = 7;
            if(MurdererRow == 0 && bomb.HasPort("stereo", 2))
                MurdererRow = 8;
            if(MurdererRow == 0 && bomb.BatteryD == 0)
                MurdererRow = 2;
            if(MurdererRow == 0 && LocationBody == "Study")
                MurdererRow = 4;
            if(MurdererRow == 0 && bomb.HasManyBatteries(5))
                MurdererRow = 9;
            if(MurdererRow == 0 && bomb.HasUnlitIndicator("FRQ"))
                MurdererRow = 1;
            if(MurdererRow == 0 && LocationBody == "Conservatory")
                MurdererRow = 3;
            if(MurdererRow == 0)
                MurdererRow = 6;
            MurdererRow--;

            if(WeaponRow == 0 && LocationBody == "Lounge")
                WeaponRow = 3;
            if(WeaponRow == 0 && bomb.HasManyBatteries(5))
                WeaponRow = 1;
            if(WeaponRow == 0 && bomb.HasPort("serial"))
                WeaponRow = 9;
            if(WeaponRow == 0 && LocationBody == "Billiard Room")
                WeaponRow = 4;
            if(WeaponRow == 0 && bomb.GetBatteries() == 0)
                WeaponRow = 6;
            if(WeaponRow == 0 && bomb.GetLitIndicators() == 0)
                WeaponRow = 5;
            if(WeaponRow == 0 && LocationBody == "Hall")
                WeaponRow = 7;
            if(WeaponRow == 0 && bomb.HasPort("stereo", 2))
                WeaponRow = 2;
            if(WeaponRow == 0)
                WeaponRow = 8;
            WeaponRow--;
        }
    }
}
