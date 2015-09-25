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

        public void DisplayMaze(string mazeDisplayString)
        {
            Console.WriteLine(Environment.NewLine + mazeDisplayString + Environment.NewLine);
        }

        #endregion
    }
}
