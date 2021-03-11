using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Creation :Module
    {
        int Permutation;
        Combination FinalCombination;
        Dictionary<string, string> WeatherElements = new Dictionary<string, string> { { "rain", "water" }, { "wind", "air" }, { "heat wave", "fire" }, { "meteor shower", "earth" }, { "clear", "none" } };
        Dictionary<string, List<string>> Permutations = new Dictionary<string, List<string>> { { "water", new List<string> { "upper right", "upper left", "bottom right", "bottom left" } }, { "air", new List<string> { "upper left", "upper right", "bottom left", "bottom right" } }, { "earth", new List<string> { "bottom left", "bottom right", "upper right", "upper left" } }, { "fire", new List<string> { "bottom right", "bottom left", "upper left", "upper right" } } };
        List<Combination> Combinations = new List<Combination> { new Combination("air"), new Combination("earth"), new Combination("fire"), new Combination("water") };
        List<string> Weathers = new List<string>();
        string CurrentWeather, ElementPosition;


        public override string Command(Bomb bomb, string command)
        {
            CurrentWeather = command.Replace("creation ", "");

            if (Weathers.Count == 0)
            {
                Weathers.Add(CurrentWeather);
                return "Where is " + WeatherElements[CurrentWeather] + " located?";
            }

            if (!WeatherElements.ContainsKey(CurrentWeather))
                ElementPosition = CurrentWeather;
            else
                Weathers.Add(CurrentWeather);

            return Solve(bomb);
        }
        public override string Solve(Bomb bomb)
        {
            if (CurrentWeather == ElementPosition)
                DefineCombinationToCreate(bomb);
            return GetCombinationFromWeather(FinalCombination);
        }

        public void DefineCombinationToCreate(Bomb bomb)
        {
            PreparePermutation();
            DefineCombination(bomb);
        }

        public void PreparePermutation()
        {
            var weather = Weathers[0];
            var element = WeatherElements[weather];
            if (element == "none")
            {
                Permutation = 0;
                return;
            }
            var listPermutations = Permutations[element];
            Permutation = listPermutations.FindIndex(x => x == ElementPosition) + 1;
        }

        public void DefineCombination(Bomb bomb)
        {
            if (bomb.HasManyBatteriesHolders(3))
            {
                if (bomb.HasAnyLitIndicator() && bomb.HasExactlyBatteries(6))
                    switch (Permutation)
                    {
                        case 0:
                            FinalCombination = new Combination("bird");
                            return;
                        case 1:
                            FinalCombination = new Combination("dinosaur");
                            return;
                        case 2:
                            FinalCombination = new Combination("turtle");
                            return;
                        case 3:
                            FinalCombination = new Combination("lizard");
                            return;
                        case 4:
                            FinalCombination = new Combination("worm");
                            return;
                    }
                if (bomb.HasAnyLitIndicator())
                    switch (Permutation)
                    {
                        case 0:
                            FinalCombination = new Combination("dinosaur");
                            return;
                        case 1:
                            FinalCombination = new Combination("turtle");
                            return;
                        case 2:
                            FinalCombination = new Combination("lizard");
                            return;
                        case 3:
                            FinalCombination = new Combination("worm");
                            return;
                        case 4:
                            FinalCombination = new Combination("bird");
                            return;
                    }
                if (bomb.HasAnyUnlitIndicator() && bomb.HasExactlyBatteries(3))
                    switch (Permutation)
                    {
                        case 0:
                            FinalCombination = new Combination("turtle");
                            return;
                        case 1:
                            FinalCombination = new Combination("lizard");
                            return;
                        case 2:
                            FinalCombination = new Combination("worm");
                            return;
                        case 3:
                            FinalCombination = new Combination("bird");
                            return;
                        case 4:
                            FinalCombination = new Combination("dinosaur");
                            return;
                    }
                if (bomb.HasAnyUnlitIndicator())
                    switch (Permutation)
                    {
                        case 0:
                            FinalCombination = new Combination("lizard");
                            return;
                        case 1:
                            FinalCombination = new Combination("worm");
                            return;
                        case 2:
                            FinalCombination = new Combination("bird");
                            return;
                        case 3:
                            FinalCombination = new Combination("dinosaur");
                            return;
                        case 4:
                            FinalCombination = new Combination("turtle");
                            return;
                    }
                switch (Permutation)
                {
                    case 0:
                        FinalCombination = new Combination("worm");
                        return;
                    case 1:
                        FinalCombination = new Combination("bird");
                        return;
                    case 2:
                        FinalCombination = new Combination("dinosaur");
                        return;
                    case 3:
                        FinalCombination = new Combination("turtle");
                        return;
                    case 4:
                        FinalCombination = new Combination("lizard");
                        return;
                }
            }

            if (bomb.GetPortPlatesQuantity() > bomb.GetBatteriesHolders())
                switch (Permutation)
                {
                    case 0:
                    case 4:
                        FinalCombination = new Combination("ghost");
                        return;
                    case 1:
                        FinalCombination = new Combination("plankton");
                        return;
                    case 2:
                        FinalCombination = new Combination("seeds");
                        return;
                    case 3:
                        FinalCombination = new Combination("mushroom");
                        return;
                }

            if (bomb.HasAnyDuplicatedPort())
                switch (Permutation)
                {
                    case 0:
                    case 4:
                        FinalCombination = new Combination("plankton");
                        return;
                    case 1:
                        FinalCombination = new Combination("seeds");
                        return;
                    case 2:
                        FinalCombination = new Combination("mushroom");
                        return;
                    case 3:
                        FinalCombination = new Combination("ghost");
                        return;
                }

            if (bomb.GetUnlitIndicators() > bomb.GetLitIndicators())
                switch (Permutation)
                {
                    case 0:
                    case 4:
                        FinalCombination = new Combination("seeds");
                        return;
                    case 1:
                        FinalCombination = new Combination("mushroom");
                        return;
                    case 2:
                        FinalCombination = new Combination("ghost");
                        return;
                    case 3:
                        FinalCombination = new Combination("plankton");
                        return;
                }

            switch (Permutation)
            {
                case 0:
                case 4:
                    FinalCombination = new Combination("mushroom");
                    return;
                case 1:
                    FinalCombination = new Combination("ghost");
                    return;
                case 2:
                    FinalCombination = new Combination("plankton");
                    return;
                case 3:
                    FinalCombination = new Combination("seeds");
                    return;
            }
        }

        public string GetCombinationFromWeather(Combination combination)
        {
            if (!Combinations.Any(x => x.Result == combination.Element1.Result))
                return GetCombinationFromWeather(combination.Element1);

            if (!Combinations.Any(x => x.Result == combination.Element2.Result))
                return GetCombinationFromWeather(combination.Element2);

            Combinations.Add(combination);
            var message = combination.GetMessage();
            switch (Weathers[Weathers.Count - 1])
            {
                case "rain":
                    message = message.Replace(WeatherElements["rain"], WeatherElements["heat wave"]);
                    break;
                case "heat wave":
                    message = message.Replace(WeatherElements["heat wave"], WeatherElements["rain"]);
                    break;
                case "wind":
                    message = message.Replace(WeatherElements["wind"], WeatherElements["meteor shower"]);
                    break;
                case "meteor shower":
                    message = message.Replace(WeatherElements["meteor shower"], WeatherElements["wind"]);
                    break;
            }
            Solved = combination.Result == FinalCombination.Result;
            return message;
        }
    }

    public class Combination
    {
        public Combination Element1, Element2;
        public string Result;

        public Combination() { }

        public Combination(string element)
        {
            var combination = GetElement(element);
            Element1 = combination.Element1;
            Element2 = combination.Element2;
            Result = combination.Result;
        }

        public Combination(string element1, string element2, string result)
        {
            Element1 = GetElement(element1);
            Element2 = GetElement(element2);
            Result = result;
        }

        public string GetMessage()
        {
            return "Mix " + Element1.Result + " and " + Element2.Result + " to create " + Result + ".";
        }

        Combination GetElement(string element)
        {
            switch (element)
            {
                //Primary elements
                case "air":
                case "earth":
                case "fire":
                case "water":
                    return new Combination("none", "none", element);

                //First gen. elements
                case "alcohol":
                    return new Combination("fire", "water", element);
                case "dust":
                    return new Combination("air", "earth", element);
                case "energy":
                    return new Combination("air", "fire", element);
                case "lava":
                    return new Combination("earth", "fire", element);
                case "steam":
                    return new Combination("air", "water", element);
                case "swamp":
                    return new Combination("earth", "water", element);

                //Second gen. elements
                case "ash":
                    return new Combination("dust", "fire", element);
                case "cement":
                    return new Combination("dust", "water", element);
                case "life":
                    return new Combination("energy", "swamp", element);
                case "lily pad":
                    return new Combination("swamp", "water", element);
                case "plasma":
                    return new Combination("energy", "fire", element);
                case "pollen":
                    return new Combination("dust", "swamp", element);
                case "stone":
                    return new Combination("lava", "water", element);
                case "tar":
                    return new Combination("fire", "swamp", element);
                case "volcano":
                    return new Combination("dust", "lava", element);

                //Third gen. elements
                case "bacteria":
                    return new Combination("life", "swamp", element);
                case "egg":
                    return new Combination("earth", "life", element);
                case "ghost":
                    return new Combination("life", "plasma", element);
                case "metal":
                    return new Combination("fire", "stone", element);
                case "sand":
                    return new Combination("stone", "water", element);
                case "weeds":
                    return new Combination("life", "water", element);

                //Fourth gen. elements
                case "bird":
                    return new Combination("air", "egg", element);
                case "dinosaur":
                    return new Combination("dinosaur", "egg", element);
                case "lizard":
                    return new Combination("egg", "swamp", element);
                case "seeds":
                    return new Combination("egg", "weeds", element);
                case "turtle":
                    return new Combination("egg", "water", element);
                case "mushroom":
                    return new Combination("earth", "weeds", element);
                case "moss":
                    return new Combination("swamp", "weeds", element);
                case "worm":
                    return new Combination("bacteria", "swamp", element);
                case "plankton":
                    return new Combination("bacteria", "water", element);

                //For primary elements
                default:
                    return new Combination();
            }
        }
    }
}