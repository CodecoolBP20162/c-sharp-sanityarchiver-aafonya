namespace SanityArchiverWinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OldFileNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NewFileNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // OldFileNameLabel
            // 
            this.OldFileNameLabel.AutoSize = true;
            this.OldFileNameLabel.Location = new System.Drawing.Point(82, 20);
            this.OldFileNameLabel.Name = "OldFileNameLabel";
            this.OldFileNameLabel.Size = new System.Drawing.Size(67, 13);
            this.OldFileNameLabel.TabIndex = 1;
            this.OldFileNameLabel.Text = "OldFileName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // NewFileNameLabel
            // 
            this.NewFileNameLabel.AutoSize = true;
            this.NewFileNameLabel.Location = new System.Drawing.Point(82, 97);
            this.NewFileNameLabel.Name = "NewFileNameLabel";
            this.NewFileNameLabel.Size = new System.Drawing.Size(73, 13);
            this.NewFileNameLabel.TabIndex = 3;
            this.NewFileNameLabel.Text = "NewFileName";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.NewFileNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OldFileNameLabel);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label OldFileNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NewFileNameLabel;
    }
}