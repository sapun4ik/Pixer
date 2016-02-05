using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pixerApi.Inner
{
    unsafe public class SaveDoc
    {

        public void Save(string path)
        {

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))

            using (BinaryWriter binWriter = new BinaryWriter(fs))
            {
                binWriter.Write(Buffer.BytesBuffer);
                //binWriter.Write(file.Image.Width);
                //binWriter.Write(file.Image.Height);
                //binWriter.Write(pict.Channels);
                //binWriter.Write(pict.PixelsCountWithChannels);
                //binWriter.Write(pict.BytesBuffer);
            }

        }

        public SaveDoc Load(string path)
        {
            SaveDoc file = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BinaryReader binReader = new BinaryReader(fs))
            {
                //string fileName = binReader.ReadString();
                //Width = binReader.ReadInt32();
                //Height = binReader.ReadInt32();
                //Channels = binReader.ReadInt32();
                //PixelsCountWithChannels = binReader.ReadInt32();
                //byfferArray = binReader.ReadBytes(PixelsCountWithChannels);

                //var bufferPixelsPtr = GCHandle.Alloc(byfferArray, GCHandleType.Pinned);
                //var image = new Bitmap(Width, Height, Width * Channels,
                //    System.Drawing.Imaging.PixelFormat.Format32bppArgb, bufferPixelsPtr.AddrOfPinnedObject());

                //file = new SaveDoc(fileName, image);
            }
            return file;

        }
    }
}
