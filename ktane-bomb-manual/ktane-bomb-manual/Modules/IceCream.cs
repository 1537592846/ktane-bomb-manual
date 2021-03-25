using System;
using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class IceCream :Module
    {
        public Dictionary<string, List<string>> Flavors = new Dictionary<string, List<string>> { { "tutti frutti", new List<string> { "vanilla", "strawberry", "banana", "cherrie", "raspberry" } }, { "rocky road", new List<string> { "chocolate", "nut", "marshmellow" } }, { "raspberry ripple", new List<string> { "vanilla", "raspberry sauce" } }, { "double chocolate", new List<string> { "chocolate", "chocolate chip" } }, { "double strawberry", new List<string> { "strawberry sauce", "strawberry" } }, { "cookies and cream", new List<string> { "vanilla", "cookie" } }, { "neapolitan", new List<string> { "strawberry", "chocolate", "vanilla" } }, { "mint chocolate chip", new List<string> { "mint", "chocolate chip" } }, { "the classic", new List<string> { "vanilla", "chocolate sauce", "cherry" } }, { "vanilla", new List<string> { "vanilla" } }, };
        public List<string> AllergyConverter = new List<string> { "chocolate", "strawberry", "raspberry", "nut", "cookie", "mint", "fruit", "cherry", "marshmellow" };
        public List<string> Fruits = new List<string> { "strawberry", "raspberry", "cherry" };
        public int LastSerialNumber;
        public Dictionary<string, List<string>> AllergyTable = new Dictionary<string, List<string>> { { "mike", new List<string> { "1,5,0", "6,8,3", "0,7,1", "4,3,2", "3,6,1" } }, { "tim", new List<string> { "0,8,3", "2,1,4", "4,3,5", "2,6,7", "1,4,3" } }, { "tom", new List<string> { "8,4,5", "1,6,7", "2,5,6", "3,7,5", "3,6,1" } }, { "dave", new List<string> { "2,6,7", "0,1,4", "8,2,3", "7,8,1", "5,7,3" } }, { "adam", new List<string> { "3,4,1", "3,6,2", "0,2,1", "2,4,7", "8,5,6" } }, { "cheryl", new List<string> { "1,6,3", "7,5,2", "1,4,5", "4,2,0", "3,7,5" } }, { "sean", new List<string> { "4,6,1", "2,3,6", "1,5,7", "6,8,2", "2,7,4" } }, { "ashley", new List<string> { "6,2,5", "4,1,7", "0,8,2", "1,2,6", "3,6,7" } }, { "jessica", new List<string> { "4,2,6", "1,2,3", "0,3,4", "6,5,0", "4,7,8" } }, { "taylor", new List<string> { "6,3,5", "5,1,2", "4,2,6", "7,1,0", "3,7,2" } }, { "simon", new List<string> { "0,3,5", "1,6,4", "5,4,8", "2,0,7", "7,3,6" } }, { "sally", new List<string> { "4,6,3", "1,0,2", "6,7,4", "2,5,8", "0,3,1" } }, { "jade", new List<string> { "3,7,1", "0,8,2", "7,1,3", "6,7,8", "4,5,1" } }, { "sam", new List<string> { "2,4,1", "7,8,0", "3,4,6", "1,0,3", "6,5,2" } }, { "gary", new List<string> { "1,2,5", "6,8,0", "3,2,1", "7,4,5", "1,8,4" } }, { "victor", new List<string> { "0,3,1", "2,5,7", "3,4,6", "6,7,1", "5,3,0" } }, { "george", new List<string> { "8,1,2", "6,4,8", "0,4,3", "1,6,4", "3,2,5" } }, { "jacob", new List<string> { "7,3,2", "1,5,6", "5,4,7", "3,4,0", "6,2,1" } }, { "pat", new List<string> { "5,6,2", "1,3,6", "3,4,7", "2,0,5", "8,1,3" } }, { "bom", new List<string> { "5,6,8", "2,1,0", "4,8,2", "4,2,5", "0,5,1" } }, };
        public List<List<string>> FlavorListTable = new List<List<string>> { new List<string> { "cookies and cream", "neapolitan", "tutti frutti", "the classic", "rocky road", "double chocolate", "mint chocolate chip", "double strawberry", "raspberry ripple", "vanilla" }, new List<string> { "double chocolate", "mint chocolate chip", "neapolitan", "rocky road", "tutti frutti", "double strawberry", "cookies and cream", "raspberry ripple", "the classic", "vanilla" }, new List<string> { "neapolitan", "tutti frutti", "cookies and cream", "raspberry ripple", "double strawberry", "mint chocolate chip", "double chocolate", "the classic", "rocky road", "vanilla" }, new List<string> { "double strawberry", "cookies and cream", "rocky road", "the classic", "neapolitan", "double chocolate", "tutti frutti", "raspberry ripple", "mint chocolate chip", "vanilla" } };
        public Dictionary<string, List<string>> Clients = new Dictionary<string, List<string>>();

        public override string Command(Bomb bomb, string command)
        {
            LastSerialNumber = bomb.GetSerialLastNumberDigit();
            var client = AllergyTable.Keys.Where(x => command.Contains(x)).FirstOrDefault();
            var flavors = new List<string>();

            if (string.IsNullOrEmpty(client))
                return "Client not found.";

            var words = command.Split(' ');
            for (int i = 0;i < words.Length;i++)
            {
                var flavor = words[i];
                if (Flavors.Keys.Contains(flavor))
                {
                    flavors.Add(flavor);
                    continue;
                }

                if (words.Length == i + 1)
                    continue;
                flavor += " " + words[i + 1];
                if (Flavors.Keys.Contains(flavor))
                {
                    flavors.Add(flavor);
                    continue;
                }

                if (words.Length == i + 2)
                    continue;
                flavor += " " + words[i + 2];
                if (Flavors.Keys.Contains(flavor))
                {
                    flavors.Add(flavor);
                }
            }

            if (flavors.Count < 5)
                return "Flavors not found.";

            Clients.Add(client, flavors);

            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            var client = Clients.Last().Key;
            var allergiesNumbers = AllergyTable[client][LastSerialNumber / 2].Split(',');
            client = client.Substring(0, 1).ToUpper() + client.Substring(1);
            var allergies = new List<string> { AllergyConverter[int.Parse(allergiesNumbers[0])], AllergyConverter[int.Parse(allergiesNumbers[1])], AllergyConverter[int.Parse(allergiesNumbers[2])] };
            if (allergies.Contains("fruit"))
            {
                allergies.Remove("fruit");
                allergies.AddRange(Fruits);
            }
            List<string> flavorsToSell = new List<string>();

            if (bomb.GetLitIndicators() > bomb.GetUnlitIndicators())
                flavorsToSell = FlavorListTable[0];
            else if (bomb.HasEmptyPortPlate())
                flavorsToSell = FlavorListTable[1];
            else if (bomb.HasManyBatteries(3))
                flavorsToSell = FlavorListTable[2];
            else
                flavorsToSell = FlavorListTable[3];

            if (Clients.Count == 3)
                Solved = true;

            foreach (var flavor in flavorsToSell.Where(x => Clients.Last().Value.Contains(x)))
            {
                if (!Flavors[flavor].Any(x => allergies.Contains(x)))
                    return $"{client} wants {flavor}. Remember, even minutes.";
            }

            return "Cannot sell any flavor.";
        }
    }
}