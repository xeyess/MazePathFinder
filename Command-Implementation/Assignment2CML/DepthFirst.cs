using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2CML
{
    public class DepthFirst : Navigation
    {
        private Stack<Node> _s = new Stack<Node>();

        //Initialise
        public DepthFirst(GenerateEnvironment envir, int goal)
        {
            gg = envir;
            searchingBlock = goal;
            goalFound = true;
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
            Console.WriteLine(OutputMoves(p, "DFS"));
        }

        //Generate path
        public Node getPath(GenerateEnvironment gg)
        {
            _s.Push(GetActorBlock());
            while (_s.Count != 0)
            {
                nodeCount++;
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
                visited[n.x, n.y] = true;

            }
            return null;
        }
    }
}
