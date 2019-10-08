using System;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Bitwise : Module
    {
        int Number1;
        int Number2;
        string Operation;

        public override string Solve(Bomb bomb)
        {
            var endResult = 0;
            switch (Operation)
            {
                case "and": endResult = Number1 & Number2; break;
                case "or": endResult = Number1 | Number2; break;
                case "xor": endResult = Number1 ^ Number2; break;
                case "not": endResult = ~Number1; break;
            }

            string bits = Convert.ToString(endResult, 2) + "00000000";
            bits = new string (bits.Substring(0, 8).Reverse().ToArray());

            var message = "The answer is ";

            foreach (var bit in bits)
            {
                message += bit + ", ";
            }

            return message.Substring(0, message.Length - 2) + ".";
        }

        public override string Command(Bomb bomb, string command)
        {
            Number1 += bomb.BatteryAA == 0 ? 128 : 0;
            Number1 += bomb.HasPort("parallel") ? 64 : 0;
            Number1 += bomb.HasLitIndicator("nsa") ? 32 : 0;
            Number1 += bomb.HasMoreModulesThanTime() ? 16 : 0;
            Number1 += bomb.GetLitIndicators() > 1 ? 8 : 0;
            Number1 += bomb.ModulesQuantity % 3 == 0 ? 4 : 0;
            Number1 += bomb.BatteryD < 2 ? 2 : 0;
            Number1 += bomb.GetPortsQuantity() < 4 ? 1 : 0;

            Number2 += bomb.BatteryD > 0 ? 128 : 0;
            Number2 += bomb.GetPortsQuantity() > 2 ? 64 : 0;
            Number2 += bomb.GetBatteriesHolders() > 1 ? 32 : 0;
            Number2 += bomb.HasLitIndicator("bob") ? 16 : 0;
            Number2 += bomb.GetUnlitIndicators() > 1 ? 8 : 0;
            Number2 += bomb.HasSerialOdd() ? 4 : 0;
            Number2 += bomb.ModulesQuantity % 2 == 0 ? 2 : 0;
            Number2 += bomb.HasManyBatteries(2) ? 1 : 0;

            Operation = command.Split(' ').Last();

            return Solve(bomb);
        }
    }
}
