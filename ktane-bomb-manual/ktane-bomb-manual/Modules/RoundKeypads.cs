using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class RoundKeypads : Module
    {
        public RoundKeypads()
        {
            Symbols = new List<int>();
        }

        public List<int> Symbols;

        public override string Solve(Bomb bomb)
        {
            if (Symbols.Count != 8) return "Can't solve it yet.";
            var list = SymbolOrder();
            var message = "Press this ones: ";
            foreach (var symbol in Symbols)
            {
                if (!list.Contains(symbol))
                    message += WhichSymbol(symbol) + ". ";
            }

            return message.TrimEnd();
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solve"))
            {
                var solveReturn = Solve(bomb);
                Solved = solveReturn != "Can't solve it yet.";
                return solveReturn;
            }
            foreach (var word in command.Split(' '))
            {
                AddSymbol(word);
            }

            return "";
        }

        public List<int> SymbolOrder()
        {
            var order1 = new List<int>() { (int)SymbolList.ArchaicKoppa, (int)SymbolList.LittleYus, (int)SymbolList.Lambda, (int)SymbolList.Koppa, (int)SymbolList.BigYus, (int)SymbolList.Kai, (int)SymbolList.LunateAntiSigma };
            var order2 = new List<int>() { (int)SymbolList.E, (int)SymbolList.ArchaicKoppa, (int)SymbolList.LunateAntiSigma, (int)SymbolList.OHook, (int)SymbolList.WhiteStar, (int)SymbolList.Kai, (int)SymbolList.InvertedQuestionMark };
            var order3 = new List<int>() { (int)SymbolList.CopyrightSign, (int)SymbolList.BroadOmega, (int)SymbolList.OHook, (int)SymbolList.Zhe, (int)SymbolList.KomiDzje, (int)SymbolList.Lambda, (int)SymbolList.WhiteStar };
            var order4 = new List<int>() { (int)SymbolList.Be, (int)SymbolList.Pilcrow, (int)SymbolList.Yat, (int)SymbolList.BigYus, (int)SymbolList.Zhe, (int)SymbolList.InvertedQuestionMark, (int)SymbolList.Teh };
            var order5 = new List<int>() { (int)SymbolList.Psi, (int)SymbolList.Teh, (int)SymbolList.Yat, (int)SymbolList.LunateSigma, (int)SymbolList.Pilcrow, (int)SymbolList.Ksi, (int)SymbolList.BlackStar };
            var order6 = new List<int>() { (int)SymbolList.Be, (int)SymbolList.E, (int)SymbolList.Thousand, (int)SymbolList.Aesc, (int)SymbolList.Psi, (int)SymbolList.ShortI, (int)SymbolList.Omega };

            var count1 = Symbols.Where(x => order1.Contains(x)).Count();
            var count2 = Symbols.Where(x => order2.Contains(x)).Count();
            var count3 = Symbols.Where(x => order3.Contains(x)).Count();
            var count4 = Symbols.Where(x => order4.Contains(x)).Count();
            var count5 = Symbols.Where(x => order5.Contains(x)).Count();
            var count6 = Symbols.Where(x => order6.Contains(x)).Count();

            int max = count1 > count2 ? 1 : 2;
            max = max > count3 ? max : 3;
            max = max > count4 ? max : 4;
            max = max > count5 ? max : 5;
            max = max > count6 ? max : 6;

            switch (max)
            {
                case 1: return order1;
                case 2: return order2;
                case 3: return order3;
                case 4: return order4;
                case 5: return order5;
                default: return order6;
            }
        }

        public void AddSymbol(string description)
        {
            description = " " + description + " ";
            //Symbol names
            if (description.Contains("broad omega")) { AddSymbolToList((int)SymbolList.BroadOmega); return; }
            if (description.Contains("omega")) { AddSymbolToList((int)SymbolList.Omega); return; }
            if (description.Contains("white star")) { AddSymbolToList((int)SymbolList.WhiteStar); return; }
            if (description.Contains("black star")) { AddSymbolToList((int)SymbolList.WhiteStar); return; }
            if (description.Contains("copyright")) { AddSymbolToList((int)SymbolList.CopyrightSign); return; }
            if (description.Contains("question mark")) { AddSymbolToList((int)SymbolList.InvertedQuestionMark); return; }
            if (description.Contains("archaic koppa")) { AddSymbolToList((int)SymbolList.ArchaicKoppa); return; }
            if (description.Contains("small b ")) { AddSymbolToList((int)SymbolList.Be); return; }
            if (description.Contains("small be")) { AddSymbolToList((int)SymbolList.Be); return; }
            if (description.Contains("big yus")) { AddSymbolToList((int)SymbolList.BigYus); return; }
            if (description.Contains("kai")) { AddSymbolToList((int)SymbolList.Kai); return; }
            if (description.Contains("komi dzje")) { AddSymbolToList((int)SymbolList.KomiDzje); return; }
            if (description.Contains("koppa")) { AddSymbolToList((int)SymbolList.Koppa); return; }
            if (description.Contains("ksi")) { AddSymbolToList((int)SymbolList.Ksi); return; }
            if (description.Contains("lambda")) { AddSymbolToList((int)SymbolList.Lambda); return; }
            if (description.Contains("psi")) { AddSymbolToList((int)SymbolList.Psi); return; }
            if (description.Contains("teh")) { AddSymbolToList((int)SymbolList.Teh); return; }
            if (description.Contains("thousand")) { AddSymbolToList((int)SymbolList.Thousand); return; }
            if (description.Contains("short i ")) { AddSymbolToList((int)SymbolList.ShortI); return; }
            if (description.Contains("pilcrow")) { AddSymbolToList((int)SymbolList.Pilcrow); return; }
            if (description.Contains("lunate anti sigma")) { AddSymbolToList((int)SymbolList.LunateAntiSigma); return; }
            if (description.Contains("anti sigma")) { AddSymbolToList((int)SymbolList.LunateAntiSigma); return; }
            if (description.Contains("lunate sigma")) { AddSymbolToList((int)SymbolList.LunateSigma); return; }
            if (description.Contains("sigma")) { AddSymbolToList((int)SymbolList.LunateSigma); return; }
            if (description.Contains("capital e ")) { AddSymbolToList((int)SymbolList.E); return; }
            if (description.Contains("zhe")) { AddSymbolToList((int)SymbolList.Zhe); return; }
            if (description.Contains("aesc")) { AddSymbolToList((int)SymbolList.Aesc); return; }
            if (description.Contains("little yus")) { AddSymbolToList((int)SymbolList.LittleYus); return; }
            if (description.Contains("yat")) { AddSymbolToList((int)SymbolList.Yat); return; }
            if (description.Contains(" ha ")) { AddSymbolToList((int)SymbolList.Ha); return; }

            //Symbols descriptions
            if (description.Contains("ballon")) { AddSymbolToList((int)SymbolList.ArchaicKoppa); return; }
            if (description.Contains("six")) { AddSymbolToList((int)SymbolList.Be); return; }
            if (description.Contains("6")) { AddSymbolToList((int)SymbolList.Be); return; }
            if (description.Contains("spider")) { AddSymbolToList((int)SymbolList.BigYus); return; }
            if (description.Contains("three legs")) { AddSymbolToList((int)SymbolList.BigYus); return; }
            if (description.Contains("stylish")) { AddSymbolToList((int)SymbolList.Kai); return; }
            if (description.Contains("broken three")) { AddSymbolToList((int)SymbolList.KomiDzje); return; }
            if (description.Contains("resistance")) { AddSymbolToList((int)SymbolList.Koppa); return; }
            if (description.Contains("alien three")) { AddSymbolToList((int)SymbolList.Ksi); return; }
            if (description.Contains("trident")) { AddSymbolToList((int)SymbolList.Psi); return; }
            if (description.Contains("smiley face")) { AddSymbolToList((int)SymbolList.Teh); return; }
            if (description.Contains("not equal")) { AddSymbolToList((int)SymbolList.Thousand); return; }
            if (description.Contains("lightning")) { AddSymbolToList((int)SymbolList.ShortI); return; }
            if (description.Contains("paragraph")) { AddSymbolToList((int)SymbolList.Pilcrow); return; }
            if (description.Contains("backwards c ")) { AddSymbolToList((int)SymbolList.LunateAntiSigma); return; }
            if (description.Contains("backwards e ")) { AddSymbolToList((int)SymbolList.E); return; }
            if (description.Contains("backwards n ")) { AddSymbolToList((int)SymbolList.ShortI); return; }
            if (description.Contains("backwards p ")) { AddSymbolToList((int)SymbolList.Pilcrow); return; }
            if (description.Contains("anti sigma")) { AddSymbolToList((int)SymbolList.LunateAntiSigma); return; }
            if (description.Contains(" c with a dot")) { AddSymbolToList((int)SymbolList.LunateSigma); return; }
            if (description.Contains("sigma")) { AddSymbolToList((int)SymbolList.E); return; }
            if (description.Contains(" x with")) { AddSymbolToList((int)SymbolList.Zhe); return; }
            if (description.Contains("mirroed k ")) { AddSymbolToList((int)SymbolList.Zhe); return; }
            if (description.Contains(" a e ")) { AddSymbolToList((int)SymbolList.Aesc); return; }
            if (description.Contains(" a t ")) { AddSymbolToList((int)SymbolList.LittleYus); return; }
            if (description.Contains(" b t ")) { AddSymbolToList((int)SymbolList.Yat); return; }
            if (description.Contains(" c l ")) { AddSymbolToList((int)SymbolList.Ha); return; }
            if (description.Contains(" w ")) { AddSymbolToList((int)SymbolList.BroadOmega); return; }
            if (description.Contains("double u ")) { AddSymbolToList((int)SymbolList.BroadOmega); return; }
        }

        private void AddSymbolToList(int symbolNumber)
        {
            if (!Symbols.Contains(symbolNumber))
                Symbols.Add(symbolNumber);
        }

        public string WhichSymbol(int symbol)
        {
            switch (symbol)
            {
                //Latin small aesc
                case 1: return "Aesc";
                //Greek archaic koppa, similar to a ballon with a cord
                case 2: return "Archaic Koppa";
                //Cyrillic small be
                case 3: return "Be";
                //Cyrillic capital iotified big yus
                case 4: return "Big Yus";
                //Black star
                case 5: return "Black Star";
                //Broad omega with pokrytie and psilon pneuma
                case 6: return "Broad Omega";
                //Copyright sign
                case 7: return "Copyright Sign";
                //Cyrillic capital E with diaeresis
                case 8: return "E";
                //Latin inverted question mark
                case 9: return "Inverted Question Mark";
                //Greek kai, looks like a stylish x/h/n, with some extra drawing on the right botton side
                case 10: return "Kai";
                //Cyrillic capital Komi Dzje
                case 11: return "Komi Dzje";
                //Greek koppa
                case 12: return "Koppa";
                //Cyrillic capital ksi
                case 13: return "Ksi";
                //The greek letter Lambda with a small line across the upper portion
                case 14: return "Lambda";
                //Cyrillic capital little yus, similar to the letter 'A' with a small line connecter underneath it
                case 15: return "Little Yus";
                //Greek dotted lunate anti-sigma, a backwards 'C' with a dot in the middle
                case 16: return "Lunate Anti Sigma";
                //Greek dotted lunate sigma
                case 17: return "Lunate Sigma";
                //Cyrillic O-hook
                case 18: return "Ha";
                //Greek capital omega
                case 19: return "Omega";
                //Pilcrow sign
                case 20: return "Pilcrow";
                //Greek capital psi
                case 21: return "Psi";
                //Cyrillic capital letter short i with tail
                case 22: return "Short I";
                //Arabic teh with ring
                case 23: return "Teh";
                //Cyrillic thousands sign
                case 24: return "Thousand";
                //White star
                case 25: return "White Star";
                //Cyrillic capital yat
                case 26: return "Yat";
                //Cyrillic capital zhe with descender
                case 27: return "Zhe";
                default: return "";
            }
        }

        public enum SymbolList
        {
            Aesc = 1,
            ArchaicKoppa,
            Be,
            BigYus,
            BlackStar,
            BroadOmega,
            CopyrightSign,
            E,
            InvertedQuestionMark,
            Kai,
            KomiDzje,
            Koppa,
            Ksi,
            Lambda,
            LittleYus,
            LunateAntiSigma,
            LunateSigma,
            Ha,
            Omega,
            Pilcrow,
            Psi,
            ShortI,
            Teh,
            Thousand,
            WhiteStar,
            Yat,
            Zhe,
        }
    }
}