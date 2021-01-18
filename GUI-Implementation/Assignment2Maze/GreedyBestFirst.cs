using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Assignment2Maze
{
    public class GreedyBestFirst : Navigation
    {
        private Queue<Node> _q = new Queue<Node>();
        private Node foundNode;

        //Initialise
        public GreedyBestFirst(Control c, GenerateEnvironment envir, int goal, bool explore)
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
            BeginGBFS();
            GetSuccess();
        }

        //Begin Algorithms
        public void BeginGBFS()
        {
            visited = new bool[gg.gridx, gg.gridy];
            if(getPath(gg) && foundNode != null && foundNode.Parent != null)
            {
                while(foundNode.Parent != null) //output
                {
                    foundNode = foundNode.Parent;
                    if (gg.grid[foundNode.x, foundNode.y] == GenerateEnvironment.Block.Path) //ignore start 
                    {
                        gg.grid[foundNode.x, foundNode.y] = GenerateEnvironment.Block.Move;
                    }
                    moves++;
                    RefreshControl(gridControl, gg);
                }
            }
        }

        //Generate path
        public bool getPath(GenerateEnvironment gg)
        {
            Node current = null;

            int g = 0;
            Node start = GetActorBlock();
            Node target = GetGoalBlock();
            _q.Enqueue(start);
            while (_q.Count != 0)
            {
                List<Node> children = new List<Node>();
                current = _q.Peek();
                _q.Dequeue();
                visited[current.x, current.y] = true;
                if (current.x == target.x && current.y == target.y)
                {
                    foundNode = current;
                    success = true;
                    return true;
                }

                children = getNeighbours(current);

                g++;

                foreach (Node n in children)
                {
                    if (!visited[n.x, n.y])
                    {
                        //Heuristic
                        n.g = g;
                        n.h = ComputeHScore(n.x, n.y, target.x, target.y);
                        n.f = n.g + n.h;

                        if (n.h < current.h)
                        {
                            _q.Enqueue(current);
                            _q.Enqueue(n);
                            n.Parent = current;
                            break;
                        }
                        else
                        {
                            _q.Enqueue(n);
                            n.Parent = current;
                        }

                        if (explore)
                        {
                            ApplyExplorer(gridControl, gg, n.x, n.y); //display exploration
                        }

                        _q.Enqueue(n);
                    }
                }
            }
            return false;
        }
    }
}
