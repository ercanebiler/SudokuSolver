namespace MultiThread
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.DosyaSec = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // DosyaSec
            // 
            this.DosyaSec.Location = new System.Drawing.Point(12, 12);
            this.DosyaSec.Name = "DosyaSec";
            this.DosyaSec.Size = new System.Drawing.Size(414, 23);
            this.DosyaSec.TabIndex = 0;
            this.DosyaSec.Text = "Sudoku Yükle";
            this.DosyaSec.UseVisualStyleBackColor = true;
            this.DosyaSec.Click += new System.EventHandler(this.DosyaSec_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(414, 387);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 440);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.DosyaSec);
            this.Name = "Form1";
            this.Text = "Sudoku";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DosyaSec;
        private System.Windows.Forms.ListView listView1;
    }
}

