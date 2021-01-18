using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2CML
{
    public class AStar : Navigation
    {
        //Initialise
        public AStar(GenerateEnvironment envir, int goal)
        {
            gg = envir;
            searchingBlock = goal;
            goalFound = true;
            Start();
        }

        //Start method
        public void Start()
        {
            BeginAStar();
            GetSuccess();
        }

        //Begin Algorithm
        public void BeginAStar()
        {
            Node current = null;
            Node start = GetActorBlock();
            Node target = GetGoalBlock();
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();
            int g = 0;
            openList.Add(start);
            while (openList.Count > 0)
            {
                nodeCount++;
                //get lowest cost node (from start to node and node to end)
                int lowest = openList.Min(l => l.f);
                current = openList.First(l => l.f == lowest);
                closedList.Add(current);
                openList.Remove(current);
                if (closedList.FirstOrDefault(l => l.x == target.x && l.y == target.y) != null) //if target is found in closedList
                {
                    moves++;
                    success = true;
                    break;
                }
                List<Node> adjacentSquareList = GetWalkableAdjacents(current.x, current.y, gg);
                g++;
                foreach (Node adjacentSquares in adjacentSquareList)
                {
                    // if this adjacent square is already in the closed list, ignore it
                    if (closedList.FirstOrDefault(l => l.x == adjacentSquares.x && l.y == adjacentSquares.y) != null)
                    {
                        continue;
                    }
                    // if not in open list
                    if (openList.FirstOrDefault(l => l.x == adjacentSquares.x && l.y == adjacentSquares.y) == null)
                    {
                        // compute its score, set the parent
                        adjacentSquares.g = g;
                        adjacentSquares.h = ComputeHScore(adjacentSquares.x, adjacentSquares.y, target.x, target.y);
                        adjacentSquares.f = adjacentSquares.g + adjacentSquares.h;
                        adjacentSquares.Parent = current;


                        // and add it to the open list
                        openList.Insert(0, adjacentSquares);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g + adjacentSquares.h < adjacentSquares.f)
                        {
                            adjacentSquares.g = g;
                            adjacentSquares.f = adjacentSquares.g + adjacentSquares.h;
                            adjacentSquares.Parent = current;
                        }
                    }
                }
            }
            if (current != null) //redundant condition to avoid preemptive output
            {
                Console.WriteLine(OutputMoves(current, "A*"));
            }
        }

        //Variant method to isOpen and getNeightbour
        public List<Node> CheckGrid(int x, int y, GenerateEnvironment gg) 
        {
            List<Node> Result = new List<Node>();
            if (y > 0) //up
            {
                Result.Add(new Node { x = x, y = y - 1 });
            }
            if (x > 0) //left
            {
                Result.Add(new Node { x = x - 1, y = y });
            }
            if (y < gg.gridy - 1) //down
            {
                Result.Add(new Node { x = x, y = y + 1 });
            }
            if (x < gg.gridx - 1) //right
            {
                Result.Add(new Node { x = x + 1, y = y });
            }
            return Result;
        }

        //Variant method to isOpen
        public List<Node> GetWalkableAdjacents(int x, int y, GenerateEnvironment gg) 
        {
            List<Node> proposedLocations = CheckGrid(x, y, gg);
            return proposedLocations.Where(l => gg.grid[l.x, l.y] == GenerateEnvironment.Block.Path || gg.grid[l.x, l.y] == GenerateEnvironment.Block.Goal).ToList();
        }
    }
}

