﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2CML
{
    public class GenerateEnvironment
    {
        public string defaultFile; //default grid
        public string usedFile;

        public int gridx;
        public int gridy;
        public Block[,] grid;

        public int goalCount;
        public enum Block
        {
            Actor,
            Path,
            Move,
            Wall,
            Goal
            //Goal1,
            //Goal2

        }

        public int agentx;
        public int agenty;

        // [0, 0] , [0, 1] | Goal 1
        // [1, 0] , [1, 1] | Goal 2
        public int[,] goals; // = new int[2, 2]; 

        //Initialise default file
        public GenerateEnvironment()
        {
            defaultFile = Directory.GetCurrentDirectory() + "/RobotNav-test.txt"; //default file
        }

        //Initialise data through file (by default)
        public bool GetData()
        {
            return Load(defaultFile);
        }

        //Initialise data through file (by fileInput(
        public bool GetData(string fileName)
        {
            try
            {
                return Load(fileName);
            }
            catch
            {
                Console.WriteLine("Invalid file input.");
                return false;
            }
        }

        //Load data
        public bool Load(string src) 
        {
            usedFile = src;
            int fileLength = File.ReadLines(src).Count();
            StreamReader sr = new StreamReader(src);

            //Read lines
            for (int i = 0; i < fileLength; i++)
            {
                string line = sr.ReadLine();
                string[] lines = line.Split('[', ']', ',', '(', ')', '|');
                if (i == 0) //Start State - Row & Columns
                {
                    gridx = Convert.ToInt32(lines[2]);
                    gridy = Convert.ToInt32(lines[1]);
                    if (gridx <= 1 || gridy <= 1)
                    {
                        Console.WriteLine("NxM Grid; N and/or M cannot be lower than 2.");
                        return false;
                    }
                    grid = new Block[gridx, gridy];
                    InitialiseGird();
                }
                else if (i == 1) //Get Agent
                {
                    agentx = Convert.ToInt32(lines[1]);
                    agenty = Convert.ToInt32(lines[2]);
                }
                else if (i == 2) //Get Goals
                {
                    goalCount = 2;
                    goals = new int[lines.Count() / 4, 2];
                    //default 2
                    goals[0, 0] = Convert.ToInt32(lines[1]);
                    goals[0, 1] = Convert.ToInt32(lines[2]);
                    goals[1, 0] = Convert.ToInt32(lines[5]);
                    goals[1, 1] = Convert.ToInt32(lines[6]);
                    //if more
                    int nextGoal = 2; //next goalx index in array
                    int counter = 9; //next index in readLine
                    while (counter < lines.Count())
                    {
                        goals[nextGoal, 0] = Convert.ToInt32(lines[counter]);
                        goals[nextGoal, 1] = Convert.ToInt32(lines[counter + 1]);
                        nextGoal++;
                        goalCount++;
                        counter += 4; //offset
                    }
                }
                else if (i >= 3) //Get Walls
                {
                    int wallx = Convert.ToInt32(lines[1]);
                    int wally = Convert.ToInt32(lines[2]);
                    int wallWide = Convert.ToInt32(lines[3]);
                    int wallHeight = Convert.ToInt32(lines[4]);

                    ExpandWall(wallx, wally, wallWide, wallHeight);
                }
            }
            //Finish Grid
            grid[agentx, agenty] = Block.Actor;
            //Make Goals
            for (int counter = 0; counter < goalCount; counter++)
            {
                grid[goals[counter, 0], goals[counter, 1]] = Block.Goal;
            }
            return true;
        }

        //Extend walls depending on wall wide and height 
        public void ExpandWall(int wallx, int wally, int wallWide, int wallHeight)
        {
            grid[wallx, wally] = Block.Wall;
            if (wallWide >= 2)
            {
                for (int i = 1; i < wallWide; i++)
                {
                    grid[wallx + i, wally] = Block.Wall;
                }
            }
            if (wallHeight >= 2)
            {
                for (int j = 1; j < wallHeight; j++)
                {
                    grid[wallx, wally + j] = Block.Wall;
                }
            }
            if (wallWide >= 2 && wallHeight >= 2) 
            {
                for (int i = 1; i < wallWide; i++)//It could be just this but for the sake of ease 
                {
                    for (int j = 1; j < wallHeight; j++)
                    {
                        grid[wallx + i, wally + j] = Block.Wall;
                    }
                }
            }
        }

        //Initialise Blocks as paths by default
        public void InitialiseGird()
        {
            for (int i = 0; i < gridx; i++)
            {
                for (int j = 0; j < gridy; j++)
                {
                    grid[i, j] = Block.Path;
                }
            }
        }

        //Draw Text-based grid (using rtb)
        public string DrawGrid()
        {
            string output = "";
            if (grid != null)
            {
                for (int i = 0; i < gridy; i++)
                {
                    for (int j = 0; j < gridx; j++)
                    {
                        if (grid[j, i] == Block.Path)
                        {
                            output += "[   ]";
                        }
                        else if (grid[j, i] == Block.Wall)
                        {
                            output += "[w]";
                        }
                        else if (grid[j, i] == Block.Actor)
                        {
                            output += "[A]";
                        }
                        else if (grid[j, i] == Block.Goal)
                        {
                            output += "[G]";
                        }
                        else if (grid[j, i] == Block.Move)
                        {
                            output += "[■ ]";
                        }

                    }
                    if (i < gridy - 1) { output += Environment.NewLine; }
                }
            }
            else
            {
                //throw new System.ArgumentException("The NxM Grid has not been initialised.");
                
            }
            return output;
        }

        //Clean up paths
        public void CleanGrid()
        {
            for (int i = 0; i < gridy; i++)
            {
                for (int j = 0; j < gridx; j++)
                {
                    if (grid[j, i] == Block.Move)
                    {
                        grid[j, i] = Block.Path;
                    }
                }
            }
        }
    }
}
