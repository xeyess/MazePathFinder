using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Maze
{
    public class DepthFirst : Navigation
    {
        private Stack<Node> _s = new Stack<Node>();

        //Initialise
        public DepthFirst(Control c, GenerateEnvironment envir, int goal, bool explore)
        {
            gg = envir;
            gridControl = c;
            searchingBlock = goal;
            goalFound = true;
            this.explore = explore;
            Start();
        }

        //Start Method
        public void Start()
        {
            BeginBFS();
            GetSuccess();
        }

        //Begin Algorithm
        public void BeginBFS()
        {
            visited = new bool[gg.gridx, gg.gridy];
            Node p = getPath(gg); //x y
            if (p.Parent != null)
            {
                while (p.Parent != null)
                {
                    p = p.Parent;
                    if (gg.grid[p.x, p.y] == GenerateEnvironment.Block.Path) //ignore start 
                    {
                        gg.grid[p.x, p.y] = GenerateEnvironment.Block.Move;
                    }
                    moves++;
                    RefreshControl(gridControl, gg);
                }
            }
        }

        //Generate path
        public Node getPath(GenerateEnvironment gg)
        {
            _s.Push(GetActorBlock());
            while (_s.Count != 0)
            {
                List<Node> neighbours = new List<Node>();
                Node n = _s.Pop();
                if (visited[n.x, n.y] == false)
                {
                    if (n.x == GetGoalBlock().x && n.y == GetGoalBlock().y)
                    {
                        success = true;
                        return n;
                    }

                    neighbours = getNeighbours(n);

                    foreach (Node nb in neighbours)
                    {
                        _s.Push(nb);
                    }
                }

                if (explore)
                {
                    ApplyExplorer(gridControl, gg, n.x, n.y); //display exploration
                }
                visited[n.x, n.y] = true;

            }
            return null;
        }
    }
}
