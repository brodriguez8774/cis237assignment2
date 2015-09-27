// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// Runs program and handles interactions between all classes.
    /// </summary>
    class RunProgram
    {

        #region Variables

        // Classes
        Maze maze;
        Character player;
        UserInterface userInterface;
        Settings settings;

        bool runProgramBool;
        int indexXInt;
        int indexYInt;
        string userInputString;

        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor which controls execution of program.
        /// </summary>
        public RunProgram()
        {
            userInterface = new UserInterface();
            settings = new Settings(userInterface);
            runProgramBool = true;

            while (runProgramBool)
            {
                userInterface.DisplayMainMenu();
                UserMenuSelection();
            }

            //Testing newTest = new Testing();
            //newTest.ForceTesting();
        }

        #endregion



        #region Properties

        #endregion



        #region Methods

        /// <summary>
        /// Gets User Selection and takes appropriate action.
        /// </summary>
        private void UserMenuSelection()
        {
            userInputString = userInterface.GetUserInput();
            Console.WriteLine();

            switch (userInputString)
            {
                case "1":
                    CreateMazeMenu();
                    break;
                case "2":
                    SolveMaze();
                    break;
                case "3":
                    AdjustSettings();
                    break;
                case "4":
                    CloseProgram();
                    break;
                case "esc":
                    CloseProgram();
                    break;
                default:
                    userInterface.Display("Invalid selection.");
                    break;
            }
        }

        /// <summary>
        /// Creates a new maze.
        /// </summary>
        private void CreateMazeMenu()
        {
            userInterface.DisplayCreateMazeMenu();
            userInputString = userInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    maze = new Maze(settings);
                    player = new Character(settings, maze, 1, 1);
                    break;
                case "2":
                    maze = new Maze(settings);
                    maze.TransposeMaze();
                    player = new Character(settings, maze, 1, 1);
                    break;
                case "esc":
                    break;
                default:
                    userInterface.Display("Invalid selection.");
                    break;

                
            }
        }

        /// <summary>
        /// Solves current maze.
        /// </summary>
        private void SolveMaze()
        {
            if (maze != null)
            {
                player.MoveCharacter(0, maze.StartingY, maze.StartingX);
            }
            else
            {
                userInterface.Display("Must create a maze first!");
            }
        }

        /// <summary>
        /// Opens up settings menu.
        /// </summary>
        private void AdjustSettings()
        {
            settings.RunSettingsMenu();
        }

        /// <summary>
        /// Exits program.
        /// </summary>
        private void CloseProgram()
        {
            runProgramBool = false;
        }

        #endregion


    }
}
