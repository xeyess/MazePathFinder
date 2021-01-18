using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2CML
{
    public class Navigation
    {
        public bool[,] visited;

        public GenerateEnvironment gg; 
        public int searchingBlock; //block being searched for
        public bool goalFound;

        public int nodeCount = 0;

        public int maxDepth = 0; //for Iterative Deepening
        public bool success = false; 
        public int moves;

        public bool explore = false;

        public Navigation() { }

        //Navigation can be used to access all methods
        public Navigation(string method, GenerateEnvironment envir, int goalNo)
        {
            gg = envir;
            moves = 0;

            goalFound = true;

            //Check if goals exist
            if (goalNo > 0 && goalNo <= gg.goalCount)
            {
                this.searchingBlock = goalNo; //redundant but safe check
            }
            else
            {
                Console.WriteLine("Goal invalid.");
                this.goalFound = false;
            }

            if (this.goalFound)
            {
                Start(method);
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        //Navigation cast method
        private void Start(string method)
        {
            if (method == "DFS")
            {
                DepthFirst dfs = new DepthFirst(gg, searchingBlock);
                this.moves = dfs.moves;
            }
            else if (method == "BFS")
            {
                BreadthFirst bfs = new BreadthFirst(gg, searchingBlock);
                this.moves = bfs.moves;
            }
            else if (method == "A*")
            {
                AStar a = new AStar(gg, searchingBlock);
                this.moves = a.moves;
            }
            else if (method == "GBFS")
            {
                GreedyBestFirst gbfs = new GreedyBestFirst(gg, searchingBlock);
                this.moves = gbfs.moves;
            }
            else if (method == "IDS")
            {
                Console.WriteLine("Insert a depth.");
                string depthBox = Console.ReadLine();
                if(int.TryParse(depthBox, out int depth))
                {
                    maxDepth = Convert.ToInt32(depthBox);
                    IterativeDeepening ids = new IterativeDeepening(gg, maxDepth, searchingBlock);
                    this.moves = ids.moves;
                }
                else
                {
                    Console.WriteLine("Error has occured.");
                }
                
            }
            else if (method == "BDS")
            {
                Bidirectional bds = new Bidirectional(gg, searchingBlock);
                this.moves = bds.moves;
            }
            else if(method == "UCS")
            {
                UniformCost ucs = new UniformCost(gg, searchingBlock);
                this.moves = ucs.moves;
            }
            
        }

        //Method to output success
        public void GetSuccess()
        {
            if(!success)
            {
                Console.WriteLine("No solution found.");
            }
        }

        //Retrieve node containing the 'robot'
        public Node GetActorBlock()
        {
            return new Node { x = gg.agentx, y = gg.agenty, Parent = null };
        }

        //Retrieve the node containing one of the goals
        public Node GetGoalBlock()
        {
            return new Node { x = gg.goals[searchingBlock - 1, 0], y = gg.goals[searchingBlock - 1, 1] };
        }

        //HScore calculation for Heuriustic Algorithms
        public static int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }

        //Retrieve neighbouring nodes
        public List<Node> getNeighbours(Node n)
        {
            List<Node> neighbours = new List<Node>();
            if (isOpen(gg, n.x, n.y - 1)) //up
            {
                neighbours.Add(new Node(n.x, n.y - 1, n));
            }
            if (isOpen(gg, n.x - 1, n.y)) //left
            {
                neighbours.Add(new Node(n.x - 1, n.y, n));
            }
            if (isOpen(gg, n.x, n.y + 1)) //down
            {
                neighbours.Add(new Node(n.x, n.y + 1, n));
            }
            if (isOpen(gg, n.x + 1, n.y)) //right
            {
                neighbours.Add(new Node(n.x + 1, n.y, n));
            }

            return neighbours;
        }

        public virtual String OutputMoves(Node n, string method) //is virtual for bidirectional
        {
            //write filename, method and number of nodes
            Console.WriteLine(gg.usedFile + " " + method + " " + nodeCount.ToString());
            string output = "";
            //trace backtrack moves then flip
            List<Node> moveList = new List<Node>();
            if (n.Parent != null)
            {
                while (n.Parent != null)
                {
                    n = n.Parent;
                    if (gg.grid[n.x, n.y] == GenerateEnvironment.Block.Path) //ignore start 
                    {
                        moveList.Add(n);
                        gg.grid[n.x, n.y] = GenerateEnvironment.Block.Move;
                    }
                }
                Node current = GetActorBlock();
                Node end = GetGoalBlock();
                moveList.Reverse();
                foreach (Node ml in moveList)
                {
                    //Output moves
                    if (isMove(gg, current.x + 1, current.y) && current.x + 1 == ml.x && current.y == ml.y)
                    {
                        output += "right; ";
                        current = ml;
                    }
                    else if (isMove(gg, current.x - 1, current.y) && current.x - 1 == ml.x && current.y == ml.y)
                    {
                        output += "left; ";
                        current = ml;
                    }
                    else if (isMove(gg, current.x, current.y + 1) && current.x == ml.x && current.y + 1 == ml.y)
                    {
                        output += "down; ";
                        current = ml;
                    }
                    else if (isMove(gg, current.x, current.y - 1) && current.x == ml.x && current.y - 1 == ml.y)
                    {
                        output += "up; ";
                        current = ml;
                    }
                }
                //Final move to goal
                if (isMove(gg, current.x + 1, current.y) && current.x + 1 == end.x && current.y == end.y)
                {
                    output += "right.";
                }
                else if (isMove(gg, current.x - 1, current.y) && current.x - 1 == end.x && current.y == end.y)
                {
                    output += "left.";
                }
                else if (isMove(gg, current.x, current.y + 1) && current.x == end.x && current.y + 1 == end.y)
                {
                    output += "down.";
                }
                else if (isMove(gg, current.x, current.y - 1) && current.x == end.x && current.y - 1 == end.y)
                {
                    output += "up.";
                }
            }
            return output;
        }

        //Condition if neighbours are able to be added 
        public bool isOpen(GenerateEnvironment gg, int x, int y)
        {
            if ((x >= 0 && x < gg.gridx) && (y >= 0 && y < gg.gridy) && (gg.grid[x, y] == GenerateEnvironment.Block.Path || gg.grid[x, y] == GenerateEnvironment.Block.Goal))
            {
                return true;
            }
            return false;
        }

        //Condition if neighbours are able to be added 
        public bool isMove(GenerateEnvironment gg, int x, int y)
        {
            if ((x >= 0 && x < gg.gridx) && (y >= 0 && y < gg.gridy) && (gg.grid[x, y] == GenerateEnvironment.Block.Move || gg.grid[x, y] == GenerateEnvironment.Block.Goal))
            {
                return true;
            }
            return false;
        }

    }
}
