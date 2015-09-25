using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Character
    {
        #region Variables

        // Classes
        Maze maze;
        UserInterface userInterface = new UserInterface();

        // Working Variables

        private int startingXInt;
        private int startingYInt;
        private int currentXInt;
        private int currentYInt;
        private int testedValueInt;
        private char tileDisplayChar = '*';

        #endregion



        #region Constructor

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public Character()
        {

        }

        public Character(Maze currentMaze, int startingX, int startingY)
        {
            Maze = currentMaze;
            StartingX = startingX;
            StartingY = startingY;
            currentXInt = startingXInt;
            currentYInt = startingYInt;
        }

        #endregion



        #region Properties

        public Maze Maze
        {
            set
            {
                maze = value;
            }
        }

        public int StartingX
        {
            set
            {
                startingXInt = value;
            }
        }

        public int StartingY
        {
            set
            {
                startingYInt = value;
            }
        }

        public int CurrentX
        {
            get
            {
                return currentXInt;
            }
        }

        public int CurrentY
        {
            get
            {
                return currentYInt;
            }
        }

        public char CharacterDisplay
        {
            get
            {
                return tileDisplayChar;
            }
        }

        #endregion



        #region PrivateMethods


        private void AttemptRight(int testedValue, int currentY, int currentX)
        {
            // If tile can be moved into.
            if (maze.MazeLayout[currentY, currentX + 1].Movement)
            {
                // Puts priority on untested tiles.
                if (maze.MazeLayout[currentY, currentX + 1].Tested == testedValue)
                {
                    // If move successful, try again with new space.
                    MoveCharacter(0, currentY, currentX + 1);
                }
                else
                {
                    AttemptDown(testedValue, currentY, currentX);
                }
            }
            else
            {
                AttemptDown(testedValue, currentY, currentX);
            }
        }

        private void AttemptDown(int testedValue, int currentY, int currentX)
        {
            // If tile can be moved into.
            if (maze.MazeLayout[currentY + 1, currentX].Movement)
            {
                // Puts priority on untested tiles.
                if (maze.MazeLayout[currentY + 1, currentX].Tested == testedValue)
                {
                    // If move successful, try again with new space.
                    MoveCharacter(0, currentY + 1, currentX);
                }
                else
                {
                    AttemptLeft(testedValue, currentY, currentX);
                }
            }
            else
            {
                AttemptLeft(testedValue, currentY, currentX);
            }
        }

        private void AttemptLeft(int testedValue, int currentY, int currentX)
        {
            // If tile can be moved into.
            if (maze.MazeLayout[currentY, currentX - 1].Movement)
            {
                // Puts priority on untested tiles.
                if (maze.MazeLayout[currentY, currentX - 1].Tested == testedValue)
                {
                    // If move successful, try again with new space.
                    MoveCharacter(0, currentY, currentX - 1);
                }
                else
                {
                    AttemptUp(testedValue, currentY, currentX);
                }
            }
            else
            {
                AttemptUp(testedValue, currentY, currentX);
            }
        }

        private void AttemptUp(int testedValue, int currentY, int currentX)
        {
            // If tile can be moved into.
            if (maze.MazeLayout[currentY - 1, currentX].Movement)
            {
                // Puts priority on untested tiles.
                if (maze.MazeLayout[currentY - 1, currentX].Tested == testedValue)
                {
                    // If move successful, try again with new space.
                    MoveCharacter(0, currentY - 1, currentX);
                }
                /* Unecessary lines?
            // If no moves can be made on first pass, incriment tested index to go backward spaces.
            else
            {
                testedValue++;
                MoveCharacter(testedValue, currentX, currentY);
            }
        }
        // If no moves can be made on first pass, incriment tested index to go backward spaces.
        else
        {
            testedValue++;
            MoveCharacter(testedValue, currentX, currentY);
        } */
            }
        }

        #endregion

        #region Public Methods

        public void MoveCharacter(int testedValue, int currentY, int currentX)
        {
            userInterface.DisplayMaze(maze.MazeToString(maze, currentX, currentY));
            // If not yet at the exit.
            if (maze.MazeLayout[currentX, currentY].ID != '!')
            {
                AttemptRight(testedValue, currentX, currentY);
            }
            else
            {
                // Victory!
            }
        }

        #endregion

    }
}
