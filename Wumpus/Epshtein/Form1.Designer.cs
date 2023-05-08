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
            this.SuspendLayout();
            // 
            // ConstructorButton
            // 
            this.ConstructorButton.Location = new System.Drawing.Point(117, 147);
            this.ConstructorButton.Name = "ConstructorButton";
            this.ConstructorButton.Size = new System.Drawing.Size(147, 71);
            this.ConstructorButton.TabIndex = 0;
            this.ConstructorButton.Text = "Create Game Locations Object";
            this.ConstructorButton.UseVisualStyleBackColor = true;
            this.ConstructorButton.Click += new System.EventHandler(this.ConstructorButton_Click);
            // 
            // PlayerConstructorButton
            // 
            this.PlayerConstructorButton.Location = new System.Drawing.Point(363, 147);
            this.PlayerConstructorButton.Name = "PlayerConstructorButton";
            this.PlayerConstructorButton.Size = new System.Drawing.Size(147, 71);
            this.PlayerConstructorButton.TabIndex = 1;
            this.PlayerConstructorButton.Text = "Create Player Object";
            this.PlayerConstructorButton.UseVisualStyleBackColor = true;
            this.PlayerConstructorButton.Click += new System.EventHandler(this.PlayerConstructorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.PlayerConstructorButton);
            this.Controls.Add(this.ConstructorButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button ConstructorButton;
        private Button PlayerConstructorButton;
    }
}