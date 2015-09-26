using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class RunProgram
    {

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

        /// <summary>
        /// Base constructor which controls execution of program.
        /// </summary>
        public RunProgram()
        {
            maze = new Maze();
            player = new Character(maze, 1, 1);

            player.MoveCharacter(0, maze.StartingY, maze.StartingX);


            userInterface = new UserInterface();

            //Testing newTest = new Testing();
            //newTest.ForceTesting();
        }

        #endregion



        #region Properties

        #endregion



        #region Methods

        /// <summary>
        /// Displays maze and character's current position.
        /// </summary>
        /// <param name="currentMaze">Maze to display. Should be current maze.</param>
        /// <param name="currentPlayerX">Players current x coordinate.</param>
        /// <param name="currentPlayerY">Player's current y coordinate.</param>
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
