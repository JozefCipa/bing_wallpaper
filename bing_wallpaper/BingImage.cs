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

    /// <summary>
    /// Class BingImage
    /// 
    /// Explanation: 
    /// 1. create request to BingHost
    /// 2. find image name
    /// 3. return BingURL + image name from first request
    /// 
    /// </summary>
    class BingImage
    {
        private WebRequest RequestToHost;
        private StreamReader StreamReader;
       
        private Regex regex;
        private Match match;

        private string BingURL;
        private string BingHost;

        private BingImage(string BingURL)
        {
            
            // URL settings
            Uri Uri = new Uri(BingURL);
            BingHost = Uri.Scheme + "://" +  Uri.Host;
            this.BingURL = BingURL; 

            // Pattern to select image path from source code of BingURL
            regex = new Regex("url:'(.*?)'"); 

        }

        public static string GetImageURL(string BingURL)
        {
            return new BingImage(BingURL).GetImageURL();
        }
        
        public string GetImageURL()
        {
            return BingURL + GetImageName();
        } 
        
        private string GetImageName()
        {
            //Find image name in source
            match = regex.Match( GetSource() ); 

            if (match.Success)
                return Path.GetFileName( match.Value ).Replace("'", ""); //delete ' from end
            else
                throw new Exception("No match was found.");
        }

        private string GetSource()
        {

            try{

                RequestToHost = HttpWebRequest.Create(BingHost);
                RequestToHost.Method = "GET";
                StreamReader = new StreamReader(RequestToHost.GetResponse().GetResponseStream());
               
            }
            catch (WebException) { MessageBox.Show("Could not connect to" + BingHost); }
            catch (Exception e) { MessageBox.Show("Exception has been occured: \n\n" + e);}

            return StreamReader.ReadToEnd();
        }
    }
}
