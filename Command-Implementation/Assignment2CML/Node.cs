using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2CML
{
    public class Node
    {
        public int x;
        public int y;
        public int f; //g + h
        public int g; //distance from start
        public int h; //estimate distance from end
        public Node Parent;
        public Node() { }
        public Node(int x, int y, Node parent)
        {
            this.x = x;
            this.y = y;
            this.Parent = parent;
        }

        
    }
}
