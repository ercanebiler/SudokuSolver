namespace MultiThread
{
    partial class Form4
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
            this.Th3View = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Th3View
            // 
            this.Th3View.Location = new System.Drawing.Point(12, 12);
            this.Th3View.Name = "Th3View";
            this.Th3View.Size = new System.Drawing.Size(414, 416);
            this.Th3View.TabIndex = 0;
            this.Th3View.UseCompatibleStateImageBehavior = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 440);
            this.Controls.Add(this.Th3View);
            this.Name = "Form4";
            this.Text = "Thread 3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Th3View;
    }
}