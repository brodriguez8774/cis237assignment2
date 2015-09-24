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

        bool runProgramBool;

        #endregion



        #region Constructor

        public RunProgram()
        {
            Testing newTest = new Testing();
            newTest.BruteForceTesting();
        }

        #endregion



        #region Properties

        #endregion



        #region Methods



        #endregion





    }
}
