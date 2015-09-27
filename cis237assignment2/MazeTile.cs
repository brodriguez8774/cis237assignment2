// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// Constructs each individual maze tile's properties.
    /// </summary>
    class MazeTile
    {
        #region Variables

        private char tileIDChar;
        private string tileIDString;
        private char tileDisplayChar;
        private bool tileMovementBool;
        private int tileTestedInt;          // "Is tile tested" value. 0 for no. 1 for tested but retracable (can still be walked over). 2 for tested dead end.

        // Constants
        private static string ID_WALL = "Wall";
        private static string ID_FLOOR_UNTESTED = "Untested Floor";
        private static string ID_FLOOR_TESTED = "Tested Floor";
        private static string ID_DEAD_END = "Dead End";
        private static string ID_EXIT = "Exit";

        #endregion



        #region Constructor

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public MazeTile()
        {

        }

        /// <summary>
        /// Constructor which sets tile properties based on ID.
        /// </summary>
        /// <param name="tileID">The ID of tile to create.</param>
        public MazeTile(char tileIDChar)
        {
            IDChar = tileIDChar;

            SetTileProperties();
        }

        #endregion



        #region Properties

        public char IDChar
        {
            set
            {
                tileIDChar = value;
            }
            get
            {
                return tileIDChar;
            }
        }

        public string IDString
        {
            get
            {
                return tileIDString;
            }
        }

        public char Display
        {
            get
            {
                return tileDisplayChar;
            }
        }

        public bool Movement
        {
            get
            {
                return tileMovementBool;
            }
        }

        public int Tested
        {
            get
            {
                return tileTestedInt;
            }
        }

        public static string ID_Wall
        {
            get
            {
                return ID_WALL;
            }
        }

        public static string ID_FloorUntested
        {
            get
            {
                return ID_FLOOR_UNTESTED;
            }
        }

        public static string ID_FloorTested
        {
            get
            {
                return ID_FLOOR_TESTED;
            }
        }

        public static string ID_DeadEnd
        {
            get
            {
                return ID_DEAD_END;
            }
        }

        public static string ID_Exit
        {
            get
            {
                return ID_EXIT;
            }
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Determines properties of tile based on Tile's ID.
        /// </summary>
        private void SetTileProperties()
        {
            switch (tileIDChar)
            {
                case '#':
                    tileDisplayChar = '#';
                    tileIDString = ID_WALL;
                    tileMovementBool = false;
                    break;

                case '.':
                    tileDisplayChar = '.';
                    tileIDString = ID_FLOOR_UNTESTED;
                    tileMovementBool = true;
                    tileTestedInt = 0;
                    break;

                case 'X':
                    tileDisplayChar = 'X';
                    tileIDString = ID_FLOOR_TESTED;
                    tileMovementBool = true;
                    tileTestedInt = 1;
                    break;

                case 'O':
                    tileDisplayChar = 'O';
                    tileIDString = ID_DEAD_END;
                    tileMovementBool = false;
                    tileTestedInt = 2;
                    break;

                case '!':
                    tileDisplayChar = '.';
                    tileIDString = ID_EXIT;
                    tileMovementBool = true;
                    tileTestedInt = 0;
                    break;
            }
        }

        #endregion

    }
}
