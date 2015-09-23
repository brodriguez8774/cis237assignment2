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

        // Working Variables
        
        private int currentXInt;
        private int currentYInt;
        private int testedValueIndexInt;

        #endregion



        #region Constructor

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public Character()
        {

        }

        public Character(Maze selectedMaze)
        {
            Maze = selectedMaze;
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

        #endregion



        #region Methods


        private void MoveCharacter(int testedValue, int currentX, int currentY)
        {
            // If not yet at the exit.
            if (maze.MazeLayout[currentXInt, currentYInt].ID != "Exit")
            {
                AttemptRight(testedValue, currentX, currentY);
            }
            else
            {
                // Victory!
            }
        }

        private void AttemptRight(int testedValue, int currentX, int currentY)
        {
            // If tile can be moved into.
            if (maze.MazeLayout[currentX + 1, currentY].Movement)
            {
                // Puts priority on untested tiles.
                if (maze.MazeLayout[currentX + 1, currentY].Tested == testedValue)
                {
                    // If move successful, try again with new space.
                    MoveCharacter(testedValue, currentX + 1, currentY);
                }
                else
                {
                    AttemptDown(testedValue, currentX, currentY);
                }
            }
            else
            {
                AttemptDown(testedValue, currentX, currentY);
            }
        }

        private void AttemptDown(int testedValue, int currentX, int currentY)
        {
            // If tile can be moved into.
            if (maze.MazeLayout[currentX, currentY - 1].Movement)
            {
                // Puts priority on untested tiles.
                if (maze.MazeLayout[currentX, currentY - 1].Tested == testedValue)
                {
                    // If move successful, try again with new space.
                    MoveCharacter(testedValue, currentX, currentY - 1);
                }
                else
                {
                    AttemptLeft(testedValue, currentX, currentY);
                }
            }
            else
            {
                AttemptLeft(testedValue, currentX, currentY);
            }
        }

        private void AttemptLeft(int testedValue, int currentX, int currentY)
        {
            // If tile can be moved into.
            if (maze.MazeLayout[currentX - 1, currentY].Movement)
            {
                // Puts priority on untested tiles.
                if (maze.MazeLayout[currentX - 1, currentY].Tested == testedValue)
                {
                    // If move successful, try again with new space.
                    MoveCharacter(testedValue, currentX - 1, currentY);
                }
                else
                {
                    AttemptUp(testedValue, currentX, currentY);
                }
            }
            else
            {
                AttemptUp(testedValue, currentX, currentY);
            }
        }

        private void AttemptUp(int testedValue, int currentX, int currentY)
        {
            // If tile can be moved into.
            if (maze.MazeLayout[currentX, currentY + 1].Movement)
            {
                // Puts priority on untested tiles.
                if (maze.MazeLayout[currentX, currentY + 1].Tested == testedValue)
                {
                    // If move successful, try again with new space.
                    MoveCharacter(testedValue, currentX, currentY + 1);
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


        private void MoveRight()
        {

        }

        private void MoveDown()
        {

        }

        private void MoveLeft()
        {

        }

        private void MoveDown()
        {

        }

        #endregion
    }
}
