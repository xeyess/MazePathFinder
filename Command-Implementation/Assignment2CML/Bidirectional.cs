using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2CML
{
    public class Bidirectional : Navigation
    {
        //S = Source | T = Target
        private bool[,] _visitedS;
        private bool[,] _visitedT;
        private Queue<Node> _qS = new Queue<Node>();
        private Queue<Node> _qT = new Queue<Node>();
        private Node _foundNodeS;
        private Node _foundNodeT;

        //Initialise
        public Bidirectional(GenerateEnvironment envir, int goal)
        {
            gg = envir;
            searchingBlock = goal;
            goalFound = true;
  
            Start();
        }

        //Start method
        public void Start()
        {
            BeginBDS();
            GetSuccess();
        }

        //Begin Algorithm
        public void BeginBDS()
        {
            _visitedS = new bool[gg.gridx, gg.gridy];
            _visitedT = new bool[gg.gridx, gg.gridy];

            Node intersectNode = null;
            Node actor = GetActorBlock();
            Node goal = GetGoalBlock();

            _qS.Enqueue(actor);
            _visitedS[actor.x, actor.y] = true;

            _qT.Enqueue(goal);
            _visitedT[goal.x, goal.y] = true;

            while (_qS.Count != 0 && _qT.Count != 0)
            {
                BFS("s", _qS, _visitedS);
                BFS("t", _qT, _visitedT);
                intersectNode = isIntersecting(_visitedS, _visitedT);
                if(intersectNode != null)
                {
                    if (_foundNodeS != null && _foundNodeT != null)
                    {
                        getPath(_foundNodeS, _foundNodeT, intersectNode);
                        moves -= 1; //offset to account for changing queue
                        break;
                    }
                }
            }
        }

        //Main method
        public void BFS(string src, Queue<Node> q, bool[,] visited)
        {
            nodeCount++;

            Node current = q.First();
            q.Dequeue();

            List<Node> neighbours = getNeighbours(current);

            foreach (Node nb in neighbours)
            {

                if (src == "s") //if dealing with source queue
                {
                    if (!_visitedS[nb.x, nb.y] ) //if intersected
                    {
                        _visitedS[nb.x, nb.y] = true;
                        if (_visitedT[nb.x, nb.y] && _visitedS[nb.x, nb.y])
                        {
                            _foundNodeS = nb;
                            break;
                        }
                        
                    }
                }
                else //if dealing with target queue
                {
                    if (!_visitedT[nb.x, nb.y]) //if intersected
                    {
                        _visitedT[nb.x, nb.y] = true;
                        if (_visitedS[nb.x, nb.y] && _visitedT[nb.x, nb.y])
                        {
                            _foundNodeT = nb;
                            break;
                        }
                        
                    }
                }
                
                nb.Parent = current;
                q.Enqueue(nb);
                
            }
        }

        //if visited nodes have connected
        public Node isIntersecting(bool[,] _visitedS, bool[,] _visitedT)
        {
            for (int i = 0; i < gg.gridy; i++)
            {
                for (int j = 0; j < gg.gridx; j++)
                {
                    if (_visitedS[j, i] == _visitedT[j, i])
                    {
                        return new Node(j, i, null);
                    }
                }
            }
            return null;
        }

        //return intersect node (replacement method) 
        public Node getIntersectNode(Node s, Node t)
        {
            int nodex;
            int nodey;
            if(s.x > t.x)
            {
                nodex = t.x + 1;
            }
            else if (s.x == t.x)
            {
                return null;
            }
            else
            {
                nodex = s.x + 1;
            }
            if (s.y > t.y)
            {
                nodey = t.y + 1;
            }
            else if (s.y == t.y)
            {
                return null;
            }
            else
            {
                nodey = s.y + 1;
            }
            return new Node(nodex, nodey, null);
        }

        //special method for bidirectional due to nature (paths made not in a line);
        public override string OutputMoves(Node n, string method)
        {
            Console.WriteLine(gg.usedFile + " " + method + " " + nodeCount.ToString());
            //Node is dummy to override
            string output = "";
            Node current = GetActorBlock();
            Node end = GetGoalBlock();
            string lastMove = ""; //no backtrack (using poor method)
            for (int i = 0; i < moves; i++)
            {
                //Output moves
                if (isMove(gg, current.x + 1, current.y) && lastMove != "left")
                {
                    if (gg.grid[current.x + 1, current.y] == GenerateEnvironment.Block.Move)
                    {
                        output += "right; ";
                        current = new Node(current.x + 1, current.y, null);
                        lastMove = "right";
                    }
                }
                else if (isMove(gg, current.x - 1, current.y) && lastMove != "right")
                {
                    if (gg.grid[current.x - 1, current.y] == GenerateEnvironment.Block.Move)
                    {
                        output += "left; ";
                        current = new Node(current.x - 1, current.y, null);
                        lastMove = "left";
                    }
                }
                else if (isMove(gg, current.x, current.y + 1) && lastMove != "up")
                {
                    if (gg.grid[current.x, current.y + 1] == GenerateEnvironment.Block.Move)
                    {
                        output += "down; ";
                        current = new Node(current.x, current.y + 1, null);
                        lastMove = "down";
                    }
                }
                else if (isMove(gg, current.x, current.y - 1) && lastMove != "down")
                {
                    if (gg.grid[current.x, current.y - 1] == GenerateEnvironment.Block.Move)
                    {
                        output += "up; ";
                        current = new Node(current.x, current.y - 1, null);
                        lastMove = "up";
                    }
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
            return output;
        }

        //Generate path 
        public void getPath(Node s, Node t, Node intersectNode)
        {
            Queue<Node> q = new Queue<Node>();
            intersectNode = getIntersectNode(s, t);
            q.Enqueue(intersectNode);
            Node n = intersectNode;
            
            
            //Build queue with both queues
            while (s != null)
            {
                q.Enqueue(s.Parent);
                s = s.Parent;
            }
            q.Reverse();
            while (t != null)
            {
                q.Enqueue(t.Parent);
                t = t.Parent;
            }
            
            //Output result
            if (q != null)
            {
                foreach (Node qN in q)
                {
                    if (qN != null)
                    {
                        if (gg.grid[qN.x, qN.y] == GenerateEnvironment.Block.Path) //ignore start 
                        {
                            gg.grid[qN.x, qN.y] = GenerateEnvironment.Block.Move;
                        }
                        moves++;
                    }
                }
                Console.WriteLine(OutputMoves(new Node(), "BDS")); //null node
                success = true;
            }

        }
    }
}
