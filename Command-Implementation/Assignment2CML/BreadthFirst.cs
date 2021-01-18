using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2CML
{
    public class BreadthFirst : Navigation
    {
        private Queue<Node> _q = new Queue<Node>();

        //Initialise
        public BreadthFirst(GenerateEnvironment envir, int goal)
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
            Console.WriteLine(OutputMoves(p, "BFS"));
        }
        //Generate path
        public Node getPath(GenerateEnvironment gg)
        {
            _q.Enqueue(GetActorBlock());
            while (_q.Count != 0)
            {
                nodeCount++;
                List<Node> neighbours = new List<Node>();
                Node n = _q.Dequeue();
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
                        _q.Enqueue(nb);
                    }
                }

                visited[n.x, n.y] = true;

            }
            return null;
        }

    }

}
