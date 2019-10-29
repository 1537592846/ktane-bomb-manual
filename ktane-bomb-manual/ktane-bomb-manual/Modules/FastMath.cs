using System;
using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class FastMath : Module
    {
        public string FirstLetter;
        public string SecondLetter;
        public Dictionary<string, int> PairedValues = new Dictionary<string, int>() { { "AA", 25 }, { "AB", 11 }, { "AC", 53 }, { "AD", 97 }, { "AE", 02 }, { "AG", 42 }, { "AK", 51 }, { "AN", 97 }, { "AP", 12 }, { "AS", 86 }, { "AT", 55 }, { "AX", 73 }, { "AZ", 33 }, { "BA", 54 }, { "BB", 07 }, { "BC", 32 }, { "BD", 19 }, { "BE", 84 }, { "BG", 33 }, { "BK", 27 }, { "BN", 78 }, { "BP", 26 }, { "BS", 46 }, { "BT", 09 }, { "BX", 13 }, { "BZ", 58 }, { "CA", 86 }, { "CB", 37 }, { "CC", 44 }, { "CD", 01 }, { "CE", 05 }, { "CG", 26 }, { "CK", 93 }, { "CN", 49 }, { "CP", 18 }, { "CS", 69 }, { "CT", 23 }, { "CX", 40 }, { "CZ", 22 }, { "DA", 54 }, { "DB", 28 }, { "DC", 77 }, { "DD", 93 }, { "DE", 11 }, { "DG", 00 }, { "DK", 35 }, { "DN", 61 }, { "DP", 27 }, { "DS", 48 }, { "DT", 13 }, { "DX", 72 }, { "DZ", 80 }, { "EA", 99 }, { "EB", 36 }, { "EC", 23 }, { "ED", 95 }, { "EE", 67 }, { "EG", 05 }, { "EK", 26 }, { "EN", 17 }, { "EP", 44 }, { "ES", 60 }, { "ET", 26 }, { "EX", 41 }, { "EZ", 67 }, { "GA", 74 }, { "GB", 95 }, { "GC", 03 }, { "GD", 04 }, { "GE", 56 }, { "GG", 23 }, { "GK", 54 }, { "GN", 29 }, { "GP", 52 }, { "GS", 38 }, { "GT", 10 }, { "GX", 76 }, { "GZ", 98 }, { "KA", 88 }, { "KB", 64 }, { "KC", 37 }, { "KD", 96 }, { "KE", 02 }, { "KG", 52 }, { "KK", 81 }, { "KN", 37 }, { "KP", 12 }, { "KS", 70 }, { "KT", 14 }, { "KX", 36 }, { "KZ", 78 }, { "NA", 54 }, { "NB", 43 }, { "NC", 12 }, { "ND", 65 }, { "NE", 94 }, { "NG", 03 }, { "NK", 47 }, { "NN", 23 }, { "NP", 16 }, { "NS", 62 }, { "NT", 73 }, { "NX", 46 }, { "NZ", 21 }, { "PA", 07 }, { "PB", 33 }, { "PC", 26 }, { "PD", 01 }, { "PE", 67 }, { "PG", 26 }, { "PK", 27 }, { "PN", 77 }, { "PP", 83 }, { "PS", 14 }, { "PT", 27 }, { "PX", 93 }, { "PZ", 09 }, { "SA", 63 }, { "SB", 64 }, { "SC", 94 }, { "SD", 27 }, { "SE", 48 }, { "SG", 84 }, { "SK", 33 }, { "SN", 10 }, { "SP", 16 }, { "SS", 74 }, { "ST", 43 }, { "SX", 99 }, { "SZ", 04 }, { "TA", 35 }, { "TB", 39 }, { "TC", 03 }, { "TD", 25 }, { "TE", 47 }, { "TG", 62 }, { "TK", 38 }, { "TN", 45 }, { "TP", 88 }, { "TS", 48 }, { "TT", 34 }, { "TX", 31 }, { "TZ", 27 }, { "XA", 67 }, { "XB", 30 }, { "XC", 27 }, { "XD", 71 }, { "XE", 09 }, { "XG", 11 }, { "XK", 44 }, { "XN", 37 }, { "XP", 18 }, { "XS", 40 }, { "XT", 32 }, { "XX", 15 }, { "XZ", 78 }, { "ZA", 13 }, { "ZB", 23 }, { "ZC", 26 }, { "ZD", 85 }, { "ZE", 92 }, { "ZG", 12 }, { "ZK", 73 }, { "ZN", 56 }, { "ZP", 81 }, { "ZS", 07 }, { "ZT", 75 }, { "ZX", 47 }, { "ZZ", 99 } };

        public override string Solve(Bomb bomb)
        {
            int numberToReturn = 0;
            numberToReturn += bomb.HasLitIndicator("msa") ? 20 : 0;
            numberToReturn += bomb.HasPort("serial") ? 14 : 0;
            numberToReturn += bomb.HasAnySerialChar("fast") ? -5 : 0;
            numberToReturn += bomb.HasPort("rj") ? 27 : 0;
            numberToReturn += bomb.HasManyBatteries(4) ? -15 : 0;
            numberToReturn += PairedValues[FirstLetter.ToUpper() + SecondLetter.ToUpper()];

            if (numberToReturn < 0) numberToReturn += 50;
            numberToReturn = numberToReturn % 100;

            Solved = true;

            return String.Format("{0:00}.", numberToReturn);
        }

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.GetLetterFromPhoneticLetter(word) != "")
                {
                    if (string.IsNullOrWhiteSpace(FirstLetter)) FirstLetter = InternalFunctions.GetLetterFromPhoneticLetter(word);
                    else SecondLetter = InternalFunctions.GetLetterFromPhoneticLetter(word);
                }
            }

            if (string.IsNullOrWhiteSpace(FirstLetter) || string.IsNullOrWhiteSpace(SecondLetter)) return "Missing letter.";
            return Solve(bomb);
        }
    }
}
