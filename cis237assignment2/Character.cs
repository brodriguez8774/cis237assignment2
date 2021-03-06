﻿// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// Character (player) which moves through and solves the maze.
    /// </summary>
    class Character
    {
        #region Variables

        // Classes
        Maze maze;

        // Working Variables
        private int currentXInt;
        private int currentYInt;
        private static char tileDisplayChar = '*';

        #endregion



        #region Constructor

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public Character()
        {

        }

        /// <summary>
        /// Sets up the initial properties of the player character.
        /// </summary>
        /// <param name="currentMaze">Current maze of which the player is to solve.</param>
        /// <param name="startingX">The starting X coordinates of player.</param>
        /// <param name="startingY">The starting Y coordinates of player.</param>
        public Character(Maze currentMaze)
        {
            Maze = currentMaze;
            currentXInt = Settings.StartingX;
            currentYInt = Settings.StartingY;
        }

        #endregion



        #region Properties

        public Maze Maze
        {
            set { maze = value; }
        }

        public int CurrentX
        {
            get { return currentXInt; }
        }

        public int CurrentY
        {
            get { return currentYInt; }
        }

        public static char CharacterDisplay
        {
            get { return tileDisplayChar; }
        }

        #endregion



        #region PrivateMethods

        /// <summary>
        /// Checks if player can move one space to the right.
        /// </summary>
        /// <param name="testedValue">"Is tile tested" value. See maze property class for details.</param>
        /// <param name="currentY">Player's current Y index.</param>
        /// <param name="currentX">Player's current X index.</param>
        private void AttemptRight(int testedValue, int currentY, int currentX)
        {
            
            if (maze.MazeLayout[currentY, currentX + 1].Movement &&             // If tile can be moved into.
            maze.MazeLayout[currentY, currentX + 1].Tested == testedValue)      // Puts priority on untested tiles.
            {
                // If move successful, try again with new space.
                UserInterface.DisplayMaze(maze.MazeToString(currentY, currentX));
                currentXInt = currentX + 1;
                maze.UpdateMazeTile(currentY, currentX);
                MoveCharacter(0, currentY, currentX + 1);
            }
            else
            {
                AttemptDown(testedValue, currentY, currentX);
            }
        }

        /// <summary>
        /// Checks if player can move one space down.
        /// </summary>
        /// <param name="testedValue">"Is tile tested" value. See maze property class for details.</param>
        /// <param name="currentY">Player's current Y index.</param>
        /// <param name="currentX">Player's current X index.</param>
        private void AttemptDown(int testedValue, int currentY, int currentX)
        {
            if (maze.MazeLayout[currentY + 1, currentX].Movement &&             // If tile can be moved into.
            maze.MazeLayout[currentY + 1, currentX].Tested == testedValue)      // Puts priority on untested tiles.
            {
                // If move successful, try again with new space.
                UserInterface.DisplayMaze(maze.MazeToString(currentY, currentX));
                currentYInt = currentY + 1;
                maze.UpdateMazeTile(currentY, currentX);
                MoveCharacter(0, currentY + 1, currentX);
            }
            else
            {
                AttemptLeft(testedValue, currentY, currentX);
            }
        }

        /// <summary>
        /// Checks if player can move one space to the left.
        /// </summary>
        /// <param name="testedValue">"Is tile tested" value. See maze property class for details.</param>
        /// <param name="currentY">Player's current Y index.</param>
        /// <param name="currentX">Player's current X index.</param>
        private void AttemptLeft(int testedValue, int currentY, int currentX)
        {
            if (maze.MazeLayout[currentY, currentX - 1].Movement &&             // If tile can be moved into.
            maze.MazeLayout[currentY, currentX - 1].Tested == testedValue)      // Puts priority on untested tiles.
            {
                // If move successful, try again with new space.
                UserInterface.DisplayMaze(maze.MazeToString(currentY, currentX));
                currentXInt = currentX - 1;
                maze.UpdateMazeTile(currentY, currentX);
                MoveCharacter(0, currentY, currentX - 1);
            }
            else
            {
                AttemptUp(testedValue, currentY, currentX);
            }
        }

        /// <summary>
        /// Checks if player can move one space up.
        /// </summary>
        /// <param name="testedValue">"Is tile tested" value. See maze property class for details.</param>
        /// <param name="currentY">Player's current Y index.</param>
        /// <param name="currentX">Player's current X index.</param>
        private void AttemptUp(int testedValue, int currentY, int currentX)
        {
            if (maze.MazeLayout[currentY - 1, currentX].Movement &&             // If tile can be moved into.
            maze.MazeLayout[currentY - 1, currentX].Tested == testedValue)      // Puts priority on untested tiles.
            {
                // If move successful, try again with new space.
                UserInterface.DisplayMaze(maze.MazeToString(currentY, currentX));
                currentYInt = currentY - 1;
                maze.UpdateMazeTile(currentY, currentX);
                MoveCharacter(0, currentY - 1, currentX);
            }
            // If no moves can be made on first pass, incriment tested index to go backward spaces.
            else
            {
                testedValue++;
                MoveCharacter(testedValue, currentY, currentX);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Start of recursive attempt to solve maze.
        /// </summary>
        /// <param name="testedValue">"Is tile tested" value. See maze property class for details.</param>
        /// <param name="currentY">Player's current Y index.</param>
        /// <param name="currentX">Player's current X index.</param>
        public void MoveCharacter(int testedValue, int currentY, int currentX)
        {
            // If not yet at the exit.
            if (maze.MazeLayout[currentY, currentX].IDString != MazeTile.ID_Exit)
            {
                AttemptRight(testedValue, currentY, currentX);
            }
            else
            {
                // Base Case.
                UserInterface.DisplayMaze(maze.MazeToString(currentY, currentX));
                UserInterface.Display("Maze complete!");
            }
        }

        #endregion

    }
}
