namespace Wumpus
{
    partial class StartingCutScene
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingCutScene));
            this.diffiultySelector = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // diffiultySelector
            // 
            this.diffiultySelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diffiultySelector.FormattingEnabled = true;
            this.diffiultySelector.Items.AddRange(new object[] {
            "Baby",
            "Easy",
            "Normal",
            "Hard"});
            this.diffiultySelector.Location = new System.Drawing.Point(118, 592);
            this.diffiultySelector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.diffiultySelector.Name = "diffiultySelector";
            this.diffiultySelector.Size = new System.Drawing.Size(180, 28);
            this.diffiultySelector.TabIndex = 0;
            this.diffiultySelector.SelectedIndexChanged += new System.EventHandler(this.diffiultySelector_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 631);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Continue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.Location = new System.Drawing.Point(458, 592);
            this.buttonMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(156, 35);
            this.buttonMenu.TabIndex = 2;
            this.buttonMenu.Text = "Back to Menu";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 592);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Difficulty:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(592, 498);
            this.label2.TabIndex = 4;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // StartingCutScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 698);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.diffiultySelector);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StartingCutScene";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartingCutScene";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.ComboBox diffiultySelector;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonMenu;
    }
}