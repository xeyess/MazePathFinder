namespace Assignment2Maze
{
    partial class Navigator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBeginNavigate = new System.Windows.Forms.Button();
            this.cbAlgorithms = new System.Windows.Forms.ComboBox();
            this.pSearchA = new System.Windows.Forms.Panel();
            this.lblSearchA = new System.Windows.Forms.Label();
            this.cbGoals = new System.Windows.Forms.ComboBox();
            this.pGoals = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.chkExplore = new System.Windows.Forms.CheckBox();
            this.pSearchA.SuspendLayout();
            this.pGoals.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBeginNavigate
            // 
            this.btnBeginNavigate.Location = new System.Drawing.Point(9, 143);
            this.btnBeginNavigate.Margin = new System.Windows.Forms.Padding(2);
            this.btnBeginNavigate.Name = "btnBeginNavigate";
            this.btnBeginNavigate.Size = new System.Drawing.Size(242, 70);
            this.btnBeginNavigate.TabIndex = 0;
            this.btnBeginNavigate.Text = "Navigate";
            this.btnBeginNavigate.UseVisualStyleBackColor = true;
            this.btnBeginNavigate.Click += new System.EventHandler(this.btnBeginNavigate_Click);
            // 
            // cbAlgorithms
            // 
            this.cbAlgorithms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAlgorithms.FormattingEnabled = true;
            this.cbAlgorithms.Items.AddRange(new object[] {
            "Depth-First Search (DFS)",
            "Breadth-First Search (BFS)",
            "Greedy Best-First (GBFS)",
            "A* (ASTAR)",
            "Iterative Deepening (IDS)",
            "Bidirectional Search (BDS)",
            "Uniform Cost Search (UCS)"});
            this.cbAlgorithms.Location = new System.Drawing.Point(22, 17);
            this.cbAlgorithms.Margin = new System.Windows.Forms.Padding(2);
            this.cbAlgorithms.Name = "cbAlgorithms";
            this.cbAlgorithms.Size = new System.Drawing.Size(204, 28);
            this.cbAlgorithms.TabIndex = 1;
            this.cbAlgorithms.Text = "Depth-First Search (DFS)";
            this.cbAlgorithms.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pSearchA
            // 
            this.pSearchA.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pSearchA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSearchA.Controls.Add(this.cbAlgorithms);
            this.pSearchA.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pSearchA.Location = new System.Drawing.Point(9, 16);
            this.pSearchA.Margin = new System.Windows.Forms.Padding(2);
            this.pSearchA.Name = "pSearchA";
            this.pSearchA.Size = new System.Drawing.Size(243, 67);
            this.pSearchA.TabIndex = 2;
            // 
            // lblSearchA
            // 
            this.lblSearchA.AutoSize = true;
            this.lblSearchA.Location = new System.Drawing.Point(21, 9);
            this.lblSearchA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearchA.Name = "lblSearchA";
            this.lblSearchA.Size = new System.Drawing.Size(92, 13);
            this.lblSearchA.TabIndex = 2;
            this.lblSearchA.Text = "Search Algorithms";
            // 
            // cbGoals
            // 
            this.cbGoals.FormattingEnabled = true;
            this.cbGoals.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbGoals.Location = new System.Drawing.Point(14, 8);
            this.cbGoals.Margin = new System.Windows.Forms.Padding(2);
            this.cbGoals.Name = "cbGoals";
            this.cbGoals.Size = new System.Drawing.Size(66, 21);
            this.cbGoals.TabIndex = 3;
            this.cbGoals.Text = "1";
            this.cbGoals.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CbGoals_MouseClick);
            // 
            // pGoals
            // 
            this.pGoals.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pGoals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGoals.Controls.Add(this.cbGoals);
            this.pGoals.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pGoals.Location = new System.Drawing.Point(9, 100);
            this.pGoals.Margin = new System.Windows.Forms.Padding(2);
            this.pGoals.Name = "pGoals";
            this.pGoals.Size = new System.Drawing.Size(96, 39);
            this.pGoals.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Goal";
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Location = new System.Drawing.Point(120, 110);
            this.lblDepth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(36, 13);
            this.lblDepth.TabIndex = 5;
            this.lblDepth.Text = "Depth";
            this.lblDepth.Visible = false;
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(160, 108);
            this.txtDepth.Margin = new System.Windows.Forms.Padding(2);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(76, 20);
            this.txtDepth.TabIndex = 6;
            this.txtDepth.Visible = false;
            // 
            // chkExplore
            // 
            this.chkExplore.AutoSize = true;
            this.chkExplore.Location = new System.Drawing.Point(79, 220);
            this.chkExplore.Name = "chkExplore";
            this.chkExplore.Size = new System.Drawing.Size(108, 17);
            this.chkExplore.TabIndex = 7;
            this.chkExplore.Text = "Show Exploration";
            this.chkExplore.UseVisualStyleBackColor = true;
            // 
            // Navigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 245);
            this.Controls.Add(this.chkExplore);
            this.Controls.Add(this.txtDepth);
            this.Controls.Add(this.lblDepth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pGoals);
            this.Controls.Add(this.lblSearchA);
            this.Controls.Add(this.pSearchA);
            this.Controls.Add(this.btnBeginNavigate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(278, 268);
            this.Name = "Navigator";
            this.Text = "Navigator";
            this.Load += new System.EventHandler(this.Navigator_Load);
            this.pSearchA.ResumeLayout(false);
            this.pGoals.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBeginNavigate;
        private System.Windows.Forms.ComboBox cbAlgorithms;
        private System.Windows.Forms.Panel pSearchA;
        private System.Windows.Forms.Label lblSearchA;
        private System.Windows.Forms.ComboBox cbGoals;
        private System.Windows.Forms.Panel pGoals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.TextBox txtDepth;
        private System.Windows.Forms.CheckBox chkExplore;
    }
}