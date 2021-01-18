namespace Assignment2Maze
{
    partial class Main
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
            this.rtbGrid = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbGrid
            // 
            this.rtbGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbGrid.Font = new System.Drawing.Font("Minion Pro", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbGrid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.rtbGrid.Location = new System.Drawing.Point(12, 12);
            this.rtbGrid.Name = "rtbGrid";
            this.rtbGrid.ReadOnly = true;
            this.rtbGrid.Size = new System.Drawing.Size(737, 329);
            this.rtbGrid.TabIndex = 0;
            this.rtbGrid.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 353);
            this.Controls.Add(this.rtbGrid);
            this.Name = "Main";
            this.Text = "Robot Navigation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbGrid;
    }
}

