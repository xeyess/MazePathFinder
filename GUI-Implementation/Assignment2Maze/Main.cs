using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Maze
{
    public partial class Main : Form
    {
        //Old Text-based Form
        public Main()
        {
            InitializeComponent();
        }

        //GG = Generated Ground
        GenerateEnvironment gg;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            ScaleElements(gg);
            rtbGrid.Text = gg.DrawGrid();
        }

        //Scale form and elements accordingly
        private void ScaleElements(GenerateEnvironment gg)
        {
            //Scale Form
            int scalingx = (800 / 11) * gg.gridx;
            int scalingy = (400 / 5) * gg.gridy;
            //Scale Rtb
            int rscalingx = (737 / 11) * gg.gridx;
            int rscalingy = (329 / 5) * gg.gridy;

            this.Size = new Size(scalingx, scalingy);
            rtbGrid.Size = new Size(rscalingx, rscalingy);
            
        }

        //Grid Control Getter
        public Control Grid
        {
            get { return this.rtbGrid; }
        }


        //Grid Data Getter
        public GenerateEnvironment GridData
        {
            get { return this.gg; }
            set { gg = value; }
        }
    }
   
}
