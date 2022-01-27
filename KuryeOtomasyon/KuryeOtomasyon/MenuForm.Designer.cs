
namespace KuryeOtomasyon
{
    partial class MenuForm
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
            this.btnKurye = new System.Windows.Forms.Button();
            this.btnSiparis = new System.Windows.Forms.Button();
            this.btnGonderi = new System.Windows.Forms.Button();
            this.btnGonderiAta = new System.Windows.Forms.Button();
            this.btnKullanici = new System.Windows.Forms.Button();
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnGonderiGecmisi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKurye
            // 
            this.btnKurye.Location = new System.Drawing.Point(32, 22);
            this.btnKurye.Name = "btnKurye";
            this.btnKurye.Size = new System.Drawing.Size(158, 64);
            this.btnKurye.TabIndex = 0;
            this.btnKurye.Text = "Kurye İşlemler";
            this.btnKurye.UseVisualStyleBackColor = true;
            this.btnKurye.Click += new System.EventHandler(this.btnKurye_Click);
            // 
            // btnSiparis
            // 
            this.btnSiparis.Location = new System.Drawing.Point(211, 22);
            this.btnSiparis.Name = "btnSiparis";
            this.btnSiparis.Size = new System.Drawing.Size(158, 64);
            this.btnSiparis.TabIndex = 1;
            this.btnSiparis.Text = "Sipariş İşlemleri";
            this.btnSiparis.UseVisualStyleBackColor = true;
            this.btnSiparis.Click += new System.EventHandler(this.btnSiparis_Click);
            // 
            // btnGonderi
            // 
            this.btnGonderi.Location = new System.Drawing.Point(386, 22);
            this.btnGonderi.Name = "btnGonderi";
            this.btnGonderi.Size = new System.Drawing.Size(158, 64);
            this.btnGonderi.TabIndex = 2;
            this.btnGonderi.Text = "Gönderi İşlemleri";
            this.btnGonderi.UseVisualStyleBackColor = true;
            this.btnGonderi.Click += new System.EventHandler(this.btnGonderi_Click);
            // 
            // btnGonderiAta
            // 
            this.btnGonderiAta.Location = new System.Drawing.Point(32, 106);
            this.btnGonderiAta.Name = "btnGonderiAta";
            this.btnGonderiAta.Size = new System.Drawing.Size(158, 64);
            this.btnGonderiAta.TabIndex = 3;
            this.btnGonderiAta.Text = "Gönderi Ata";
            this.btnGonderiAta.UseVisualStyleBackColor = true;
            this.btnGonderiAta.Click += new System.EventHandler(this.btnGonderiAta_Click);
            // 
            // btnKullanici
            // 
            this.btnKullanici.Location = new System.Drawing.Point(211, 106);
            this.btnKullanici.Name = "btnKullanici";
            this.btnKullanici.Size = new System.Drawing.Size(158, 64);
            this.btnKullanici.TabIndex = 4;
            this.btnKullanici.Text = "Kullanıcı İşlemleri";
            this.btnKullanici.UseVisualStyleBackColor = true;
            this.btnKullanici.Click += new System.EventHandler(this.btnKullanici_Click);
            // 
            // btnMusteri
            // 
            this.btnMusteri.Location = new System.Drawing.Point(386, 106);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(158, 64);
            this.btnMusteri.TabIndex = 5;
            this.btnMusteri.Text = "Müşteri İşlemleri";
            this.btnMusteri.UseVisualStyleBackColor = true;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnGonderiGecmisi
            // 
            this.btnGonderiGecmisi.Location = new System.Drawing.Point(577, 22);
            this.btnGonderiGecmisi.Name = "btnGonderiGecmisi";
            this.btnGonderiGecmisi.Size = new System.Drawing.Size(158, 64);
            this.btnGonderiGecmisi.TabIndex = 6;
            this.btnGonderiGecmisi.Text = "Gönderi Geçmişi";
            this.btnGonderiGecmisi.UseVisualStyleBackColor = true;
            this.btnGonderiGecmisi.Click += new System.EventHandler(this.btnGonderiGecmisi_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 198);
            this.Controls.Add(this.btnGonderiGecmisi);
            this.Controls.Add(this.btnMusteri);
            this.Controls.Add(this.btnKullanici);
            this.Controls.Add(this.btnGonderiAta);
            this.Controls.Add(this.btnGonderi);
            this.Controls.Add(this.btnSiparis);
            this.Controls.Add(this.btnKurye);
            this.Name = "MenuForm";
            this.Text = "Menü";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKurye;
        private System.Windows.Forms.Button btnSiparis;
        private System.Windows.Forms.Button btnGonderi;
        private System.Windows.Forms.Button btnGonderiAta;
        private System.Windows.Forms.Button btnKullanici;
        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Button btnGonderiGecmisi;
    }
}