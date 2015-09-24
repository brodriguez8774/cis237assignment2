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

        private char tileIDChar;
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


        public MazeTile(char tileID)
        {
            ID = tileID;

            SetTileProperties();
        }

        #endregion



        #region Properties

        public char ID
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

        #endregion



        #region Private Methods

        /// <summary>
        /// Determines properties of tile based on Tile's ID.
        /// </summary>
        private void SetTileProperties()
        {
            ReadTileType();
        }


        private void ReadTileType()
        {
            switch (tileIDChar)
            {
                case '#':
                    tileDisplayChar = '#';
                    tileMovementBool = false;
                    break;

                case '.':
                    tileDisplayChar = '.';
                    tileMovementBool = true;
                    tileTestedInt = 0;
                    break;

                case 'X':
                    tileDisplayChar = 'X';
                    tileMovementBool = true;
                    tileTestedInt = 1;
                    break;

                case 'O':
                    tileDisplayChar = 'O';
                    tileMovementBool = false;
                    tileTestedInt = 2;
                    break;

                case '!':
                    tileDisplayChar = '.';
                    tileMovementBool = true;
                    tileTestedInt = 0;
                    break;
            }
        }

        #endregion



        #region Public Methods

        

        #endregion

    }
}
