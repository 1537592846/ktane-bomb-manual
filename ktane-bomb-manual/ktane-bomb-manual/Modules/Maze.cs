namespace ktane_bomb_manual.Modules
{
    public class Maze : Module
    {
        public Maze()
        {
            MazeConfiguration = new MazeCell[6, 6];
        }

        public MazeCell[,] MazeConfiguration;
        public string Circle1;
        public string Circle2;
        public string ExitPosition;
        public string PlayerPosition;

        public override string Solve(Bomb bomb)
        {
            if (string.IsNullOrEmpty(Circle1) || string.IsNullOrEmpty(Circle2) || string.IsNullOrEmpty(ExitPosition) || string.IsNullOrEmpty(PlayerPosition)) return "Can't solve it yet.";
            Solved = true;
            return ExitPath();
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solve"))
            {
                return Solve(bomb);
            }
            if (command.Contains("player"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (InternalFunctions.GetNumber(word) != -1)
                    {
                        PlayerPosition += InternalFunctions.GetNumber(word) + " ";
                    }
                    PlayerPosition = PlayerPosition.Trim().Replace(' ', ',');
                }

                return "";
            }
            if (command.Contains("exit"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (InternalFunctions.GetNumber(word) != -1)
                    {
                        ExitPosition += InternalFunctions.GetNumber(word) + " ";
                    }
                    ExitPosition = ExitPosition.Trim().Replace(' ', ',');
                }

                return "";
            }
            if (command.Contains("circle"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (InternalFunctions.GetNumber(word) != -1)
                    {
                        Circle2 += InternalFunctions.GetNumber(word) + " ";
                    }
                    Circle2 = Circle2.Trim().Replace(' ', ',');
                }

                if (string.IsNullOrEmpty(Circle1))
                {
                    Circle1 = Circle2;
                    Circle2 = "";
                }

                return "";
            }

            return "";
        }

        public void CreateConfig1()
        {
            MazeConfiguration[0, 0] = new MazeCell("left top");
            MazeConfiguration[0, 1] = new MazeCell("top bottom");
            MazeConfiguration[0, 2] = new MazeCell("top right");
            MazeConfiguration[0, 3] = new MazeCell("left top");
            MazeConfiguration[0, 4] = new MazeCell("top bottom");
            MazeConfiguration[0, 5] = new MazeCell("top right bottom");

            MazeConfiguration[1, 0] = new MazeCell("circle left right");
            MazeConfiguration[1, 1] = new MazeCell("left top");
            MazeConfiguration[1, 2] = new MazeCell("bottom right");
            MazeConfiguration[1, 3] = new MazeCell("left bottom");
            MazeConfiguration[1, 4] = new MazeCell("top bottom");
            MazeConfiguration[1, 5] = new MazeCell("top right");

            MazeConfiguration[2, 0] = new MazeCell("left right");
            MazeConfiguration[2, 1] = new MazeCell("left bottom");
            MazeConfiguration[2, 2] = new MazeCell("top right");
            MazeConfiguration[2, 3] = new MazeCell("left top");
            MazeConfiguration[2, 4] = new MazeCell("top bottom");
            MazeConfiguration[2, 5] = new MazeCell("circle right");

            MazeConfiguration[3, 0] = new MazeCell("left right");
            MazeConfiguration[3, 1] = new MazeCell("top left bottom");
            MazeConfiguration[3, 2] = new MazeCell("bottom");
            MazeConfiguration[3, 3] = new MazeCell("bottom right");
            MazeConfiguration[3, 4] = new MazeCell("top bottom left");
            MazeConfiguration[3, 5] = new MazeCell("right");

            MazeConfiguration[4, 0] = new MazeCell("left");
            MazeConfiguration[4, 1] = new MazeCell("top bottom");
            MazeConfiguration[4, 2] = new MazeCell("top right");
            MazeConfiguration[4, 3] = new MazeCell("left top");
            MazeConfiguration[4, 4] = new MazeCell("right top bottom");
            MazeConfiguration[4, 5] = new MazeCell("left right");

            MazeConfiguration[5, 0] = new MazeCell("left bottom");
            MazeConfiguration[5, 1] = new MazeCell("top right bottom");
            MazeConfiguration[5, 2] = new MazeCell("left bottom");
            MazeConfiguration[5, 3] = new MazeCell("bottom right");
            MazeConfiguration[5, 4] = new MazeCell("left top bottom");
            MazeConfiguration[5, 5] = new MazeCell("right bottom");
        }

        public void CreateConfig2()
        {
            MazeConfiguration[0, 0] = new MazeCell("left top bottom");
            MazeConfiguration[0, 1] = new MazeCell("top");
            MazeConfiguration[0, 2] = new MazeCell("top right bottom");
            MazeConfiguration[0, 3] = new MazeCell("left top");
            MazeConfiguration[0, 4] = new MazeCell("top");
            MazeConfiguration[0, 5] = new MazeCell("top right bottom");

            MazeConfiguration[1, 0] = new MazeCell("left top");
            MazeConfiguration[1, 1] = new MazeCell("bottom right");
            MazeConfiguration[1, 2] = new MazeCell("top left");
            MazeConfiguration[1, 3] = new MazeCell("bottom right");
            MazeConfiguration[1, 4] = new MazeCell("circle bottom left");
            MazeConfiguration[1, 5] = new MazeCell("top right");

            MazeConfiguration[2, 0] = new MazeCell("left right");
            MazeConfiguration[2, 1] = new MazeCell("left top");
            MazeConfiguration[2, 2] = new MazeCell("bottom right");
            MazeConfiguration[2, 3] = new MazeCell("left top");
            MazeConfiguration[2, 4] = new MazeCell("top bottom");
            MazeConfiguration[2, 5] = new MazeCell("right");

            MazeConfiguration[3, 0] = new MazeCell("left");
            MazeConfiguration[3, 1] = new MazeCell("circle right bottom");
            MazeConfiguration[3, 2] = new MazeCell("top left");
            MazeConfiguration[3, 3] = new MazeCell("bottom right");
            MazeConfiguration[3, 4] = new MazeCell("top rigth left");
            MazeConfiguration[3, 5] = new MazeCell("left right");

            MazeConfiguration[4, 0] = new MazeCell("left right");
            MazeConfiguration[4, 1] = new MazeCell("top right top");
            MazeConfiguration[4, 2] = new MazeCell("left right");
            MazeConfiguration[4, 3] = new MazeCell("left top right");
            MazeConfiguration[4, 4] = new MazeCell("right bottom");
            MazeConfiguration[4, 5] = new MazeCell("left right");

            MazeConfiguration[5, 0] = new MazeCell("left bottom right");
            MazeConfiguration[5, 1] = new MazeCell("left bottom");
            MazeConfiguration[5, 2] = new MazeCell("right bottom");
            MazeConfiguration[5, 3] = new MazeCell("bottom left");
            MazeConfiguration[5, 4] = new MazeCell("top bottom");
            MazeConfiguration[5, 5] = new MazeCell("right bottom");
        }

        public void CreateConfig3()
        {
            MazeConfiguration[0, 0] = new MazeCell("top left");
            MazeConfiguration[0, 1] = new MazeCell("top bottom");
            MazeConfiguration[0, 2] = new MazeCell("top right");
            MazeConfiguration[0, 3] = new MazeCell("top left right");
            MazeConfiguration[0, 4] = new MazeCell("top left");
            MazeConfiguration[0, 5] = new MazeCell("top right");

            MazeConfiguration[1, 0] = new MazeCell("left bottom right");
            MazeConfiguration[1, 1] = new MazeCell("left top right");
            MazeConfiguration[1, 2] = new MazeCell("left right");
            MazeConfiguration[1, 3] = new MazeCell("left bottom");
            MazeConfiguration[1, 4] = new MazeCell("bottom right");
            MazeConfiguration[1, 5] = new MazeCell("right left");

            MazeConfiguration[2, 0] = new MazeCell("left top");
            MazeConfiguration[2, 1] = new MazeCell("right");
            MazeConfiguration[2, 2] = new MazeCell("left right");
            MazeConfiguration[2, 3] = new MazeCell("left top");
            MazeConfiguration[2, 4] = new MazeCell("top right");
            MazeConfiguration[2, 5] = new MazeCell("left right");

            MazeConfiguration[3, 0] = new MazeCell("left right");
            MazeConfiguration[3, 1] = new MazeCell("left right");
            MazeConfiguration[3, 2] = new MazeCell("left right");
            MazeConfiguration[3, 3] = new MazeCell("left right circle");
            MazeConfiguration[3, 4] = new MazeCell("left right");
            MazeConfiguration[3, 5] = new MazeCell("left right circle");

            MazeConfiguration[4, 0] = new MazeCell("left right");
            MazeConfiguration[4, 1] = new MazeCell("left bottom");
            MazeConfiguration[4, 2] = new MazeCell("bottom right");
            MazeConfiguration[4, 3] = new MazeCell("left right");
            MazeConfiguration[4, 4] = new MazeCell("left right");
            MazeConfiguration[4, 5] = new MazeCell("left right");

            MazeConfiguration[5, 0] = new MazeCell("left bottom");
            MazeConfiguration[5, 1] = new MazeCell("bottom top");
            MazeConfiguration[5, 2] = new MazeCell("bottom top");
            MazeConfiguration[5, 3] = new MazeCell("bottom right");
            MazeConfiguration[5, 4] = new MazeCell("left bottom");
            MazeConfiguration[5, 5] = new MazeCell("bottom right");
        }

        public void CreateConfig4()
        {
            MazeConfiguration[0, 0] = new MazeCell("circle top left");
            MazeConfiguration[0, 1] = new MazeCell("top right");
            MazeConfiguration[0, 2] = new MazeCell("top bottom left");
            MazeConfiguration[0, 3] = new MazeCell("top bottom");
            MazeConfiguration[0, 4] = new MazeCell("top bottom");
            MazeConfiguration[0, 5] = new MazeCell("top right");

            MazeConfiguration[1, 0] = new MazeCell("left right");
            MazeConfiguration[1, 1] = new MazeCell("left right");
            MazeConfiguration[1, 2] = new MazeCell("top left");
            MazeConfiguration[1, 3] = new MazeCell("top bottom");
            MazeConfiguration[1, 4] = new MazeCell("top bottom");
            MazeConfiguration[1, 5] = new MazeCell("right");

            MazeConfiguration[2, 0] = new MazeCell("left right");
            MazeConfiguration[2, 1] = new MazeCell("left bottom");
            MazeConfiguration[2, 2] = new MazeCell("bottom right");
            MazeConfiguration[2, 3] = new MazeCell("left top");
            MazeConfiguration[2, 4] = new MazeCell("top left bottom");
            MazeConfiguration[2, 5] = new MazeCell("left right");

            MazeConfiguration[3, 0] = new MazeCell("left right circle");
            MazeConfiguration[3, 1] = new MazeCell("left top bottom");
            MazeConfiguration[3, 2] = new MazeCell("top bottom");
            MazeConfiguration[3, 3] = new MazeCell("bottom");
            MazeConfiguration[3, 4] = new MazeCell("top bottom");
            MazeConfiguration[3, 5] = new MazeCell("right");

            MazeConfiguration[4, 0] = new MazeCell("left");
            MazeConfiguration[4, 1] = new MazeCell("top bottom");
            MazeConfiguration[4, 2] = new MazeCell("top bottom");
            MazeConfiguration[4, 3] = new MazeCell("top bottom");
            MazeConfiguration[4, 4] = new MazeCell("top right");
            MazeConfiguration[4, 5] = new MazeCell("left right");

            MazeConfiguration[5, 0] = new MazeCell("left bottom");
            MazeConfiguration[5, 1] = new MazeCell("top bottom");
            MazeConfiguration[5, 2] = new MazeCell("top bottom right");
            MazeConfiguration[5, 3] = new MazeCell("left top bottom");
            MazeConfiguration[5, 4] = new MazeCell("bottom right");
            MazeConfiguration[5, 5] = new MazeCell("left right bottom");
        }

        public void CreateConfig5()
        {
            MazeConfiguration[0, 0] = new MazeCell("left top bottom");
            MazeConfiguration[0, 1] = new MazeCell("top bottom");
            MazeConfiguration[0, 2] = new MazeCell("top bottom");
            MazeConfiguration[0, 3] = new MazeCell("top bottom");
            MazeConfiguration[0, 4] = new MazeCell("top");
            MazeConfiguration[0, 5] = new MazeCell("top right");

            MazeConfiguration[1, 0] = new MazeCell("left top");
            MazeConfiguration[1, 1] = new MazeCell("top bottom");
            MazeConfiguration[1, 2] = new MazeCell("top bottom");
            MazeConfiguration[1, 3] = new MazeCell("top");
            MazeConfiguration[1, 4] = new MazeCell("bottom right");
            MazeConfiguration[1, 5] = new MazeCell("left bottom right");

            MazeConfiguration[2, 0] = new MazeCell("left");
            MazeConfiguration[2, 1] = new MazeCell("top right");
            MazeConfiguration[2, 2] = new MazeCell("top left right");
            MazeConfiguration[2, 3] = new MazeCell("bottom right");
            MazeConfiguration[2, 4] = new MazeCell("top left circle");
            MazeConfiguration[2, 5] = new MazeCell("top right");

            MazeConfiguration[3, 0] = new MazeCell("left right");
            MazeConfiguration[3, 1] = new MazeCell("left bottom");
            MazeConfiguration[3, 2] = new MazeCell("top bottom");
            MazeConfiguration[3, 3] = new MazeCell("top right");
            MazeConfiguration[3, 4] = new MazeCell("right left bottom");
            MazeConfiguration[3, 5] = new MazeCell("right left");

            MazeConfiguration[4, 0] = new MazeCell("left right");
            MazeConfiguration[4, 1] = new MazeCell("top left");
            MazeConfiguration[4, 2] = new MazeCell("top bottom");
            MazeConfiguration[4, 3] = new MazeCell("bottom");
            MazeConfiguration[4, 4] = new MazeCell("top bottom right");
            MazeConfiguration[4, 5] = new MazeCell("left right");

            MazeConfiguration[5, 0] = new MazeCell("left bottom right");
            MazeConfiguration[5, 1] = new MazeCell("left bottom");
            MazeConfiguration[5, 2] = new MazeCell("top bottom");
            MazeConfiguration[5, 3] = new MazeCell("top bottom");
            MazeConfiguration[5, 4] = new MazeCell("top bottom");
            MazeConfiguration[5, 5] = new MazeCell("bottom right");
        }

        public void CreateConfig6()
        {
            MazeConfiguration[0, 0] = new MazeCell("left right top");
            MazeConfiguration[0, 1] = new MazeCell("left top");
            MazeConfiguration[0, 2] = new MazeCell("top right");
            MazeConfiguration[0, 3] = new MazeCell("left top bottom");
            MazeConfiguration[0, 4] = new MazeCell("top circle");
            MazeConfiguration[0, 5] = new MazeCell("top right");

            MazeConfiguration[1, 0] = new MazeCell("left right");
            MazeConfiguration[1, 1] = new MazeCell("left right");
            MazeConfiguration[1, 2] = new MazeCell("left right");
            MazeConfiguration[1, 3] = new MazeCell("left top");
            MazeConfiguration[1, 4] = new MazeCell("bottom right");
            MazeConfiguration[1, 5] = new MazeCell("left right");

            MazeConfiguration[2, 0] = new MazeCell("left");
            MazeConfiguration[2, 1] = new MazeCell("right bottom");
            MazeConfiguration[2, 2] = new MazeCell("left right bottom");
            MazeConfiguration[2, 3] = new MazeCell("left right");
            MazeConfiguration[2, 4] = new MazeCell("left top");
            MazeConfiguration[2, 5] = new MazeCell("right bottom");

            MazeConfiguration[3, 0] = new MazeCell("left bottom");
            MazeConfiguration[3, 1] = new MazeCell("top right");
            MazeConfiguration[3, 2] = new MazeCell("top left");
            MazeConfiguration[3, 3] = new MazeCell("right");
            MazeConfiguration[3, 4] = new MazeCell("left right");
            MazeConfiguration[3, 5] = new MazeCell("left right top");

            MazeConfiguration[4, 0] = new MazeCell("top left");
            MazeConfiguration[4, 1] = new MazeCell("bottom right");
            MazeConfiguration[4, 2] = new MazeCell("left right bottom circle");
            MazeConfiguration[4, 3] = new MazeCell("left right");
            MazeConfiguration[4, 4] = new MazeCell("left bottom");
            MazeConfiguration[4, 5] = new MazeCell("right");

            MazeConfiguration[5, 0] = new MazeCell("left bottom");
            MazeConfiguration[5, 1] = new MazeCell("top bottom");
            MazeConfiguration[5, 2] = new MazeCell("top bottom");
            MazeConfiguration[5, 3] = new MazeCell("bottom right");
            MazeConfiguration[5, 4] = new MazeCell("left top bottom");
            MazeConfiguration[5, 5] = new MazeCell("bottom right");
        }

        public void CreateConfig7()
        {
            MazeConfiguration[0, 0] = new MazeCell("top left");
            MazeConfiguration[0, 1] = new MazeCell("top bottom");
            MazeConfiguration[0, 2] = new MazeCell("top bottom");
            MazeConfiguration[0, 3] = new MazeCell("top right");
            MazeConfiguration[0, 4] = new MazeCell("top left");
            MazeConfiguration[0, 5] = new MazeCell("tpo right");

            MazeConfiguration[1, 0] = new MazeCell("left right");
            MazeConfiguration[1, 1] = new MazeCell("top left");
            MazeConfiguration[1, 2] = new MazeCell("top right bottom");
            MazeConfiguration[1, 3] = new MazeCell("left bottom");
            MazeConfiguration[1, 4] = new MazeCell("bottom right");
            MazeConfiguration[1, 5] = new MazeCell("left right");

            MazeConfiguration[2, 0] = new MazeCell("bottom left");
            MazeConfiguration[2, 1] = new MazeCell("bottom right");
            MazeConfiguration[2, 2] = new MazeCell("top left");
            MazeConfiguration[2, 3] = new MazeCell("bottom right top");
            MazeConfiguration[2, 4] = new MazeCell("top left");
            MazeConfiguration[2, 5] = new MazeCell("bottom right");

            MazeConfiguration[3, 0] = new MazeCell("top left");
            MazeConfiguration[3, 1] = new MazeCell("top right");
            MazeConfiguration[3, 2] = new MazeCell("left");
            MazeConfiguration[3, 3] = new MazeCell("top bottom");
            MazeConfiguration[3, 4] = new MazeCell("bottom right");
            MazeConfiguration[3, 5] = new MazeCell("top right left");

            MazeConfiguration[4, 0] = new MazeCell("left right");
            MazeConfiguration[4, 1] = new MazeCell("bottom right left");
            MazeConfiguration[4, 2] = new MazeCell("bottom left");
            MazeConfiguration[4, 3] = new MazeCell("top bottom");
            MazeConfiguration[4, 4] = new MazeCell("top right");
            MazeConfiguration[4, 5] = new MazeCell("left right");

            MazeConfiguration[5, 0] = new MazeCell("bottom left");
            MazeConfiguration[5, 1] = new MazeCell("top bottom");
            MazeConfiguration[5, 2] = new MazeCell("top bottom");
            MazeConfiguration[5, 3] = new MazeCell("top bottom");
            MazeConfiguration[5, 4] = new MazeCell("bottom");
            MazeConfiguration[5, 5] = new MazeCell("bottom right");
        }

        public void CreateConfig8()
        {
            MazeConfiguration[0, 0] = new MazeCell("top left right");
            MazeConfiguration[0, 1] = new MazeCell("top left");
            MazeConfiguration[0, 2] = new MazeCell("top bottom");
            MazeConfiguration[0, 3] = new MazeCell("top right circle");
            MazeConfiguration[0, 4] = new MazeCell("top left");
            MazeConfiguration[0, 5] = new MazeCell("top right");

            MazeConfiguration[1, 0] = new MazeCell("left");
            MazeConfiguration[1, 1] = new MazeCell("bottom");
            MazeConfiguration[1, 2] = new MazeCell("top bottom right");
            MazeConfiguration[1, 3] = new MazeCell("bottom left");
            MazeConfiguration[1, 4] = new MazeCell("bottom right");
            MazeConfiguration[1, 5] = new MazeCell("left right");

            MazeConfiguration[2, 0] = new MazeCell("left right");
            MazeConfiguration[2, 1] = new MazeCell("top left");
            MazeConfiguration[2, 2] = new MazeCell("top bottom");
            MazeConfiguration[2, 3] = new MazeCell("top bottom");
            MazeConfiguration[2, 4] = new MazeCell("top right");
            MazeConfiguration[2, 5] = new MazeCell("left right");

            MazeConfiguration[3, 0] = new MazeCell("left right");
            MazeConfiguration[3, 1] = new MazeCell("bottom left");
            MazeConfiguration[3, 2] = new MazeCell("top right circle");
            MazeConfiguration[3, 3] = new MazeCell("top bottom left");
            MazeConfiguration[3, 4] = new MazeCell("bottom");
            MazeConfiguration[3, 5] = new MazeCell("bottom right");

            MazeConfiguration[4, 0] = new MazeCell("left right");
            MazeConfiguration[4, 1] = new MazeCell("left right top");
            MazeConfiguration[4, 2] = new MazeCell("bottom left");
            MazeConfiguration[4, 3] = new MazeCell("top bottom");
            MazeConfiguration[4, 4] = new MazeCell("top bottom");
            MazeConfiguration[4, 5] = new MazeCell("top bottom right");

            MazeConfiguration[5, 0] = new MazeCell("bottom left");
            MazeConfiguration[5, 1] = new MazeCell("bottom");
            MazeConfiguration[5, 2] = new MazeCell("top bottom");
            MazeConfiguration[5, 3] = new MazeCell("top bottom");
            MazeConfiguration[5, 4] = new MazeCell("top bottom");
            MazeConfiguration[5, 5] = new MazeCell("top bottom right");
        }

        public void CreateConfig9()
        {
            MazeConfiguration[0, 0] = new MazeCell("top left right");
            MazeConfiguration[0, 1] = new MazeCell("top left");
            MazeConfiguration[0, 2] = new MazeCell("top bottom");
            MazeConfiguration[0, 3] = new MazeCell("top bottom");
            MazeConfiguration[0, 4] = new MazeCell("top");
            MazeConfiguration[0, 5] = new MazeCell("top right");

            MazeConfiguration[1, 0] = new MazeCell("left right");
            MazeConfiguration[1, 1] = new MazeCell("left right");
            MazeConfiguration[1, 2] = new MazeCell("top left circle");
            MazeConfiguration[1, 3] = new MazeCell("top right bottom");
            MazeConfiguration[1, 4] = new MazeCell("left right");
            MazeConfiguration[1, 5] = new MazeCell("left right");

            MazeConfiguration[2, 0] = new MazeCell("left");
            MazeConfiguration[2, 1] = new MazeCell("bottom");
            MazeConfiguration[2, 2] = new MazeCell("bottom right");
            MazeConfiguration[2, 3] = new MazeCell("top left");
            MazeConfiguration[2, 4] = new MazeCell("bottom right");
            MazeConfiguration[2, 5] = new MazeCell("left right");

            MazeConfiguration[3, 0] = new MazeCell("left right");
            MazeConfiguration[3, 1] = new MazeCell("top left right");
            MazeConfiguration[3, 2] = new MazeCell("top left");
            MazeConfiguration[3, 3] = new MazeCell("bottom right");
            MazeConfiguration[3, 4] = new MazeCell("top bottom left");
            MazeConfiguration[3, 5] = new MazeCell("right");

            MazeConfiguration[4, 0] = new MazeCell("left right circle");
            MazeConfiguration[4, 1] = new MazeCell("left right");
            MazeConfiguration[4, 2] = new MazeCell("left right");
            MazeConfiguration[4, 3] = new MazeCell("left top");
            MazeConfiguration[4, 4] = new MazeCell("top right");
            MazeConfiguration[4, 5] = new MazeCell("bottom left right");

            MazeConfiguration[5, 0] = new MazeCell("bottom left");
            MazeConfiguration[5, 1] = new MazeCell("bottom right");
            MazeConfiguration[5, 2] = new MazeCell("left bottom");
            MazeConfiguration[5, 3] = new MazeCell("bottom right");
            MazeConfiguration[5, 4] = new MazeCell("bottom left");
            MazeConfiguration[5, 5] = new MazeCell("top bottom right");
        }

        public string ExitPath()
        {
            if (string.IsNullOrEmpty(Circle1)) return "Still need the first red circle.";
            if (string.IsNullOrEmpty(Circle2)) return "Still need the second red circle.";
            if (string.IsNullOrEmpty(ExitPosition)) return "Still need the exit position.";
            if (string.IsNullOrEmpty(PlayerPosition)) return "Still need the player position.";

            if ((Circle1 == "1,0" && Circle2 == "2,5") || (Circle1 == "2,5" && Circle2 == "1,0")) CreateConfig1();
            if ((Circle1 == "3,1" && Circle2 == "1,4") || (Circle1 == "1,4" && Circle2 == "3,1")) CreateConfig2();
            if ((Circle1 == "3,3" && Circle2 == "3,5") || (Circle1 == "3,5" && Circle2 == "3,3")) CreateConfig3();
            if ((Circle1 == "0,0" && Circle2 == "0,3") || (Circle1 == "0,3" && Circle2 == "0,0")) CreateConfig4();
            if ((Circle1 == "2,4" && Circle2 == "5,3") || (Circle1 == "5,3" && Circle2 == "2,4")) CreateConfig5();
            if ((Circle1 == "4,2" && Circle2 == "0,4") || (Circle1 == "0,4" && Circle2 == "4,2")) CreateConfig6();
            if ((Circle1 == "0,1" && Circle2 == "5,1") || (Circle1 == "5,1" && Circle2 == "0,1")) CreateConfig7();
            if ((Circle1 == "0,3" && Circle2 == "3,2") || (Circle1 == "3,2" && Circle2 == "0,3")) CreateConfig8();
            if ((Circle1 == "1,2" && Circle2 == "4,0") || (Circle1 == "4,0" && Circle2 == "1,2")) CreateConfig9();

            MazeConfiguration[int.Parse(ExitPosition[0].ToString()), int.Parse(ExitPosition[2].ToString())].Exit = true;
            MazeConfiguration[int.Parse(PlayerPosition[0].ToString()), int.Parse(PlayerPosition[2].ToString())].Player = true;

            return "Take a " + FindWayOut(int.Parse(PlayerPosition[0].ToString()), int.Parse(PlayerPosition[2].ToString()), "none");
        }

        public string FindWayOut(int line, int column, string directionMoved)
        {
            var message = "";

            var mazeCell = MazeConfiguration[line, column];

            if (mazeCell.Exit) return "and you are there.";

            if (!mazeCell.CanMove(directionMoved))
            {
                return "and you can't move anymore.";
            }

            if (!mazeCell.LeftWall && !(message.Contains("and you can't move anymore.") || message.Contains("and you are there.")) && directionMoved != "right")
            {
                var messageOfMovement = "left, " + FindWayOut(line, column - 1, "left");
                if (!messageOfMovement.Contains("and you can't move anymore.")) message += messageOfMovement;
            }

            if (!mazeCell.RightWall && !(message.Contains("and you can't move anymore.") || message.Contains("and you are there.")) && directionMoved != "left")
            {
                var messageOfMovement = "right, " + FindWayOut(line, column + 1, "right");
                if (!messageOfMovement.Contains("and you can't move anymore.")) message += messageOfMovement;
            }

            if (!mazeCell.TopWall && !(message.Contains("and you can't move anymore.") || message.Contains("and you are there.")) && directionMoved != "down")
            {
                var messageOfMovement = "up, " + FindWayOut(line - 1, column, "up");
                if (!messageOfMovement.Contains("and you can't move anymore.")) message += messageOfMovement;
            }

            if (!mazeCell.BottomWall && !(message.Contains("and you can't move anymore.") || message.Contains("and you are there.")) && directionMoved != "up")
            {
                var messageOfMovement = "down, " + FindWayOut(line + 1, column, "down");
                if (!messageOfMovement.Contains("and you can't move anymore.")) message += messageOfMovement;
            }

            if (!message.EndsWith(".")) return "and you can't move anymore.";

            return message;
        }
    }

    public class MazeCell
    {
        public MazeCell(string information)
        {
            if (information.Contains("left")) LeftWall = true; else LeftWall = false;
            if (information.Contains("right")) RightWall = true; else RightWall = false;
            if (information.Contains("top")) TopWall = true; else TopWall = false;
            if (information.Contains("bottom")) BottomWall = true; else BottomWall = false;
            if (information.Contains("circle")) Circle = true; else Circle = false;
            if (information.Contains("exit")) Exit = true; else Exit = false;
            if (information.Contains("player")) Player = true; else Player = false;
        }

        public bool LeftWall;
        public bool RightWall;
        public bool TopWall;
        public bool BottomWall;
        public bool Circle;
        public bool Exit;
        public bool Player;

        public bool CanMove(string lastMove)
        {
            switch (lastMove)
            {
                case "left": return !LeftWall || !TopWall || !BottomWall;
                case "right": return !RightWall || !TopWall || !BottomWall;
                case "up": return !RightWall || !LeftWall || !TopWall;
                case "down": return !RightWall || !BottomWall || !LeftWall;
                default: return true;
            }
        }
    }
}