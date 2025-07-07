﻿namespace PA6_Draft
{
    partial class Chessboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chessboard));
            this.Board = new System.Windows.Forms.PictureBox();
            this.Player2Time = new System.Windows.Forms.TextBox();
            this.Player1Time = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.Player2 = new System.Windows.Forms.TextBox();
            this.Player1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Board)).BeginInit();
            this.SuspendLayout();
            // 
            // Board
            // 
            this.Board.Location = new System.Drawing.Point(24, 71);
            this.Board.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Board.MaximumSize = new System.Drawing.Size(1024, 985);
            this.Board.MinimumSize = new System.Drawing.Size(1024, 985);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(1024, 985);
            this.Board.TabIndex = 0;
            this.Board.TabStop = false;
            this.Board.Click += new System.EventHandler(this.Board_Click);
            this.Board.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.Board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Board_MouseDown);
            this.Board.MouseLeave += new System.EventHandler(this.Board_MouseLeave);
            this.Board.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Board_MouseMove);
            this.Board.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Board_MouseUp);
            // 
            // Player2Time
            // 
            this.Player2Time.BackColor = System.Drawing.SystemColors.Menu;
            this.Player2Time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Player2Time.Enabled = false;
            this.Player2Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Time.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Player2Time.Location = new System.Drawing.Point(946, 21);
            this.Player2Time.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Player2Time.Name = "Player2Time";
            this.Player2Time.Size = new System.Drawing.Size(102, 37);
            this.Player2Time.TabIndex = 1;
            // 
            // Player1Time
            // 
            this.Player1Time.BackColor = System.Drawing.SystemColors.Menu;
            this.Player1Time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Player1Time.Enabled = false;
            this.Player1Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Time.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Player1Time.Location = new System.Drawing.Point(946, 1067);
            this.Player1Time.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Player1Time.Name = "Player1Time";
            this.Player1Time.Size = new System.Drawing.Size(102, 37);
            this.Player1Time.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.AliceBlue;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 37;
            this.listBox1.Location = new System.Drawing.Point(1078, 87);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(466, 966);
            this.listBox1.TabIndex = 9;
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 15;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // Player2
            // 
            this.Player2.BackColor = System.Drawing.SystemColors.Menu;
            this.Player2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Player2.Enabled = false;
            this.Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Player2.Location = new System.Drawing.Point(24, 21);
            this.Player2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(322, 37);
            this.Player2.TabIndex = 10;
            // 
            // Player1
            // 
            this.Player1.BackColor = System.Drawing.SystemColors.Menu;
            this.Player1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Player1.Enabled = false;
            this.Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Player1.Location = new System.Drawing.Point(24, 1067);
            this.Player1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(322, 37);
            this.Player1.TabIndex = 11;
            // 
            // Chessboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1592, 1140);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Player1Time);
            this.Controls.Add(this.Player2Time);
            this.Controls.Add(this.Board);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Chessboard";
            this.Text = "Chessboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chessboard_FormClosed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChessBoard_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.Board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Board;
        private System.Windows.Forms.TextBox Player2Time;
        private System.Windows.Forms.TextBox Player1Time;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.TextBox Player2;
        private System.Windows.Forms.TextBox Player1;
    }
}