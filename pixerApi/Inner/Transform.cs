using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace pixerApi
{
    unsafe public struct Transform
    {
        //private void setDate(out int x_ratio, out int y_ratio)
        //{

        //}
        /// <summary>
        /// Трансформации
        /// </summary>
        /// <param name="picture"></param>
        /// <summary>
        /// Изменение позиции, размера и поворот изображения
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <param name="angle"></param>
        public void NearestNoResizeBitmap(int Width, int Height, int offsetX, int offsetY, int angle, bool save = false)
        {
            int X, Y, X2, Y2;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (Buffer.Width / 2 - Width / 2);
            int currentOffsetY = offsetX - (Buffer.Height / 2 - Height / 2);

            int x_ratio = (Buffer.Width << 16) / Width + 1;
            int y_ratio = (Buffer.Height << 16) / Height + 1;

            double value = Math.PI / 180 * angle;
            double cos = Math.Cos(value);
            double sin = Math.Sin(value);

            for (int i = 0; i < Buffer.Height; i++)
            {
                for (int j = 0; j < Buffer.Width; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (X * x_ratio) >> 16;
                    Y2 = (Y * y_ratio) >> 16;

                    int intValue = i * Buffer.stride + j * 4;
                    int intValue2 = Y2 * Buffer.stride + X2 * 4;

                    if (intValue >= 0 && intValue < Buffer.pixelsCountWithChannels &&
                        intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < Buffer.Width)
                        {
                            Buffer.ptrFirstPixel[intValue] = Buffer.pixelsBuffer[intValue2];
                            Buffer.ptrFirstPixel[intValue + 1] = Buffer.pixelsBuffer[intValue2 + 1];
                            Buffer.ptrFirstPixel[intValue + 2] = Buffer.pixelsBuffer[intValue2 + 2];
                            Buffer.ptrFirstPixel[intValue + 3] = 255;
                        }
                        else Buffer.ptrFirstPixel[intValue + 3] = 0;
                    }
                    else Buffer.ptrFirstPixel[intValue + 3] = 0;  
                }
            }
            if (save)
                Buffer.addData();
            Buffer.Refrash();
        }

        /// <summary>
        /// Изменение позиции, размера и поворот изображения, с биллинейной интерполяцией
        /// </summary>
        public void BilinearInterpolationNoResizeBitmap(int Width, int Height, int offsetX, int offsetY, int angle, bool save = false)
        {
            int X, Y, X2, Y2;

            Color A = Color.FromArgb(255,255,255);
            Color B =  Color.FromArgb(255,255,255);
            Color C =  Color.FromArgb(255,255,255);
            Color D = Color.FromArgb(255, 255, 255);

            byte r, g, b;
            double w, h;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (Buffer.Width / 2 - Width / 2);
            int currentOffsetY = offsetX - (Buffer.Height / 2 - Height / 2);

            double x_ratio = (double)(Buffer.Width - 1) / Width;
            double y_ratio = (double)(Buffer.Height - 1) / Height;

            double value = Math.PI / 180 * angle;
            double cos = Math.Cos(value);
            double sin = Math.Sin(value);

            for (int i = 0; i < Buffer.Height; i++)
            {
                for (int j = 0; j < Buffer.Width; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (int)(X * x_ratio);
                    Y2 = (int)(Y * y_ratio);

                    w = x_ratio * X - X2;
                    h = y_ratio * Y - Y2;

                    int intValue = i * Buffer.stride + j * 4;
                    int intValue2 = Y2 * Buffer.stride + X2 * 4;

                    if (intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        A = Color.FromArgb(Buffer.pixelsBuffer[intValue2 + 2], Buffer.pixelsBuffer[intValue2 + 1], Buffer.pixelsBuffer[intValue2]);
                    }
                    int intValue3 = Y2 * Buffer.stride + (X2 + 1) * 4;
                    if (intValue3 >= 0 && intValue3 < Buffer.pixelsCountWithChannels)
                    {
                        B = Color.FromArgb(Buffer.pixelsBuffer[intValue3 + 2], Buffer.pixelsBuffer[intValue3 + 1], Buffer.pixelsBuffer[intValue3]);
                    }
                    intValue3 = (Y2 + 1) * Buffer.stride + X2 * 4;
                    if (intValue3 >= 0 && intValue3 < Buffer.pixelsCountWithChannels)
                    {
                        C = Color.FromArgb(Buffer.pixelsBuffer[intValue3 + 2], Buffer.pixelsBuffer[intValue3 + 1], Buffer.pixelsBuffer[intValue3]);
                    }
                    intValue3 = (Y2 + 1) * Buffer.stride + (X2 + 1) * 4;
                    if (intValue3 >= 0 && intValue3 < Buffer.pixelsCountWithChannels)
                    {
                        D = Color.FromArgb(Buffer.pixelsBuffer[intValue3 + 2], Buffer.pixelsBuffer[intValue3 + 1], Buffer.pixelsBuffer[intValue3]);
                    }

                    r = (byte)(A.R * (1 - w) * (1 - h) + B.R * (w) * (1 - h) + C.R * (h) * (1 - w) + D.R * (w * h));
                    g = (byte)(A.G * (1 - w) * (1 - h) + B.G * (w) * (1 - h) + C.G * (h) * (1 - w) + D.G * (w * h));
                    b = (byte)(A.B * (1 - w) * (1 - h) + B.B * (w) * (1 - h) + C.B * (h) * (1 - w) + D.B * (w * h));

                    if (intValue >= 0 && intValue < Buffer.pixelsCountWithChannels &&
                        intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < Buffer.Width)
                        {
                            Buffer.ptrFirstPixel[intValue] = b;
                            Buffer.ptrFirstPixel[intValue + 1] = g;
                            Buffer.ptrFirstPixel[intValue + 2] = r;
                            Buffer.ptrFirstPixel[intValue + 3] = 255;
                        }
                        else Buffer.ptrFirstPixel[intValue + 3] = 0;
                        
                    }
                    else Buffer.ptrFirstPixel[intValue + 3] = 0;
                }
            }
            if (save)
                Buffer.addData();
            Buffer.Refrash();
        }


        /// <summary>
        /// Изменение позиции, размера и поворот изображения, с линейной интерполяцией
        /// </summary>
        public void LinearInterpolationNoResizeBitmap(int Width, int Height, int offsetX, int offsetY, int angle, bool save = false)
        {
            int X, Y, X2, Y2;

            Color A = Color.FromArgb(255, 255, 255);
            Color B = Color.FromArgb(255, 255, 255);

            byte r, g, b;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (Buffer.Width / 2 - Width / 2);
            int currentOffsetY = offsetX - (Buffer.Height / 2 - Height / 2);

            double x_ratio = (double)(Buffer.Width - 1) / Width;
            double y_ratio = (double)(Buffer.Height - 1) / Height;

            double value = Math.PI / 180 * angle;
            double cos = Math.Cos(value);
            double sin = Math.Sin(value);

            for (int i = 0; i < Buffer.Height; i++)
            {
                for (int j = 0; j < Buffer.Width; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (int)(X * x_ratio);
                    Y2 = (int)(Y * y_ratio);

                    int intValue = i * Buffer.stride + j * 4;
                    int intValue2 = Y2 * Buffer.stride + X2 * 4;

                    if (intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        A = Color.FromArgb(Buffer.pixelsBuffer[intValue2 + 2], Buffer.pixelsBuffer[intValue2 + 1], Buffer.pixelsBuffer[intValue2]);

                    }
                    int intValue3 = Y2 * Buffer.stride + (X2 + 1) * 4;
                    if (intValue3 >= 0 && intValue3 < Buffer.pixelsCountWithChannels)
                    {
                        B = Color.FromArgb(Buffer.pixelsBuffer[intValue3 + 2], Buffer.pixelsBuffer[intValue3 + 1], Buffer.pixelsBuffer[intValue3]);

                    }
                    r = A.R + (Buffer.Width * (B.R - A.R) / Width) < 0 ? r = 0 :
                        A.R + (Buffer.Width*(B.R - A.R) / Width) > 255 ? r = 255 : r = (byte)(A.R + (Buffer.Width*(B.R - A.R) / Width));
                    g = A.G + (Buffer.Width * (B.G - A.G) / Width) < 0 ? g = 0 :
                        A.G + (Buffer.Width*(B.G - A.G) / Width) > 255 ? g = 255 : g = (byte)(A.G + (Buffer.Width*(B.G - A.G) / Width));
                    b = A.B + (Buffer.Width * (B.B - A.B) / Width) < 0 ? b = 0 :
                        A.R + (Buffer.Width*(B.B - A.B) / Width) > 255 ? b = 255 : b = (byte)(A.B + (Buffer.Width*(B.B - A.B) / Width));

                    if (intValue >= 0 && intValue < Buffer.pixelsCountWithChannels &&
                        intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < Buffer.Width)
                        {
                            Buffer.ptrFirstPixel[intValue] = b;
                            Buffer.ptrFirstPixel[intValue + 1] = g;
                            Buffer.ptrFirstPixel[intValue + 2] = r;
                            Buffer.ptrFirstPixel[intValue + 3] = 255;
                        }
                        else Buffer.ptrFirstPixel[intValue + 3] = 0;
                    }
                    else Buffer.ptrFirstPixel[intValue + 3] = 0;
                }
            }
            if (save)
                Buffer.addData();
            Buffer.Refrash();
        }

        /// <summary>
        /// Изменение позиции, размера и поворот изображения
        /// </summary>
        public void Nearest(int Width, int Height, int offsetX, int offsetY, int angle, bool save = false)
        {
            int h = Height, w = Width, newAngle = angle;
            double cW = 0, cH = 0;
            var oc = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2)) / 2;
            
            cH = Math.Atan((double)Height / (double)Width);
            cW = Math.Atan((double)Width / (double)Height);
            if (newAngle > 90 && newAngle < 180)
            {
                newAngle -= 90;
                cW = Math.Atan((double)Height / (double)Width);
                cH = Math.Atan((double)Width / (double)Height);
            }
            else if (newAngle > 180 && newAngle < 270)
            {
                newAngle -= 180;
                cH = Math.Atan((double)Height / (double)Width);
                cW = Math.Atan((double)Width / (double)Height);
            }
            else if (newAngle > 270)
            {
                newAngle -= 270;
                cW = Math.Atan((double)Height / (double)Width);
                cH = Math.Atan((double)Width / (double)Height);
            }

            double value = Math.PI / 180 * newAngle;

            h = (int)(2 * oc * Math.Sin(cH + value));
            w = (int)(2 * oc * Math.Sin(cW + value));

            byte[] TransformBuffer = new byte[w * h * Buffer.bytesPerPixel];

            int X, Y, X2, Y2;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int x_ratio = (Buffer.Width << 16) / Width + 1;
            int y_ratio = (Buffer.Height << 16) / Height + 1;

            value = Math.PI / 180 * angle;
            double cos = Math.Cos(value);
            double sin = Math.Sin(value);

            int currentOffsetX = offsetY + (Buffer.Width - Width) / 2 - (Buffer.Width - w) / 2;
            int currentOffsetY = offsetX - (Buffer.Height - Height) / 2 + (Buffer.Height - h) / 2;

            x_ratio = (Buffer.Width << 16) / Width + 1;
            y_ratio = (Buffer.Height << 16) / Height + 1;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (X * x_ratio) >> 16;
                    Y2 = (Y * y_ratio) >> 16;

                    int intValue = i * (w * Buffer.bytesPerPixel) + j * 4;
                    int intValue2 = Y2 * Buffer.stride + X2 * 4;

                    if (intValue >= 0 && intValue < TransformBuffer.Length &&
                        intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < Buffer.Width)
                        {
                            TransformBuffer[intValue] = Buffer.pixelsBuffer[intValue2];
                            TransformBuffer[intValue + 1] = Buffer.pixelsBuffer[intValue2 + 1];
                            TransformBuffer[intValue + 2] = Buffer.pixelsBuffer[intValue2 + 2];
                            TransformBuffer[intValue + 3] = 255;
                        }
                        else TransformBuffer[intValue + 3] = 0;
                    }
                }
            }

            Buffer.TransformBuffer = TransformBuffer;
            Buffer.WidthScaled = Math.Abs(w);
            Buffer.HeightScaled = Math.Abs(h);
            Buffer.ApplyChangesTransform();
            if (save)
                Buffer.addData();
        }

        /// <summary>
        /// Изменение позиции, размера и поворот изображения, с линейной интерполяцией
        /// </summary>
        public void LinearInterpolation(int Width, int Height, int offsetX, int offsetY, int angle, bool save = false)
        {
            int h = Height, w = Width, newAngle = angle;
            double cW = 0, cH = 0;
            var oc = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2)) / 2;

            cH = Math.Atan((double)Height / (double)Width);
            cW = Math.Atan((double)Width / (double)Height);
            if (newAngle > 90 && newAngle < 180)
            {
                newAngle -= 90;
                cW = Math.Atan((double)Height / (double)Width);
                cH = Math.Atan((double)Width / (double)Height);
            }
            else if (newAngle > 180 && newAngle < 270)
            {
                newAngle -= 180;
                cH = Math.Atan((double)Height / (double)Width);
                cW = Math.Atan((double)Width / (double)Height);
            }
            else if (newAngle > 270)
            {
                newAngle -= 270;
                cW = Math.Atan((double)Height / (double)Width);
                cH = Math.Atan((double)Width / (double)Height);
            }

            double value = Math.PI / 180 * newAngle;

            h = (int)(2 * oc * Math.Sin(cH + value));
            w = (int)(2 * oc * Math.Sin(cW + value));

            byte[] TransformBuffer = new byte[w * h * Buffer.bytesPerPixel];

            int X, Y, X2, Y2;

            Color A = Color.FromArgb(255,255,255);
            Color B = Color.FromArgb(255, 255, 255);

            byte r, g, b;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (Buffer.Width - Width) / 2 - (Buffer.Width - w) / 2;
            int currentOffsetY = offsetX - (Buffer.Height - Height) / 2 + (Buffer.Height - h) / 2;

            int x_ratio = (Buffer.Width << 16) / Width + 1;
            int y_ratio = (Buffer.Height << 16) / Height + 1;

            value = Math.PI / 180 * angle;
            double cos = Math.Cos(value);
            double sin = Math.Sin(value);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (X * x_ratio) >> 16;
                    Y2 = (Y * y_ratio) >> 16;

                    int intValue = i * (w * Buffer.bytesPerPixel) + j * 4;
                    int intValue2 = Y2 * Buffer.stride + X2 * 4;

                    if (intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        A = Color.FromArgb(Buffer.pixelsBuffer[intValue2 + 2], Buffer.pixelsBuffer[intValue2 + 1], Buffer.pixelsBuffer[intValue2]);
                    }

                    int intValue3 = Y2 * Buffer.stride + (X2 + 1) * 4;

                    if (intValue3 >= 0 && intValue3 < Buffer.pixelsCountWithChannels)
                    {
                        B = Color.FromArgb(Buffer.pixelsBuffer[intValue3 + 2], Buffer.pixelsBuffer[intValue3 + 1], Buffer.pixelsBuffer[intValue3]);
                    }

                    r = A.R + (Buffer.Width * (B.R - A.R) / Width) < 0 ? r = 0 :
                        A.R + (Buffer.Width * (B.R - A.R) / Width) > 255 ? r = 255 : r = (byte)(A.R + (Buffer.Width * (B.R - A.R) / Width));
                    g = A.G + (Buffer.Width * (B.G - A.G) / Width) < 0 ? g = 0 :
                        A.G + (Buffer.Width * (B.G - A.G) / Width) > 255 ? g = 255 : g = (byte)(A.G + (Buffer.Width * (B.G - A.G) / Width));
                    b = A.B + (Buffer.Width * (B.B - A.B) / Width) < 0 ? b = 0 :
                        A.R + (Buffer.Width * (B.B - A.B) / Width) > 255 ? b = 255 : b = (byte)(A.B + (Buffer.Width * (B.B - A.B) / Width));

                    if (intValue >= 0 && intValue < TransformBuffer.Length &&
                        intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < Buffer.Width)
                        {
                            TransformBuffer[intValue] = b;
                            TransformBuffer[intValue + 1] = g;
                            TransformBuffer[intValue + 2] = r;
                            TransformBuffer[intValue + 3] = 255;
                        }
                        else TransformBuffer[intValue + 3] = 0;
                    }
                }
            }
            Buffer.TransformBuffer = TransformBuffer;
            Buffer.WidthScaled = Math.Abs(w);
            Buffer.HeightScaled = Math.Abs(h);
            Buffer.ApplyChangesTransform();
            if (save)
                Buffer.addData();
        }

        /// <summary>
        /// Изменение позиции, размера и поворот изображения, с биллинейной интерполяцией
        /// </summary>
        public void BilinearInterpolation(int Width, int Height, int offsetX, int offsetY, int angle, bool save = false)
        {
            int h = Height, w = Width, newAngle = angle;
            double cW = 0, cH = 0;
            var oc = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2)) / 2;

            cH = Math.Atan((double)Height / (double)Width);
            cW = Math.Atan((double)Width / (double)Height);
            if (newAngle > 90 && newAngle < 180)
            {
                newAngle -= 90;
                cW = Math.Atan((double)Height / (double)Width);
                cH = Math.Atan((double)Width / (double)Height);
            }
            else if (newAngle > 180 && newAngle < 270)
            {
                newAngle -= 180;
                cH = Math.Atan((double)Height / (double)Width);
                cW = Math.Atan((double)Width / (double)Height);
            }
            else if (newAngle > 270)
            {
                newAngle -= 270;
                cW = Math.Atan((double)Height / (double)Width);
                cH = Math.Atan((double)Width / (double)Height);
            }

            double value = Math.PI / 180 * newAngle;

            h = (int)(2 * oc * Math.Sin(cH + value));
            w = (int)(2 * oc * Math.Sin(cW + value));

            byte[] TransformBuffer = new byte[w * h * Buffer.bytesPerPixel];

            int X, Y, X2, Y2;

            Color A = Color.FromArgb(255, 255, 255);
            Color B = Color.FromArgb(255, 255, 255);
            Color C = Color.FromArgb(255, 255, 255);
            Color D = Color.FromArgb(255, 255, 255);

            byte r, g, b;
            double W, H;

            int pointX = Width / 2;
            int pointY = Height / 2;

            int currentOffsetX = offsetY + (Buffer.Width - Width) / 2 - (Buffer.Width - w) / 2;
            int currentOffsetY = offsetX - (Buffer.Height - Height) / 2 + (Buffer.Height - h) / 2;

            double x_ratio = (double)(Buffer.Width - 1) / Width;
            double y_ratio = (double)(Buffer.Height - 1) / Height;

            value = Math.PI / 180 * angle;
            double cos = Math.Cos(value);
            double sin = Math.Sin(value);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    X = (int)(cos * (j - currentOffsetX - pointX) - sin * (i + currentOffsetY - pointY) + pointX);
                    Y = (int)(sin * (j - currentOffsetX - pointX) + cos * (i + currentOffsetY - pointY) + pointY);

                    X2 = (int)(X * x_ratio);
                    Y2 = (int)(Y * y_ratio);

                    W = x_ratio * X - X2;
                    H = y_ratio * Y - Y2;

                    int intValue = i * (w * Buffer.bytesPerPixel) + j * 4;
                    int intValue2 = Y2 * Buffer.stride + X2 * 4;

                    if (intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        A = Color.FromArgb(Buffer.pixelsBuffer[intValue2 + 2], Buffer.pixelsBuffer[intValue2 + 1], Buffer.pixelsBuffer[intValue2]);
                    }
                    int intValue3 = Y2 * Buffer.stride + (X2 + 1) * 4;
                    if (intValue3 >= 0 && intValue3 < Buffer.pixelsCountWithChannels)
                    {
                        B = Color.FromArgb(Buffer.pixelsBuffer[intValue3 + 2], Buffer.pixelsBuffer[intValue3 + 1], Buffer.pixelsBuffer[intValue3]);
                    }
                    intValue3 = (Y2 + 1) * Buffer.stride + X2 * 4;
                    if (intValue3 >= 0 && intValue3 < Buffer.pixelsCountWithChannels)
                    {
                        C = Color.FromArgb(Buffer.pixelsBuffer[intValue3 + 2], Buffer.pixelsBuffer[intValue3 + 1], Buffer.pixelsBuffer[intValue3]);
                    }
                    intValue3 = (Y2 + 1) * Buffer.stride + (X2 + 1) * 4;
                    if (intValue3 >= 0 && intValue3 < Buffer.pixelsCountWithChannels)
                    {
                        D = Color.FromArgb(Buffer.pixelsBuffer[intValue3 + 2], Buffer.pixelsBuffer[intValue3 + 1], Buffer.pixelsBuffer[intValue3]);
                    }

                    r = (byte)(A.R * (1 - W) * (1 - H) + B.R * (W) * (1 - H) + C.R * (H) * (1 - W) + D.R * (W * H));
                    g = (byte)(A.G * (1 - W) * (1 - H) + B.G * (W) * (1 - H) + C.G * (H) * (1 - W) + D.G * (W * H));
                    b = (byte)(A.B * (1 - W) * (1 - H) + B.B * (W) * (1 - H) + C.B * (H) * (1 - W) + D.B * (W * H));

                    if (intValue >= 0 && intValue < TransformBuffer.Length &&
                        intValue2 >= 0 && intValue2 < Buffer.pixelsCountWithChannels)
                    {
                        if (X2 >= 0 && X2 < Buffer.Width)
                        {
                            TransformBuffer[intValue] = b;
                            TransformBuffer[intValue + 1] = g;
                            TransformBuffer[intValue + 2] = r;
                            TransformBuffer[intValue + 3] = 255;
                        }
                        else TransformBuffer[intValue + 3] = 0;
                    }
                }
            }
            Buffer.TransformBuffer = TransformBuffer;
            Buffer.WidthScaled = Math.Abs(w);
            Buffer.HeightScaled = Math.Abs(h);
            Buffer.ApplyChangesTransform();
            if (save)
                Buffer.addData();
        }
    }
}