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

        // Classes

        // Working Variables
        private int mazeSizeInt;
        private int startingXInt = 1;
        private int startingYInt = 1;
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
                return startingXInt;
            }
        }

        public int StartingY
        {
            get
            {
                return startingYInt;
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

        /// <summary>
        /// Gets the TileDisplay property of current index.
        /// </summary>
        /// <param name="currentY">Current Y index.</param>
        /// <param name="currentX">Current X Index.</param>
        /// <returns>The DisplayChar of the index.</returns>
        public char DisplayMazeTile(int currentY, int currentX)
        {
            return mazeLayout[currentY, currentX].Display;
        }

        /// <summary>
        /// Creates string to display current maze, including player location and status.
        /// </summary>
        /// <param name="currentMaze">The current Maze to navigate.</param>
        /// <param name="currentPlayerX">Player's current X index.</param>
        /// <param name="currentPlayerY">Player's current Y index.</param>
        /// <returns>String composed of maze visual.</returns>
        public string MazeToString(Maze currentMaze, int currentPlayerY, int currentPlayerX)
        {
            indexXInt = 0;
            indexYInt = 0;
            string displayString = "";

            Character player = new Character(currentMaze, startingYInt, startingXInt);


            // While y axis not = max maze size.
            while (indexYInt < mazeSizeInt)
            {
                // While x axis not = max maze size.
                if (indexXInt < mazeSizeInt)
                {
                    // If spot = index character is on, display character instead.
                    if (player.CurrentX == indexXInt && player.CurrentY == indexYInt)
                    {
                        displayString += player.CharacterDisplay;
                        indexXInt++;
                    }
                    else
                    {
                        displayString += DisplayMazeTile(indexYInt, indexXInt);
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

            return displayString;
        }

        #endregion

    }
}
