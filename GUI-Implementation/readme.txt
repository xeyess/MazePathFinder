Robot Navigation
	COS30019 Assignment 1
		Option B : Robot Navigation 

This is the solution that was developed to solve
the robot navigation that is shown within the 
assignment brief. This is a GUI implementation 
with no command line. Different files can be opened
from a menu bar within the form. Here are some short 
instuctions on how to use this.

	Main Functions

Two forms are shown when the program is started. 
One controls the grid and the other displays it.
The grid will have a number of blocks.
	Red - The robot
	Gray - Walls
	Green - Goals
	Light Blue/White - Path (when path is found)
	Orange - Explorer when 'Show exploration' is turned on
Pressing the navigate button will execute the selected Searching Algorithm
from the comboBox to find the selected Goal.

	Additional

- Selecting show exploration will display how nodes are expanded. 
  Keep in mind some algorithms may be slow with this.
- The number of moves will be shown on the title of the grid after navigation
- Selecting Iterative Deepening will reveal a depth input to
  limit the number of iterations
- A different file may be loaded from the menu from file -> Open
	*Please note that the default file "RobotNav-test.txt" must exist for the program to work.

       Ignore
- The "main" form is infact the old form and any references of "gg.DrawGrid" are from the old
  textBased grid that still exists in some code that I may not have been able to purge.
  However, it did form a large basis of my current code so it was left to exist.