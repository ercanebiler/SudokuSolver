namespace MultiThread
{
    partial class Form2
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
            this.Th1View = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Th1View
            // 
            this.Th1View.Location = new System.Drawing.Point(12, 12);
            this.Th1View.Name = "Th1View";
            this.Th1View.Size = new System.Drawing.Size(414, 416);
            this.Th1View.TabIndex = 0;
            this.Th1View.TileSize = new System.Drawing.Size(9, 9);
            this.Th1View.UseCompatibleStateImageBehavior = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 440);
            this.Controls.Add(this.Th1View);
            this.Name = "Form2";
            this.Text = "Thread 1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Th1View;
    }
}