using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Maze
    {
        #region Variables

        // Working Variables
        private int mazeSizeInt;
        private int startXInt = 1;
        private int startYInt = 1;
        private int indexXInt;
        private int indexYInt;

        MazeTile[,] mazeLayout;
        char[,] preDefinedMaze = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '!' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };


        #endregion



        #region Constructor

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public Maze()
        {
            ReadMaze();
        }

        #endregion



        #region Properties

        public MazeTile[,] MazeLayout
        {
            get
            {
                return mazeLayout;
            }
        }

        public int StartingX
        {
            get
            {
                return startXInt;
            }
        }

        public int StartingY
        {
            get
            {
                return startYInt;
            }
        }

        public int MazeSize
        {
            get
            {
                return mazeSizeInt;
            }
        }

        #endregion



        #region Private Methods

        private void ReadMaze()
        {
            indexXInt = 0;
            indexYInt = 0;
            mazeSizeInt = preDefinedMaze.GetLength(0);
            mazeLayout = new MazeTile[mazeSizeInt, mazeSizeInt];

            while (indexYInt < mazeSizeInt)
            {
                // If not yet at end of horizontal, add 1 to X. Otherwise reset x and add 1 to Y.
                if (indexXInt < mazeSizeInt)
                {
                    // Creates a full MazeTile spot based on the given ID of predefined maze spot.
                    mazeLayout[indexYInt, indexXInt] = new MazeTile(preDefinedMaze[indexYInt, indexXInt]);
                    indexXInt++;
                }
                else
                {
                    indexXInt = 0;
                    indexYInt++;
                }
            }
        }

        #endregion



        #region Public Methods

        public char DisplayMazeTile(int currentY, int currentX)
        {
            return mazeLayout[currentY, currentX].Display;
        }

        #endregion

    }
}
