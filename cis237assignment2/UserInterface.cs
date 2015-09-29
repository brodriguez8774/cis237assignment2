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
    class UserInterface
    {
        #region Variables

        private string userInputString;

        #endregion



        #region Constructor

        #endregion



        #region Properties

        public string UserSelection
        {
            get
            {
                return userInputString;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method specific for output of maze strings.
        /// </summary>
        /// <param name="mazeDisplayString">String representing maze to display.</param>
        public void DisplayMaze(string mazeDisplayString)
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine +
                Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                mazeDisplayString);
        }

        /// <summary>
        /// Gets user input from console.
        /// </summary>
        /// <returns>String of user's input.</returns>
        public string GetUserInput()
        {
            userInputString = Console.ReadLine().Trim().ToLower();
            return userInputString;
        }

        /// <summary>
        /// Display standard output to console.
        /// </summary>
        /// <param name="outputString">Output to display.</param>
        public void Display(string outputString)
        {
            Console.WriteLine(outputString);
        }

        /// <summary>
        /// Output for displaying errors to console.
        /// </summary>
        /// <param name="outputString">Error to output.</param>
        public void DisplayError(string outputString)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(outputString);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Outputs Main Menu to console.
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine +
                "   Choose an Option:" + "          Note:"+ Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~" + "          You may type 'esc' at any point to back out." + Environment.NewLine +
                "    1) Create Maze" + Environment.NewLine +
                "    2) Display Maze" + Environment.NewLine +
                "    3) Solve Maze" + Environment.NewLine +
                "    4) Settings" + Environment.NewLine +
                "    5) Exit" + Environment.NewLine);
        }

        /// <summary>
        /// Outputs Settings Menu to console.
        /// </summary>
        public void DisplaySettingsMenu(int mazeTileWidth, int mazeTileSpacing, string startingPositionString, int displayTimer)
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine +
                "   Choose an Option:" + "          Note:" + Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~" + "          You may type 'esc' at any point to back out." + Environment.NewLine +
                "                    " + "              Current Value: " + Environment.NewLine +
                "   1) Width of each tile" + "          " + mazeTileWidth.ToString() + Environment.NewLine +
                "   2) Space between each tile" + "     " + mazeTileSpacing.ToString() + Environment.NewLine +
                "   3) Change Starting Postion" + "     " + startingPositionString + Environment.NewLine +
                "   4) Adjust Display Timer" + "        " + displayTimer.ToString() + Environment.NewLine +
                "   5) Exit" + Environment.NewLine);
        }

        /// <summary>
        /// Menu for changing starting position.
        /// </summary>
        public void DisplayStartingPostionMenu()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine +
                "   1) Start at Top Left" + Environment.NewLine +
                "   2) Start at Top Right" + Environment.NewLine +
                "   3) Start at Bottom Left" + Environment.NewLine +
                "   4) Start at Bottom Right" + Environment.NewLine);
        }

        /// <summary>
        /// Menu for creating new maze.
        /// </summary>
        public void DisplayCreateMazeMenu()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine +
                "   1) Standard Maze" + Environment.NewLine +
                "   2) Transpose Maze Diagonally" + Environment.NewLine +
                "   3) Transpose Maze Horizontally" + Environment.NewLine +
                "   4) Transpose Maze Vertically" + Environment.NewLine);
        }

        #endregion
    }
}
