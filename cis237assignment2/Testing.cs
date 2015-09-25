using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Testing
    {
        #region Testing

        /// <summary>
        /// Basic tests for fundamental class functionality.
        /// Starts with the absolute minimum and slowly expands after pass.
        /// </summary>
        public void ForceTesting()
        {

            #region MazeTileTest

            Console.WriteLine(Environment.NewLine +
                "******************************" + Environment.NewLine +
                "Basic Test for Base MazeTile" + Environment.NewLine +
                "******************************" + Environment.NewLine);
            Console.WriteLine();

            MazeTile testTile = new MazeTile('#');
            Console.WriteLine("Tile ID: " + testTile.ID);
            Console.WriteLine("Tile Display: " + testTile.Display);
            Console.WriteLine("Tile Movement True/False: " + testTile.Movement);
            Console.WriteLine("Tile Tested Initial Value: " + testTile.Tested);
            Console.WriteLine();

            testTile = new MazeTile('.');
            Console.WriteLine("Tile ID: " + testTile.ID);
            Console.WriteLine("Tile Display: " + testTile.Display);
            Console.WriteLine("Tile Movement True/False: " + testTile.Movement);
            Console.WriteLine("Tile Tested Initial Value: " + testTile.Tested);
            Console.WriteLine();

            testTile = new MazeTile('X');
            Console.WriteLine("Tile ID: " + testTile.ID);
            Console.WriteLine("Tile Display: " + testTile.Display);
            Console.WriteLine("Tile Movement True/False: " + testTile.Movement);
            Console.WriteLine("Tile Tested Initial Value: " + testTile.Tested);
            Console.WriteLine();

            testTile = new MazeTile('O');
            Console.WriteLine("Tile ID: " + testTile.ID);
            Console.WriteLine("Tile Display: " + testTile.Display);
            Console.WriteLine("Tile Movement True/False: " + testTile.Movement);
            Console.WriteLine("Tile Tested Initial Value: " + testTile.Tested);
            Console.WriteLine();

            testTile = new MazeTile('!');
            Console.WriteLine("Tile ID: " + testTile.ID);
            Console.WriteLine("Tile Display: " + testTile.Display);
            Console.WriteLine("Tile Movement True/False: " + testTile.Movement);
            Console.WriteLine("Tile Tested Initial Value: " + testTile.Tested);
            Console.WriteLine();


            #endregion



            #region MazeDefaultDisplayTest

            Console.WriteLine(Environment.NewLine +
                "******************************" + Environment.NewLine +
                "Basic Test for Maze Creation" + Environment.NewLine +
                "******************************" + Environment.NewLine);
            Console.WriteLine();

            Maze testMaze = new Maze();
            int currentX = 0;
            int currentY = 0;
            string displayString = "";


            while (currentY < testMaze.MazeSize)
            {
                if (currentX < testMaze.MazeSize)
                {
                    displayString += testMaze.DisplayMazeTile(currentY, currentX);
                    currentX++;
                }
                else
                {
                    displayString += Environment.NewLine;
                    currentX = 0;
                    currentY++;
                }
            }

            Console.WriteLine(displayString);

            #endregion



            #region TransposeTest

            Console.WriteLine(Environment.NewLine +
                "******************************" + Environment.NewLine +
                "Basic Test for Maze Transposition" + Environment.NewLine +
                "******************************" + Environment.NewLine);
            Console.WriteLine();

            currentX = 0;
            currentY = 0;
            displayString = "";

            while (currentY < testMaze.MazeSize)
            {
                if (currentX < testMaze.MazeSize)
                {
                    displayString += testMaze.DisplayMazeTile(currentX, currentY);
                    currentX++;
                }
                else
                {
                    displayString += Environment.NewLine;
                    currentX = 0;
                    currentY++;
                }
            }

            Console.WriteLine(displayString);

            #endregion



            #region CharacterDisplayTest

            Console.WriteLine(Environment.NewLine +
                "******************************" + Environment.NewLine +
                "Basic Test for Maze Transposition" + Environment.NewLine +
                "******************************" + Environment.NewLine);
            Console.WriteLine();

            testMaze = new Maze();
            currentX = 0;
            currentY = 0;
            displayString = "";

            int startingX = 1;
            int startingY = 1;
            Character solver = new Character(testMaze, startingX, startingY);
            


            while (currentY < testMaze.MazeSize)
            {

                if (currentX < testMaze.MazeSize)
                {
                    // If spot = spot character is on, display character instead.
                    if (solver.CurrentX == currentX && solver.CurrentY == currentY)
                    {
                        displayString += solver.CharacterDisplay;
                        currentX++;
                    }
                    else
                    {
                        displayString += testMaze.DisplayMazeTile(currentY, currentX);
                        currentX++;
                    }
                }
                else
                {
                    displayString += Environment.NewLine;
                    currentX = 0;
                    currentY++;
                }
            }

            Console.WriteLine(displayString);

            #endregion



            #region CharacterMovementTest

            Console.WriteLine(Environment.NewLine +
                "******************************" + Environment.NewLine +
                "Basic Test for --" + Environment.NewLine +
                "******************************" + Environment.NewLine);
            Console.WriteLine();

            testMaze = new Maze();
            currentX = 0;
            currentY = 0;
            displayString = "";

            startingX = 1;
            startingY = 1;
            solver = new Character(testMaze, startingX, startingY);


            #endregion



        }

        public void CaseTesting()
        {

        }

        #endregion
    }
}
