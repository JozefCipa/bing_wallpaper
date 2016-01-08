using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace bing_wallpaper
{
    class ImageManager
    {

        private HttpWebRequest RequestToImage;

        private Stream ResponseStream;
        private WebResponse ImageResponse;
        
        private FileStream FileStream;
        private BinaryReader BinaryReader;
        private BinaryWriter BinaryWriter;

        private byte[] Image;
        private string ImagePath;

        public bool Save( string ImagePath, string ImageURL){

            if (! Directory.Exists(ImagePath))
                Directory.CreateDirectory(ImagePath);

            string ImageName = Path.GetFileName(ImageURL);

            // Read image as byte array
            try
            {
                RequestToImage = (HttpWebRequest) WebRequest.Create(ImageURL);
                ImageResponse = RequestToImage.GetResponse();
                ResponseStream = ImageResponse.GetResponseStream();
                BinaryReader = new BinaryReader(ResponseStream);

                Image = BinaryReader.ReadBytes(500000);
            }
            catch (IOException) { MessageBox.Show("Failed to load image."); }
            finally
            {
                BinaryReader.Close();
                ResponseStream.Close();
                ImageResponse.Close();
            }
            
            // Write image to file
            FileStream = new FileStream(ImagePath + ImageName, FileMode.Create);
            BinaryWriter = new BinaryWriter(FileStream);

            try
            {
                BinaryWriter.Write(Image);
            }
            catch (IOException) { MessageBox.Show("Failed to save image."); }
            finally
            {
                FileStream.Close();
                BinaryWriter.Close();
            }

            this.ImagePath = ImagePath + ImageName;

            return File.Exists(this.ImagePath);
        }

        public string GetSavedImage()
        {
            return this.ImagePath;
        }

    }

    
}
