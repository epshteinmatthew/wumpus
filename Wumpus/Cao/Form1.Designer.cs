namespace Cao
{
    partial class SubmitAnswerButton
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
            this.TriviaQuestion = new System.Windows.Forms.Label();
            this.Answer1 = new System.Windows.Forms.RadioButton();
            this.Answer2 = new System.Windows.Forms.RadioButton();
            this.Answer3 = new System.Windows.Forms.RadioButton();
            this.Answer4 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TriviaQuestion
            // 
            this.TriviaQuestion.AutoSize = true;
            this.TriviaQuestion.Location = new System.Drawing.Point(71, 40);
            this.TriviaQuestion.Name = "TriviaQuestion";
            this.TriviaQuestion.Size = new System.Drawing.Size(35, 13);
            this.TriviaQuestion.TabIndex = 0;
            this.TriviaQuestion.Text = "label1";
            // 
            // Answer1
            // 
            this.Answer1.AutoSize = true;
            this.Answer1.Location = new System.Drawing.Point(74, 72);
            this.Answer1.Name = "Answer1";
            this.Answer1.Size = new System.Drawing.Size(85, 17);
            this.Answer1.TabIndex = 1;
            this.Answer1.TabStop = true;
            this.Answer1.Text = "radioButton1";
            this.Answer1.UseVisualStyleBackColor = true;
            // 
            // Answer2
            // 
            this.Answer2.AutoSize = true;
            this.Answer2.Location = new System.Drawing.Point(74, 95);
            this.Answer2.Name = "Answer2";
            this.Answer2.Size = new System.Drawing.Size(85, 17);
            this.Answer2.TabIndex = 2;
            this.Answer2.TabStop = true;
            this.Answer2.Text = "radioButton2";
            this.Answer2.UseVisualStyleBackColor = true;
            // 
            // Answer3
            // 
            this.Answer3.AutoSize = true;
            this.Answer3.Location = new System.Drawing.Point(74, 118);
            this.Answer3.Name = "Answer3";
            this.Answer3.Size = new System.Drawing.Size(85, 17);
            this.Answer3.TabIndex = 3;
            this.Answer3.TabStop = true;
            this.Answer3.Text = "radioButton3";
            this.Answer3.UseVisualStyleBackColor = true;
            // 
            // Answer4
            // 
            this.Answer4.AutoSize = true;
            this.Answer4.Location = new System.Drawing.Point(74, 141);
            this.Answer4.Name = "Answer4";
            this.Answer4.Size = new System.Drawing.Size(85, 17);
            this.Answer4.TabIndex = 4;
            this.Answer4.TabStop = true;
            this.Answer4.Text = "radioButton4";
            this.Answer4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubmitAnswerButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 266);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Answer4);
            this.Controls.Add(this.Answer3);
            this.Controls.Add(this.Answer2);
            this.Controls.Add(this.Answer1);
            this.Controls.Add(this.TriviaQuestion);
            this.Name = "SubmitAnswerButton";
            this.Text = "Trivia Form";
            this.Load += new System.EventHandler(this.SubmitAnswerButton_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TriviaQuestion;
        private System.Windows.Forms.RadioButton Answer1;
        private System.Windows.Forms.RadioButton Answer2;
        private System.Windows.Forms.RadioButton Answer3;
        private System.Windows.Forms.RadioButton Answer4;
        private System.Windows.Forms.Button button1;
    }
}

