using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
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
            Console.WriteLine(Environment.NewLine + mazeDisplayString + Environment.NewLine);
        }

        /// <summary>
        /// Gets user input from console.
        /// </summary>
        /// <returns>String of user's input.</returns>
        public string GetUserInput()
        {
            userInputString = Console.ReadLine().Trim();
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

        #endregion
    }
}
