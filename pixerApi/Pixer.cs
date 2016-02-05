using pixerApi.Inner;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace pixerApi
{
   
    unsafe public class Pixer
    {
        private string pathTemp = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf('\\')) + "\\temp\\";
        public enum FileWeightFormat { BYTE, KB, MB, GB }
        public enum Format { BMP, JPEG}
        public Pixer() { }
        public Pixer(PictureBox workspace)
        {
            Buffer.workspace = workspace;
        }

        public void Initialization(PictureBox workspace)
        {
            Buffer.workspace = workspace;
        }
        public void InitializationHistogram(PictureBox histogram)
        {
            Buffer.histogram = histogram;
        }
        public void LoadImage(string source)
        {
            try
            {
                using (Bitmap bm = new Bitmap(source))
                {
                   Buffer.setData(new Bitmap(bm),"Start");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int widthImage { get { return Buffer.Width; } }
        public int heightImage { get { return Buffer.Height; } }
        public void Undo()
        {
            Buffer.getDownImage();
        }
        public void getSpecificImage(int number)
        {
            Buffer.getSpecificImage(number);
        }
        public void recoveryWorkspace()
        {
            Buffer.recoveryWorkspace();
            Buffer.Refrash();
        }

        public int getWorkingPosition { get { return Buffer.getWorkingPosition; } }
        public int getCountMemory{ get { return Buffer.getCountMemory; } }
       
        public void Redo() {
          Buffer.getUpImage();
        }

        /// <summary>
        /// Получает значения цвета выбранного пикселя.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixelColor(int x, int y)
        {
           int i = y * Buffer.stride + x * 4;
            return Color.FromArgb(Buffer.ptrFirstPixel[i],
                Buffer.ptrFirstPixel[i + 1],
                Buffer.ptrFirstPixel[i + 2]);
           
        }

        public Dictionary<Bitmap, string> GetStoryAction() { return new Dictionary<Bitmap, string>(); }

        public Bitmap showSaveImage(int compression = 0)
        {
            SaveJpgViser(pathTemp + "tempImageAfterCompression.jpg", compression);
            using (Bitmap bm = new Bitmap(pathTemp + "tempImageAfterCompression.jpg"))
            {

                    saveImg = new Bitmap(bm);

            }
            
            return saveImg;
        }
        public double FileWeightBefore(FileWeightFormat format)
        {
            SaveJpg(pathTemp + "tempImageBefore.jpg", 100);
            return weightFile(pathTemp + "tempImageBefore.jpg", format);
        }
        public double FileWeightAfter(FileWeightFormat format)
        {
            return weightFile(pathTemp + "tempImageAfterCompression.jpg", format);
        }
        private double weightFile(String FileName, FileWeightFormat format)
        {
            FileStream file = File.Open(FileName, FileMode.Open);
            double fileWeight = file.Length;
            file.Close();
            switch (format)
            {
                case FileWeightFormat.BYTE: return Math.Round(fileWeight, 2);
                case FileWeightFormat.KB: return Math.Round(fileWeight / 1024, 2);
                case FileWeightFormat.MB: return Math.Round(fileWeight / 1024 / 1024, 2);
                case FileWeightFormat.GB: return Math.Round(fileWeight / 1024 / 1024 / 1024, 2);
            }
            return 0;
        }
      
        public void saveImage(string fileName)
        {
            Bitmap bm = Buffer.procesingImage;
            string extension = Path.GetExtension(fileName);
            switch (extension.ToLower())
            {
                case ".bmp":
                    bm.Save(fileName, ImageFormat.Bmp);
                    break;
                case ".jpg":
                case ".jpeg":
                    bm.Save(fileName, ImageFormat.Jpeg);
                    break;
                case ".png":
                    bm.Save(fileName, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    bm.Save(fileName, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                    "Неизвестный расширение файла " + extension);
            }
        }
        private Bitmap saveImg = null;
        private void SaveJpgViser(string file_name, int compression)
        {
            try
            {
                EncoderParameters encoder_params = new EncoderParameters(1);
                encoder_params.Param[0] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.Quality, compression);
                ImageCodecInfo image_codec_info = GetEncoderInfo("image/jpeg");
                File.Delete(file_name);
                string saveImageName = file_name;
                Buffer.procesingImage.Save(file_name, image_codec_info, encoder_params);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении файла '" + file_name +
                "'\nПопробуйте другое имя файла.\n" + ex.Message,
                "Ошибка сохранения", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            //return new Bitmap(file_name);
        }
        public void SaveJpg(string file_name, int compression)
        {
            try
            {
                EncoderParameters encoder_params = new EncoderParameters(1);
                encoder_params.Param[0] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.Quality, compression);
                ImageCodecInfo image_codec_info = GetEncoderInfo("image/jpeg");
                File.Delete(file_name);
                string saveImageName = file_name;
                Buffer.procesingImage.Save(file_name, image_codec_info, encoder_params);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении файла '" + file_name +
                "'\nПопробуйте другое имя файла.\n" + ex.Message,
                "Ошибка сохранения", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        public SaveDoc @SaveDoc = new SaveDoc();
        public Palette @Palette = new Palette();

        public Correction @Correction = new Correction();
        
        public Filters @Filters = new Filters();

        public Transform @Transform = new Transform();

        public Channels @Channels = new Channels();

        public Curves @Curves = new Curves();

        public HistogramTypes setHistogramType {set{ Buffer.activHistogramTypes = value; Histograms.setHistogram(); } }

    }
   
}
