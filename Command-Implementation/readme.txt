Robot Navigation
	COS30019 Assignment 1
		Option B : Robot Navigation 

This is the solution that was developed to solve
the robot navigation that is shown within the 
assignment brief. This is a command-line implementation.

The application is located in the debug folder in the bin.
In this folder there will be 
	- Assignment2CML.exe (the search application to be used in the command line)
	- RobotNav-test.exe (the sample grid provided)
		- There are also .bat files that will automatically test 
		  the program using the labelled method name and the sample grid.
	- cmd.exe (the command prompt executable for ease of access)

The format for the command-line should be
	Assignment2CML.exe *filename.txt* *method*

The methods implemented are
		(name)             |  method
	- Depth-First Search          (DFS)
	- Breadth-First Search        (BFS)
	- Greedy Best-First Search    (GBFS)
	- A*                          (A*)
	- Iterative Deepening         (IDS)* non-custom                                           
	- BiDirectional Search        (BDS)
	- Uniform Cost Search         (UCS)

For example, Assignment2CML.exe test.txt DFS
would run the DFS algorithm on the test.txt grid.

Multiple goals can be searched for in the same instance when prompted with
Y/N. Y asks for another goal, and N asks for a new command.
