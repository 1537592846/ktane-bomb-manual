using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Keypads : Module
    {
        public Keypads()
        {
            Symbols = new List<int>();
        }

        public List<int> Symbols;

        public override string Solve(Bomb bomb)
        {
            var message = "Order as follow: ";
            foreach (var symbol in SymbolOrder())
            {
                message += WhichSymbol(symbol) + ". ";
            }

            Solved = true;

            return message.TrimEnd();
        }

        public List<int> SymbolOrder()
        {
            var Order1 = new List<int>() { (int)SymbolList.ArchaicKoppa, (int)SymbolList.LittleYus, (int)SymbolList.Lambda, (int)SymbolList.Koppa, (int)SymbolList.BigYus, (int)SymbolList.Kai, (int)SymbolList.LunateAntiSigma };
            var Order2 = new List<int>() { (int)SymbolList.E, (int)SymbolList.ArchaicKoppa, (int)SymbolList.LunateAntiSigma, (int)SymbolList.OHook, (int)SymbolList.WhiteStar, (int)SymbolList.Kai, (int)SymbolList.InvertedQuestionMark };
            var Order3 = new List<int>() { (int)SymbolList.CopyrightSign, (int)SymbolList.BroadOmega, (int)SymbolList.OHook, (int)SymbolList.Zhe, (int)SymbolList.KomiDzje, (int)SymbolList.Lambda, (int)SymbolList.WhiteStar };
            var Order4 = new List<int>() { (int)SymbolList.Be, (int)SymbolList.Pilcrow, (int)SymbolList.Yat, (int)SymbolList.BigYus, (int)SymbolList.Zhe, (int)SymbolList.InvertedQuestionMark, (int)SymbolList.Teh };
            var Order5 = new List<int>() { (int)SymbolList.Psi, (int)SymbolList.Teh, (int)SymbolList.Yat, (int)SymbolList.LunateSigma, (int)SymbolList.Pilcrow, (int)SymbolList.Ksi, (int)SymbolList.BlackStar };
            var Order6 = new List<int>() { (int)SymbolList.Be, (int)SymbolList.E, (int)SymbolList.Thousand, (int)SymbolList.Aesc, (int)SymbolList.Psi, (int)SymbolList.ShortI, (int)SymbolList.Omega };

            if (Symbols.Where(x => Order1.Contains(x)).Count() == 4) return Order1;
            if (Symbols.Where(x => Order2.Contains(x)).Count() == 4) return Order2;
            if (Symbols.Where(x => Order3.Contains(x)).Count() == 4) return Order3;
            if (Symbols.Where(x => Order4.Contains(x)).Count() == 4) return Order4;
            if (Symbols.Where(x => Order5.Contains(x)).Count() == 4) return Order5;
            return Order6;
        }

        public void AddSymbol(string description)
        {
            if (description.Contains("omega")&&!description.Contains("broad")) { Symbols.Add((int)SymbolList.Omega); return; }
            if (description.Contains("white star")) { Symbols.Add((int)SymbolList.WhiteStar); return; }
            if (description.Contains("copyright")) { Symbols.Add((int)SymbolList.CopyrightSign); return; }
            if (description.Contains("question mark")) { Symbols.Add((int)SymbolList.InvertedQuestionMark); return; }
            if (description.Contains("lambda")) { Symbols.Add((int)SymbolList.Lambda); return; }
            if (description.Contains("archaic koppa") || description.Contains("ballon")) { Symbols.Add((int)SymbolList.ArchaicKoppa); return; }
            if (description.Contains("small b") || description.Contains("six") || description.Contains("6")) { Symbols.Add((int)SymbolList.Be); return; }
            if (description.Contains("big yus") || description.Contains("spider") || description.Contains("three legs")) { Symbols.Add((int)SymbolList.BigYus); return; }
            if (description.Contains("kai") || description.Contains("stylish")) { Symbols.Add((int)SymbolList.Kai); return; }
            if (description.Contains("komi dzje") || description.Contains("broken three")) { Symbols.Add((int)SymbolList.KomiDzje); return; }
            if (description.Contains("koppa") || description.Contains("resistance")) { Symbols.Add((int)SymbolList.Koppa); return; }
            if (description.Contains("ksi") || description.Contains("alien three")) { Symbols.Add((int)SymbolList.Ksi); return; }
            if (description.Contains("lunate sigma") || description.Contains("c with a dot")) { Symbols.Add((int)SymbolList.LunateSigma); return; }
            if (description.Contains("psi") || description.Contains("trident")) { Symbols.Add((int)SymbolList.Psi); return; }
            if (description.Contains("teh") || description.Contains("smiley face")) { Symbols.Add((int)SymbolList.Teh); return; }
            if (description.Contains("thousand") || description.Contains("not equal")) { Symbols.Add((int)SymbolList.Thousand); return; }
            if (description.Contains("short i") || description.Contains("lightning") || description.Contains("backwards n")) { Symbols.Add((int)SymbolList.ShortI); return; }
            if (description.Contains("pilcrow") || description.Contains("paragraph")||description.Contains("backwards p")) { Symbols.Add((int)SymbolList.Pilcrow); return; }
            if (description.Contains("lunate anti sigma") || description.Contains("backwards c")) { Symbols.Add((int)SymbolList.LunateAntiSigma); return; }
            if (description.Contains("capital e") || description.Contains("backwards e")) { Symbols.Add((int)SymbolList.E); return; }
            if (description.Contains("zhe") || description.Contains("x with") || description.Contains("mirroed k")) { Symbols.Add((int)SymbolList.Zhe); return; }
            if (description.Contains("aesc") || description.Contains("a e")) { Symbols.Add((int)SymbolList.Aesc); return; }
            if (description.Contains("little yus") || description.Contains("a t")) { Symbols.Add((int)SymbolList.LittleYus); return; }
            if (description.Contains("yat") || description.Contains("b t")) { Symbols.Add((int)SymbolList.Yat); return; }
            if (description.Contains("o hook") || description.Contains("c l")) { Symbols.Add((int)SymbolList.OHook); return; }
            if (description.Contains("broad omega") || description.Contains("w") || description.Contains("double u")) { Symbols.Add((int)SymbolList.BroadOmega); return; }
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
                case 18: return "O Hook";
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
            Aesc=1,
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
            OHook,
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