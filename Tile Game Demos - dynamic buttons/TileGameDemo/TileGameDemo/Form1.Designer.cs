
namespace TileGameDemo
{
    partial class TileDemo
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
            this.Easy = new System.Windows.Forms.Button();
            this.CountDown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Easy
            // 
            this.Easy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Easy.Location = new System.Drawing.Point(53, 48);
            this.Easy.Margin = new System.Windows.Forms.Padding(0);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(144, 36);
            this.Easy.TabIndex = 0;
            this.Easy.Text = "Easy";
            this.Easy.UseVisualStyleBackColor = true;
            this.Easy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Easy_Click);
            // 
            // CountDown
            // 
            this.CountDown.AutoSize = true;
            this.CountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.CountDown.Location = new System.Drawing.Point(307, 51);
            this.CountDown.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(0, 32);
            this.CountDown.TabIndex = 2;
            // 
            // TileDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1082, 528);
            this.Controls.Add(this.CountDown);
            this.Controls.Add(this.Easy);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "TileDemo";
            this.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Text = "Tile Demo";
            this.Load += new System.EventHandler(this.TileDemo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Easy;
        private System.Windows.Forms.Label CountDown;
    }
}

