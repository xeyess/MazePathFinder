﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Maze
{
    public class UniformCost : Navigation
    {
        //Initialise
        public UniformCost(Control c, GenerateEnvironment envir, int goal, bool explore)
        {
            gg = envir;
            gridControl = c;
            searchingBlock = goal;
            goalFound = true;
            this.explore = explore;
            Start();
        }

        //Start method
        public void Start()
        {
            BeginUC();
            GetSuccess();
        }

        //Begin Algorithm
        public void BeginUC()
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
                //get lowest cost node (from start)
                int lowest = openList.Min(l => l.g);
                current = openList.First(l => l.g == lowest);
                closedList.Add(current);
                openList.Remove(current);
                if (closedList.FirstOrDefault(l => l.x == target.x && l.y == target.y) != null) //if target is found in closedList
                {
                    moves++;
                    success = true;
                    RefreshControl(gridControl, gg);
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

                        //display exploration
                        if (explore)
                        {
                            ApplyExplorer(gridControl, gg, adjacentSquares.x, adjacentSquares.y);
                        }

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
            while (current != null) //retrace steps
            {
                if (gg.grid[current.x, current.y] == GenerateEnvironment.Block.Path)
                {
                    gg.grid[current.x, current.y] = GenerateEnvironment.Block.Move;
                    moves++;
                    RefreshControl(gridControl, gg);
                }
                current = current.Parent;
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
