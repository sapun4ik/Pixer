using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace pixerApi
{
    unsafe public struct Filters
    {
        /// <summary>
        /// Усиление границ по Лапласу.
        /// </summary>
        /// <param name="level"></param>
        public void Laplacian(int level)
        {
            int matrixSize = level * 2 + 1;
            if ((double)level % 2 == 0)
                matrixSize = level * 2 + 1;
            level *= level;

            double[] matrix = new double[matrixSize * matrixSize];
            int MatrixOffset = (matrixSize - 1) / 2;
            int value = 0;

            for (int i = -MatrixOffset; i <= MatrixOffset; i++)
            {
                for (int j = -MatrixOffset; j <= MatrixOffset; j++)
                {
                    if (i == 0 && j == 0)
                        matrix[value++] = matrixSize * matrixSize - 1;
                    else
                        matrix[value++] = -1;
                }
            }

            Convolution(matrix, 0, matrixSize);
            Buffer.addData();
            Buffer.Refrash();
        }
        /// <summary>
        /// Матрица свертки.
        /// </summary>
        /// <param name="Matrix"></param>
        /// <param name="offset"></param>
        public void Convolution(double[] Matrix, int offset, int matrixWidth, bool save = false)
        {
            double factor = 0;
            int MatrixOffset = (matrixWidth - 1) / 2;
            for (int i = 0; i < Matrix.Length; i++)
                factor += Matrix[i];
            if (factor <= 0) factor = 1;

            for (int i = MatrixOffset; i < Buffer.Height - MatrixOffset; i++)
            {
                for (int j = 0; j < Buffer.Width; j++)
                {
                    double r = 0, g = 0, b = 0;
                    int value3 = 0;
                    int value = i * Buffer.stride + j * 4;
                    for (int mY = 0; mY < matrixWidth; mY++)
                    {
                        for (int mX = 0; mX < matrixWidth; mX++)
                        {
                            int value2 = value + (mX - MatrixOffset) * 4 + (mY - MatrixOffset) * Buffer.stride;
                            b += Buffer.pixelsBuffer[value2] * Matrix[value3];
                            g += Buffer.pixelsBuffer[value2 + 1] * Matrix[value3];
                            r += Buffer.pixelsBuffer[value2 + 2] * Matrix[value3++];
                        }
                    }
                    r = r / factor + offset;
                    g = g / factor + offset;
                    b = b / factor + offset;

                    if (b > 255) b = 255;
                    if (g > 255) g = 255;
                    if (r > 255) r = 255;

                    if (b < 0) b = 0;
                    if (g < 0) g = 0;
                    if (r < 0) r = 0;

                    Buffer.ptrFirstPixel[value] = (byte)b;
                    Buffer.ptrFirstPixel[value + 1] = (byte)g;
                    Buffer.ptrFirstPixel[value + 2] = (byte)r;
                }
            }
            if (save)
                Buffer.addData();
            Buffer.Refrash();
        }
        /// <summary>
        /// Размытие по Гауссу.
        /// </summary>
        /// <param name="level"></param>
        public void Gaussian(int level, bool save = false)
        {
            int matrixSize = level * 2 + 1;
            if ((double)level % 2 == 0)
                matrixSize = level * 2 + 1;
            level *= level;

            double[] matrix = new double[matrixSize * matrixSize];
            int MatrixOffset = (matrixSize - 1) / 2;
            int someIntValue = 0;

            for (int i = -MatrixOffset; i <= MatrixOffset; i++)
            {
                for (int j = -MatrixOffset; j <= MatrixOffset; j++)
                {
                    matrix[someIntValue++] = 1 / (2 * 3.14 * level * level) * Math.Pow(Math.E, -((i * i + j * j) / (2 * level * level)));
                }
            }

            double sum = matrix.Sum();

            for (int i = 0; i < matrixSize * matrixSize; i++)
            {
                matrix[i] /= sum;
            }

            ConvolutionXY(matrix, matrixSize);
            if (save)
                Buffer.addData();
            Buffer.Refrash();

        }

        private void ConvolutionXY(double[] Matrix, int matrixWidth)
        {
            double factor = 0;
            int MatrixOffset = (matrixWidth - 1) / 2;
            for (int i = 0; i < Matrix.Length; i++)
                factor += Matrix[i];
            if (factor <= 0) factor = 1;

            for (int i = 0; i < Buffer.pixelsCount; i++)
            {
                double r = 0, g = 0, b = 0;

                for (int mX = -MatrixOffset; mX <= MatrixOffset; mX++)
                {
                    int value = i * 4 + mX * 4;
                    b += Buffer.pixelsBuffer[value] * Matrix[mX + MatrixOffset];
                    g += Buffer.pixelsBuffer[value + 1] * Matrix[mX + MatrixOffset];
                    r += Buffer.pixelsBuffer[value + 2] * Matrix[mX + MatrixOffset];
                }

                Buffer.ptrFirstPixel[0] = (byte)(b / factor * matrixWidth);
                Buffer.ptrFirstPixel[1] = (byte)(g / factor * matrixWidth);
                Buffer.ptrFirstPixel[2] = (byte)(r / factor * matrixWidth);

                Buffer.ptrFirstPixel += Buffer.bytesPerPixel;
            }
            Buffer.ptrFirstPixel -= Buffer.pixelsCountWithChannels;

            for (int i = 0; i < Buffer.pixelsCount; i++)
            {
                double r = 0, g = 0, b = 0;

                for (int mX = -MatrixOffset; mX <= MatrixOffset; mX++)
                {
                    int value = mX * Buffer.stride;
                    if (i * 4 + value > 0 && i * 4 + value < Buffer.pixelsCountWithChannels)
                    {
                        b += Buffer.ptrFirstPixel[value] * Matrix[mX + MatrixOffset];
                        g += Buffer.ptrFirstPixel[value + 1] * Matrix[mX + MatrixOffset];
                        r += Buffer.ptrFirstPixel[value + 2] * Matrix[mX + MatrixOffset];
                    }
                }

                Buffer.ptrFirstPixel[0] = (byte)(b / factor * matrixWidth);
                Buffer.ptrFirstPixel[1] = (byte)(g / factor * matrixWidth);
                Buffer.ptrFirstPixel[2] = (byte)(r / factor * matrixWidth);

                Buffer.ptrFirstPixel += Buffer.bytesPerPixel;
            }
            Buffer.ptrFirstPixel -= Buffer.pixelsCountWithChannels;
        }
        /// <summary>
        /// Нормальное размытие.
        /// </summary>
        public void NormalBlur()
        {
            int sumR = 0, sumG = 0, sumB = 0;

            for (int i = 0; i < Buffer.pixelsCount; i++)
            {
                sumB += Buffer.ptrFirstPixel[0];
                sumG += Buffer.ptrFirstPixel[1];
                sumR += Buffer.ptrFirstPixel[2];

                Buffer.ptrFirstPixel += Buffer.bytesPerPixel;
            }
            Buffer.ptrFirstPixel -= Buffer.pixelsCountWithChannels;

            sumB /= Buffer.pixelsCount;
            sumG /= Buffer.pixelsCount;
            sumR /= Buffer.pixelsCount;

            for (int i = 0; i < Buffer.pixelsCount; i++)
            {
                Buffer.ptrFirstPixel[0] = (byte)sumB;
                Buffer.ptrFirstPixel[1] = (byte)sumG;
                Buffer.ptrFirstPixel[2] = (byte)sumR;

                Buffer.ptrFirstPixel += Buffer.bytesPerPixel;
            }
            Buffer.ptrFirstPixel -= Buffer.pixelsCountWithChannels;
            Buffer.addData();
            Buffer.Refrash();
        }
        /// <summary>
        /// Медианер.
        /// </summary>
        public void Medianer(int radius, bool save = false)
        {
            int matrixSize = radius * 2 + 1;
            if ((double)radius % 2 == 0)
                matrixSize = radius * 2 + 1;
            radius *= radius;

            int center = matrixSize * matrixSize / 2 + 1;
            int MatrixOffset = (matrixSize - 1) / 2;

            byte[] R = new byte[matrixSize * matrixSize];
            byte[] G = new byte[matrixSize * matrixSize];
            byte[] B = new byte[matrixSize * matrixSize];

            for (int i = 0; i < Buffer.Height; i++)
            {
                for (int j = 0; j < Buffer.Width; j++)
                {
                    int someIntValue3 = 0;
                    int someIntValue = i * Buffer.stride + j * 4;

                    for (int mY = 0; mY < matrixSize; mY++)
                    {
                        for (int mX = 0; mX < matrixSize; mX++)
                        {
                            int someIntValue2 = someIntValue + (mX - MatrixOffset) * 4 + (mY - MatrixOffset) * Buffer.stride;
                            if (someIntValue2 < Buffer.pixelsCountWithChannels)
                            {
                                B[someIntValue3] = Buffer.pixelsBuffer[someIntValue2];
                                G[someIntValue3] = Buffer.pixelsBuffer[someIntValue2 + 1];
                                R[someIntValue3++] = Buffer.pixelsBuffer[someIntValue2 + 2];
                            }
                        }
                    }

                    Array.Sort(B);
                    Buffer.ptrFirstPixel[someIntValue] = B[center];

                    Array.Sort(G);
                    Buffer.ptrFirstPixel[someIntValue + 1] = G[center];

                    Array.Sort(R);
                    Buffer.ptrFirstPixel[someIntValue + 2] = R[center];
                }
            }
            if (save)
                Buffer.addData();
            Buffer.Refrash();
        }
        
        private void lockingImgLighten(Bitmap bmp)
        {

            BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;
            byte* ptrFirstPixel = (byte*)bitmapData.Scan0;
            bmp.UnlockBits(bitmapData);

            int stride = bitmapData.Width * 4;
            Buffer.DataArr = new byte[heightInPixels, stride];
            for (int y = 0; y < heightInPixels; y++)
            {
                byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                {
                    Buffer.DataArr[y, x] = currentLine[x];
                    Buffer.DataArr[y, x + 1] = currentLine[x + 1];
                    Buffer.DataArr[y, x + 2] = currentLine[x + 2];
                }
            }
            Buffer.lockImgLighten = false;
        }

        public void Difference(Bitmap bmp, int value, bool save = false)
        {
            if (Buffer.lockImgLighten)
                lockingImgLighten(bmp);

            double alpha = value * 0.01;


            for (int y = 0; y < Buffer.heightInPixels; y++)
            {
                byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                {
                    int newFr = Math.Abs(currentLine[x + 2] - Buffer.DataArr[y, x + 2]);
                    int newFg = Math.Abs(currentLine[x + 1] - Buffer.DataArr[y, x + 1]);
                    int newFb = Math.Abs(currentLine[x] - Buffer.DataArr[y, x ]);
                    currentLine[x + 2] = (byte)Math.Floor(Buffer.memoryStream[y, x + 2] + (newFr - Buffer.memoryStream[y, x + 2]) * alpha);
                    currentLine[x + 1] = (byte)Math.Floor(Buffer.memoryStream[y, x + 1] + (newFg - Buffer.memoryStream[y, x + 1]) * alpha);
                    currentLine[x] = (byte)Math.Floor(Buffer.memoryStream[y, x] + (newFb - Buffer.memoryStream[y, x]) * alpha);
                }
            }
            if (save)
                Buffer.addData();
            Buffer.Refrash();
        }
    }
}
