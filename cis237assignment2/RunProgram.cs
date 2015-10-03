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

        bool runProgramBool;        // Keeps program loop running.
        bool newMazeBool;           // Tests if maze is solved or new.
        string userInputString;
        bool mazeCreatedBool;       // Stores if any maze has been made yet.

        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor which controls execution of program.
        /// </summary>
        public RunProgram()
        {
            Settings.InitializeSettings();
            maze = new Maze();
            runProgramBool = true;
            newMazeBool = false;
            mazeCreatedBool = false;

            while (runProgramBool)
            {
                UserInterface.DisplayMainMenu();
                UserMenuSelection();
            }
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
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    UserInterface.RemoveError();
                    CreateMazeMenu();
                    break;
                case "2":
                    UserInterface.RemoveError();
                    DisplayMaze();
                    break;
                case "3":
                    UserInterface.RemoveError();
                    SolveMaze();
                    break;
                case "4":
                    UserInterface.RemoveError();
                    AdjustSettings();
                    break;
                case "5":
                    CloseProgram();
                    break;
                case "esc":
                    CloseProgram();
                    break;
                default:
                    UserInterface.DisplayError("Invalid selection.");
                    break;
            }
        }

        /// <summary>
        /// Creates a new maze.
        /// </summary>
        private void CreateMazeMenu()
        {
            UserInterface.DisplayCreateMazeMenu();
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    UserInterface.RemoveError();
                    // If a maze was previously created.
                    if (mazeCreatedBool)
                    {
                        maze.ResetMazeDisplay();
                        maze.ReadMaze();
                        newMazeBool = true;
                    }
                    else
                    {
                        maze.ReadMaze();
                        newMazeBool = true;
                        mazeCreatedBool = true;
                    }
                    break;
                case "2":
                    UserInterface.RemoveError();
                    // If a maze was previously created.
                    if (mazeCreatedBool)
                    {
                        maze.ResetMazeDisplay();
                        maze.GenerateNewMaze();
                        newMazeBool = true;
                    }
                    else
                    {
                        maze.GenerateNewMaze();
                        newMazeBool = true;
                        mazeCreatedBool = true;
                    }
                    break;
                case "3":
                    UserInterface.RemoveError();
                    if (maze != null)
                    {
                        maze.TransposeMazeDiagonal();
                        newMazeBool = true;
                    }
                    else
                    {
                        UserInterface.DisplayError("Must create maze first.");
                    }
                    break;
                case "4":
                    UserInterface.RemoveError();
                    if (maze != null)
                    {
                        maze.TransposeMazeHorizontal();
                        newMazeBool = true;
                    }
                    else
                    {
                        UserInterface.DisplayError("Must create maze first.");
                    }
                    break;
                case "5":
                    UserInterface.RemoveError();
                    if (maze != null)
                    {
                        maze.TransposeMazeVertical();
                        newMazeBool = true;
                    }
                    else
                    {
                        UserInterface.DisplayError("Must create maze first.");
                    }
                    break;
                case "esc":
                    break;
                default:
                    UserInterface.DisplayError("Invalid selection.");
                    break;
            }
        }

        /// <summary>
        /// Displays current maze.
        /// </summary>
        private void DisplayMaze()
        {
            if (mazeCreatedBool)
            {
                // If maze currently unsolved.
                if (newMazeBool == true)
                {
                    UserInterface.DisplayMaze(maze.MazeToString(maze, Settings.StartingY, Settings.StartingX));
                }
                else
                {
                    maze.RefreshMaze();
                    newMazeBool = true;
                    DisplayMaze();
                }
            }
            else
            {
                UserInterface.DisplayError("Must create a maze first!");
            }
        }

        /// <summary>
        /// Solves current maze.
        /// </summary>
        private void SolveMaze()
        {
            // If a maze was created yet.
            if (mazeCreatedBool)
            {
                // If maze is currently unsolved.
                if (newMazeBool == true)
                {
                    player = new Character(maze);
                    player.MoveCharacter(0, Settings.StartingY, Settings.StartingX);
                    newMazeBool = false;
                }
                else
                {
                    maze.RefreshMaze();
                    newMazeBool = true;
                    SolveMaze();
                }
            }
            else
            {
                UserInterface.DisplayError("Must create a new maze first!");
            }
        }

        /// <summary>
        /// Opens up settings menu.
        /// </summary>
        private void AdjustSettings()
        {
            Settings.RunSettingsMenu();
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
