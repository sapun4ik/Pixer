using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixerApi
{
    public struct corect
    {
        private class RGB
        {
            public RGB()
            {
            }
            public RGB(double R, double G, double B)
            {
                this.R = R;
                this.G = G;
                this.B = B;

            }
            public double R { get; set; }
            public double G { get; set; }
            public double B { get; set; }

        }


        private RGB HSBtoRGB(double h, double s, double b)
        {
            double R = 0;
            double G = 0;
            double B = 0;

            if (s == 0)
            {
                R = G = B = b;
            }
            else
            {
                double sectorPos = h / 60.0;
                int sectorNumber = (int)(Math.Floor(sectorPos));

                double fractionalSector = sectorPos - sectorNumber;

                double p = b * (1.0 - s);
                double q = b * (1.0 - (s * fractionalSector));
                double t = b * (1.0 - (s * (1 - fractionalSector)));

                switch (sectorNumber)
                {
                    case 0:
                        R = b;
                        G = t;
                        B = p;
                        break;
                    case 1:
                        R = q;
                        G = b;
                        B = p;
                        break;
                    case 2:
                        R = p;
                        G = b;
                        B = t;
                        break;
                    case 3:
                        R = p;
                        G = q;
                        B = b;
                        break;
                    case 4:
                        R = t;
                        G = p;
                        B = b;
                        break;
                    case 5:
                        R = b;
                        G = p;
                        B = q;
                        break;
                }
            }

            return new RGB(
                Convert.ToInt32(Double.Parse(String.Format("{0:0.00}", R * 255.0))),
                Convert.ToInt32(Double.Parse(String.Format("{0:0.00}", G * 255.0))),
                Convert.ToInt32(Double.Parse(String.Format("{0:0.00}", B * 255.0)))
            );
        }
        public void setHSV(int h, int s, int v)
        {
            RGB value = HSBtoRGB(h, s * 0.01, v * 0.01);
            unsafe
            {
                for (int y = 0; y < Buffer.heightInPixels; y++)
                {
                    byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                    for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                    {
                       
                        int r = (int)(value.R + Buffer.memoryStream[y, x + 2]);
                        if (r > 255) r = 255;
                        if (r < 0) r = 0;

                        int g = (int)(value.G + Buffer.memoryStream[y, x + 1]);
                        if (g > 255) g = 255;
                        if (g < 0) g = 0;

                        int b = (int)(value.B + Buffer.memoryStream[y, x]);
                        if (b > 255) b = 255;
                        if (b < 0) b = 0;

                        currentLine[x + 2] = (byte)r;
                        currentLine[x + 1] = (byte)g;
                        currentLine[x] = (byte)b;
                    }
                }
            }
            //Buffer.addData();
            Buffer.workspace.Refresh();
        }
    }
}
