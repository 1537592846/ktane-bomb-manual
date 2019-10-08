using Newtonsoft.Json;
using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class BinaryLEDs : Module
    {
        public string NumberList1 = "17,15,6,2,24,8,26,25,21,24,1,15,18,8,18,15,1,24,21,25,26,8,24,2,6,15,17,15,6,2,24,8,26,25,21,24,1,15,18,8";
        public string NumberList2 = "18,15,19,31,12,6,19,21,11,16,19,2,1,29,1,2,19,16,11,21,19,6,12,31,19,15,18,15,19,31,12,6,19,21,11,16,19,2,1,29";
        public string NumberList3 = "8,25,1,15,20,15,9,3,6,24,1,24,5,26,5,24,1,24,6,3,9,15,20,15,1,25,8,25,1,15,20,15,9,3,6,24,1,24,5,26";
        public string NumberList4 = "21,27,6,12,27,20,7,1,19,15,3,13,9,28,9,13,3,15,19,1,7,20,27,12,6,27,21,27,6,12,27,20,7,1,19,15,3,13,9,28";
        public string NumberList5 = "3,21,14,22,7,28,16,27,22,17,26,2,31,15,31,2,26,17,22,27,16,28,7,22,14,21,3,21,14,22,7,28,16,27,22,17,26,2,31,15";
        public string NumberList6 = "8,22,30,19,1,25,31,16,9,7,6,13,9,7,9,13,6,7,9,16,31,25,1,19,30,22,8,22,30,19,1,25,31,16,9,7,6,13,9,7";
        public string NumberList7 = "5,18,12,7,5,12,31,16,10,15,17,9,12,25,12,9,17,15,10,16,31,12,5,7,12,18,5,18,12,7,5,12,31,16,10,15,17,9,12,25";
        public string NumberList8 = "4,20,18,25,20,4,24,29,17,16,12,16,29,19,29,16,12,16,17,29,24,4,20,25,18,20,4,20,18,25,20,4,24,29,17,16,12,16,29,19";

        public BinaryLEDs()
        {
            Numbers = new List<int>();
        }

        List<int> Numbers;

        public override string Solve(Bomb bomb)
        {
            var json = JsonConvert.SerializeObject(Numbers).Replace("[", "").Replace("]", "");

            Solved = true;

            if (NumberList1.Contains(json)) return "Cut the green one on 4.";
            if (NumberList2.Contains(json)) return "Cut the green one on 2-4-5.";
            if (NumberList3.Contains(json)) return "Cut the green one on 1-2-5.";
            if (NumberList4.Contains(json)) return "Cut the green one on 2-5.";
            if (NumberList5.Contains(json)) return "Cut the green one on 1-2-3.";
            if (NumberList6.Contains(json)) return "Cut the green one on 3-4.";
            if (NumberList7.Contains(json)) return "Cut the green one on 2-3-4-5.";
            if (NumberList8.Contains(json)) return "Cut the green one on 3.";

            Solved = false;
            return "Can't find it yet.";
        }

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Replace("binary leds", "").Trim().Split(' '))
            {
                Numbers.Add((word.Contains("1") ? 16 : 0) + (word.Contains("2") ? 8 : 0) + (word.Contains("3") ? 4 : 0) + (word.Contains("4") ? 2 : 0) + (word.Contains("5") ? 1 : 0));
            }

            return Solve(bomb);
        }
    }
}
