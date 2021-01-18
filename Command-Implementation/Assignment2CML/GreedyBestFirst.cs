using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2CML
{
    public class GreedyBestFirst : Navigation
    {
        private Queue<Node> _q = new Queue<Node>();
        private Node _foundNode;

        //Initialise
        public GreedyBestFirst(GenerateEnvironment envir, int goal)
        {
            gg = envir;
            searchingBlock = goal;
            goalFound = true;
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
            if(getPath(gg) && _foundNode != null && _foundNode.Parent != null)
            {
                Console.WriteLine(OutputMoves(_foundNode, "GBFS"));
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
                nodeCount++;
                List<Node> children = new List<Node>();
                current = _q.Peek();
                _q.Dequeue();
                visited[current.x, current.y] = true;
                if (current.x == GetGoalBlock().x && current.y == GetGoalBlock().y)
                {
                    _foundNode = current;
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

                        _q.Enqueue(n);
                    }
                }
            }
            return false;
        }
    }
}
