using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace pixerApi
{
    public enum ColorChannelTypes
    {
        Red = 2,
        Green = 1,
        Blue = 0,
        RGB = 3
    };
    unsafe public class Channels
    {
        public void EditabelChannel(ColorChannelTypes colorFilterType)
        {
            if (colorFilterType == Buffer.activChangeType) return;
            if (Buffer.activChangeType == ColorChannelTypes.RGB)
            {
                Buffer.editChannel = true;
                Buffer.channelBuffer = Copy(Buffer.memoryStream);
                Buffer.activChangeType = colorFilterType;
            }
            if (colorFilterType == ColorChannelTypes.RGB)
            {
                Buffer.MergeColorChannel();
                Buffer.activChangeType = colorFilterType;
                Buffer.Refrash();
                return;
            }
            for (int y = 0; y < Buffer.heightInPixels; y++)
            {
                byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                {
                    Buffer.memoryStream[y, x + 2] = currentLine[x + 2] = Buffer.channelBuffer[y, x + (int)colorFilterType];
                    Buffer.memoryStream[y, x + 1] = currentLine[x + 1] = Buffer.channelBuffer[y, x + (int)colorFilterType];
                    Buffer.memoryStream[y, x] = currentLine[x] = Buffer.channelBuffer[y, x + (int)colorFilterType];
                }
            }
            Buffer.activChangeType = colorFilterType;
            Buffer.Refrash();
        }
        static T[,] Copy<T>(T[,] array)
        {
            T[,] newArray = new T[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    newArray[i, j] = array[i, j];
            return newArray;
        }
    }
}