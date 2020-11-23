
namespace L2_TicTacToe
{
    partial class Form1
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
            this.B00 = new System.Windows.Forms.Button();
            this.B10 = new System.Windows.Forms.Button();
            this.B20 = new System.Windows.Forms.Button();
            this.B21 = new System.Windows.Forms.Button();
            this.B11 = new System.Windows.Forms.Button();
            this.B01 = new System.Windows.Forms.Button();
            this.B22 = new System.Windows.Forms.Button();
            this.B12 = new System.Windows.Forms.Button();
            this.B02 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B00
            // 
            this.B00.Location = new System.Drawing.Point(13, 13);
            this.B00.Name = "B00";
            this.B00.Size = new System.Drawing.Size(55, 55);
            this.B00.TabIndex = 0;
            this.B00.UseVisualStyleBackColor = true;
            this.B00.Click += new System.EventHandler(this.B00_Click);
            // 
            // B10
            // 
            this.B10.Location = new System.Drawing.Point(74, 13);
            this.B10.Name = "B10";
            this.B10.Size = new System.Drawing.Size(55, 55);
            this.B10.TabIndex = 1;
            this.B10.UseVisualStyleBackColor = true;
            this.B10.Click += new System.EventHandler(this.B10_Click);
            // 
            // B20
            // 
            this.B20.Location = new System.Drawing.Point(135, 12);
            this.B20.Name = "B20";
            this.B20.Size = new System.Drawing.Size(55, 55);
            this.B20.TabIndex = 2;
            this.B20.UseVisualStyleBackColor = true;
            this.B20.Click += new System.EventHandler(this.B20_Click);
            // 
            // B21
            // 
            this.B21.Location = new System.Drawing.Point(135, 73);
            this.B21.Name = "B21";
            this.B21.Size = new System.Drawing.Size(55, 55);
            this.B21.TabIndex = 5;
            this.B21.UseVisualStyleBackColor = true;
            this.B21.Click += new System.EventHandler(this.B21_Click);
            // 
            // B11
            // 
            this.B11.Location = new System.Drawing.Point(74, 74);
            this.B11.Name = "B11";
            this.B11.Size = new System.Drawing.Size(55, 55);
            this.B11.TabIndex = 4;
            this.B11.UseVisualStyleBackColor = true;
            this.B11.Click += new System.EventHandler(this.B11_Click);
            // 
            // B01
            // 
            this.B01.Location = new System.Drawing.Point(13, 74);
            this.B01.Name = "B01";
            this.B01.Size = new System.Drawing.Size(55, 55);
            this.B01.TabIndex = 3;
            this.B01.UseVisualStyleBackColor = true;
            this.B01.Click += new System.EventHandler(this.B01_Click);
            // 
            // B22
            // 
            this.B22.Location = new System.Drawing.Point(135, 133);
            this.B22.Name = "B22";
            this.B22.Size = new System.Drawing.Size(55, 55);
            this.B22.TabIndex = 8;
            this.B22.UseVisualStyleBackColor = true;
            this.B22.Click += new System.EventHandler(this.B22_Click);
            // 
            // B12
            // 
            this.B12.Location = new System.Drawing.Point(74, 134);
            this.B12.Name = "B12";
            this.B12.Size = new System.Drawing.Size(55, 55);
            this.B12.TabIndex = 7;
            this.B12.UseVisualStyleBackColor = true;
            this.B12.Click += new System.EventHandler(this.B12_Click);
            // 
            // B02
            // 
            this.B02.Location = new System.Drawing.Point(13, 134);
            this.B02.Name = "B02";
            this.B02.Size = new System.Drawing.Size(55, 55);
            this.B02.TabIndex = 6;
            this.B02.UseVisualStyleBackColor = true;
            this.B02.Click += new System.EventHandler(this.B02_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 201);
            this.Controls.Add(this.B22);
            this.Controls.Add(this.B12);
            this.Controls.Add(this.B02);
            this.Controls.Add(this.B21);
            this.Controls.Add(this.B11);
            this.Controls.Add(this.B01);
            this.Controls.Add(this.B20);
            this.Controls.Add(this.B10);
            this.Controls.Add(this.B00);
            this.Name = "Tic Tac Toe";
            this.Text = "Tic Tac Toe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B00;
        private System.Windows.Forms.Button B10;
        private System.Windows.Forms.Button B20;
        private System.Windows.Forms.Button B21;
        private System.Windows.Forms.Button B11;
        private System.Windows.Forms.Button B01;
        private System.Windows.Forms.Button B22;
        private System.Windows.Forms.Button B12;
        private System.Windows.Forms.Button B02;
    }
}

