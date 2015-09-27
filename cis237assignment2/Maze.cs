﻿// Brandon Rodriguez

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
        //Character player;
        Settings settings;

        // Working Variables
        private int mazeSizeInt;
        private int startingXInt = 1;
        private int startingYInt = 1;
        private int indexInt;
        private int indexXInt;
        private int indexYInt;
        private int waitTimerInt = 500;
        string displayString;

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
            
        }

        public Maze(Settings settings)
        {
            Settings = settings;

            ReadMaze();
            //player = new Character(settings, this, startingYInt, startingXInt);
        }

        #endregion



        #region Properties

        public Settings Settings
        {
            set
            {
                settings = value;
            }
        }

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

        /// <summary>
        /// Reads in predefined maze and populates tiles accordingly.
        /// </summary>
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
        }

        /// <summary>
        /// Gets the TileDisplay property of current index.
        /// Repeats the tile char equal to the settings.TileWidth property.
        /// </summary>
        /// <param name="currentY">Current Y index.</param>
        /// <param name="currentX">Current X Index.</param>
        /// <returns>The DisplayChar of the index.</returns>
        private string DisplayMazeTile(int currentY, int currentX)
        {
            displayString = "";
            indexInt = 0;

            // While index is less than Tile Width property.
            while (indexInt < settings.TileWidth)
            {
                displayString += mazeLayout[currentY, currentX].Display;
                indexInt++;
            }
            return displayString;
        }

        /// <summary>
        /// Repeats player display char equal to the settings.TileWidth property.
        /// </summary>
        /// <returns>The DisplayChar of the player.</returns>
        private string DisplayCharacterTile()
        {
            string tempString = "";
            indexInt = 0;

            while (indexInt < settings.TileWidth)
            {
                tempString += Character.CharacterDisplay;
                indexInt++;
            }

            return tempString;
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Transposes maze accros the diagonal.
        /// </summary>
        public void TransposeMaze()
        {
            indexXInt = 0;
            indexYInt = 0;
            tempMaze = new MazeTile[mazeSizeInt, mazeSizeInt];

            while (indexYInt < mazeSizeInt)
            {
                // If not yet at end of horizontal, add 1 to X. Otherwise reset x and add 1 to Y.
                if (indexXInt < mazeSizeInt)
                {
                    // Swaps x and y coordinates.
                    tempMaze[indexYInt, indexXInt] = mazeLayout[indexXInt, indexYInt];
                    indexXInt++;
                }
                else
                {
                    indexXInt = 0;
                    indexYInt++;
                }
            }
            mazeLayout = tempMaze;
        }

        /// <summary>
        /// Creates string to display current maze, including player location and status.
        /// Adds spaces to the right of each character based on the settings.TileSpacing property.
        /// </summary>
        /// <param name="currentMaze">The current Maze to navigate.</param>
        /// <param name="currentPlayerY">Player's current Y index.</param>
        /// <param name="currentPlayerX">Player's current X index.</param>
        /// <returns>String composed of maze visual.</returns>
        public string MazeToString(Maze currentMaze, int currentPlayerY, int currentPlayerX)
        {
            indexXInt = 0;
            indexYInt = 0;
            displayString = "";

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
                        displayString += DisplayCharacterTile();

                        indexInt = 0;
                        // while index is less than the Tile Spacing property.
                        while (indexInt < settings.TileSpacing)
                        {
                            displayString += " ";
                            indexInt++;
                        }

                        indexXInt++;
                    }
                    else
                    {
                        displayString += DisplayMazeTile(indexYInt, indexXInt);

                        indexInt = 0;
                        // while index is less than the Tile Spacing property.
                        while (indexInt < settings.TileSpacing)
                        {
                            displayString += " ";
                            indexInt++;
                        }

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
            int directionCounter = 0;       // Holds how many nearby tiles are non-accessable.

            // Check tile to the right. If wall or dead end.
            if (mazeLayout[currentY, currentX + 1].IDString == MazeTile.ID_Wall ||
                mazeLayout[currentY, currentX + 1].IDString == MazeTile.ID_DeadEnd)
            {
                directionCounter++;
            }

            // Check tile below. If wall or dead end.
            if (mazeLayout[currentY + 1, currentX].IDString == MazeTile.ID_Wall ||
                mazeLayout[currentY + 1, currentX].IDString == MazeTile.ID_DeadEnd)
            {
                directionCounter++;
            }

            // Check tile to the left. If wall or dead end.
            if (mazeLayout[currentY, currentX - 1].IDString == MazeTile.ID_Wall ||
                mazeLayout[currentY, currentX - 1].IDString == MazeTile.ID_DeadEnd)
            {
                directionCounter++;
            }

            // Check tile to the above. If wall or dead end.
            if (mazeLayout[currentY - 1, currentX].IDString == MazeTile.ID_Wall ||
                mazeLayout[currentY - 1, currentX].IDString == MazeTile.ID_DeadEnd)
            {
                directionCounter++;
            }

            // If counter is 3 or higher, then space is a dead end.
            if (directionCounter >= 3)
            {
                mazeLayout[currentY, currentX] = new MazeTile('O');
            }
            else
            {
                mazeLayout[currentY, currentX] = new MazeTile('X');
            }     
        }

        #endregion

    }
}
