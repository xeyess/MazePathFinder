using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2CML
{
    public class IterativeDeepening : Navigation
    {
        private Node _foundNode;

        //Initialise
        public IterativeDeepening(GenerateEnvironment envir, int maxDepth, int goal)
        {
            gg = envir;
            searchingBlock = goal;
            goalFound = true;
            this.maxDepth = maxDepth;
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
                    Console.WriteLine(OutputMoves(_foundNode, "IDS"));
                }
            }
        }

        //Search Method
        public bool Search(Node n, int limit)
        {
            nodeCount++;
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
                if (Search(nb, limit - 1))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
