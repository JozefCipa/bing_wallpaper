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

        Wallpaper Wallpaper;
        ImageManager image;

        SystemStartup StartOnBoot;

        string PathToImagesFolder;
        string ProgramPath;

        public Form1(bool LaunchedOnStartup)
        {
            InitializeComponent();

            StartOnBoot = new SystemStartup("BingWallpaper");
            Wallpaper = new Wallpaper();
            image = new ImageManager();

            //Set paths
            PathToImagesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ProgramPath = GetProgramPath();

            //set Checkbox state
            getAutomatic.Checked = StartOnBoot.IsOnStartup();

            if(LaunchedOnStartup)
            {
                getWallpaper_Click(null, null);

                if (Wallpaper.isSetCurrentWallpaper(image.GetSavedImage()))
                    Environment.Exit(0); 
                
            }

        }

        private void getWallpaper_Click(object sender, EventArgs e)
        {
            image.Save(PathToImagesFolder + @"\Bing Wallpapers\", BingImage.GetImageURL("http://www.bing.com/az/hprichbg/rb/"));

            Wallpaper.SetWallpaper(image.GetSavedImage());
        }

        private void getAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            if(getAutomatic.Checked)
                StartOnBoot.Register(ProgramPath);
            else
                StartOnBoot.Delete();
        }

        private string GetProgramPath()
        {
            ProgramPath = Application.ExecutablePath;
            ProgramPath = ProgramPath.Replace("/", "\\");
            ProgramPath += " /s"; // file path + command line parameter " /s"

            return ProgramPath;
        }

    }

}
