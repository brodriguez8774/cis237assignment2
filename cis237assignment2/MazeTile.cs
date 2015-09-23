using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class MazeTile
    {
        #region Variables

        private string tileIDString;
        private char tileDisplayChar;
        private bool tileMovementBool;
        private int tileTestedInt;

        #endregion



        #region Constructor

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public MazeTile()
        {

        }


        public MazeTile(char tileDisplay)
        {
            Display = tileDisplay;

            SetTileProperties();
        }

        #endregion



        #region Properties

        public char Display
        {
            set
            {
                tileDisplayChar = value;
            }
            get
            {
                return tileDisplayChar;
            }
        }

        public string ID
        {
            get
            {
                return tileIDString;
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

        #endregion



        #region Methods

        /// <summary>
        /// Determines properties of tile based on DisplayChar.
        /// </summary>
        private void SetTileProperties()
        {
            ReadTileType();
        }


        private void ReadTileType()
        {
            switch (tileDisplayChar)
            {
                case '#':
                    tileIDString = "Wall";
                    tileMovementBool = false;
                    break;

                case '.':
                    tileIDString = "Floor";
                    tileMovementBool = true;
                    tileTestedInt = 0;
                    break;

                case 'X':
                    tileIDString = "Floor";
                    tileMovementBool = true;
                    tileTestedInt = 1;
                    break;

                case 'O':
                    tileIDString = "Floor";
                    tileMovementBool = false;
                    tileTestedInt = 2;
                    break;

                case '!':
                    tileIDString = "Exit";
                    tileMovementBool = true;
                    tileTestedInt = 0;
                    break;
            }
        }

        #endregion
    }
}
