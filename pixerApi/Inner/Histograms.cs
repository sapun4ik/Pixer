using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace pixerApi
{
    public enum HistogramTypes
    {
        Red,
        Green,
        Blue,
        RGB,
        Brightness
    };
    unsafe static internal class Histograms
    {
        static public void setHistogram()
        {
            
                int[] histogram = new int[256];
                int max = 0;
                int medium = 0;
                int mediumM = 0;
                int poit = 0; // Адресс максимально точки в массиве
                int poit2 = 0; // Адресс второй максимально точки в массиве
                for (int y = 0; y < Buffer.heightInPixels; y++)
                {
                    byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                    for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                    {
                        int br=0;
                        if (Buffer.activHistogramTypes == HistogramTypes.Brightness)
                            br = Convert.ToInt16((currentLine[x + 2]*0.299 + currentLine[x + 1]*0.587 + currentLine[x]*0.114));
                        if (Buffer.activHistogramTypes == HistogramTypes.Red)
                            br = Convert.ToInt16(currentLine[x + 2] );
                        if (Buffer.activHistogramTypes == HistogramTypes.Green)
                            br = Convert.ToInt16(currentLine[x + 1]);
                        if (Buffer.activHistogramTypes == HistogramTypes.Blue)
                            br = Convert.ToInt16(currentLine[x]);
                        if (br == 255 || br > 255)
                            br = 254;
                        histogram[br]++;
                        if (max < histogram[br]) { max = histogram[br]; poit = br; }
                        if (medium < histogram[br] && max > histogram[br])
                        { medium = histogram[br]; poit2 = br; }
                        if (mediumM < histogram[br] && medium > histogram[br] && max > histogram[br])
                            mediumM = histogram[br];

                    }
                }
                medium = histogram[poit2] = Convert.ToInt32(medium - ((medium - mediumM) / 1.05));
                max = histogram[poit] = Convert.ToInt32(max - ((max - medium) / 1.05));
                int HeightHist = max;

                Bitmap diagram = new Bitmap(255, HeightHist);
                BitmapData bitmapData = diagram.LockBits(new Rectangle(0, 0, diagram.Width, diagram.Height), ImageLockMode.ReadWrite, diagram.PixelFormat);
                int bytesPerPixel = Image.GetPixelFormatSize(diagram.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0;  x < widthInBytes; x = x + bytesPerPixel)
                    {
                        currentLine[x] = (byte)0;
                        currentLine[x + 1] = (byte)0;
                        currentLine[x + 2] = (byte)0;
                        currentLine[x + 3] = (byte)0;
                        if (!(heightInPixels - y >= histogram[x / bytesPerPixel]))
                            currentLine[x + 3] = (byte)255;
                    }
                }

                diagram.UnlockBits(bitmapData);

                Buffer.histogram.Image = diagram;
            
        }
    }
}