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
            //Preparação da bomba para teste
            program.mockBomb = new Bomb();
            program.mockBomb.Serial = "TH8ZK9";
            program.mockBomb.BatteryAA = 4;
            program.mockBomb.BatteryD = 1;
            program.mockBomb.Indicators.Add(new Indicator("msa", true));
            program.mockBomb.Ports.Add(new Port("parallel", 1));
        }

        [Test]
        public void Test()
        {
            //Instanciando a classe do programa
            var program = new Program();

            //Executado na ordem do video
            ValidateCommand("forget me not is 3");
            ValidateCommand("crazy talk 'empty space'");
            ValidateCommand("bitwise n");
            ValidateCommand("rubiks cube white yellow green red orange");
            ValidateCommand("screw white magenta blue yellow red green");
            ValidateCommand("solve same word different colors");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");
            ValidateCommand("");

        }

        public string ValidateCommand(string command)
        {
            return program.MockCommand(command);
        }
    }
}