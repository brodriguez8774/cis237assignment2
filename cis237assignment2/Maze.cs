using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Maze
    {
        #region Variables

        // Working Variables
        private int mazeSizeInt;
        private int startXInt = 1;
        private int startYInt = 1;

        MazeTile[,] mazeLayout;

        #endregion



        #region Constructor

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public Maze()
        {

        }

        #endregion



        #region Properties

        public MazeTile[,] MazeLayout
        {
            get
            {
                return mazeLayout;
            }
        }

        public int StartingX
        {
            get
            {
                return startXInt;
            }
        }

        public int StartingY
        {
            get
            {
                return startYInt;
            }
        }

        #endregion



        #region Methods

        #endregion
    }
}
