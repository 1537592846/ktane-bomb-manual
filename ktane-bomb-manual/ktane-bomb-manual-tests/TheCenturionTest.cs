using ktane_bomb_manual;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class TheCenturionTest
    {
        public Program program;

        [SetUp]
        public void Setup()
        {
            //Instanciando a classe do programa
            program = new Program();
        }

        [Test]
        public void TheCenturion_Test()
        {
            //Bomb settings
            AssertCommand("Serial added.", ValidateCommand("bomb serial is tango hotel 8 zulu kilo 9"), "Serial configuration");
            AssertCommand("AA batteries added.", ValidateCommand("bomb has 4 aa batteries"), "AA batteries configuration");
            AssertCommand("D batteries added.", ValidateCommand("bomb has 1 d battery"), "D batteries configuration");
            AssertCommand("Lit MSA indicator added.", ValidateCommand("bomb has indicator mike sierra alpha lit"), "Indicator configuration");
            AssertCommand("Parallel port added.", ValidateCommand("bomb has 1 parallel port"), "Port configuration");
            AssertCommand("Time added.", ValidateCommand("bomb has 100 minutes"), "Port configuration");
            AssertCommand("Modules quantity added.", ValidateCommand("bomb has 101 modules"), "Port configuration");

            //Adjacent letters
            AssertCommand("Press: November. Yankee. Charlie. Foxtrot.", ValidateCommand("adjacent letters romeo november quebec lima uniform yankee sierra hotel charlie tango foxtrot victor"), "Adjacent Letters");

            //Adventure Games
            AssertCommand("Use symbol, then caber.", ValidateCommand("adventure games golem 6 8 3 5'3 41C 9.0m/s 107kpa broadsword caber grimoire lamp throphy symbol"), "Adventure Games");

            //Alphabet
            AssertCommand("Press zulu, november, yankee, lima.", ValidateCommand("alphabet zulu yankee november lima"), "Alphabet");

            //Astrology
            AssertCommand("Poor omen when the timer has a 1.", ValidateCommand("astrology fire uranus aries"), "Astrology");


            //Binary LEDs
            AssertCommand("Cut the green one on 1-2-5.", ValidateCommand("binary leds 1,3 2,3,4,5 5 1,2,5 2 1,2,5 5"), "Binary LEDs");

            //Bitmaps
            AssertCommand("First quadrant added.", ValidateCommand("bitmaps 3 1,3 3,4"), "Bitmaps");
            AssertCommand("Second quadrant added.", ValidateCommand("bitmaps 1,2,3,4 1,2,4 1,2,3,4 1"), "Bitmaps");
            AssertCommand("Third quadrant added.", ValidateCommand("bitmaps 2 1,3,4 2,4 3,4"), "Bitmaps");
            AssertCommand("Press 4.", ValidateCommand("bitmaps 1,2,3 3 2,3,4 1"), "Bitmaps");

            //Bitwise
            AssertCommand("The answer is 0, 0, 0, 0, 0, 0, 0, 1.", ValidateCommand("bitwise and"), "Bitwise");

            //Bulb
            AssertCommand("First unscrew, then press I, then press I, then press I, then screw, then you're done.", ValidateCommand("bulb blue off opaque"), "Bulb");

            //Cheap Checkout
            AssertCommand("Return 1 dollar and 1 cent.", ValidateCommand("cheap checkout 22 dollars saturday honey deodorant mustard socks 1 potatoes 1.5 lettuce"), "Cheap Checkout");

            //Chess
            AssertCommand("The position is echo 5.", ValidateCommand("chess echo 1 bravo 1 bravo 5 alpha 6 delta 4 delta 3"), "Chess");

            //Color math
            AssertCommand("The order is magenta, black, magenta, gray.", ValidateCommand("color math black white yellow magenta green addiction orange purple white orange"), "Color Math");

            //Complicate wires
            AssertCommand("Leave it.", ValidateCommand("complicated wires red blue led"), "Complicated wires");
            AssertCommand("Leave it.", ValidateCommand("complicated wires red"), "Complicated wires");
            AssertCommand("Leave it.", ValidateCommand("complicated wires red blue star led"), "Complicated wires");
            AssertCommand("Cut it.", ValidateCommand("complicated wires blue led"), "Complicated wires");
            AssertCommand("Cut it.", ValidateCommand("complicated wires red star"), "Complicated wires");
            AssertCommand("Cut it.", ValidateCommand("complicated wires "), "Complicated wires");

            //Clock
            AssertCommand("Set the hours to the 5 o'clock position.", ValidateCommand("clock hours gold matches no number"), "Clock");
            AssertCommand("Set the minutes to 23.", ValidateCommand("clock minutes spades gold black am present"), "Clock");

            //Fast Math
            AssertCommand("97.", ValidateCommand("fast math alpha november"), "Fast Math");
            AssertCommand("19.", ValidateCommand("fast math bravo delta"), "Fast Math");
            AssertCommand("03.", ValidateCommand("fast math golf charlie"), "Fast Math");
            AssertCommand("65.", ValidateCommand("fast math november delta"), "Fast Math");

            //Morsematics
            AssertCommand("Character added.", ValidateCommand("morsematics first dot dot dash dot next"), "Morsematics");
            AssertCommand("Character added.", ValidateCommand("morsematics second dash dot dash dot next"), "Morsematics");
            AssertCommand("Send dot dash dash dot done.", ValidateCommand("morsematics third dash dot dash next"), "Morsematics");

            //Passwords
            AssertCommand("Letters added.", ValidateCommand("passwords first golf bravo quebec yankee oscar charlie"), "Passwords");
            AssertCommand("Letters added.", ValidateCommand("passwords second whisley oscar sierra tango xray alpha"), "Passwords");
            AssertCommand("The password is could.", ValidateCommand("passwords third delta whiskey uniform india lima"), "Passwords");

            //Plumbing
            AssertCommand("Input: blue. Output: blue.", ValidateCommand("plumbing solve"), "Plumbing");

            //Round keypads
            AssertCommand("Press this ones: Aesc. Lambda. Little Yus. Lunate Sigma. Omega.", ValidateCommand("round keypads big yus yat little yus sigma omega question mark aesc lambda"), "Round keypads");

            //Safety safe
            AssertCommand("First dial: 2 turns. Second dial: 10 turns. Third dial: 4 turns. Fourth dial: 5 turns. Fifth dial: 7 turns. Sixth dial: 3 turns.", ValidateCommand("safety safe 6 3 4 6 10 1"), "Safety safe");

            //Simon states
            AssertCommand("Top left color added.", ValidateCommand("simon states top left blue"), "Simon states");
            AssertCommand("Press yellow.", ValidateCommand("simon states yellow"), "Simon states");
            AssertCommand("Press yellow blue.", ValidateCommand("simon states red green"), "Simon states");
            AssertCommand("Press yellow blue yellow.", ValidateCommand("simon states red yellow"), "Simon states");
            AssertCommand("Press yellow blue yellow red.", ValidateCommand("simon states all"), "Simon states");
            AssertCommand("Module defused.", ValidateCommand("simon states solved"), "Simon states");

            //Square button
            AssertCommand("Hold the button. What is the LED color?", ValidateCommand("square button blue run"), "Square button");
            AssertCommand("Release when the seconds are a multiple of seven.", ValidateCommand("square button led flick cyan"), "Square button");

            //Bomb final validations
            var modulesNotSolved = "";
            program.mockBomb.Modules.Where(x => !x.Solved).Select(x => x.ModuleName).ToList().ForEach(x => { modulesNotSolved += x + ", "; });
            Assert.AreEqual(program.mockBomb.Modules.Count(), program.mockBomb.Modules.Where(x => x.Solved).Count(), "Not enough modules solved. Modules not solved: " + modulesNotSolved, null);
        }

        public string ValidateCommand(string command)
        {
            return program.MockCommand(command);
        }

        public void AssertCommand(string expected, string obtained, string message)
        {
            Assert.AreEqual(expected, obtained, message, null);
        }
    }
}