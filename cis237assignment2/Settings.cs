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
    /// </summary>
    class Settings
    {
        #region Variables

        // Classes
        UserInterface userInterface;

        // Working variables
        bool runSettingsBool;
        string userInputString;
        int userInputInt;

        int mazeTileSpacingInt;             // Number of spaces between each tile. Cannot go negative.
        int mazeTileWidthInt;               // Size of each individual tile. Cannot go below 1.

        int userStartingXInt;               // Values for user's starting position.
        int userStartingYInt;
        string userStartingString;

        int displayTimerInt;                // Timer value for console delay.


        #endregion



        #region Constructor

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Settings()
        {
            
        }

        /// <summary>
        /// Constructor which sets initial values of settings.
        /// </summary>
        /// <param name="userInterface">UserInterface Class.</param>
        public Settings(UserInterface userInterface)
        {
            Interface = userInterface;

            mazeTileSpacingInt = 1;
            mazeTileWidthInt = 2;
            userStartingXInt = 1;
            userStartingYInt = 1;
            userStartingString = "Top Left";
            displayTimerInt = 500;
        }

        #endregion



        #region Properties

        public UserInterface Interface
        {
            set
            {
                userInterface = value;
            }
        }

        public int TileSpacing
        {
            get
            {
                return mazeTileSpacingInt;
            }
        }

        public int TileWidth
        {
            get
            {
                return mazeTileWidthInt;
            }
        }

        public int StartingX
        {
            get
            {
                return userStartingXInt;
            }
        }

        public int StartingY
        {
            get
            {
                return userStartingYInt;
            }
        }

        public string StartingString
        {
            get
            {
                return userStartingString;
            }
        }

        public int DisplayTimer
        {
            get
            {
                return displayTimerInt;
            }
        }

        #endregion



        #region Private Methods

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
                    CloseMenu();
                    break;
                case "esc":
                    CloseMenu();
                    break;
                default:
                    userInterface.DisplayError("Invalid selection.");
                    break;
            }
        }

        /// <summary>
        /// Changes the Tile Width setting. Impacts maze display.
        /// </summary>
        private void ChangeTileWidth()
        {
            userInterface.Display("Width of each individual tile. Must be a number. Cannot go below 1.");
            userInputString = userInterface.GetUserInput();
            
            try
            {
                // Allows user to back out.
                if (userInputString != "esc")
                {
                    userInputInt = Convert.ToInt32(userInputString);
                    // If input is greater than 0.
                    if (userInputInt > 0)
                    {
                        mazeTileWidthInt = userInputInt;
                    }
                    else
                    {
                        userInterface.DisplayError("Invalid input. Must be a number greater than 0.");
                    }
                }
            }
            catch
            {
                userInterface.DisplayError("Invalid input. Must be a number greater than 0.");
            }
        }

        /// <summary>
        /// Changes the Tile Spacing setting. Impacts maze display.
        /// </summary>
        private void ChangeTileSpacing()
        {
            userInterface.Display("Spacing between each tile. Must be a number. Cannot go negative.");
            userInputString = userInterface.GetUserInput();

            try
            {
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
                        userInterface.DisplayError("Invalid input. Must be a non-negative number.");
                    }
                }
            }
            catch
            {
                userInterface.DisplayError("Invalid input. Must be a non-negative number.");
            }
        }

        /// <summary>
        /// Changes player's starting position.
        /// </summary>
        private void ChangeStartingPosition()
        {
            userInterface.DisplayStartingPostionMenu();
            userInputString = userInterface.GetUserInput();

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
                    userInterface.Display("Invalid selection.");
                    break;
            }
        }

        /// <summary>
        /// Changes the delay for console output when solving a maze.
        /// </summary>
        private void ChangeDisplayTimer()
        {
            userInterface.Display("Enter a non-negative number. Note: Input of 1000 equals 1 second.");
            userInputString = userInterface.GetUserInput();

            try
            {
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
                        userInterface.DisplayError("Invalid input. Must be a non-negative number.");
                    }
                }
            }
            catch
            {
                userInterface.DisplayError("Invalid input. Must be a non-negative number.");
            }
        }

        /// <summary>
        /// Exits settings menu.
        /// </summary>
        private void CloseMenu()
        {
            runSettingsBool = false;
        }


        #endregion



        #region PublicMethods

        /// <summary>
        /// Loops to display and run Setting Menu until user chooses to exit.
        /// </summary>
        public void RunSettingsMenu()
        {
            runSettingsBool = true;

            while (runSettingsBool)
            {
                userInterface.DisplaySettingsMenu(mazeTileWidthInt, mazeTileSpacingInt, userStartingString, displayTimerInt);
                UserMenuSelection();
            }
        }

        #endregion

    }
}
