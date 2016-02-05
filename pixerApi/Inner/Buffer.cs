using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pixerApi
{
    unsafe internal static class Buffer
    {
        static public int Width, Height, WidthScaled, HeightScaled;
        static internal PictureBox workspace;
        static internal PictureBox histogram;

        // For Diff
         static public bool lockImgLighten = true;
         static public byte[,] DataArr;


        public static HistogramTypes activHistogramTypes = HistogramTypes.Brightness;
        // Стартовая позиция
        static private int i = 0;
        // Максимальное кол-во элементов в буфере
        const int lenghtArr = 100;
        // Стартовая позиция
        static int workingPosition = -1;
        // Сам буффер изображение и текстовое обозначение действия
        static private Bitmap[] bitmaps = new Bitmap[lenghtArr];
        static private string[] eventNames = new string[lenghtArr];
        // Отображаемый Bitmap
        public static Bitmap procesingImage;
        // Сохранить новое действие
        static public int heightInPixels;
        static public int widthInBytes;
        static public int bytesPerPixel;
        static public int stride; 
        static public int pixelsCountWithChannels;
        static public int pixelsCount;
        static public BitmapData bitmapData;
        static unsafe public byte* ptrFirstPixel;
        static unsafe public byte* pixelsBuffer;
        static public byte[,] memoryStream;
        // Исходные данные изображения перед применением канала
        static public byte[,] channelBuffer;
        // Редактирование по каналам
        static public bool editChannel = false;
        static public byte[] BytesBuffer;
        //
        static public byte[] TransformBuffer;


        static public void Refrash()
        {
            workspace.Refresh();
        }
        static public void addData(String eventName = "")
        {
            if (activChangeType != ColorChannelTypes.RGB) MergeColorChannel();
            Bitmap bitmap = new Bitmap(workspace.Image);
            i = workingPosition + 1;
            if (i == lenghtArr)
            {
                resArr(); bitmaps[i - 1] = bitmap; eventNames[i - 1] = eventName;
            }
            else
            {
                eventNames[i] = eventName; bitmaps[i] = bitmap; workingPosition++; i++;
            }
            
            toMemoryData(bitmap);
            activChangeType = ColorChannelTypes.RGB;
            Histograms.setHistogram();
        }
        static public void setData(Bitmap bitmap, String eventName = "Start")
        {
            bitmaps = new Bitmap[lenghtArr];
            eventNames = new string[lenghtArr];
            i = 0;
            workingPosition = -1;
            eventNames[i] = eventName; bitmaps[i] = bitmap; workingPosition++; i++;
            toMemoryData(bitmap);
            Width = bitmap.Width;
            Height = bitmap.Height;
            Histograms.setHistogram();
        }
        // Получаем аддрес изображения в памяти, и заполняем массив  memoryStream исходными данными
        static private void toMemoryData(Bitmap bitmap)
        {
            procesingImage = new Bitmap(bitmap);
            unsafe
            {
                bitmapData = procesingImage.LockBits(new Rectangle(0, 0, procesingImage.Width, procesingImage.Height), ImageLockMode.ReadWrite, procesingImage.PixelFormat);
                bytesPerPixel = Bitmap.GetPixelFormatSize(procesingImage.PixelFormat) / 8;
                heightInPixels = bitmapData.Height;
                stride = bitmapData.Stride;
                pixelsCountWithChannels = stride * bitmap.Height;
                widthInBytes = bitmapData.Width * bytesPerPixel;
                ptrFirstPixel = (byte*)bitmapData.Scan0;
                memoryStream = new byte[heightInPixels, widthInBytes];
                pixelsCount = pixelsCountWithChannels / bytesPerPixel;
                
                for (int y = 0; y < Buffer.heightInPixels; y++)
                {
                    byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                    for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                    {
                        memoryStream[y, x] = currentLine[x];//B
                        memoryStream[y, x + 1] = currentLine[x + 1];//G
                        memoryStream[y, x + 2] = currentLine[x + 2];//R
                    }
                }

                procesingImage.UnlockBits(bitmapData);

                BytesBuffer = new byte[pixelsCountWithChannels];
                Marshal.Copy(bitmapData.Scan0, BytesBuffer, 0, pixelsCountWithChannels);
                GCHandle bufferPixelsPtr = GCHandle.Alloc(BytesBuffer, GCHandleType.Pinned);

                pixelsBuffer = (byte*)bufferPixelsPtr.AddrOfPinnedObject();
                pixelsCount = pixelsCountWithChannels / bytesPerPixel;

                bufferPixelsPtr.Free();
                GC.Collect();
                workspace.Image = procesingImage;
            }
           
        }
        // Получить последнее изображение
        static public Bitmap getLastImage 
        {
            get
            {
                if (workingPosition != i - 1)
                    i = workingPosition + 1;
                return bitmaps[i - 1];
            }
        }
        // Получить следующее изображение из буфера
        static public void getUpImage()
        {
            if (workingPosition + 1 >= i)
            {
                workspace.Image = bitmaps[workingPosition];  }
            else
            {
                 workspace.Image = bitmaps[workingPosition += 1];
            }
            toMemoryData(new Bitmap(workspace.Image));
            activChangeType = ColorChannelTypes.RGB;
            Histograms.setHistogram();
        }
        // Получить предыдущее изображение из буфера
        static public void getDownImage()
        {
            if (workingPosition - 1 < 0)
            {
                workspace.Image = bitmaps[workingPosition];
            }
            else
            {
                workspace.Image = bitmaps[workingPosition -= 1];
            }
            toMemoryData(new Bitmap(workspace.Image));
            activChangeType = ColorChannelTypes.RGB;
            Histograms.setHistogram();
        }
        // Получить конеретное изображение из буфера
        static public void getSpecificImage(int number)
        {
            if(number >= i) { number = i - 1; }
            if (number < i - 1) { number = 0; }

            workingPosition = number;
            workspace.Image = bitmaps[workingPosition];
            toMemoryData(new Bitmap(workspace.Image));
        }
        // Получить количество элементов в буффере
        static public int getCountMemory { get { return i; } }
        // Позиция в буффере
        static public int getWorkingPosition { get { return workingPosition; } }
        // Сдвик в буффере при переполнении
        static private void resArr()
        {
            for (int i = 1; i < lenghtArr; i++)// С 1 что бы не затерать первое действие
            {
                if (i + 1 == lenghtArr) return;
                bitmaps[i] = bitmaps[i + 1];
                eventNames[i] = eventNames[i + 1];
            }
        }
        public static void recoveryWorkspace()
        {
            for (int y = 0; y < Buffer.heightInPixels; y++)
            {
                byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                {
                    currentLine[x] = memoryStream[y, x];//B
                    currentLine[x + 1]=memoryStream[y, x + 1];//G
                    currentLine[x + 2]=memoryStream[y, x + 2];//R
                }
            }
        }
        public static ColorChannelTypes activChangeType = ColorChannelTypes.RGB;
        // Восстановление каналов 
        public static void MergeColorChannel()
        {
            for (int y = 0; y < Buffer.heightInPixels; y++)
            {
                byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.bitmapData.Stride);
                for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                {
                    if (activChangeType == ColorChannelTypes.Red)
                    {
                        Buffer.memoryStream[y, x + 1] = currentLine[x + 1] = Buffer.channelBuffer[y, x + 1];
                        Buffer.memoryStream[y, x] = currentLine[x] = Buffer.channelBuffer[y, x];
                    }
                    if (activChangeType == ColorChannelTypes.Green)
                    {
                        Buffer.memoryStream[y, x + 2] = currentLine[x + 2] = Buffer.channelBuffer[y, x + 2];
                        Buffer.memoryStream[y, x] = currentLine[x] = Buffer.channelBuffer[y, x];
                    }
                    if (activChangeType == ColorChannelTypes.Blue)
                    {
                        Buffer.memoryStream[y, x + 1] = currentLine[x + 1] = Buffer.channelBuffer[y, x + 1];
                        Buffer.memoryStream[y, x + 2] = currentLine[x + 2] = Buffer.channelBuffer[y, x + 2];
                    }
                }
            }
        }
        // Новый размер битмапа
        static public void ApplyChangesTransform()
        {
            var bufferPixelsPtr = GCHandle.Alloc(TransformBuffer, GCHandleType.Pinned);
            procesingImage = new Bitmap(WidthScaled, HeightScaled, WidthScaled * bytesPerPixel, procesingImage.PixelFormat, bufferPixelsPtr.AddrOfPinnedObject());
            bufferPixelsPtr.Free();
            GC.Collect();
            workspace.Image = procesingImage;
        }
    }
}
