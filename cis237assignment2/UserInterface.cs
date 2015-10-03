// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// Handles all console output and user input. Using this class helps keep visual consistency.
    /// </summary>
    static class UserInterface
    {
        #region Variables

        private static string userInputString;

        #endregion



        #region Properties

        public static string UserSelection
        {
            get { return userInputString; }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method specific for output of maze strings.
        /// </summary>
        /// <param name="mazeDisplayString">String representing maze to display.</param>
        public static void DisplayMaze(string mazeDisplayString)
        {
            Console.SetCursorPosition(0, 12);

            if (Settings.DisplayColors)
            {
                foreach (char character in mazeDisplayString)
                {
                    if (character == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(character);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write(character);
                    }
                }
            }
            else
            {
                Console.WriteLine(mazeDisplayString);
            }
        }


        /// <summary>
        /// NOTE: Call from maze class instead!
        /// Resets display of maze.
        /// </summary>
        /// <param name="mazeSizeInt">Current mazeSizeInt from Maze class.</param>
        public static void ResetMazeDisplay(int mazeSizeInt)
        {
            Console.SetCursorPosition(0, 12);

            int index = 0;
            while (index < (mazeSizeInt * 2))
            {
                Console.Write("".PadRight(Console.WindowWidth - 1));
                index++;
            }

        }

        /// <summary>
        /// Gets user input from console.
        /// </summary>
        /// <returns>String of user's input.</returns>
        public static string GetUserInput()
        {
            Console.SetCursorPosition(1, 11);

            // Reads in user's input.
            userInputString = Console.ReadLine().Trim().ToLower();

            // Clears user's input out of UI.
            Console.SetCursorPosition(1, 11);
            Console.Write("".PadRight(Console.WindowWidth - 1));
            return userInputString;
        }

        /// <summary>
        /// Single line output to console.
        /// </summary>
        /// <param name="outputString">Output to display.</param>
        public static void Display(string outputString)
        {
            Console.SetCursorPosition(1, 10);

            Console.WriteLine(outputString.PadRight(Console.WindowWidth - 1));
        }

        /// <summary>
        /// Output for displaying errors to console.
        /// </summary>
        /// <param name="outputString">Error to output.</param>
        public static void DisplayError(string outputString)
        {
            Console.SetCursorPosition(1, 10);

            // Checks if colors are enabled.
            if (Settings.DisplayColors)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(outputString.PadRight(Console.WindowWidth - 1));
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.WriteLine(outputString.PadRight(Console.WindowWidth - 1));
            }
        }

        /// <summary>
        /// Outputs Main Menu to console.
        /// </summary>
        public static void DisplayMainMenu()
        {
            Console.SetCursorPosition(0, 1);

            Console.WriteLine(
                "   Choose an Option:          Note:".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~          You may type 'esc' at any point to back out.".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   1) Create Maze".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   2) Display Maze".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   3) Solve Maze".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   4) Settings".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   5) Exit".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine);
        }

        /// <summary>
        /// Outputs Settings Menu to console.
        /// </summary>
        public static void DisplaySettingsMenu()
        {
            Console.SetCursorPosition(0, 1);

            Console.WriteLine(
                "   Choose an Option:          Note:".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~          You may type 'esc' at any point to back out.".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "                                  ".PadRight((Console.WindowWidth - 1) / 2) + "Current Value: ".PadRight((Console.WindowWidth - 1) / 2) + Environment.NewLine +
                "   1) Width of each tile          ".PadRight((Console.WindowWidth - 1) / 2) + Settings.TileWidth.ToString().PadRight((Console.WindowWidth - 1) / 2) + Environment.NewLine +
                "   2) Space between each tile     ".PadRight((Console.WindowWidth - 1) / 2) + Settings.TileSpacing.ToString().PadRight((Console.WindowWidth - 1) / 2) + Environment.NewLine +
                "   3) Change Starting Postion     ".PadRight((Console.WindowWidth - 1) / 2) + Settings.StartingString.PadRight((Console.WindowWidth - 1) / 2) + Environment.NewLine +
                "   4) Adjust Display Timer        ".PadRight((Console.WindowWidth - 1) / 2) + Settings.DisplayTimer.ToString().PadRight((Console.WindowWidth - 1) / 2) + Environment.NewLine +
                "   5) Display Colors:             ".PadRight((Console.WindowWidth - 1) / 2) + Settings.DisplayColors.ToString().PadRight((Console.WindowWidth - 1) / 2) + Environment.NewLine +
                "   6) Exit".PadRight(Console.WindowWidth - 1) + Environment.NewLine);
        }

        /// <summary>
        /// Menu for changing starting position.
        /// </summary>
        public static void DisplayStartingPostionMenu()
        {
            Console.SetCursorPosition(0, 1);

            Console.WriteLine(
                "   Choose an Option:          Note:".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~          You may type 'esc' at any point to back out.".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   1) Start at Top Left".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   2) Start at Top Right".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   3) Start at Bottom Left".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   4) Start at Bottom Right".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine);
        }

        /// <summary>
        /// Menu for creating new maze.
        /// </summary>
        public static void DisplayCreateMazeMenu()
        {
            Console.SetCursorPosition(0, 1);

            Console.WriteLine(
                "   Choose an Option:          Note:".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~          You may type 'esc' at any point to back out.".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   1) Standard Maze".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   2) Randomly Generated Maze".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   3) Transpose Maze Diagonally".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   4) Transpose Maze Horizontally".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "   5) Transpose Maze Vertically".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine +
                "".PadRight(Console.WindowWidth - 1) + Environment.NewLine);
        }

        /// <summary>
        /// Clears out UI single line display.
        /// </summary>
        public static void RemoveDisplayLine()
        {
            Console.SetCursorPosition(0, 10);
            Console.Write("".PadRight(Console.WindowWidth - 1));
        }

        #endregion
    }
}
