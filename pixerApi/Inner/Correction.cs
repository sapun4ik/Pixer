using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace pixerApi
{
    unsafe public struct Correction
    {
        /// <summary>
        /// Операция "Инверсия".
        /// </summary>
        public void Invert()
        {
            unsafe
            {
                for (int y = 0; y < Buffer.heightInPixels; y++)
                {
                    byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                    for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                    {
                        currentLine[x + 2] = (byte)(255 - currentLine[x + 2]);
                        currentLine[x + 1] = (byte)(255 - currentLine[x + 1]);
                        currentLine[x] = (byte)(255 - currentLine[x]);
                    }
                }
            }
            Buffer.addData();
            Buffer.Refrash();
        }
        /// <summary>
        /// Операция "Изменение яркости и контрастности". 
        /// Параметры "brightness и contrast" - коэффициенты.
        /// </summary>
        public void BrightnessAndContrast(int brightness, double contrast, bool save = false)
        {
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            int value;
            unsafe
            {
                for (int y = 0; y < Buffer.heightInPixels; y++)
                {
                    byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                    for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                    {
                        value = (int)(contrast * (Buffer.memoryStream[y, x + 2] - 128) + 128) + brightness;
                        currentLine[x+2] = (byte)(value | ((255 - value) >> 31));
                        if (value < byte.MinValue) currentLine[x + 2] = byte.MinValue;

                        value = (int)(contrast * (Buffer.memoryStream[y, x + 1] - 128) + 128) + brightness;
                        currentLine[x + 1] = (byte)(value | ((255 - value) >> 31));
                        if (value < byte.MinValue) currentLine[x + 1] = byte.MinValue;

                        value = (int)(contrast * (Buffer.memoryStream[y, x] - 128) + 128) + brightness;
                        currentLine[x] = (byte)(value | ((255 - value) >> 31));
                        if (value < byte.MinValue) currentLine[x] = byte.MinValue;
                    }
                }
            }
            if (save)
                Buffer.addData();
            Buffer.workspace.Refresh();
        }
        /// <summary>
        /// Операция "Бинаризация изображения по пороговому значению". 
        /// </summary>
        public void Binary(int threshold, bool save = false)
        {
                for (int y = 0; y < Buffer.heightInPixels; y++)
                {
                    byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                    for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                    {
                        int br = Convert.ToInt16((Buffer.memoryStream[y, x + 2] * 0.299 + Buffer.memoryStream[y, x + 1] * 0.587 + Buffer.memoryStream[y, x] * 0.114));
                        if (br > threshold)
                        {
                            currentLine[x + 2] = (byte)255;
                            currentLine[x + 1] = (byte)255;
                            currentLine[x] = (byte)255;
                        }
                        else
                        {
                            currentLine[x + 2] = (byte)0;
                            currentLine[x + 1] = (byte)0;
                            currentLine[x] = (byte)0;
                        }
                    }
            }
            if (save)
                Buffer.addData();
            Buffer.workspace.Refresh();
        }
        /// <summary>
        /// Операция "Градации серого".
        /// </summary>
        public void Grayscale()
        {
                for (int y = 0; y < Buffer.heightInPixels; y++)
                {
                    byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                    for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                    {
                        int br = Convert.ToInt16((Buffer.memoryStream[y, x + 2] * 0.299 + Buffer.memoryStream[y, x + 1] * 0.587 + Buffer.memoryStream[y, x] * 0.114));
                        currentLine[x + 2] = (byte)br;
                        currentLine[x + 1] = (byte)br;
                        currentLine[x] = (byte)br;
                    }
            }
            Buffer.addData();
            Buffer.workspace.Refresh();
        }
        /// <summary>
        /// Цветовой тон/Насыщенность
        /// </summary>
        /// <param name="h">minValue="0" maxValue="360"</param>
        /// <param name="s">minValue="0" maxValue="100"</param>
        /// <param name="v">minValue="-255" maxValue="255"</param>
        /// 
        public void HSB(double h, double s, double v, bool save = false)
        {
            double max = 0, min = 256;
            int R, G, B;
            double H = 0, S = 0, V = 0;
            double Hi = 0, Vmin = 0, a = 0, Vinc = 0, Vdec = 0;

            for (int i = 0; i < Buffer.pixelsCount; i++)
            {
                max = 0;
                min = 256;

                B = Buffer.pixelsBuffer[0];
                G = Buffer.pixelsBuffer[1];
                R = Buffer.pixelsBuffer[2];

                if (B > max)
                    max = B;
                if (B < min)
                    min = B;

                if (G > max)
                    max = G;
                if (G < min)
                    min = G;

                if (R > max)
                    max = R;
                if (R < min)
                    min = R;

                H = h;
                S = s;
                V = max + v;

                if (V > 255) V = 255;
                if (V < 0) V = 0;
                if (H < 0) H = 0;

                Hi = (H / 60) % 6;

                Vmin = ((100 - S) * V) / 100;

                a = (V - Vmin) * ((H % 60) / 60);

                Vinc = Vmin + a;

                Vdec = V - a;

                if (Hi >= 0 && Hi < 1) { Buffer.ptrFirstPixel[2] = (byte)V; Buffer.ptrFirstPixel[1] = (byte)Vinc; Buffer.ptrFirstPixel[0] = (byte)Vmin; }
                if (Hi >= 1 && Hi < 2) { Buffer.ptrFirstPixel[2] = (byte)Vdec; Buffer.ptrFirstPixel[1] = (byte)V; Buffer.ptrFirstPixel[0] = (byte)Vmin; }
                if (Hi >= 2 && Hi < 3) { Buffer.ptrFirstPixel[2] = (byte)Vmin; Buffer.ptrFirstPixel[1] = (byte)V; Buffer.ptrFirstPixel[0] = (byte)Vinc; }
                if (Hi >= 3 && Hi < 4) { Buffer.ptrFirstPixel[2] = (byte)Vmin; Buffer.ptrFirstPixel[1] = (byte)Vdec; Buffer.ptrFirstPixel[0] = (byte)V; }
                if (Hi >= 4 && Hi < 5) { Buffer.ptrFirstPixel[2] = (byte)Vinc; Buffer.ptrFirstPixel[1] = (byte)Vmin; Buffer.ptrFirstPixel[0] = (byte)V; }
                if (Hi >= 5) { Buffer.ptrFirstPixel[2] = (byte)V; Buffer.ptrFirstPixel[1] = (byte)Vmin; Buffer.ptrFirstPixel[0] = (byte)Vdec; }

                Buffer.ptrFirstPixel += Buffer.bytesPerPixel;
                Buffer.pixelsBuffer += Buffer.bytesPerPixel;
            }
            Buffer.ptrFirstPixel -= Buffer.pixelsCountWithChannels;
            Buffer.pixelsBuffer -= Buffer.pixelsCountWithChannels;
            if (save)
                Buffer.addData();
            Buffer.Refrash();
        }
        /// <summary>
        /// Наложение цвета
        /// </summary>
        /// <param name="color">Color(RGB)</param>
        /// <param name="opacity">minValue="0" maxValue="100"</param>
        public void ColorOverlay(Color color, double opacity, bool save = false)
        {
            opacity *= 0.01;
            for (int y = 0; y < Buffer.heightInPixels; y++)
            {
                byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                {
                    currentLine[x + 2] = (byte)(Buffer.memoryStream[y, x + 2] + (color.R - Buffer.memoryStream[y, x + 2]) * opacity);
                    currentLine[x + 1] = (byte)(Buffer.memoryStream[y, x + 1] + (color.G - Buffer.memoryStream[y, x + 1]) * opacity);
                    currentLine[x] = (byte)(Buffer.memoryStream[y, x] + (color.B - Buffer.memoryStream[y, x]) * opacity);
                }
            }
            if (save)
                Buffer.addData();
            Buffer.Refrash();
        }
        /// <summary>
        /// Точка белого и черного.
        /// </summary>
        public void PointBlackAndWhite(Color black, Color white) 
        {
            byte r2 = white.R, g2 = white.G, b2 = white.B;
            int r = black.R, g = black.G, b = black.B;

            for (int i = 0; i < Buffer.pixelsCount; i++)
            {
                if (r > Buffer.ptrFirstPixel[2])
                    Buffer.ptrFirstPixel[2] = 0;
                if (g > Buffer.ptrFirstPixel[1])
                    Buffer.ptrFirstPixel[1] = 0;
                if (b > Buffer.ptrFirstPixel[0])
                    Buffer.ptrFirstPixel[0] = 0;

                if (Buffer.ptrFirstPixel[2] > r2)
                    Buffer.ptrFirstPixel[2] = 255;
                if (Buffer.ptrFirstPixel[1] > g2)
                    Buffer.ptrFirstPixel[1] = 255;
                if (Buffer.ptrFirstPixel[0] > b2)
                    Buffer.ptrFirstPixel[0] = 255;

                Buffer.ptrFirstPixel += Buffer.bytesPerPixel;
            }
            Buffer.ptrFirstPixel -= Buffer.pixelsCountWithChannels;
            Buffer.Refrash();
        }
        /// <summary>
        /// S - коррекция.
        /// </summary>
        /// <param name="s"></param>
        public void SCorrection(double s)
        {
            s = 1 / s;

            double value = (100 + 50) / 100.0;
            value *= value;

            for (int i = 0; i < Buffer.pixelsCount; i++)
            {
                int value2 = (int)(value * (Buffer.ptrFirstPixel[0] - 128) + 128);
                if (value2 > 255) value2 = 255;
                if (value2 < 0) value2 = 0;

                Buffer.ptrFirstPixel[0] = (byte)(255 * (Math.Pow((double)value2 / (double)255, s)));
                value2 = (int)(value * (Buffer.ptrFirstPixel[1] - 128) + 128);
                if (value2 > 255) value2 = 255;
                if (value2 < 0) value2 = 0;

                Buffer.ptrFirstPixel[1] = (byte)(255 * (Math.Pow((double)value2 / (double)255, s)));
                value2 = (int)(value * (Buffer.ptrFirstPixel[2] - 128) + 128);
                if (value2 > 255) value2 = 255;
                if (value2 < 0) value2 = 0;

                Buffer.ptrFirstPixel[2] = (byte)(255 * (Math.Pow((double)value2 / (double)255, s)));
                Buffer.ptrFirstPixel += Buffer.bytesPerPixel;
            }
            Buffer.ptrFirstPixel -= Buffer.pixelsCountWithChannels;
            Buffer.addData();
            Buffer.Refrash();
        }

        /// <summary>
        /// Гамма коррекция.
        /// </summary>
        /// <param name="gamma"></param>
        public void GammaCorrection(double gamma)
        {
            for (int i = 0; i < Buffer.pixelsCount; i++)
            {
                Buffer.ptrFirstPixel[0] = (byte)(255 * (Math.Pow((double)Buffer.ptrFirstPixel[0] / (double)255, gamma)));
                Buffer.ptrFirstPixel[1] = (byte)(255 * (Math.Pow((double)Buffer.ptrFirstPixel[1] / (double)255, gamma)));
                Buffer.ptrFirstPixel[2] = (byte)(255 * (Math.Pow((double)Buffer.ptrFirstPixel[2] / (double)255, gamma)));

                Buffer.ptrFirstPixel += Buffer.bytesPerPixel;
            }
            Buffer.ptrFirstPixel -= Buffer.pixelsCountWithChannels;
            Buffer.addData();
            Buffer.Refrash();
        }

    }
}