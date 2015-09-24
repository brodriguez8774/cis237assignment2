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
        public void BruteForceTesting()
        {

            #region MazeTileTest

            Console.WriteLine(Environment.NewLine +
                "******************************" + Environment.NewLine +
                "Brute Test for Base MazeTile" + Environment.NewLine +
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
                "Brute Test for Maze Creation" + Environment.NewLine +
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
                "Brute Test forMaze Transposition" + Environment.NewLine +
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
                "Brute Test forMaze Transposition" + Environment.NewLine +
                "******************************" + Environment.NewLine);
            Console.WriteLine();



            #endregion
        }

        public void CaseTesting()
        {

        }

        #endregion
    }
}
