using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;
using System.IO;

namespace bing_wallpaper
{
    public partial class Form1 : Form
    {

        BingWallpaper Wallpaper;
        RegistryKey StartOnBoot;
        RegistryKey CurrentWallpaper;

        string AppLocation = "";
        string PathToImagesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        bool SavedImage = false;
        bool IsSetCurrentImage = false;

        public Form1(bool LaunchedOnStartup)
        {
            InitializeComponent();

            Wallpaper = BingWallpaper.GetWallpaper("http://www.bing.com", PathToImagesFolder + @"\Bing Wallpapers\");

            StartOnBoot = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            CurrentWallpaper = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            getAutomatic.Checked = IsStartup();
            
            
            if(LaunchedOnStartup)
            {
                MakeWallpaper();

                if (SavedImage && IsSetCurrentImage)
                     Environment.Exit(-1);
            }

        }

        private void getWallpaper_Click(object sender, EventArgs e)
        {
            MakeWallpaper();
        }

        private void MakeWallpaper()
        {

            Wallpaper.GetSource();

            if (Wallpaper.CheckSource())
            {

                // Wallpaper.EditImagePath();

                Wallpaper.Result = Wallpaper.Result.Remove(0, 6);
                Wallpaper.Result = Wallpaper.Result.Remove(Wallpaper.Result.Length - 1, 1);

                Wallpaper.Result = Wallpaper.Result.Remove(0, 15);


                /* Set Image */

                WallpaperPreview.Width = 418;
                WallpaperPreview.Height = 315;
                WallpaperPreview.ImageLocation = "http://www.bing.com/az/hprichbg/rb/" + Wallpaper.Result;

                Wallpaper.GetImage();
                SavedImage = Wallpaper.SaveImage();


                /* set background */
                Wallpaper.SetWallpaper();
                IsSetCurrentImage = GetCurrentWallpaper( CurrentWallpaper.GetValue("Wallpaper").ToString());

            }

            else
            {
                MessageBox.Show("String not found.");
            }

        }

        private void getAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            RegisterInStartup(getAutomatic.Checked);
        }

        private void RegisterInStartup(bool isChecked)
        {
            
            if (isChecked)
            {
                AppLocation = Application.ExecutablePath;
                AppLocation = AppLocation.Replace("/", "\\");
                AppLocation += " /s"; // file path + command line parameter " /s"

                StartOnBoot.SetValue("BingWallpaper", AppLocation);
            }
            else
                StartOnBoot.DeleteValue("BingWallpaper");
            
        }

        private bool IsStartup()
        {
            return StartOnBoot.GetValue("BingWallpaper") == null;
        }

        private bool GetCurrentWallpaper(string CurrentWallpaperPath)
        {
            return CurrentWallpaperPath == Wallpaper.SaveLocation + Wallpaper.Result;
        }
   
    }

}
