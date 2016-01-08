using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace bing_wallpaper
{
    class SystemStartup
    {
        private RegistryKey Reg;
        private string Name;

        public SystemStartup(string Name)
        {
            Reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            this.Name = Name;
        }

        public void Register(string FilePath)
        {
            Reg.SetValue(Name, FilePath);
        }

        public void Delete()
        {
            Reg.DeleteValue(Name);
        }

        public bool IsOnStartup() 
        { 
            return Reg.GetValue(Name) != null;
        }
    }
}
