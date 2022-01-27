
namespace KuryeOtomasyon
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGonderiler = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbKurye = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGonderiler)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGonderiler);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 378);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gönderiler";
            // 
            // dgvGonderiler
            // 
            this.dgvGonderiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGonderiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGonderiler.Location = new System.Drawing.Point(3, 16);
            this.dgvGonderiler.Name = "dgvGonderiler";
            this.dgvGonderiler.Size = new System.Drawing.Size(571, 359);
            this.dgvGonderiler.TabIndex = 0;
            this.dgvGonderiler.SelectionChanged += new System.EventHandler(this.dgvGonderiler_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 56);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kurye Ata";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbKurye
            // 
            this.cmbKurye.FormattingEnabled = true;
            this.cmbKurye.Location = new System.Drawing.Point(701, 60);
            this.cmbKurye.Name = "cmbKurye";
            this.cmbKurye.Size = new System.Drawing.Size(121, 21);
            this.cmbKurye.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kurye";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(675, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 56);
            this.button2.TabIndex = 4;
            this.button2.Text = "Otomatk Dağıt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 415);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKurye);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGonderiler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvGonderiler;
        private System.Windows.Forms.ComboBox cmbKurye;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}

