namespace bing_wallpaper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.getWallpaper = new System.Windows.Forms.Button();
            this.getAutomatic = new System.Windows.Forms.CheckBox();
            this.WallpaperPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WallpaperPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // getWallpaper
            // 
            this.getWallpaper.Location = new System.Drawing.Point(202, 363);
            this.getWallpaper.Name = "getWallpaper";
            this.getWallpaper.Size = new System.Drawing.Size(228, 41);
            this.getWallpaper.TabIndex = 0;
            this.getWallpaper.Text = "Get Wallpaper";
            this.getWallpaper.UseVisualStyleBackColor = true;
            this.getWallpaper.Click += new System.EventHandler(this.getWallpaper_Click);
            // 
            // getAutomatic
            // 
            this.getAutomatic.AutoSize = true;
            this.getAutomatic.Location = new System.Drawing.Point(202, 340);
            this.getAutomatic.Name = "getAutomatic";
            this.getAutomatic.Size = new System.Drawing.Size(96, 17);
            this.getAutomatic.TabIndex = 1;
            this.getAutomatic.Text = "Run on startup";
            this.getAutomatic.UseVisualStyleBackColor = true;
            this.getAutomatic.CheckedChanged += new System.EventHandler(this.getAutomatic_CheckedChanged);
            // 
            // WallpaperPreview
            // 
            this.WallpaperPreview.Location = new System.Drawing.Point(12, 12);
            this.WallpaperPreview.Name = "WallpaperPreview";
            this.WallpaperPreview.Size = new System.Drawing.Size(418, 315);
            this.WallpaperPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WallpaperPreview.TabIndex = 2;
            this.WallpaperPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "©2016 joci";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(442, 413);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WallpaperPreview);
            this.Controls.Add(this.getAutomatic);
            this.Controls.Add(this.getWallpaper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bing Wallpaper";
            ((System.ComponentModel.ISupportInitialize)(this.WallpaperPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getWallpaper;
        private System.Windows.Forms.CheckBox getAutomatic;
        private System.Windows.Forms.PictureBox WallpaperPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

