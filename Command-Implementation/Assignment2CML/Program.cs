using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment2CML
{
    class Program
    {
        static void Main(string[] args)
        {
            //For testing
            /*
            args = new string[2];
            args[0] = "RobotNav-test.txt";
            args[1] = "UCS";
            */
            Console.Clear();
            string fileName = "";
            string method = "";
            Console.WriteLine("[Robot Navigation]");

            //if two paramaters given (batch format : .exe filename.txt method)
            if (args.Length == 2) 
            {
                    if (File.Exists(args[0]))
                    {
                        GenerateEnvironment gg = new GenerateEnvironment();
                        fileName = args[0];
                        method = args[1];
                        if (gg.Load(fileName)) //if valid file
                        {
                            BeginSearch(fileName, gg, method); 
                        }
                        else
                        {
                            Console.WriteLine("Argument format should be *.exe fileName method*");
                            Console.ReadLine();
                            Close();
                        } 
                    }
                    else
                    {
                        Console.WriteLine("File does not exist.");
                        Console.ReadLine();
                        Close();
                    }
            }
            else
            {
                Console.WriteLine("Argument format should be *.exe fileName method*");
                Console.ReadLine();
                Close();
            }
            
        }

        private static void BeginSearch(string src, GenerateEnvironment gg, string method)
        {
            int goalNumber = -1;
            bool active = true;
            string choice;
            while (active)
            {
                Console.WriteLine("Please enter which goal you would like to go to.");
                goalNumber = Convert.ToInt32(Console.ReadLine());
                if (goalNumber < 1 || goalNumber > gg.goalCount)  
                {
                    Console.WriteLine("Invalid input. Put a valid goal number.");
                    Console.WriteLine("---------------------------------------");
                }
                else
                {
                    Navigation nv = new Navigation(method, gg, goalNumber);
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Would you like use the same algorithm? Y/N");
                    choice = Console.ReadLine();
                    if (choice == "Y")
                    {
                        gg.CleanGrid();
                    }
                    else
                    {
                        active = false;
                        gg.CleanGrid();
                        Console.Clear();
                        Reset();
                        
                    }
                    
                        
                }
                
            }
        }

        private static void Reset()
        {
            Console.WriteLine("Please enter a new search using the same format, or type 'x' to exit.");
            string[] arg = Console.ReadLine().Split();
            if (arg[0] == "x")
            {
                Close();
            }
            else
            {
                Console.Clear();
                Main(arg);
            }
        }

        private static void Close()
        {
            Environment.Exit(0);
        }

    }
}
