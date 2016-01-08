using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace bing_wallpaper
{
    class Wallpaper
    {

        /* Wallpaper settings */
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);
        private readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        public void SetWallpaper(string ImagePath)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, ImagePath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public string GetWallpaperPath()
        {
            RegistryKey CurrentWallpaper = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            return CurrentWallpaper.GetValue("Wallpaper").ToString();
        }

        public bool isSetCurrentWallpaper(string ImagePath)
        {
            return ImagePath == GetWallpaperPath();
        }
    }
}
