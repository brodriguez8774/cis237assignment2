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
                mazeDisplayString +
                Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);
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
        /// Outputs Main Menu to console.
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine +
                "   Choose an Option:" + "          Note:"+ Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~" + "          You may type 'esc' at any point to back out." + Environment.NewLine +
                "    1) Create a Maze" + Environment.NewLine +
                "    2) Solve a Maze" + Environment.NewLine +
                "    3) Settings" + Environment.NewLine +
                "    4) Exit" + Environment.NewLine);
        }

        /// <summary>
        /// Outputs Settings Menu to console.
        /// </summary>
        public void DisplaySettingsMenu(int mazeTileWidth, int mazeTileSpacing)
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine +
                "   Choose an Option:" + "          Note:" + Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~" + "          You may type 'esc' at any point to back out." + Environment.NewLine +
                "                    " + "              Current Value: " + Environment.NewLine +
                "   1) Width of each tile" + "          " + mazeTileWidth.ToString() + Environment.NewLine +
                "   2) Space between each tile" + "     " + mazeTileSpacing.ToString() + Environment.NewLine +
                "   3) Exit" + Environment.NewLine);
        }

        /// <summary>
        /// Menu for creating new maze.
        /// </summary>
        public void DisplayCreateMazeMenu()
        {
            Console.WriteLine(
                "   1) Standard Maze" + Environment.NewLine +
                "   2) Transposed Maze" + Environment.NewLine);
        }

        #endregion
    }
}
