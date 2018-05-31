namespace B18_Ex05_Gregory_317612950_Mariya_321373136
{
    partial class GameSettings
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
            this.groupBoxBoardSize = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSecondPlayer = new System.Windows.Forms.TextBox();
            this.CheckBoxSecondPlayer = new System.Windows.Forms.CheckBox();
            this.textBoxFirstPlayer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxBoardSize.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBoardSize
            // 
            this.groupBoxBoardSize.Controls.Add(this.radioButton3);
            this.groupBoxBoardSize.Controls.Add(this.radioButton2);
            this.groupBoxBoardSize.Controls.Add(this.radioButton1);
            this.groupBoxBoardSize.Location = new System.Drawing.Point(27, 20);
            this.groupBoxBoardSize.Name = "groupBoxBoardSize";
            this.groupBoxBoardSize.Size = new System.Drawing.Size(251, 65);
            this.groupBoxBoardSize.TabIndex = 0;
            this.groupBoxBoardSize.TabStop = false;
            this.groupBoxBoardSize.Text = "Board Size";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(160, 29);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(60, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "10 x 10";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(87, 29);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "8 x 8";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "6 x 6";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSecondPlayer);
            this.groupBox2.Controls.Add(this.CheckBoxSecondPlayer);
            this.groupBox2.Controls.Add(this.textBoxFirstPlayer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(27, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 115);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Players:";
            // 
            // textBoxSecondPlayer
            // 
            this.textBoxSecondPlayer.Enabled = false;
            this.textBoxSecondPlayer.Location = new System.Drawing.Point(87, 63);
            this.textBoxSecondPlayer.Name = "textBoxSecondPlayer";
            this.textBoxSecondPlayer.Size = new System.Drawing.Size(146, 20);
            this.textBoxSecondPlayer.TabIndex = 4;
            this.textBoxSecondPlayer.Text = "Computer";
            // 
            // CheckBoxSecondPlayer
            // 
            this.CheckBoxSecondPlayer.AutoSize = true;
            this.CheckBoxSecondPlayer.Location = new System.Drawing.Point(14, 68);
            this.CheckBoxSecondPlayer.Name = "CheckBoxSecondPlayer";
            this.CheckBoxSecondPlayer.Size = new System.Drawing.Size(67, 17);
            this.CheckBoxSecondPlayer.TabIndex = 3;
            this.CheckBoxSecondPlayer.Text = "Player 2:";
            this.CheckBoxSecondPlayer.UseVisualStyleBackColor = true;
            this.CheckBoxSecondPlayer.CheckStateChanged += new System.EventHandler(this.checkBoxSecondPlayer_CheckStateChanged);
            // 
            // textBoxFirstPlayer
            // 
            this.textBoxFirstPlayer.Location = new System.Drawing.Point(87, 31);
            this.textBoxFirstPlayer.Name = "textBoxFirstPlayer";
            this.textBoxFirstPlayer.Size = new System.Drawing.Size(146, 20);
            this.textBoxFirstPlayer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(203, 243);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start Game";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 283);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GameSettings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameSettings_FormClosed);
            this.groupBoxBoardSize.ResumeLayout(false);
            this.groupBoxBoardSize.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBoardSize;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxSecondPlayer;
        private System.Windows.Forms.CheckBox CheckBoxSecondPlayer;
        private System.Windows.Forms.TextBox textBoxFirstPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
    }
}