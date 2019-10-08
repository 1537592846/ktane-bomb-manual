using ktane_bomb_manual;
using NUnit.Framework;

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
            AssertCommand("Unscrew, then press I, I, I, then screw.", ValidateCommand("bulb blue off opaque"), "Bulb");

            //Complicate wires
            AssertCommand("Leave it.", ValidateCommand("complicated wires red blue led"), "Complicated wires");
            AssertCommand("Leave it.", ValidateCommand("complicated wires red"), "Complicated wires");
            AssertCommand("Leave it.", ValidateCommand("complicated wires red blue star led"), "Complicated wires");
            AssertCommand("Cut it.", ValidateCommand("complicated wires blue led"), "Complicated wires");
            AssertCommand("Cut it.", ValidateCommand("complicated wires red star"), "Complicated wires");
            AssertCommand("Cut it.", ValidateCommand("complicated wires "), "Complicated wires");

            //Morsematics
            AssertCommand("Character added.", ValidateCommand("morsematics first dot dot dash dot next"), "Morsematics");
            AssertCommand("Character added.", ValidateCommand("morsematics second dash dot dash dot next"), "Morsematics");
            AssertCommand("Send dot dash dash dot done.", ValidateCommand("morsematics third dash dot dash next"), "Morsematics");

            //Passwords
            AssertCommand("Letters added.", ValidateCommand("passwords first golf bravo quebec yankee oscar charlie"), "Passwords");
            AssertCommand("Letters added.", ValidateCommand("passwords second whisley oscar sierra tango xray alpha"), "Passwords");
            AssertCommand("The password is could.", ValidateCommand("passwords third delta whiskey uniform india lima"), "Passwords");

            //Plumbing
            AssertCommand("Input: blue. Output: blue.", ValidateCommand("solve plumbing"), "Plumbing");

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

            //Square button
            AssertCommand("Hold the button. What is the LED color?", ValidateCommand("square button blue run"), "Square button");
            AssertCommand("Release when the seconds are a multiple of seven.", ValidateCommand("square button led flick cyan"), "Square button");
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