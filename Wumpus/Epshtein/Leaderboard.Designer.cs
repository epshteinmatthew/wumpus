using System.ComponentModel;
using System.Windows.Forms;

namespace Wumpus.Epshtein
{
    partial class Leaderboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.ListBox leaderboardListBox;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.radioButtonTime = new System.Windows.Forms.RadioButton();
            this.radioButtonScore = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.leaderboardListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // leaderboardListBox
            // 
            this.leaderboardListBox.FormattingEnabled = true;
            this. leaderboardListBox.ItemHeight = 20;
            this.leaderboardListBox.Location = new System.Drawing.Point(58, 81);
            this.leaderboardListBox.Name = "leaderboardListBox";
            this.leaderboardListBox.Size = new System.Drawing.Size(191, 304);
            this.leaderboardListBox.TabIndex = 0;
            this. leaderboardListBox.SelectedIndexChanged += new System.EventHandler(this.leaderboardList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(268, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(268, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(268, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Time Spent";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(368, 81);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(134, 26);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxScore
            // 
            this.textBoxScore.Location = new System.Drawing.Point(368, 125);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.ReadOnly = true;
            this.textBoxScore.Size = new System.Drawing.Size(134, 26);
            this.textBoxScore.TabIndex = 5;
            // 
            // radioButtonTime
            // 
            this.radioButtonTime.Location = new System.Drawing.Point(58, 460);
            this.radioButtonTime.Name = "radioButtonTime";
            this.radioButtonTime.Size = new System.Drawing.Size(214, 34);
            this.radioButtonTime.TabIndex = 7;
            this.radioButtonTime.TabStop = true;
            this.radioButtonTime.Text = "Time (Lowest to Highest";
            this.radioButtonTime.UseVisualStyleBackColor = true;
            this.radioButtonTime.CheckedChanged += new System.EventHandler(this.radioButtonTime_CheckedChanged_1);
            // 
            // radioButtonScore
            // 
            this.radioButtonScore.Location = new System.Drawing.Point(58, 421);
            this.radioButtonScore.Name = "radioButtonScore";
            this.radioButtonScore.Size = new System.Drawing.Size(237, 33);
            this.radioButtonScore.TabIndex = 8;
            this.radioButtonScore.TabStop = true;
            this.radioButtonScore.Text = "Score (Highest to Lowest)";
            this.radioButtonScore.UseVisualStyleBackColor = true;
            this.radioButtonScore.CheckedChanged += new System.EventHandler(this.radioButtonScore_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(58, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Order By";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(58, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Hunt the Putin Leaderboard";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(368, 172);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(134, 26);
            this.textBoxTime.TabIndex = 11;
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 515);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButtonScore);
            this.Controls.Add(this.radioButtonTime);
            this.Controls.Add(this.textBoxScore);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leaderboardListBox);
            this.Name = "Leaderboard";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Leaderboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxName;

        private System.Windows.Forms.TextBox textBoxScore;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton radioButtonTime;
        private System.Windows.Forms.RadioButton radioButtonScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        #endregion
    }
}