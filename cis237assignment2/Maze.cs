// Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// Handles all properties and creation of full mazes.
    /// </summary>
    class Maze
    {
        #region Variables

        // Working Variables
        private int mazeSizeInt;
        private int indexInt;
        private int indexXInt;
        private int indexYInt;
        string displayString;

        MazeTile[,] mazeLayout;     // The maze used in majority of program.
        MazeTile[,] mazeHolder;     // Holds value of maze so that it can be transposed/solved multiple times, if desired.

        char[,] preDefinedMaze = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '!' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

        // Variables for random maze generation.
        Random random = new Random();
        int randomInt;
        int savedRandomInt;
        int mazeExitXInt;
        int mazeExitYInt;

        bool firstTileBool;
        int farthestDistanceInt;
        int startingXInt;           // Only used in random gen, not premade.
        int startingYInt;           // Only used in random gen, not premade.
        bool successfulGenerationBool;  // Used to stop the program from sploding horrifically.

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
            get { return mazeLayout; }
        }

        public int MazeSize
        {
            get { return mazeSizeInt;}
        }

        public bool GenerationSuccessful
        {
            get { return successfulGenerationBool; }
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Gets the TileDisplay property of current index.
        /// Repeats the tile char equal to the settings.TileWidth property.
        /// </summary>
        /// <param name="currentY">Current Y index.</param>
        /// <param name="currentX">Current X Index.</param>
        /// <returns>The DisplayChar of the index.</returns>
        private string DisplayMazeTile(int currentY, int currentX)
        {
            displayString = "";
            indexInt = 0;

            // While index is less than Tile Width property.
            while (indexInt < Settings.TileWidth)
            {
                if (mazeLayout[currentY, currentX] != null)
                {
                    displayString += mazeLayout[currentY, currentX].Display;
                    indexInt++;
                }
                else
                {
                    displayString += " ";
                    indexInt++;
                }
            }
            return displayString;
        }

        /// <summary>
        /// Repeats player display char equal to the settings.TileWidth property.
        /// </summary>
        /// <returns>The DisplayChar of the player.</returns>
        private string DisplayCharacterTile()
        {
            string tempString = "";
            indexInt = 0;

            while (indexInt < Settings.TileWidth)
            {
                tempString += Character.CharacterDisplay;
                indexInt++;
            }

            return tempString;
        }

        /// <summary>
        /// Creates placeholder maze so that maze can be tansposed/solved multiple times, if desired.
        /// </summary>
        private void CreatePlaceHolderMaze()
        {
            // Saves placeholder maze.
            indexXInt = 0;
            indexYInt = 0;
            mazeHolder = new MazeTile[mazeSizeInt, mazeSizeInt];
            while (indexYInt < mazeSizeInt)
            {
                // If not yet at end of horizontal, add 1 to X. Otherwise reset x and add 1 to Y.
                if (indexXInt < mazeSizeInt)
                {
                    // Creates a full MazeTile spot based on the given ID of predefined maze spot.
                    mazeHolder[indexYInt, indexXInt] = mazeLayout[indexYInt, indexXInt];
                    indexXInt++;
                }
                else
                {
                    indexXInt = 0;
                    indexYInt++;
                }
            }
        }

        #endregion



        #region Public Methods

        #region Maze Transposition

        /// <summary>
        /// Transposes maze accros the diagonal.
        /// </summary>
        public void TransposeMazeDiagonal()
        {
            indexXInt = 0;
            indexYInt = 0;
            mazeLayout = new MazeTile[mazeSizeInt, mazeSizeInt];

            while (indexYInt < mazeSizeInt)
            {
                // If not yet at end of horizontal, add 1 to X. Otherwise reset x and add 1 to Y.
                if (indexXInt < mazeSizeInt)
                {
                    // Swaps x and y coordinates.
                    mazeLayout[indexYInt, indexXInt] = mazeHolder[indexXInt, indexYInt];
                    indexXInt++;
                }
                else
                {
                    indexXInt = 0;
                    indexYInt++;
                }
            }
            CreatePlaceHolderMaze();

            if (Settings.RandomMazeBool)
            {
                int tempInt = startingXInt;
                startingXInt = startingYInt;
                startingYInt = tempInt;

                Settings.RandomMazeStartingLocation(startingYInt, startingXInt);
            }
        }

        /// <summary>
        /// Transposes maze accross the horizontal (x) axis.
        /// </summary>
        public void TransposeMazeHorizontal()
        {
            indexXInt = 0;
            indexYInt = 0;
            mazeLayout = new MazeTile[mazeSizeInt, mazeSizeInt];

            while (indexYInt < mazeSizeInt)
            {
                // If not yet at end of horizontal, add 1 to X. Otherwise reset x and add 1 to Y.
                if (indexXInt < mazeSizeInt)
                {
                    indexInt = (mazeSizeInt - 1) - indexYInt;
                    // Swaps x and y coordinates.
                    mazeLayout[indexInt, indexXInt] = mazeHolder[indexYInt, indexXInt];
                    indexXInt++;
                }
                else
                {
                    indexXInt = 0;
                    indexYInt++;
                }
            }
            CreatePlaceHolderMaze();

            if (Settings.RandomMazeBool)
            {
                startingYInt = (mazeSizeInt - 1) - startingYInt;

                Settings.RandomMazeStartingLocation(startingYInt, startingXInt);
            }
        }

        /// <summary>
        /// Transposes maze accross the vertical (y) axis.
        /// </summary>
        public void TransposeMazeVertical()
        {
            indexXInt = 0;
            indexYInt = 0;
            mazeLayout = new MazeTile[mazeSizeInt, mazeSizeInt];

            while (indexYInt < mazeSizeInt)
            {
                // If not yet at end of horizontal, add 1 to X. Otherwise reset x and add 1 to Y.
                if (indexXInt < mazeSizeInt)
                {
                    // Swaps y coordinates.
                    indexInt = (mazeSizeInt - 1) - indexXInt;
                    mazeLayout[indexYInt, indexInt] = mazeHolder[indexYInt, indexXInt];
                    indexXInt++;
                }
                else
                {
                    indexXInt = 0;
                    indexYInt++;
                }
            }
            CreatePlaceHolderMaze();

            if (Settings.RandomMazeBool)
            {
                startingXInt = (mazeSizeInt - 1) - startingXInt;

                Settings.RandomMazeStartingLocation(startingYInt, startingXInt);
            }
        }

        #endregion

        /// <summary>
        /// Reads in predefined maze and populates tiles accordingly.
        /// </summary>
        public void ReadMaze()
        {
            indexXInt = 0;
            indexYInt = 0;
            mazeSizeInt = preDefinedMaze.GetLength(0);
            mazeLayout = new MazeTile[mazeSizeInt, mazeSizeInt];

            while (indexYInt < mazeSizeInt)
            {
                // If not yet at end of horizontal, add 1 to X. Otherwise reset x and add 1 to Y.
                if (indexXInt < mazeSizeInt)
                {
                    // Creates a full MazeTile spot based on the given ID of predefined maze spot.
                    mazeLayout[indexYInt, indexXInt] = new MazeTile(preDefinedMaze[indexYInt, indexXInt]);
                    indexXInt++;
                }
                else
                {
                    indexXInt = 0;
                    indexYInt++;
                }
            }
            Settings.PremadeMazeStartingLocation();

            CreatePlaceHolderMaze();
        }

        /// <summary>
        /// Creates string to display current maze, including player location and status.
        /// Adds spaces to the right of each character based on the settings.TileSpacing property.
        /// </summary>
        /// <param name="currentMaze">The current Maze to navigate.</param>
        /// <param name="currentPlayerY">Player's current Y index.</param>
        /// <param name="currentPlayerX">Player's current X index.</param>
        /// <returns>String composed of maze visual.</returns>
        public string MazeToString(Maze currentMaze, int currentPlayerY, int currentPlayerX)
        {
            indexXInt = 0;
            indexYInt = 0;
            displayString = "";

            // While y axis not = max maze size.
            while (indexYInt < mazeSizeInt)
            {
                // While x axis not = max maze size.
                if (indexXInt < mazeSizeInt)
                {
                    // If spot = index character is on, display character instead.
                    if (currentPlayerX == indexXInt && currentPlayerY == indexYInt)
                    {
                        displayString += DisplayCharacterTile();

                        indexInt = 0;
                        // while index is less than the Tile Spacing property.
                        while (indexInt < Settings.TileSpacing)
                        {
                            displayString += " ";
                            indexInt++;
                        }

                        indexXInt++;
                    }
                    else
                    {
                        displayString += DisplayMazeTile(indexYInt, indexXInt);

                        indexInt = 0;
                        // while index is less than the Tile Spacing property.
                        while (indexInt < Settings.TileSpacing)
                        {
                            displayString += " ";
                            indexInt++;
                        }

                        indexXInt++;
                    }
                }
                else
                {
                    displayString += Environment.NewLine;
                    indexXInt = 0;
                    indexYInt++;
                }
            }

            return displayString;
        }

        /// <summary>
        /// Updates specific maze tile for player interaction.
        /// </summary>
        /// <param name="currentY">Player's current Y coordinate.</param>
        /// <param name="currentX">Player's current X coordinate.</param>
        public void UpdateMazeTile(int currentY, int currentX)
        {
            int directionCounter = 0;       // Holds how many nearby tiles are non-accessable.

            // Check tile to the right. If wall or dead end.
            if (mazeLayout[currentY, currentX + 1].IDString == MazeTile.ID_Wall ||
                mazeLayout[currentY, currentX + 1].IDString == MazeTile.ID_DeadEnd)
            {
                directionCounter++;
            }

            // Check tile below. If wall or dead end.
            if (mazeLayout[currentY + 1, currentX].IDString == MazeTile.ID_Wall ||
                mazeLayout[currentY + 1, currentX].IDString == MazeTile.ID_DeadEnd)
            {
                directionCounter++;
            }

            // Check tile to the left. If wall or dead end.
            if (mazeLayout[currentY, currentX - 1].IDString == MazeTile.ID_Wall ||
                mazeLayout[currentY, currentX - 1].IDString == MazeTile.ID_DeadEnd)
            {
                directionCounter++;
            }

            // Check tile to the above. If wall or dead end.
            if (mazeLayout[currentY - 1, currentX].IDString == MazeTile.ID_Wall ||
                mazeLayout[currentY - 1, currentX].IDString == MazeTile.ID_DeadEnd)
            {
                directionCounter++;
            }

            // If counter is 3 or higher, then space is a dead end.
            if (directionCounter >= 3)
            {
                mazeLayout[currentY, currentX] = new MazeTile('O');
            }
            else
            {
                mazeLayout[currentY, currentX] = new MazeTile('X');
            }
        }

        /// <summary>
        /// Recreates mazeLayout from placeholder maze.
        /// </summary>
        public void RefreshMaze()
        {
            indexXInt = 0;
            indexYInt = 0;
            while (indexYInt < mazeSizeInt)
            {
                // If not yet at end of horizontal, add 1 to X. Otherwise reset x and add 1 to Y.
                if (indexXInt < mazeSizeInt)
                {
                    // Creates a full MazeTile spot based on the given ID of predefined maze spot.
                    mazeLayout[indexYInt, indexXInt] = mazeHolder[indexYInt, indexXInt];
                    indexXInt++;
                }
                else
                {
                    indexXInt = 0;
                    indexYInt++;
                }
            }
        }

        /// <summary>
        /// Resets current display of maze.
        /// Note: Call this one. It will send mazeSizeInt to UserInterface.
        /// </summary>
        public void ResetMazeDisplay()
        {
            UserInterface.ResetMazeDisplay(mazeSizeInt);
        }

        #endregion



        #region Generate Random Maze Methods

        /* NOTE: The previousDirection int occurs frequently in following methods.
         * The values are as follows:
         * 
         * Result 0 means Left.
         * Result 1 means Top.
         * Result 2 means Right.
         * Result 3 means Bottom.
         */


        /// <summary>
        /// Initial method to call random maze generation.
        /// Handles all calling of maze generation methods.
        /// </summary>
        public void GenerateNewMaze()
        {
            successfulGenerationBool = false;
            UserInterface.Display("Enter size of maze:      (Must be a number between 1 and 20.)");
            string userInput = UserInterface.GetUserInput();
            try
            {
                if (Convert.ToInt32(userInput) > 0 && Convert.ToInt32(userInput) < 21)
                {
                    // Assumes value user enters is the number of tiles INSIDE the outer walls.
                    // IE: if the user enters size "3", then the array will be a 5 x 5, including outer walls.
                    mazeSizeInt = Convert.ToInt32(userInput) + 2;
                    UserInterface.RemoveDisplayLine();
                    successfulGenerationBool = true;

                    // Actually generate maze.
                    DetermineMazeStart();
                    CreateOuterWalls();
                    firstTileBool = true;
                    farthestDistanceInt = 0;
                    CreateMazeInside(mazeExitYInt, mazeExitXInt, savedRandomInt, 0);

                    // Saving of last minute settings.
                    Settings.RandomMazeStartingLocation(startingYInt, startingXInt);
                    VoidOutExtraTiles();
                    CreatePlaceHolderMaze();
                    UserInterface.DisplayMaze(MazeToString(this, Settings.StartingY, Settings.StartingX));
                }
                else
                {
                    UserInterface.DisplayError("Maze must be between 1 and 20 tiles long.");
                }
            }
            catch
            {
                UserInterface.DisplayError("Invalid input. Must be a number greater than 0 and less than 20.");
            }
        }

        /// <summary>
        /// Determines initial location for maze generation. This tile becomes the maze exit.
        /// </summary>
        private void DetermineMazeStart()
        {
            // Creates temp array of size equal to mazeSizeInt.
            mazeLayout = new MazeTile[mazeSizeInt, mazeSizeInt];
            
            /* Pulls a random number between 0 and 3.
             * Result 0 sets exit to Left outer wall.
             * Result 1 sets exit to Top outer wall.
             * Result 2 sets exit to Right outer wall.
             * Result 3 sets exit to Bottom outer wall.
             */
            randomInt = random.Next(4);
            savedRandomInt = randomInt;     // Stores value so program knows which wall exit is on. Prevents
                                            // Accidentally checking for null tiles outside of array bounds.
            randomInt = random.Next(1, mazeSizeInt - 1);
            // Set to left wall.
            if (savedRandomInt == 0)
            {
                mazeLayout[randomInt, 0] = new MazeTile('!');
                mazeExitXInt = 0;
                mazeExitYInt = randomInt;
            }
            else
            {
                // Set to top wall.
                if (savedRandomInt == 1)
                {
                    mazeLayout[0, randomInt] = new MazeTile('!');
                    mazeExitXInt = randomInt;
                    mazeExitYInt = 0;
                }
                else
                {
                    // Set to right wall.
                    if (savedRandomInt == 2)
                    {
                        mazeLayout[randomInt, mazeSizeInt - 1] = new MazeTile('!');
                        mazeExitXInt = mazeSizeInt - 1;
                        mazeExitYInt = randomInt;
                    }
                    else
                    {
                        // Set to bottom wall.
                        mazeLayout[mazeSizeInt - 1, randomInt] = new MazeTile('!');
                        mazeExitXInt = randomInt;
                        mazeExitYInt = mazeSizeInt - 1;
                    }
                }
            }
        }

        /// <summary>
        /// Creates all the outer walls of maze, taking the exit into account.
        /// </summary>
        private void CreateOuterWalls()
        {
            // Creates left outer walls.
            indexXInt = 0;
            indexYInt = 0;

            // While not yet through entire y-axis.
            while (indexYInt < mazeSizeInt)
            {
                // If not on same spot as exit.
                if (indexYInt != mazeExitYInt || indexXInt != mazeExitXInt)
                {
                    mazeLayout[indexYInt, indexXInt] = new MazeTile('#');
                }
                indexYInt++;
            }

            // Creates Top outer walls.
            indexXInt = 0;
            indexYInt = 0;

            // While not yet through entire y-axis.
            while (indexXInt < mazeSizeInt)
            {
                // If not on same spot as exit.
                if (indexYInt != mazeExitYInt || indexXInt != mazeExitXInt)
                {
                    mazeLayout[indexYInt, indexXInt] = new MazeTile('#');
                }
                indexXInt++;
            }

            // Creates Right outer walls.
            indexXInt = mazeSizeInt - 1;
            indexYInt = 0;

            // While not yet through entire y-axis.
            while (indexYInt < mazeSizeInt)
            {
                // If not on same spot as exit.
                if (indexYInt != mazeExitYInt || indexXInt != mazeExitXInt)
                {
                    mazeLayout[indexYInt, indexXInt] = new MazeTile('#');
                }
                indexYInt++;
            }

            // Creates Bottom outer walls.
            indexXInt = 0;
            indexYInt = mazeSizeInt - 1;

            // While not yet through entire y-axis.
            while (indexXInt < mazeSizeInt)
            {
                // If not on same spot as exit.
                if (indexYInt != mazeExitYInt || indexXInt != mazeExitXInt)
                {
                    mazeLayout[indexYInt, indexXInt] = new MazeTile('#');
                }
                indexXInt++;
            }

        }

        /// <summary>
        /// Start of recursive loop to generate the inside of the maze.
        /// As long as a tile has neighbors that are not generated (null tiles), it continues.
        /// </summary>
        /// <param name="currentY">Current Y location.</param>
        /// <param name="currentX">Current X location.</param>
        /// <param name="previousDirection">Direction previous tile was.</param>
        /// <param name="currentDistance">Current distance from maze start. Pass + 1 for each time this method is called.</param>
        private void CreateMazeInside(int currentY, int currentX, int previousDirection, int currentDistance)
        {
            UserInterface.DisplayMaze(MazeToString(this, currentY, currentX));


            // If current tile distance from start is greater than saved farthest distance.
            if (currentDistance > farthestDistanceInt)
            {
                // Updates starting location to be path which is farthest from maze exit.
                farthestDistanceInt = currentDistance;
                startingXInt = currentX;
                startingYInt = currentY;
            }

            // Forces a specific first move from exit. Doing so prevents accidentally checking outside of array bounds during random gen.
            if (firstTileBool)
            {
                // If exit is on left wall.
                if (savedRandomInt == 0)
                {
                    firstTileBool = false;
                    currentX++;
                    CreateMazeInside(currentY, currentX, previousDirection, currentDistance + 1);
                }
                else
                {
                    // If exit is on top wall.
                    if (savedRandomInt == 1)
                    {
                        firstTileBool = false;
                        currentY++;
                        CreateMazeInside(currentY, currentX, previousDirection, currentDistance + 1);
                    }
                    else
                    {
                        // If exit is on right wall.
                        if (savedRandomInt == 2)
                        {
                            firstTileBool = false;
                            currentX--;
                            CreateMazeInside(currentY, currentX, previousDirection, currentDistance + 1);
                        }
                        else
                        {
                            // If exit is on bottom wall.
                            firstTileBool = false;
                            currentY--;
                            CreateMazeInside(currentY, currentX, previousDirection, currentDistance + 1);
                        }
                    }
                }
            }
            else
            {
                GenerateTile(currentY, currentX, previousDirection, currentDistance);
            }
        }

        /// <summary>
        /// Sets current tile to a valid path. Then checks which directions (from current tile) still need generation.
        /// Also has a 2% chance of creating a new wall tile.
        /// </summary>
        /// <param name="currentY"></param>
        /// <param name="currentX"></param>
        /// <param name="currentDistance">Current distance from maze start. Passing due to nature of recursion.</param>
        /// <param name="previousDirection"></param>
        private void GenerateTile(int currentY, int currentX, int previousDirection, int currentDistance)
        {
            // Specify current tile as a valid path.
            mazeLayout[currentY, currentX] = new MazeTile('.');

            // Check how many directions are null (uncreated tiles).
            // Initialize to first enter while loop.
            int generateMazeInt = 4;

            // Keeps recursive method from backtracking out of tile until all directions are explored.
            while (generateMazeInt > 0)
            {
                CheckNearbyTiles(currentY, currentX);

                // Checks on each cycle for exit of loop.
                generateMazeInt = 4;
                int maxXInt = 2;
                int minXInt = 0;
                int maxYInt = 2;
                int minYInt = 0;

                // Check left.
                if (mazeLayout[currentY, currentX - 1] != null)
                {
                    generateMazeInt--;
                    minXInt++;
                }
                // Check down.
                if (mazeLayout[currentY + 1, currentX] != null)
                {
                    generateMazeInt--;
                    maxYInt--;
                }
                // Check right.
                if (mazeLayout[currentY, currentX + 1] != null)
                {
                    generateMazeInt--;
                    maxXInt--;
                }
                // Check up.
                if (mazeLayout[currentY - 1, currentX] != null)
                {
                    generateMazeInt--;
                    minYInt++;
                }

                // If any of the spots are null (uncreated), then choose a new direction.
                if (generateMazeInt > 0)
                {
                    ChooseRandomDirection(currentY, currentX, maxYInt, maxXInt, minYInt, minXInt, currentDistance);
                }
            }
        }

        /// <summary>
        /// Grabs a random direction from current location.
        /// </summary>
        /// <param name="currentY">Current Y location.</param>
        /// <param name="currentX">Current X location.</param>
        /// <param name="maxY">Holds if down tile is valid choice. 2 if valid. 1 if invalid.</param>
        /// <param name="maxX">Holds if right tile is valid choice. 2 if valid. 1 if invalid.</param>
        /// <param name="minY">Holds if up tile is valid choice. 0 if valid. 1 if invalid.</param>
        /// <param name="minX">Holds if left tile is valid choice. 0 if valid. 1 if invalid.</param>
        /// <param name="currentDistance">Current distance from maze start. Passing due to nature of recursion.</param>
        private void ChooseRandomDirection(int currentY, int currentX, int maxY, int maxX, int minY, int minX, int currentDistance)
        {
            int combinedX = maxX - minX;
            int combinedY = maxY - minY;

            // Tuple created so that I can return multiple values from a single method.
            var returnInt = Tuple.Create<int, int>(0, 0);
            int previousDirection;

            // If already done both left and right.
            if (combinedX == 0)
            {
                returnInt = ChooseYDirection(currentY, currentX, maxY, minY);
                currentY = returnInt.Item1;
                previousDirection = returnInt.Item2;
            }
            else
            {
                // If already done both up and down.
                if (combinedY == 0)
                {
                    returnInt = ChooseXDirection(currentY, currentX, maxX, minX);
                    currentX = returnInt.Item1;
                    previousDirection = returnInt.Item2;
                }
                else
                {
                // Else at least one x and one y are valid.
                    randomInt = random.Next(2);
                    // Randomly selects one axis to move. If 0, use Y axis.
                    if (randomInt == 0)
                    {
                        returnInt = ChooseYDirection(currentY, currentX, maxY, minY);
                        currentY = returnInt.Item1;
                        previousDirection = returnInt.Item2;
                    }
                    else
                    {
                    // Else use x axis.
                        returnInt = ChooseXDirection(currentY, currentX, maxX, minX);
                        currentX = returnInt.Item1;
                        previousDirection = returnInt.Item2;
                    }
                }
            }
            CreateMazeInside(currentY, currentX, previousDirection, currentDistance + 1);
        }

        /// <summary>
        /// Chooses random direction to move on the X axis.
        /// </summary>
        /// <param name="currentY">Current Y location.</param>
        /// <param name="currentX">Current X location.</param>
        /// <param name="maxX">Holds if right tile is valid choice. 2 if valid. 1 if invalid.</param>
        /// <param name="minX">Holds if left tile is valid choice. 0 if valid. 1 if invalid.</param>
        /// <returns>Tuple which holds updated currentX Int and previousDirection Int.</returns>
        private Tuple<int, int> ChooseXDirection(int currentY, int currentX, int maxX, int minX)
        {
            int previousDirection;
            int combinedX = maxX - minX;
            // If either right or left is already created (invalid direction to choose).
            if (combinedX == 1)
            {
                // Checks which is invalid. If left is invalid.
                if (minX == 1)
                {
                    currentX++;
                    previousDirection = 0; // After move, will have come from left.
                }
                else
                {
                    // Else right must be invalid
                    currentX--;
                    previousDirection = 2; // After move, will have come from right.
                }
            }
            else
            {
            // Else both right and left are valid. Randomly force one of the two.
                // Get a random int from min/max X values.
                randomInt = random.Next(minX, maxX);
                // If random = 0, go left. Otherwise right.
                if (randomInt == 0)
                {
                    currentX--;
                    previousDirection = 2; // After move, will have come from right.
                }
                else
                {
                    currentX++;
                    previousDirection = 0; // After move, will have come from left.
                }
            }
            var returnInt = Tuple.Create<int, int>(currentX, previousDirection);
            return returnInt;
        }

        /// <summary>
        /// Chooses random direction to move on the Y axis.
        /// </summary>
        /// <param name="currentY">Current Y location.</param>
        /// <param name="currentX">Current X location.</param>
        /// <param name="maxY">Holds if down tile is valid choice. 2 if valid. 1 if invalid.</param>
        /// <param name="minY">Holds if up tile is valid choice. 0 if valid. 1 if invalid.</param>
        /// <returns>Tuple which holds updated currentY Int and previousDirection Int.</returns>
        private Tuple<int, int> ChooseYDirection(int currentY, int currentX, int maxY, int minY)
        {
            int previousDirection;
            int combinedY = maxY - minY;
            // If either up or down is already created (invalid direction to choose).
            if (combinedY == 1)
            {
                // Checks which is invalid. If up is invalid.
                if (minY == 1)
                {
                    currentY++;
                    previousDirection = 1; // After move, will have come from above.
                }
                else
                {
                // Else down must be invalid
                    currentY--;
                    previousDirection = 3; // After move, will have come from below.
                }
            }
            else
            {
            // Else both up and down are valid. Randomly force one of the two.
                // Get a random int from min/max Y values.
                randomInt = random.Next(minY, maxY);
                // If random = 0, go up. Otherwise down.
                if (randomInt == 0)
                {
                    currentY--;
                    previousDirection = 3; // After move, will have come from below.
                }
                else
                {
                    currentY++;
                    previousDirection = 1; // After move, will have come from above.
                }
            }
            var returnInt = Tuple.Create<int, int>(currentY, previousDirection);
            return returnInt;
        }

        /// <summary>
        /// Checks all nearby tiles for wall generation.
        /// </summary>
        /// <param name="currentY">Current Y location.</param>
        /// <param name="currentX">Current X location.</param>
        private void CheckNearbyTiles(int currentY, int currentX)
        {
            CheckTileAbove(currentY, currentX);
            CheckTileBelow(currentY, currentX);
            CheckTileToLeft(currentY, currentX);
            CheckTileToRight(currentY, currentX);
        }

        /// <summary>
        /// Checks adj tiles of left of current and generate appropriate wall tiles.
        /// Also has a 2% chance per check of generating a random wall.
        /// </summary>
        /// <param name="currentY">Current Y location.</param>
        /// <param name="currentX"> Current X location.</param>
        private void CheckTileToLeft(int currentY, int currentX)
        {
            // Checks if tile to left is null. if so, check tiles adj to it.
            if (mazeLayout[currentY, currentX - 1] == null)
            {
                // First off, 2% chance that it is simply turned into a wall. If so, removes need for checking adj tiles.
                randomInt = random.Next(100);
                if (randomInt < 2)
                {
                    mazeLayout[currentY, currentX - 1] = new MazeTile('#');
                }
                else
                {
                    // Checks tiles directly adjecent to tile left of current.
                    // If any adj space is a path, make tile left of current into a wall.
                    // Check left adj.
                    if (mazeLayout[currentY, currentX - 2] != null && mazeLayout[currentY, currentX - 2].IDChar == '.')
                    {
                        mazeLayout[currentY, currentX - 1] = new MazeTile('#');
                    }
                    else
                    {
                        // Check below adj.
                        if (mazeLayout[currentY + 1, currentX - 1] != null && mazeLayout[currentY + 1, currentX - 1].IDChar == '.')
                        {
                            mazeLayout[currentY, currentX - 1] = new MazeTile('#');
                        }
                        else
                        {
                            // Check above adj.
                            if (mazeLayout[currentY - 1, currentX - 1] != null && mazeLayout[currentY - 1, currentX - 1].IDChar == '.')
                            {
                                mazeLayout[currentY, currentX - 1] = new MazeTile('#');
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks adj tiles of right of current and generate appropriate wall tiles.
        /// Also has a 2% chance per check of generating a random wall.
        /// </summary>
        /// <param name="currentY">Current Y location.</param>
        /// <param name="currentX">Current X location.</param>
        private void CheckTileToRight(int currentY, int currentX)
        {
            // Checks if tile to right is null. if so, check tiles adj to it.
            if (mazeLayout[currentY, currentX + 1] == null)
            {
                // First off, 2% chance that it is simply turned into a wall. If so, removes need for checking adj tiles.
                randomInt = random.Next(100);
                if (randomInt < 2)
                {
                    mazeLayout[currentY, currentX + 1] = new MazeTile('#');
                }
                else
                {
                    // Checks tiles directly adjecent to tile right of current.
                    // If any adj space is a path, make tile right of current into a wall.
                    // Check right adj.
                    if (mazeLayout[currentY, currentX + 2] != null && mazeLayout[currentY, currentX + 2].IDChar == '.')
                    {
                        mazeLayout[currentY, currentX + 1] = new MazeTile('#');
                    }
                    else
                    {
                        // Check below adj.
                        if (mazeLayout[currentY + 1, currentX + 1] != null && mazeLayout[currentY + 1, currentX + 1].IDChar == '.')
                        {
                            mazeLayout[currentY, currentX + 1] = new MazeTile('#');
                        }
                        else
                        {
                            // Check above adj.
                            if (mazeLayout[currentY - 1, currentX + 1] != null && mazeLayout[currentY - 1, currentX + 1].IDChar == '.')
                            {
                                mazeLayout[currentY, currentX + 1] = new MazeTile('#');
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks adj tiles of above current and generate appropriate wall tiles.
        /// Also has a 2% chance per check of generating a random wall.
        /// </summary>
        /// <param name="currentY">Current Y location.</param>
        /// <param name="currentX">Current X location.</param>
        private void CheckTileAbove(int currentY, int currentX)
        {
            // Checks if tile above is null. if so, check tiles adj to it.
            if (mazeLayout[currentY - 1, currentX] == null)
            {
                // First off, 2% chance that it is simply turned into a wall. If so, removes need for checking adj tiles.
                randomInt = random.Next(100);
                if (randomInt < 2)
                {
                    mazeLayout[currentY - 1, currentX] = new MazeTile('#');
                }
                else
                {
                    // Checks tiles directly adjecent to tile above current.
                    // If any adj space is a path, make tile above current into a wall.
                    // Check above adj.
                    if (mazeLayout[currentY - 2, currentX] != null && mazeLayout[currentY - 2, currentX].IDChar == '.')
                    {
                        mazeLayout[currentY - 1, currentX] = new MazeTile('#');
                    }
                    else
                    {
                        // Check right adj.
                        if (mazeLayout[currentY - 1, currentX + 1] != null && mazeLayout[currentY - 1, currentX + 1].IDChar == '.')
                        {
                            mazeLayout[currentY - 1, currentX] = new MazeTile('#');
                        }
                        else
                        {
                            // Check left adj.
                            if (mazeLayout[currentY - 1, currentX - 1] != null && mazeLayout[currentY - 1, currentX - 1].IDChar == '.')
                            {
                                mazeLayout[currentY - 1, currentX] = new MazeTile('#');
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks adj tiles of below current and generate appropriate wall tiles.
        /// Also has a 2% chance per check of generating a random wall.
        /// </summary>
        /// <param name="currentY">Current Y location.</param>
        /// <param name="currentX">Current X location.</param>
        private void CheckTileBelow(int currentY, int currentX)
        {
            // Checks if tile below is null. if so, check tiles adj to it.
            if (mazeLayout[currentY + 1, currentX] == null)
            {
                // First off, 2% chance that it is simply turned into a wall. If so, removes need for checking adj tiles.
                randomInt = random.Next(100);
                if (randomInt < 2)
                {
                    mazeLayout[currentY + 1, currentX] = new MazeTile('#');
                }
                else
                {
                    // Checks tiles directly adjecent to tile below current.
                    // If any adj space is a path, make tile below current into a wall.
                    // Check below adj.
                    if (mazeLayout[currentY + 2, currentX] != null && mazeLayout[currentY + 2, currentX].IDChar == '.')
                    {
                        mazeLayout[currentY + 1, currentX] = new MazeTile('#');
                    }
                    else
                    {
                        // Check right adj.
                        if (mazeLayout[currentY + 1, currentX + 1] != null && mazeLayout[currentY + 1, currentX + 1].IDChar == '.')
                        {
                            mazeLayout[currentY + 1, currentX] = new MazeTile('#');
                        }
                        else
                        {
                            // Check left adj.
                            if (mazeLayout[currentY + 1, currentX - 1] != null && mazeLayout[currentY + 1, currentX - 1].IDChar == '.')
                            {
                                mazeLayout[currentY + 1, currentX] = new MazeTile('#');
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Accounts for any possible skipped tiles and sets them to be walls.
        /// </summary>
        private void VoidOutExtraTiles()
        {
            indexXInt = 0;
            indexYInt = 0;
            while (indexYInt < mazeSizeInt)
            {
                while (indexXInt < mazeSizeInt)
                {
                    if (mazeLayout[indexYInt, indexXInt] == null)
                    {
                        mazeLayout[indexYInt, indexXInt] = new MazeTile('#');
                    }
                    indexXInt++;
                }
                indexXInt = 0;
                indexYInt++;
            }
        }

        #endregion

    }
}
