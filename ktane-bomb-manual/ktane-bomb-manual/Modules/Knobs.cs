using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Knobs : Module
    {
        public string Sequence { get; set; }

        public override string Solve(Bomb bomb)
        {
            return GetKnobFinalPosition();
        }

        public override string Command(Bomb bomb, string command)
        {
            Sequence = "";
            foreach (var word in command.Split(' ').Where(x => x == "both" || x == "top" || x == "bottom" || x == "none"))
            {
                Sequence += word+" ";
            }
            Sequence = Sequence.Trim();

            return Solve(bomb);
        }

        public string GetKnobFinalPosition()
        {
            var SplitedSequence = Sequence.Split(' ').Where(x => x == "top" || x == "bottom" || x == "both" || x == "none");
            string leds = "";
            string message = "";
            bool top1;
            bool top2;
            bool left1;
            bool left2;
            bool bottom1;
            bool bottom2;
            bool right1;
            bool right2;

            foreach (var config in SplitedSequence)
            {
                leds += config.Replace("top", "10").Replace("bottom", "01").Replace("both", "11").Replace("none", "00");
            }

            top1 = CompareConfigurationWithLeds(leds, "010111011011");
            top2 = CompareConfigurationWithLeds(leds, "100111001101");
            bottom1 = CompareConfigurationWithLeds(leds, "011111010011");
            bottom2 = CompareConfigurationWithLeds(leds, "100110001001");
            left1 = CompareConfigurationWithLeds(leds, "010000011101");
            left2 = CompareConfigurationWithLeds(leds, "000000011100");
            right1 = CompareConfigurationWithLeds(leds, "110111101110");
            right2 = CompareConfigurationWithLeds(leds, "110111100100");

            if (top1 || top2)
            {
                if (message == "")
                    message = "Final position is up.";
                else
                {
                    message = "Can't tell yet.";
                }
            }

            if (bottom1 || bottom2)
            {
                if (message == "")
                    message = "Final position is down.";
                else
                {
                    message = "Can't tell yet.";
                }
            }

            if (left1 || left2)
            {
                if (message == "")
                    message = "Final position is left.";
                else
                {
                    message = "Can't tell yet.";
                }
            }

            if (right1 || right2)
            {
                if (message == "")
                    message = "Final position is right.";
                else
                {
                    message = "Can't tell yet.";
                }
            }

            if (message == "")
            {
                message = "Can't tell yet.";
            }

            return message;
        }

        public bool CompareConfigurationWithLeds(string leds, string config)
        {
            for (int i = 0; i < leds.Length; i++)
            {
                if (leds[i] != config[i]) return false;
            }
            return true;
        }
    }
}
