namespace MultiThread
{
    partial class Form3
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
            this.Th2View = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Th2View
            // 
            this.Th2View.Location = new System.Drawing.Point(12, 12);
            this.Th2View.Name = "Th2View";
            this.Th2View.Size = new System.Drawing.Size(414, 416);
            this.Th2View.TabIndex = 0;
            this.Th2View.TileSize = new System.Drawing.Size(9, 9);
            this.Th2View.UseCompatibleStateImageBehavior = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 440);
            this.Controls.Add(this.Th2View);
            this.Name = "Form3";
            this.Text = "Thread 2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Th2View;
    }
}