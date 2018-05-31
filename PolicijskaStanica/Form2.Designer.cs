namespace PolicijskaStanica
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
            this.btn_Operacija = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btn_Operacija
            // 
            this.btn_Operacija.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Operacija.Location = new System.Drawing.Point(270, 478);
            this.btn_Operacija.Name = "btn_Operacija";
            this.btn_Operacija.Size = new System.Drawing.Size(270, 42);
            this.btn_Operacija.TabIndex = 0;
            this.btn_Operacija.Text = "Operacija";
            this.btn_Operacija.UseVisualStyleBackColor = true;
            this.btn_Operacija.Click += new System.EventHandler(this.btn_Operacija_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 460);
            this.panel1.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 532);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Operacija);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Operacija;
        private System.Windows.Forms.Panel panel1;
    }
}