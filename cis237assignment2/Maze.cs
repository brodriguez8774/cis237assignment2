using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// Handles all properties and creation of full mazes.
    /// </summary>
    class Maze
    {
        #region Variables

        // Classes
        Character player;

        // Working Variables
        private int mazeSizeInt;
        private int startingXInt = 1;
        private int startingYInt = 1;
        private int indexXInt;
        private int indexYInt;
        private int waitTimerInt = 500;

        MazeTile[,] mazeLayout;
        MazeTile[,] tempMaze;

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
            player = new Character(this, startingYInt, startingXInt);
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
                    mazeLayout[indexXInt, indexYInt] = new MazeTile(preDefinedMaze[indexYInt, indexXInt]);
                    indexXInt++;
                }
                else
                {
                    indexXInt = 0;
                    indexYInt++;
                }
            }

            tempMaze = mazeLayout;
        }

        /// <summary>
        /// Transposes maze accros the diagonal.
        /// </summary>
        private void TransposeMaze()
        {
            indexXInt = 0;
            indexYInt = 0;

            while (indexYInt < mazeSizeInt)
            {
                if (indexXInt < mazeSizeInt)
                {
                    mazeLayout[indexYInt, indexXInt] = tempMaze[indexXInt, indexYInt];
                    indexXInt++;
                }
                indexXInt = 0;
                indexYInt++;
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
        /// <param name="currentPlayerY">Player's current Y index.</param>
        /// <param name="currentPlayerX">Player's current X index.</param>
        /// <returns>String composed of maze visual.</returns>
        public string MazeToString(Maze currentMaze, int currentPlayerY, int currentPlayerX)
        {
            indexXInt = 0;
            indexYInt = 0;
            string displayString = "";

            Task.Delay(waitTimerInt).Wait();

            // While y axis not = max maze size.
            while (indexYInt < mazeSizeInt)
            {
                // While x axis not = max maze size.
                if (indexXInt < mazeSizeInt)
                {
                    // If spot = index character is on, display character instead.
                    if (currentPlayerX == indexXInt && currentPlayerY == indexYInt)
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

        /// <summary>
        /// Updates specific maze tile for player interaction.
        /// </summary>
        /// <param name="currentY">Player's current Y coordinate.</param>
        /// <param name="currentX">Player's current X coordinate.</param>
        public void UpdateMazeTile(int currentY, int currentX)
        {
            // If tile has not been tested (walked on) yet.
            if (mazeLayout[currentY, currentX].Tested == 0)
            {
                mazeLayout[currentY, currentX] = new MazeTile('X');
            }
            else
            {
                // If tile has been tested (walked on) once before.
                if (mazeLayout[currentY, currentX].Tested == 1)
                {
                    mazeLayout[currentY, currentX] = new MazeTile('O');
                }
            }
        }

        #endregion

    }
}
