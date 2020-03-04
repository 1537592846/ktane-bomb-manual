using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class AdventureGames : Module
    {
        public AdventureGames()
        {
            Weapons = new List<string>();
            Items = new List<string>();
        }

        public string Enemy;
        public int STR;
        public int DEX;
        public int INT;
        public string Height;
        public int Temperature;
        public double Gravity;
        public int Pressure;
        public List<string> Weapons;
        public List<string> Items;
        public List<string> PossibleItems = new List<string>() { "ballon", "battery", "bellows", "crystal ball", "feather", "hard drive", "lamp", "moonstone", "potion", "small dog", "stepladder", "sunstone", "symbol", "ticket", "throphy" };
        public List<string> PossibleWeapons = new List<string>() { "caber", "longbow", "grimoire", "broadsword", "nasty knife", "magic orb" };
        public Dictionary<string, string> Enemies = new Dictionary<string, string> { { "demon", "50-50-50" }, { "dragon", "10-11-13" }, { "eagle", "4-7-3" }, { "goblin", "3-6-5" }, { "golem", "9-4-7" }, { "troll", "8-5-4" }, { "lizard", "4-6-3" }, { "wizard", "4-3-8" } };

        public override string Solve(Bomb bomb)
        {
            var message = "Use ";
            foreach (var item in Items)
            {
                switch (item)
                {
                    case "ballon": { if ((Gravity < 9.3 || Pressure > 110) && Enemy != "eagle") message += item + ", then "; break; }
                    case "battery": { if (bomb.HasManyBatteries(1) && !bomb.HasManyBatteries(0) && !(Enemy == "golem" || Enemy == "wizard")) message += item + ", then "; break; }
                    case "bellows": { if (((Enemy == "dragon" || Enemy == "eagle") && Pressure > 105) || (!(Enemy == "dragon" || Enemy == "eagle") && Pressure < 95)) message += item + ", then "; break; }
                    case "crystal ball": { if (INT > bomb.GetSerialLastNumberDigit() && Enemy != "wizard") message += item + ", then "; break; }
                    case "feather": { if (DEX > STR || DEX > INT) message += item + ", then "; break; }
                    case "hard drive": { if (bomb.HasAnyDuplicatedPort()) message += item + ", then "; break; }
                    case "lamp": { if (Temperature < 12 && Enemy != "lizard") message += item + ", then "; break; }
                    case "moonstone": { if (bomb.GetUnlitIndicators() >= 2) message += item + ", then "; break; }
                    case "potion": { ClearModule(); return "Use the potion first, then update the status."; }
                    case "small dog": { if (Enemy != "demon" && Enemy != "dragon" && Enemy != "troll") message += item + ", then "; break; }
                    case "stepladder": { if (int.Parse(Height[0].ToString()) < 4) message += item + ", then "; break; }
                    case "sunstone": { if (bomb.GetLitIndicators() >= 2) message += item + ", then "; break; }
                    case "symbol": { if (Enemy == "demon" || Enemy == "golem" || Temperature > 31) message += item + ", then "; break; }
                    case "ticket": { var H1 = int.Parse(Height[0].ToString()); var H2 = 0; int.TryParse(Height[3].ToString(), out H2); if ((H1 > 4 || (H1 == 4 && H2 >= 6)) && Gravity >= 9.2 && Gravity <= 10.4) message += item + ", then "; break; }
                    case "throphy": { if (STR > bomb.GetSerialFirstNumberDigit() || Enemy == "troll") message += item + ", then "; break; }
                    default: break;
                }
            }

            var enemySTR = int.Parse(Enemies[Enemy].Split('-')[0]);
            var enemyDEX = int.Parse(Enemies[Enemy].Split('-')[1]);
            var enemyINT = int.Parse(Enemies[Enemy].Split('-')[2]);
            var checkSTR = Weapons.Contains("broadsword") || Weapons.Contains("caber");
            var checkDEX = Weapons.Contains("nasty knife") || Weapons.Contains("longbow");
            var checkINT = Weapons.Contains("magic orb") || Weapons.Contains("grimoire");
            var differenceBefore = 10;
            var weaponToUse = "";

            foreach (var weapon in PossibleWeapons.Where(x => Weapons.Contains(x)))
            {
                var differenceInSTR = checkSTR ? enemySTR - STR - (weapon == "caber" ? 2 : 0) : 10;
                var differenceInDEX = checkDEX ? enemyDEX - DEX - (weapon == "longbow" ? 2 : 0) : 10;
                var differenceInINT = checkINT ? enemyINT - INT - (weapon == "grimoire" ? 2 : 0) : 10;

                if (differenceInSTR < differenceInDEX && differenceInSTR < differenceInINT && differenceInSTR < differenceBefore)
                {
                    differenceBefore = differenceInSTR;
                    weaponToUse = weapon;
                    continue;
                }

                if (differenceInDEX < differenceInSTR && differenceInDEX < differenceInINT && differenceInDEX < differenceBefore)
                {
                    differenceBefore = differenceInDEX;
                    weaponToUse = weapon;
                    continue;
                }

                if (differenceInINT < differenceInDEX && differenceInINT < differenceInSTR && differenceInINT < differenceBefore)
                {
                    differenceBefore = differenceInINT;
                    weaponToUse = weapon;
                    continue;
                }
            }
            Solved = true;
            return message + weaponToUse + ".";
        }

        public override string Command(Bomb bomb, string command)
        {
            var wordList = command.Replace("adventure games", "").Trim().Split(' ');
            Enemy = wordList[0];
            STR = int.Parse(wordList[1]);
            DEX = int.Parse(wordList[2]);
            INT = int.Parse(wordList[3]);
            Height = wordList[4];
            Temperature = int.Parse(wordList[5].Replace("c", ""));
            Gravity = double.Parse(wordList[6].Replace("m/s", ""), CultureInfo.InvariantCulture);
            Pressure = int.Parse(wordList[7].Replace("kpa", ""));
            var weaponAndItem = wordList.Skip(8).ToList();
            for (int i = 0; i < weaponAndItem.Count; i++)
            {
                try { if (PossibleWeapons.Contains(weaponAndItem[i])) Weapons.Add(weaponAndItem[i]); } catch { }
                try { if (PossibleWeapons.Contains(weaponAndItem[i] + weaponAndItem[i + 1])) Weapons.Add(weaponAndItem[i] + weaponAndItem[i + 1]); } catch { }
                try { if (PossibleItems.Contains(weaponAndItem[i])) Items.Add(weaponAndItem[i]); } catch { }
                try { if (PossibleItems.Contains(weaponAndItem[i] + weaponAndItem[i + 1])) Items.Add(weaponAndItem[i] + weaponAndItem[i + 1]); } catch { }
            }

            return Solve(bomb);
        }

        public void ClearModule()
        {
            Enemy = "";
            STR = 0;
            DEX = 0;
            INT = 0;
            Height = "";
            Temperature = 0;
            Gravity = 0;
            Pressure = 0;
            Weapons.Clear();
            Items.Clear();
        }
    }
}
