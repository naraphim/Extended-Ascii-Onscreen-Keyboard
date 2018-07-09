namespace Keyboard_1
{
    partial class Onscreen_Arrows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Onscreen_Arrows));
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 0;
            // 
            // Onscreen_Arrows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(2)))), ((int)(((byte)(1)))));
            this.BackgroundImage = global::Keyboard_1.Properties.Resources.Arrows_Small_Underlay;
            this.ClientSize = new System.Drawing.Size(292, 212);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Onscreen_Arrows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Onscreen Arrows";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(2)))), ((int)(((byte)(1)))));
            this.Load += new System.EventHandler(this.Onscreen_Arrows_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Onscreen_Arrows_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Onscreen_Arrows_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Onscreen_Arrows_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Onscreen_Arrows_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
    }
}