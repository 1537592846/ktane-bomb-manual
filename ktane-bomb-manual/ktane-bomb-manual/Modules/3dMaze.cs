namespace ktane_bomb_manual.Modules
{
    public class _3dMaze : Module
    {
        int Row;
        int Column;

        public override string Solve(Bomb bomb)
        {
            Row = bomb.GetSerialFirstNumberDigit();
            Row += bomb.GetUnlitIndicatorsWithLetter("M");
            Row += bomb.GetUnlitIndicatorsWithLetter("A");
            Row += bomb.GetUnlitIndicatorsWithLetter("Z");
            Row += bomb.GetUnlitIndicatorsWithLetter("E");
            Row += bomb.GetUnlitIndicatorsWithLetter("G");
            Row += bomb.GetUnlitIndicatorsWithLetter("A");
            Row += bomb.GetUnlitIndicatorsWithLetter("M");
            Row += bomb.GetUnlitIndicatorsWithLetter("E");
            Row += bomb.GetUnlitIndicatorsWithLetter("R");

            if (Row > 7) Row = Row - 8;

            Column = bomb.GetSerialLastNumberDigit();
            Column += bomb.GetUnlitIndicatorsWithLetter("M");
            Column += bomb.GetUnlitIndicatorsWithLetter("A");
            Column += bomb.GetUnlitIndicatorsWithLetter("Z");
            Column += bomb.GetUnlitIndicatorsWithLetter("E");
            Column += bomb.GetUnlitIndicatorsWithLetter("G");
            Column += bomb.GetUnlitIndicatorsWithLetter("A");
            Column += bomb.GetUnlitIndicatorsWithLetter("M");
            Column += bomb.GetUnlitIndicatorsWithLetter("E");
            Column += bomb.GetUnlitIndicatorsWithLetter("R");

            if (Column > 7) Row = Column - 8;

            return "I'm still lost.";
        }

        public override string Command(Bomb bomb, string command)
        {
            return "Need to finish writing it first.";
        }
    }
}
