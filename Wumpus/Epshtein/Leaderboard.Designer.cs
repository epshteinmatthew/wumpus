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
            this.buttonBack = new System.Windows.Forms.Button();
            this.leaderboardListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // leaderboardListBox
            // 
            this.leaderboardListBox.FormattingEnabled = true;
            this.leaderboardListBox.Location = new System.Drawing.Point(39, 53);
            this.leaderboardListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.leaderboardListBox.Name = "leaderboardListBox";
            this.leaderboardListBox.Size = new System.Drawing.Size(129, 199);
            this.leaderboardListBox.TabIndex = 0;
            this.leaderboardListBox.SelectedIndexChanged += new System.EventHandler(this.leaderboardList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(179, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(179, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(179, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Time Spent";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(245, 53);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(91, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxScore
            // 
            this.textBoxScore.Enabled = false;
            this.textBoxScore.Location = new System.Drawing.Point(245, 81);
            this.textBoxScore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.ReadOnly = true;
            this.textBoxScore.Size = new System.Drawing.Size(91, 20);
            this.textBoxScore.TabIndex = 5;
            // 
            // radioButtonTime
            // 
            this.radioButtonTime.Location = new System.Drawing.Point(39, 299);
            this.radioButtonTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonTime.Name = "radioButtonTime";
            this.radioButtonTime.Size = new System.Drawing.Size(143, 22);
            this.radioButtonTime.TabIndex = 7;
            this.radioButtonTime.TabStop = true;
            this.radioButtonTime.Text = "Time (Lowest to Highest";
            this.radioButtonTime.UseVisualStyleBackColor = true;
            this.radioButtonTime.CheckedChanged += new System.EventHandler(this.radioButtonTime_CheckedChanged_1);
            // 
            // radioButtonScore
            // 
            this.radioButtonScore.Location = new System.Drawing.Point(39, 274);
            this.radioButtonScore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonScore.Name = "radioButtonScore";
            this.radioButtonScore.Size = new System.Drawing.Size(158, 21);
            this.radioButtonScore.TabIndex = 8;
            this.radioButtonScore.TabStop = true;
            this.radioButtonScore.Text = "Score (Highest to Lowest)";
            this.radioButtonScore.UseVisualStyleBackColor = true;
            this.radioButtonScore.CheckedChanged += new System.EventHandler(this.radioButtonScore_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(39, 257);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Order By";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(39, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Hunt the Putin Leaderboard";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Enabled = false;
            this.textBoxTime.Location = new System.Drawing.Point(245, 112);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(91, 20);
            this.textBoxTime.TabIndex = 11;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(179, 222);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(97, 28);
            this.buttonBack.TabIndex = 12;
            this.buttonBack.Text = "Back to Menu";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 335);
            this.Controls.Add(this.buttonBack);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Leaderboard";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Leaderboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button buttonBack;

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