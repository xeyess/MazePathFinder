# MazePathFinder
 A C# Maze Solver using common pathfinding techniques. 

This is the solution that was developed to solve a maze with a
designated start and end location. Used for an assignment.

## Main Functions
- Two forms are shown when the program is started. 
One controls the grid and the other displays it.
The grid will have a number of blocks.
	Red - The robot
	Gray - Walls
	Green - Goals
	Light Blue/White - Path (when path is found)
	Orange - Explorer when 'Show exploration' is turned on
Pressing the navigate button will execute the selected Searching Algorithm
from the comboBox to find the selected Goal.
- 2 and only 2 goals can be set, no more no less as it adheres to the example
and no instructions were given otherwise.

## Additional
- Selecting show exploration will display how nodes are expanded. 
  Keep in mind some algorithms may be slow with this.
- The number of moves will be shown on the title of the grid after navigation
- Selecting Iterative Deepening will reveal a depth input to
  limit the number of iterations
- A different file may be loaded from the menu from file -> Open
	*Please note that the default file "RobotNav-test.txt" must exist for the program to work.

 ## Ignore
- The "main" form is infact the old form and any references of "gg.DrawGrid" are from the old
  textBased grid that still exists in some code that I may not have been able to purge.
  However, it did form a large basis of my current code so it was left to exist.
