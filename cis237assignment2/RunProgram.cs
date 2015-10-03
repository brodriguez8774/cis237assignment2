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
                    CreateMazeMenu();
                    break;
                case "2":
                    DisplayMaze();
                    break;
                case "3":
                    SolveMaze();
                    break;
                case "4":
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
            UserInterface.RemoveDisplayLine();

            UserInterface.DisplayCreateMazeMenu();
            userInputString = UserInterface.GetUserInput();

            switch (userInputString)
            {
                case "1":
                    CreatePremadeMaze();
                    break;
                case "2":
                    CreateRandomMaze();
                    break;
                case "3":
                    TransposeCurrentMazeDiagonal();
                    break;
                case "4":
                    TransposeCurrentMazeHorizontal();
                    break;
                case "5":
                    TransposeCurrentMazeVertical();
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
            UserInterface.RemoveDisplayLine();

            // If a maze has been created already.
            if (mazeCreatedBool)
            {
                maze.ResetMazeDisplay();

                // If maze currently unsolved.
                if (newMazeBool == true)
                {
                    UserInterface.DisplayMaze(maze.MazeToString(Settings.StartingY, Settings.StartingX));
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
            UserInterface.RemoveDisplayLine();

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
            UserInterface.RemoveDisplayLine();
            Settings.RunSettingsMenu();
        }

        /// <summary>
        /// Exits program.
        /// </summary>
        private void CloseProgram()
        {
            runProgramBool = false;
        }

        /// <summary>
        /// Creates a maze from premade template.
        /// </summary>
        private void CreatePremadeMaze()
        {
            UserInterface.RemoveDisplayLine();

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
            // Displays new maze.
            maze.ResetMazeDisplay();
            UserInterface.DisplayMaze(maze.MazeToString(Settings.StartingY, Settings.StartingX));
        }

        /// <summary>
        /// Randomly generates a new maze. Displays entire generation of maze.
        /// </summary>
        private void CreateRandomMaze()
        {
            UserInterface.RemoveDisplayLine();

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
                // Prevents program from breaking if user enters bad(large) numbers.
                if (maze.GenerationSuccessful)
                {
                    newMazeBool = true;
                    mazeCreatedBool = true;
                }
            }
        }

        /// <summary>
        /// Transposes (flips) current maze diagonally.
        /// </summary>
        private void TransposeCurrentMazeDiagonal()
        {
            UserInterface.RemoveDisplayLine();

            if (maze.MazeLayout != null)
            {
                maze.TransposeMazeDiagonal();
                newMazeBool = true;

                // Displays new maze.
                maze.ResetMazeDisplay();
                UserInterface.DisplayMaze(maze.MazeToString(Settings.StartingY, Settings.StartingX));
            }
            else
            {
                UserInterface.DisplayError("Must create maze first.");
            }
        }

        /// <summary>
        /// Transposes (flips) current maze horizontally (accross the y axis).
        /// </summary>
        private void TransposeCurrentMazeHorizontal()
        {
            UserInterface.RemoveDisplayLine();

            if (maze.MazeLayout != null)
            {
                maze.TransposeMazeHorizontal();
                newMazeBool = true;

                // Displays new maze.
                maze.ResetMazeDisplay();
                UserInterface.DisplayMaze(maze.MazeToString(Settings.StartingY, Settings.StartingX));
            }
            else
            {
                UserInterface.DisplayError("Must create maze first.");
            }
        }

        /// <summary>
        /// Transposes(flips) current maze vertically (accross the x axis).
        /// </summary>
        private void TransposeCurrentMazeVertical()
        {
            UserInterface.RemoveDisplayLine();

            if (maze.MazeLayout != null)
            {
                maze.TransposeMazeVertical();
                newMazeBool = true;

                // Displays new maze.
                maze.ResetMazeDisplay();
                UserInterface.DisplayMaze(maze.MazeToString(Settings.StartingY, Settings.StartingX));
            }
            else
            {
                UserInterface.DisplayError("Must create maze first.");
            }
        }

        #endregion


    }
}
