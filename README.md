# Assignment 2 - C# Recursion Maze

## Author

Brandon Rodriguez

## Description

Program which creates and solves a maze using recursion and an attempt at "self-updating entity" logic.

User is given a menu. They can create new mazes (both premade and randomly generated), display and solve the mazes, or adjust settings of the maze's display.

Each tile in the maze has its own properties, as opposed to just being a static char.

The display is on a timer so that the user can watch while the character navigates to the exit. Character currently attempts to navigate in the following order: right, down, left, then up. Any tiles which have been passed over are marked with an X. Any tiles which have been determined to be a dead end are marked with an O.

Things like console color, speed, and starting location can be turned off or toggled.

The maze generation should work with all sizes (as long as it fits within the console window) and even shows user as it's being created. Is fully solve-able and can be transposed just like premade maze.

UI is "static" in that it doesn't scroll like a standard console application.

## Project Requirements

You must write a program to traverse a 12 x 12 maze and find a successful path from a starting point to an exit. You are given a hard coded maze in the program, as well as some starting coordinates. Each spot in the maze is represented by either a '#' or a '.' (dot). The #'s represent the walls of the maze, and the dots represent paths through the maze. Moves can be made only up, down, left, or right (not diagonally), one spot at a time, and only over paths (not into or across a wall). The exit will be any spot that is on the outside of the array. As your program attempts to find a path leading to the exit, it should place the character 'X' in each spot along the path. If a dead end is reached, your program should replace the X’s with '0'. But, the spots with '0' should be marked back to 'X' if these spots are part of a successful path leading to a final state. The output of your program is the maze configuration after each move. In your testing, you may assume that each maze has a path from its starting point to its exit point. If there is no exit, you will arrive at the starting spot again.

There is a method stub in the main program for transposing the 2D array. The progarm is setup to solve both the orignal maze, and the transposed maze. Your program should be able to solve both of them without any issue.

You are required to use recursion to solve this problem.

Please remember to fill out this README file with the relevent information that is missing.

Also make sure that you comment your name at the top of each file, and add comments for each method.

Comment anything else that isn't obvious about what you are trying to do in the code.

I also want you to comment the recursive method you implement thoroughly to show me that you know what is going on inside your method.

### Notes

It might be useful while developing this program to use a smaller sized maze, and then get it to work with the real ones.

Don't forget that you must have a base case for your recursive method or you will continue to get a stack overflow. 

## Outside Resources Used

http://stackoverflow.com/questions/5449956/how-to-add-a-delay-for-a-2-or-3-seconds
https://msdn.microsoft.com/en-us/library/hh194873%28v=vs.110%29.aspx
* Used to figure out how to add a delay to console output. Prior to the delay, the program would solve itself way too fast for the user to follow.

http://www.dotnetperls.com/static-property
* Learned how to create static properties. Prior to static properties, there were a few instances of creating an entire redundant class just go gain access to a single variable.

http://www.dotnetperls.com/console-color
http://stackoverflow.com/questions/10058854/look-at-each-character-in-a-string
* Learned how to output different console colors and display different colors in the same string.

https://msdn.microsoft.com/en-us/library/system.random%28v=vs.110%29.aspx
* Brushing up on and learning more indepth intricacies of random number generation.

https://en.wikipedia.org/wiki/Maze_generation_algorithm
* Used in attempting to figure out random maze generation.

http://stackoverflow.com/questions/748062/how-can-i-return-multiple-values-from-a-function-in-c
https://msdn.microsoft.com/en-us/library/system.tuple%28v=vs.110%29.aspx
* Learned how to return multiple values with a single method (used in maze gen).

https://msdn.microsoft.com/en-us/library/xzcawzfw%28v=vs.90%29.aspx
* Realized that in an if statment, "+1" and "++" behave differently
* IE: "if (int + 1)" will just check for the int incrimented by one. "if (int++)" appears to both check for the incrimented int AND actually change all future references to that value as well.

http://stackoverflow.com/questions/5435460/console-application-how-to-update-the-display-without-flicker
https://msdn.microsoft.com/en-us/library/system.console.setcursorposition%28v=vs.110%29.aspx
https://msdn.microsoft.com/en-us/library/system.console.windowwidth%28v=vs.110%29.aspx
* Got rid of annoying console flickering when creating/solving a new maze! Yay!

## Known Problems, Issues, And/Or Errors in the Program

*Maze generation works best when a larger size. The 10 to 20 tile range seems ideal.


