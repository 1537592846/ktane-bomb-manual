using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Knobs : Module
    {
        public Knobs(string sequence)
        {
            Sequence = sequence;
        }

        public string Sequence { get; set; }

        public override string Solve(Bomb bomb)
        {
            Solved = true;
            return GetKnobFinalPosition();
        }

        public string GetKnobFinalPosition()
        {
            var SplitedSequence = Sequence.Split(' ').Where(x => x == "up" || x == "down" || x == "both" || x == "none");
            string leds = "";
            string message = "";
            bool up1;
            bool up2;
            bool left1;
            bool left2;
            bool down1;
            bool down2;
            bool right1;
            bool right2;

            foreach (var config in SplitedSequence)
            {
                leds += config.Replace("up", "10").Replace("down", "01").Replace("both", "11").Replace("none", "00");
            }

            up1 = CompareConfigurationWithLeds(leds, "010111011011");
            up2 = CompareConfigurationWithLeds(leds, "100111001101");
            down1 = CompareConfigurationWithLeds(leds, "011111010011");
            down2 = CompareConfigurationWithLeds(leds, "100110001001");
            left1 = CompareConfigurationWithLeds(leds, "010000011101");
            left2 = CompareConfigurationWithLeds(leds, "000000011100");
            right1 = CompareConfigurationWithLeds(leds, "110111101110");
            right2 = CompareConfigurationWithLeds(leds, "110111100100");

            if (up1||up2)
            {
                if (message == "")
                    message = "Final position is up.";
                else
                {
                    message = "Can't tell yet.";
                }
            }

            if (down1 || down2)
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
