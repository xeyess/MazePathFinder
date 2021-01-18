using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Maze
{
    public class Navigation
    {
        public bool[,] visited;

        public Control gridControl = null; //for grid element
        public GenerateEnvironment gg; 
        public int searchingBlock; //Goal being searched for

        public bool goalFound;

        public int maxDepth = 0; //for Iterative Deepening
        public bool success = false; 
        public int moves;

        public bool explore = false;

        public Navigation() { }

        //Navigation can be used to access all methods
        public Navigation(string method, Control f, Control c, GenerateEnvironment envir, int goalNo, bool explore)
        {
            gg = envir;
            gridControl = c;
            moves = 0;
            this.explore = explore;

            goalFound = true;

            //Check if goal exists
            if (goalNo > 0 && goalNo <= gg.goalCount)
            {
                this.searchingBlock = goalNo;
            }
            else
            {
                MessageBox.Show("Goal Block Invalid.");
                this.goalFound = false;
            }

            if (this.goalFound)
            {
                Start(f, method);
            }
            else
            {
                MessageBox.Show("Goals have not been found." + Environment.NewLine + "Please reinitialise.");
            }
        }

        //Navigation cast method
        private void Start(Control f, string method)
        {
            if (method == "DFS")
            {
                DepthFirst dfs = new DepthFirst(gridControl, gg, searchingBlock, explore);
                this.moves = dfs.moves;
            }
            else if (method == "BFS")
            {
                BreadthFirst bfs = new BreadthFirst(gridControl, gg, searchingBlock, explore);
                this.moves = bfs.moves;
            }
            else if (method == "A*")
            {
                AStar a = new AStar(gridControl, gg, searchingBlock, explore);
                this.moves = a.moves;
            }
            else if (method == "GBFS")
            {
                GreedyBestFirst gbfs = new GreedyBestFirst(gridControl, gg, searchingBlock, explore);
                this.moves = gbfs.moves;
            }
            else if (method == "IDS")
            {
                string depthBox = f.Controls[1].Text;
                if(int.TryParse(depthBox, out int depth))
                {
                    maxDepth = Convert.ToInt32(depthBox);
                    IterativeDeepening ids = new IterativeDeepening(gridControl, gg, maxDepth, searchingBlock, explore);
                    this.moves = ids.moves;
                }
                else
                {
                    MessageBox.Show("Error has occured.");
                }
                
            }
            else if (method == "BDS")
            {
                Bidirectional bds = new Bidirectional(gridControl, gg, searchingBlock, explore);
                this.moves = bds.moves;
            }
            else if(method == "UCS")
            {
                UniformCost ucs = new UniformCost(gridControl, gg, searchingBlock, explore);
                this.moves = ucs.moves;
            }
            
        }

        //Method to output success
        public void GetSuccess()
        {
            if(!success)
            {
                MessageBox.Show("No solution found.");
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

        //Condition if neighbours are able to be added 
        public bool isOpen(GenerateEnvironment gg, int x, int y)
        {
            if ((x >= 0 && x < gg.gridx) && (y >= 0 && y < gg.gridy) && (gg.grid[x, y] == GenerateEnvironment.Block.Path || gg.grid[x, y] == GenerateEnvironment.Block.Goal))
            {
                return true;
            }
            return false;
        }

        //To display exploration
        public void ApplyExplorer(Control c, GenerateEnvironment gg, int x, int y)
        {
            gg.DrawExplorer(c, x, y);
            System.Threading.Thread.Sleep(20);
        }

        //Refresh and Update grid
        public void RefreshControl(Control c, GenerateEnvironment gg)
        {
            //c.Text = gg.DrawGrid(); //for text-based
            gg.DrawGridPanel(c);
            System.Threading.Thread.Sleep(500);
            c.Refresh();
        }

    }
}
