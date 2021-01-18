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
    public partial class UpdatedMain : Form
    {
        public UpdatedMain()
        {
            InitializeComponent();
        }

        GenerateEnvironment gg; //Generated Ground
        Graphics g; //Graphics variable
        List<string> goals = new List<string>();

        //Initialise
        private void UpdatedMain_Load(object sender, EventArgs e)
        {
           // ScaleElements(gg);
        }

        //Graphics Paint
        private void pGrid_Paint(object sender, PaintEventArgs e)
        {
            g = gg.DrawGridPanel(pGrid);
        }

        //Scale form according to grid data
        Size defaultSize = new Size(800, 400);
        private void ScaleElements(GenerateEnvironment gg)
        {
            //keep scaling for default
            /*
            int modifierX = (800 / 11) * gg.gridx;
            int modifierY = (400 / 5) * gg.gridy;
            this.Size = new Size(modifierX, modifierY);
            */

            //Scaling depending on whichever is longer
            if (gg.gridx < gg.gridy)
            {
                this.Size = new Size(defaultSize.Height, defaultSize.Width);

            }
            else
            {
                this.Size = new Size(defaultSize.Width, defaultSize.Height);
            }

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File|*.txt";
            ofd.Title = "Open..";
            ofd.DefaultExt = "txt";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                if (fileName != null || fileName != "")
                {
                    gg.GetData(fileName);

                    this.ScaleElements(gg);
                    this.Refresh();
                }
                else
                {
                    MessageBox.Show("An error occured. Try again.");
                }
            }
        }

        private void useDefaultFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            gg.GetData();
            this.Refresh();
        }

        public List<string> MoreGoals
        {
            get { return goals; }
        }

        //Grid Control getter
        public Control Grid
        {
            get { return this.pGrid; }
        }

        //Grid Data getter
        public GenerateEnvironment GridData
        {
            get { return this.gg; }
            set { gg = value; }
        }

        //Ignore
    }
}
