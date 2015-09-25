using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class RunProgram
    {
        /*
        /// <summary>
        /// Starting Coordinates.
        /// </summary>
        const int X_START = 1;
        const int Y_START = 1;

        private void MazeSolver()
        {
            MazeSolver mazeSolver = new MazeSolver();

            /// <summary>
            /// Tell the instance to solve the first maze with the passed maze, and start coordinates.
            /// </summary>
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            //Solve the transposed maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);
        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            //Write code her to create a transposed maze.
            return new char[1, 1];
        }
         */

        #region Variables

        // Classes
        Maze maze;
        Character player;
        UserInterface userInterface;

        bool runProgramBool;
        int indexXInt;
        int indexYInt;

        #endregion



        #region Constructor

        public RunProgram()
        {
            //maze = new Maze();
            //player = new Character(maze, 1, 1);

            //player.MoveCharacter(0, maze.StartingY, maze.StartingX);


            userInterface = new UserInterface();

             Testing newTest = new Testing();
             newTest.ForceTesting();
        }

        #endregion



        #region Properties

        #endregion



        #region Methods

        public void DisplayMove(Maze currentMaze, int currentPlayerX, int currentPlayerY)
        {
            maze = currentMaze;
            indexXInt = 0;
            indexYInt = 0;
            string displayString = "";

            int startingX = 1;
            int startingY = 1;
            Character player = new Character(currentMaze, startingX, startingY);


            // While y axis not = max maze size.
            while (indexYInt < maze.MazeSize)
            {
                // While x axis not = max maze size.
                if (indexXInt < maze.MazeSize)
                {
                    // If spot = index character is on, display character instead.
                    if (player.CurrentX == indexXInt && player.CurrentY == indexYInt)
                    {
                        displayString += player.CharacterDisplay;
                        indexXInt++;
                    }
                    else
                    {
                        displayString += maze.DisplayMazeTile(indexYInt, indexXInt);
                        indexXInt++;
                    }
                }
                else
                {
                    displayString += Environment.NewLine;
                    indexXInt = 0;
                    indexYInt++;
                }
            }

            userInterface.DisplayMaze(displayString);
        }

        #endregion





    }
}
