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

        int mazeTileSpacingInt;            // Number of spaces between each tile. Cannot go negative.
        int mazeTileWidthInt;              // Size of each individual tile. Cannot go below 1.


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
                    CloseMenu();
                    break;
                case "esc":
                    CloseMenu();
                    break;
                default:
                    userInterface.Display("Invalid selection.");
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
                        userInterface.Display("Invalid input. Must be a number greater than 0.");
                    }
                }
            }
            catch
            {
                userInterface.Display("Invalid input. Must be a number greater than 0.");
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
                        userInterface.Display("Invalid input. Must be a non-negative number.");
                    }
                }
            }
            catch
            {
                userInterface.Display("Invalid input. Must be a non-negative number.");
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
                userInterface.DisplaySettingsMenu(mazeTileWidthInt, mazeTileSpacingInt);
                UserMenuSelection();
            }
        }

        #endregion

    }
}
