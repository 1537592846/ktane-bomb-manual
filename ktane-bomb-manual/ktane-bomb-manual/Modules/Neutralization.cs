using System;
using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Neutralization :Module
    {
        string Color;
        int Volume;
        List<Solution> Solutions = new List<Solution> {
            new Solution { Name = "ammonia", Formula = "NH3", Cation = "hydrogen", CationFormula = "H", CationAtomicNumber = 1, Message = "Ammonia, november hotel three. " },
            new Solution { Name = "lythium hydroxide", Formula = "LiOH", Cation = "lythium", CationFormula = "Li", CationAtomicNumber = 3, Message = "Lithium hydroxide, lima india oscar hotel. " },
            new Solution { Name = "sodium hydroxide", Formula = "NaOH", Cation = "sodium", CationFormula = "Na", CationAtomicNumber = 11, Message = "Sodium hydroxide, november alpha oscar hotel. " },
            new Solution { Name = "potassium hydroxide", Formula = "KOH", Cation = "potassium", CationFormula = "K", CationAtomicNumber = 19, Message = "Potassium hydroxide, kilo oscar hotel. " },
            new Solution { Name = "hydrogen bromide", Formula = "HBe", Anion = "bromine", AnionFormula = "B", AnionAtomicNumber = 35, Color = "red" },
            new Solution { Name = "hydrogen fluoride", Formula = "HF", Anion = "fluorine", AnionFormula = "F", AnionAtomicNumber = 9, Color = "yellow" },
            new Solution { Name = "hydrogen chloride", Formula = "HCl", Anion = "chlorine", AnionFormula = "Cl", AnionAtomicNumber = 17, Color = "green" },
            new Solution { Name = "hydrogen iodide", Formula = "HI", Anion = "iodine", AnionFormula = "I", AnionAtomicNumber = 53, Color = "blue" } };

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsColor(word))
                    Color = word;

                if (InternalFunctions.IsNumber(word))
                    Volume = InternalFunctions.GetNumber(word);
            }

            if (string.IsNullOrEmpty(Color))
                return "Could not identify solution.";
            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            var message = "";
            Solution acidSolution = Solutions.First(x => x.Color == Color);
            Solution baseSolution;

            //Defining base to add
            if (bomb.HasLitIndicator("NSA")&&bomb.HasExactlyBatteries(3))
                baseSolution = Solutions.First(x => x.Name == "ammonia");
            else if (bomb.HasLitIndicator("CAR") || bomb.HasLitIndicator("FRQ") || bomb.HasLitIndicator("IND"))
                baseSolution = Solutions.First(x => x.Name == "potassium hydroxide");
            else if (!bomb.HasManyPorts(1) && bomb.HasSerialVowel())
                baseSolution = Solutions.First(x => x.Name == "lythium hydroxide");
            else if (bomb.HasIndicatorWithLetterInWord(acidSolution.Formula))
                baseSolution = Solutions.First(x => x.Name == "potassium hydroxide");
            else if (bomb.GetDBatteries() > bomb.GetAABatteries())
                baseSolution = Solutions.First(x => x.Name == "ammonia");
            else if (acidSolution.AnionAtomicNumber < 20)
                baseSolution = Solutions.First(x => x.Name == "sodium hydroxide");
            else
                baseSolution = Solutions.First(x => x.Name == "lythium hydroxide");

            message += baseSolution.Message;

            //Defining acid concentration
            double acidConcentration = 0;

            acidConcentration += acidSolution.AnionAtomicNumber;
            acidConcentration -= baseSolution.CationAtomicNumber;
            if (InternalFunctions.HasVowelInWord(acidSolution.AnionFormula) || InternalFunctions.HasVowelInWord(baseSolution.CationFormula))
                acidConcentration -= 4;
            if (acidSolution.AnionFormula.Length == baseSolution.CationFormula.Length)
                acidConcentration *= 3;
            acidConcentration = InternalFunctions.GetNumber(acidConcentration.ToString().Last().ToString());
            if (acidConcentration == 0)
                acidConcentration = Volume * 2 / 5;
            acidConcentration /= 10;

            //Defining base concentration
            double baseConcentration = 0;

            if (bomb.GetBatteriesHolders() > bomb.GetPortsQuantity() && bomb.GetBatteriesHolders() > bomb.GetIndicators())
                baseConcentration = 5;
            if (bomb.GetPortTypesQuantity() > bomb.GetBatteriesHolders() && bomb.GetPortTypesQuantity() > bomb.GetIndicators())
                baseConcentration = 10;
            if (bomb.GetIndicators() > bomb.GetBatteriesHolders() && bomb.GetIndicators() > bomb.GetPortTypesQuantity())
                baseConcentration = 20;
            if (bomb.GetBatteriesHolders() == bomb.GetPortTypesQuantity() && bomb.GetPortTypesQuantity() == bomb.GetIndicators())
            {
                var difference5 = Math.Abs(5 - baseSolution.CationAtomicNumber);
                var difference10 = Math.Abs(10 - baseSolution.CationAtomicNumber);
                var difference20 = Math.Abs(20 - baseSolution.CationAtomicNumber);

                if (difference5 < difference10 && difference5 < difference20)
                    baseConcentration = 5;
                if (difference10 < difference5 && difference10 < difference20)
                    baseConcentration = 10;
                if (difference20 < difference5 && difference20 < difference10)
                    baseConcentration = 20;
            }

            if ((acidSolution.Formula == "HI" && baseSolution.Formula == "KOH") || (acidSolution.Formula == "HCl" && baseSolution.Formula == "NH3"))
                baseConcentration = 20;

            //Defining drops
            double drops = 20;
            drops /= baseConcentration;
            drops *= Volume;
            drops *= acidConcentration;
            message += $"{(int)drops} drops. ";

            //Defining filter
            switch (acidSolution.Formula)
            {
                case "HBr":
                    if (baseSolution.Formula == "NH3" || baseSolution.Formula == "NaOH")
                        message += "Filter off.";
                    else
                        message += "Filter on.";
                    break;

                case "HF":
                    if (baseSolution.Formula == "KOH" || baseSolution.Formula == "NaOH")
                        message += "Filter off.";
                    else
                        message += "Filter on.";
                    break;

                case "HCl":
                    if (baseSolution.Formula == "LiOH")
                        message += "Filter off.";
                    else
                        message += "Filter on.";
                    break;

                case "HI":
                    if (baseSolution.Formula != "NaOH")
                        message += "Filter off.";
                    else
                        message += "Filter on.";
                    break;
            }

            Solved = true;

            return message;
        }
    }

    public class Solution
    {
        public string Name = "", Formula = "", Cation = "", CationFormula = "", Message = "", Anion = "", AnionFormula = "", Color = "";
        public int CationAtomicNumber = 0, AnionAtomicNumber = 0;
    }
}