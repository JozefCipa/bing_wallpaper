using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace bing_wallpaper
{
    class BingWallpaper
    {
        private WebRequest webRequest;
        private HttpWebRequest imageRequest;
        private WebResponse imageResponse;
        
        private Stream responseStream;
        private FileStream fileStream;

        private BinaryReader binaryReader;
        private StreamReader streamReader;
        private BinaryWriter binaryWriter;
       
        private Regex regex;
        //private MatchCollection mc;
        private Match match;

        public string image_path;
        private string source;
        public string Result;
        public string SaveLocation;
        private string bing_url;

        public static BingWallpaper Wallpaper = null;

        private byte[] imageBytes; //array to read image

        /* Wallpaper settings */
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);
        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;



        private BingWallpaper(string bing_url, string saveLocation)
        {
            this.source = "";
            this.Result = "";
            this.bing_url = bing_url;
            this.SaveLocation = saveLocation;
      
            this.image_path = "";
            this.webRequest = HttpWebRequest.Create(bing_url);
            this.regex = new Regex("url:'(.*?)'"); // Pattern to select image path from source code from bing.com page
            
        }

        public static BingWallpaper GetWallpaper(string bing_url, string saveLocation)
        {
            if (Wallpaper == null)
                Wallpaper = new BingWallpaper(bing_url, saveLocation);

            return Wallpaper;
        }

        public string GetSource()
        {
            webRequest.Method = "GET";

            try{

                streamReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                source = streamReader.ReadToEnd();
            }
            catch (WebException e) { MessageBox.Show("Connection failed." + bing_url); Environment.Exit(1); }
            catch (Exception e) { MessageBox.Show("Exception has been occured: \n\n" + e); Environment.Exit(1); }
            
            return source;
        }

        public bool CheckSource()
        {
           match = regex.Match(source); //Comparing source code with pattern

            if (match.Success)
            {
                Result = match.Value;
                return true;
            }else
                return false;
           
            /*
            mc = regex.Matches(source);

            int mIdx = 0;
            foreach (Match match in mc)
            {
                for (int gIdx = 0; gIdx < match.Groups.Count; gIdx++)
                {
                    Console.WriteLine("[{0}][{1}] = {2}", mIdx, regex.GetGroupNames()[gIdx], match.Groups[gIdx].Value);
                    Console.WriteLine("dkl " + match.Groups[1].Value);
                }

                mIdx++;
            }
            return false;*/

        }

        public void EditImagePath()
        {
           
            Result = Result.Remove(0, 6); //delete url://
            Result = Result.Remove(Wallpaper.Result.Length - 1, 1); //delete '
            Result = Result.Remove(0, 15); // extract image name
             
        }

        public void GetImage()
        {
            
            imageRequest = (HttpWebRequest) WebRequest.Create("http://www.bing.com/az/hprichbg/rb/" + Result);
            imageResponse = imageRequest.GetResponse();
            responseStream = imageResponse.GetResponseStream();

            binaryReader = new BinaryReader(responseStream);
            imageBytes = binaryReader.ReadBytes(500000);
            binaryReader.Close();

            responseStream.Close();
            imageResponse.Close();

        }
        public bool SaveImage()
        {

            if (!Directory.Exists(SaveLocation))
                Directory.CreateDirectory(SaveLocation); 

            fileStream = new FileStream(SaveLocation + Result, FileMode.Create); 
            binaryWriter = new BinaryWriter(fileStream);

            try
            {
                binaryWriter.Write(imageBytes);
            }
            finally
            {
               
                fileStream.Close();
                binaryWriter.Close();
            }

            if (File.Exists(SaveLocation + Result))
                return true;
            else
                return false;
        }

        public void SetWallpaper()
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, SaveLocation + Result , SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

    }
}
