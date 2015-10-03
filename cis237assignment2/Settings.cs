// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// Holds values of settings which are used throughout program.
    /// Make sure to run InitializeSettings method before first use!
    /// </summary>
    static class Settings
    {
        #region Variables

        // Working variables
        private static bool runSettingsBool;
        private static string userInputString;
        private static int userInputInt;

        private static int mazeTileSpacingInt;              // Number of spaces between each tile. Cannot go negative.
        private static int mazeTileWidthInt;                // Size of each individual tile. Cannot go below 1.

        private static int userStartingXInt;                // Values for user's starting position.
        private static int userStartingYInt;
        private static bool randomMazeBool;                 // Prevents user from changing starting location if randomly generated.
        private static string userStartingString;

        private static int displayTimerInt;                 // Timer value for console delay.
        private static bool displayColorsBool;

        #endregion



        #region Properties

        public static int TileSpacing
        {
            get { return mazeTileSpacingInt; }
        }

        public static int TileWidth
        {
            get { return mazeTileWidthInt; }
        }

        public static int StartingX
        {
            get { return userStartingXInt; }
        }

        public static int StartingY
        {
            get { return userStartingYInt; }
        }

        public static string StartingString
        {
            get { return userStartingString; }
        }

        public static int DisplayTimer
        {
            get { return displayTimerInt; }
        }

        public static bool DisplayColors
        {
            get { return displayColorsBool; }
        }

        public static bool RandomMazeBool
        {
            get { return randomMazeBool; }
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Gets User Selection and takes appropriate action.
        /// </summary>
        private static void UserMenuSelection()
        {
            userInputString = UserInterface.GetUserInput();
            Console.WriteLine();

            switch (userInputString)
            {
                case "1":
                    ChangeTileWidth();
                    break;
                case "2":
                    ChangeTileSpacing();
                    break;
                case "3":
                    ChangeStartingPosition();
                    break;
                case "4":
                    ChangeDisplayTimer();
                    break;
                case "5":
                    ChangeDisplayColorBool();
                    break;
                case "6":
                    CloseMenu();
                    break;
                case "esc":
                    CloseMenu();
                    break;
                default:
                    UserInterface.DisplayError("Invalid selection.");
                    break;
            }
        }

        /// <summary>
        /// Changes the Tile Width setting. Impacts maze display.
        /// </summary>
        private static void ChangeTileWidth()
        {
            UserInterface.RemoveDisplayLine();

            UserInterface.Display("Width of each individual tile. Must be a number. Cannot go below 1.");
            userInputString = UserInterface.GetUserInput();
            
            try
            {
                // Allows user to back out.
                if (userInputString != "esc")
                {
                    userInputInt = Convert.ToInt32(userInputString);
                    // If input is greater than 0.
                    if (userInputInt > 0)
                    {
                        UserInterface.RemoveDisplayLine();
                        mazeTileWidthInt = userInputInt;
                    }
                    else
                    {
                        UserInterface.DisplayError("Invalid input. Must be a number greater than 0.");
                    }
                }
            }
            catch
            {
                UserInterface.DisplayError("Invalid input. Must be a number greater than 0.");
            }
        }

        /// <summary>
        /// Changes the Tile Spacing setting. Impacts maze display.
        /// </summary>
        private static void ChangeTileSpacing()
        {
            UserInterface.RemoveDisplayLine();
            UserInterface.Display("Spacing between each tile. Must be a number. Cannot go negative.");
            userInputString = UserInterface.GetUserInput();

            try
            {
                UserInterface.RemoveDisplayLine();

                // Allows user to back out.
                if (userInputString != "esc")
                {
                    userInputInt = Convert.ToInt32(userInputString);
                    // If input is non-negative.
                    if (userInputInt >= 0)
                    {
                        mazeTileSpacingInt = userInputInt;
                    }
                    else
                    {
                        UserInterface.DisplayError("Invalid input. Must be a non-negative number.");
                    }
                }
            }
            catch
            {
                UserInterface.DisplayError("Invalid input. Must be a non-negative number.");
            }
        }

        /// <summary>
        /// Changes player's starting position.
        /// </summary>
        private static void ChangeStartingPosition()
        {
            UserInterface.RemoveDisplayLine();
            // If premade maze.
            if (randomMazeBool == false)
            {
                UserInterface.DisplayStartingPostionMenu();
                userInputString = UserInterface.GetUserInput();

                switch (userInputString)
                {
                    case "1":
                        userStartingXInt = 1;
                        userStartingYInt = 1;
                        userStartingString = "Top Left";
                        break;
                    case "2":
                        userStartingXInt = 10;
                        userStartingYInt = 1;
                        userStartingString = "Top Right";
                        break;
                    case "3":
                        userStartingXInt = 1;
                        userStartingYInt = 10;
                        userStartingString = "Bottom Left";
                        break;
                    case "4":
                        userStartingXInt = 10;
                        userStartingYInt = 10;
                        userStartingString = "Bottom Right";
                        break;
                    case "esc":
                        break;
                    default:
                        UserInterface.Display("Invalid selection.");
                        break;
                }
            }
            else
            {
                UserInterface.DisplayError("Sorry. You can only change the starting location of premade mazes.");
            }
        }

        /// <summary>
        /// Changes the delay for console output when solving a maze.
        /// </summary>
        private static void ChangeDisplayTimer()
        {
            UserInterface.RemoveDisplayLine();

            UserInterface.Display("Enter a non-negative number. Note: Input of 1000 equals 1 second.");
            userInputString = UserInterface.GetUserInput();

            try
            {
                UserInterface.RemoveDisplayLine();

                // Allows user to back out.
                if (userInputString != "esc")
                {
                    userInputInt = Convert.ToInt32(userInputString);
                    // If input is greater than 0.
                    if (userInputInt >= 0)
                    {
                        displayTimerInt = userInputInt;
                    }
                    else
                    {
                        UserInterface.DisplayError("Invalid input. Must be a non-negative number.");
                    }
                }
            }
            catch
            {
                UserInterface.DisplayError("Invalid input. Must be a non-negative number.");
            }
        }

        /// <summary>
        /// Changes bool for displaying colors.
        /// </summary>
        private static void ChangeDisplayColorBool()
        {
            UserInterface.RemoveDisplayLine();

            if (displayColorsBool == true)
            {
                displayColorsBool = false;
            }
            else
            {
                displayColorsBool = true;
            }
        }

        /// <summary>
        /// Exits settings menu.
        /// </summary>
        private static void CloseMenu()
        {
            UserInterface.RemoveDisplayLine();

            runSettingsBool = false;
        }


        #endregion



        #region PublicMethods

        /// <summary>
        /// Replaces constructor now that method is static. Must be ran to get prefered default values.
        /// </summary>
        public static void InitializeSettings()
        {
            mazeTileSpacingInt = 0;
            mazeTileWidthInt = 2;
            userStartingXInt = 1;
            userStartingYInt = 1;
            userStartingString = "Top Left";
            displayTimerInt = 75;
            randomMazeBool = false;
            displayColorsBool = true;
        }

        /// <summary>
        /// Loops to display and run Setting Menu until user chooses to exit.
        /// </summary>
        public static void RunSettingsMenu()
        {
            runSettingsBool = true;

            while (runSettingsBool)
            {
                UserInterface.DisplaySettingsMenu();
                UserMenuSelection();
            }
        }

        /// <summary>
        /// Called from maze if creating a randomly generated maze.
        /// </summary>
        /// <param name="startingY">The maze's starting T location.</param>
        /// <param name="startingX">The maze's starting X location.</param>
        public static void RandomMazeStartingLocation(int startingY, int startingX)
        {
            userStartingXInt = startingX;
            userStartingYInt = startingY;
            randomMazeBool = true;
        }

        /// <summary>
        /// Called from maze if creating a premade maze.
        /// </summary>
        public static void PremadeMazeStartingLocation()
        {
            userStartingXInt = 1;
            userStartingYInt = 1;
            randomMazeBool = false;
        }

        #endregion

    }
}
