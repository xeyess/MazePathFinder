using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Maze
{
    public class IterativeDeepening : Navigation
    {
        private Node _foundNode;

        //Initialise
        public IterativeDeepening(Control c, GenerateEnvironment envir, int maxDepth, int goal, bool explore)
        {
            gg = envir;
            gridControl = c;
            searchingBlock = goal;
            goalFound = true;
            this.maxDepth = maxDepth;
            this.explore = explore;
            Start();
        }
        
        //Start Method
        public void Start()
        {
            BeginIDDFS();
            GetSuccess();
        }

        //Begin Algorithm
        public void BeginIDDFS()
        {
            for (int limit = 0; limit < maxDepth; limit++)
            {
                if (Search(GetActorBlock(), limit))
                {
                    while (_foundNode.Parent != null)
                    {
                        _foundNode = _foundNode.Parent;
                        if (gg.grid[_foundNode.x, _foundNode.y] == GenerateEnvironment.Block.Path) //ignore start 
                        {
                            gg.grid[_foundNode.x, _foundNode.y] = GenerateEnvironment.Block.Move;
                        }
                        moves++;
                        RefreshControl(gridControl, gg);
                    }
                }
            }
        }

        //Search Method
        public bool Search(Node n, int limit)
        {
            List<Node> neighbours = new List<Node>();
            if (n.x == GetGoalBlock().x && n.y == GetGoalBlock().y)
            {
                _foundNode = n;
                success = true;
                return true;
            }
            if (limit <= 0)
            {
                return false;
            }

            neighbours = getNeighbours(n);

            foreach (Node nb in neighbours)
            {
                if (explore)
                {
                    ApplyExplorer(gridControl, gg, n.x, n.y); //display exploration
                }

                if (Search(nb, limit - 1))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
