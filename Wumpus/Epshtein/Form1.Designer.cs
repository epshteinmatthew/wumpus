using System.Windows.Forms;

namespace Epshtein
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConstructorButton = new System.Windows.Forms.Button();
            this.PlayerConstructorButton = new System.Windows.Forms.Button();
            this.buttonmovewump = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMovePlayer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxtoMove = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConstructorButton
            // 
            this.ConstructorButton.Location = new System.Drawing.Point(229, 12);
            this.ConstructorButton.Name = "ConstructorButton";
            this.ConstructorButton.Size = new System.Drawing.Size(147, 71);
            this.ConstructorButton.TabIndex = 0;
            this.ConstructorButton.Text = "Create Game Locations Object";
            this.ConstructorButton.UseVisualStyleBackColor = true;
            this.ConstructorButton.Click += new System.EventHandler(this.ConstructorButton_Click);
            // 
            // PlayerConstructorButton
            // 
            this.PlayerConstructorButton.Location = new System.Drawing.Point(382, 12);
            this.PlayerConstructorButton.Name = "PlayerConstructorButton";
            this.PlayerConstructorButton.Size = new System.Drawing.Size(147, 71);
            this.PlayerConstructorButton.TabIndex = 1;
            this.PlayerConstructorButton.Text = "Create Player Object";
            this.PlayerConstructorButton.UseVisualStyleBackColor = true;
            this.PlayerConstructorButton.Click += new System.EventHandler(this.PlayerConstructorButton_Click);
            // 
            // buttonmovewump
            // 
            this.buttonmovewump.Location = new System.Drawing.Point(81, 12);
            this.buttonmovewump.Name = "buttonmovewump";
            this.buttonmovewump.Size = new System.Drawing.Size(142, 71);
            this.buttonmovewump.TabIndex = 2;
            this.buttonmovewump.Text = "move wumpus";
            this.buttonmovewump.UseVisualStyleBackColor = true;
            this.buttonmovewump.Click += new System.EventHandler(this.buttonmovewump_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 80.25F);
            this.label1.Location = new System.Drawing.Point(78, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 120);
            this.label1.TabIndex = 3;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonMovePlayer
            // 
            this.buttonMovePlayer.Location = new System.Drawing.Point(81, 89);
            this.buttonMovePlayer.Name = "buttonMovePlayer";
            this.buttonMovePlayer.Size = new System.Drawing.Size(142, 71);
            this.buttonMovePlayer.TabIndex = 4;
            this.buttonMovePlayer.Text = "move player";
            this.buttonMovePlayer.UseVisualStyleBackColor = true;
            this.buttonMovePlayer.Click += new System.EventHandler(this.buttonMovePlayer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "rplayeroom";
            // 
            // textBoxtoMove
            // 
            this.textBoxtoMove.Location = new System.Drawing.Point(382, 115);
            this.textBoxtoMove.Name = "textBoxtoMove";
            this.textBoxtoMove.Size = new System.Drawing.Size(100, 20);
            this.textBoxtoMove.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.textBoxtoMove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonMovePlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonmovewump);
            this.Controls.Add(this.PlayerConstructorButton);
            this.Controls.Add(this.ConstructorButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ConstructorButton;
        private Button PlayerConstructorButton;
        private Button buttonmovewump;
        private Label label1;
        private Button buttonMovePlayer;
        private Label label2;
        private TextBox textBoxtoMove;
    }
}