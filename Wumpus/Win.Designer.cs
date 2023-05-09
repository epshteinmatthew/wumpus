namespace Wumpus
{
    partial class Win
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
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRetry = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 21);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonRetry
            // 
            this.buttonRetry.Location = new System.Drawing.Point(153, 106);
            this.buttonRetry.Name = "buttonRetry";
            this.buttonRetry.Size = new System.Drawing.Size(75, 21);
            this.buttonRetry.TabIndex = 5;
            this.buttonRetry.Text = "Try Again?";
            this.buttonRetry.UseVisualStyleBackColor = true;
            this.buttonRetry.Click += new System.EventHandler(this.buttonRetry_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "You Win!";
            // 
            // Win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 238);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRetry);
            this.Controls.Add(this.label1);
            this.Name = "Win";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Win";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRetry;
        private System.Windows.Forms.Label label1;
    }
}