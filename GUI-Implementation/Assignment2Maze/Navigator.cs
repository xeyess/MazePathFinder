using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Assignment2Maze
{
    public partial class Navigator : Form
    {
        public Navigator()
        {
            InitializeComponent();
        }

        //Main main = new Main(); //Text-Based Form
        UpdatedMain main = new UpdatedMain(); //Graphics-Based Form
        GenerateEnvironment gg = new GenerateEnvironment();

        //Initialise
        private void Navigator_Load(object sender, EventArgs e)
        {
            if (File.Exists(gg.defaultFile))
            {
                gg.GetData();
                main.GridData = gg;

                main.Show();
            }
            else
            {
                MessageBox.Show("Default file is missing.");
                Application.Exit();
            }
        }

        //cbAlgorithms | show depth input when Iterative Deepening is selected
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAlgorithms.SelectedIndex == 4)
            {
                this.lblDepth.Visible = true;
                this.txtDepth.Visible = true;
            }
            else
            {
                this.lblDepth.Visible = false;
                this.txtDepth.Visible = false;
            }
        }

        //Method to reset form elements
        private void Reset()
        {
            gg.CleanGrid();
            //main.Grid.Text = gg.DrawGrid(); //Old Method for Text-Based Grid

            main.Text = "Robot Navigation";
            main.Update();
            main.Refresh();

        }

        //Navigate button
        private void btnBeginNavigate_Click(object sender, EventArgs e)
        {
            Reset();
            string method = null;
            if (cbAlgorithms.Text == "Depth-First Search (DFS)" || cbAlgorithms.SelectedIndex == 0)
            {
                method = "DFS";
            }
            else if (cbAlgorithms.Text == "Breadth-First Search (BFS)" || cbAlgorithms.SelectedIndex == 1)
            {
                method = "BFS";
            }
            else if (cbAlgorithms.Text == "Greedy Best-First (GBFS)" || cbAlgorithms.SelectedIndex == 2)
            {
                method = "GBFS";
            }
            else if (cbAlgorithms.Text == "A * (ASTAR)" || cbAlgorithms.SelectedIndex == 3)
            {
                method = "A*";
            }
            else if (cbAlgorithms.Text == "Iterative Deepening (IDS)" || cbAlgorithms.SelectedIndex == 4)
            {
                method = "IDS";
            }
            else if (cbAlgorithms.Text == "Bidirectional Search (BDS)" || cbAlgorithms.SelectedIndex == 5)
            {
                method = "BDS";
            }
            else if (cbAlgorithms.Text == "Uniform Cost Search (UCS)" || cbAlgorithms.SelectedIndex == 6)
            {
                method = "UCS";
            }

            bool explore = chkExplore.Checked;

            Navigation nv = new Navigation(method, this, main.Grid, main.GridData, Convert.ToInt32(cbGoals.Text), explore); //Cast template within itself
            MovesToForm(nv.moves); //Get moves and display
        }

        //Display moves counted to main form
        private void MovesToForm(int moves)
        {
            if (moves != 0)
            {
                main.Text += " | Moves: " + moves.ToString();
            }
        }

        //Update Goals Check
        private void CbGoals_MouseClick(object sender, MouseEventArgs e)
        {
            //Add extra goals to list
            if (gg.goalCount > cbGoals.Items.Count)
            {
                int newGoal = cbGoals.Items.Count + 1;
                for (int i = newGoal; i <= gg.goalCount; i++)
                {
                    cbGoals.Items.Add(i.ToString());
                }
            }
        }
    }
}
