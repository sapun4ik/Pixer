using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace pixerApi.Inner
{
    public class Palette
    {
        private readonly List<RGB> colorList;
        private readonly List<PaletteCube> cubeList;
        private readonly Dictionary<RGB, Int32> cache;
        public class RGB
        {
            //byte R, G, B;
            public byte R { get; set; }
            public byte G { get; set; }
            public byte B { get; set; }
            public RGB() { }
            public RGB(byte R, byte G, byte B)
            {
                this.R = R;
                this.G = G;
                this.B = B;
            }
        }
        public Palette()
        {
            cache = new Dictionary<RGB, Int32>();
            cubeList = new List<PaletteCube>();
            colorList = new List<RGB>();
        }
        public void setPalette(int colorCount, bool save = false)
        {
            unsafe
            {
                Clear();

                for (int y = 0; y < Buffer.heightInPixels; y++)
                {
                    byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.stride);
                    for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                    {
                        colorList.Add(new RGB(Buffer.memoryStream[y, x + 2], Buffer.memoryStream[y, x + 1], Buffer.memoryStream[y, x]));
                    }
                }

                List<RGB> palette = GetPalette(colorCount);
                int k = 0;
                for (int y = 0; y < Buffer.heightInPixels; y++)
                {
                    byte* currentLine = Buffer.ptrFirstPixel + (y * Buffer.stride);
                    for (int x = 0; x < Buffer.widthInBytes; x = x + Buffer.bytesPerPixel)
                    {

                        RGB color = new RGB(Buffer.memoryStream[y,x + 2], Buffer.memoryStream[y,x + 1], Buffer.memoryStream[y,x]);
                        
                        Int32 b;
                        if (!cache.TryGetValue(color, out b))
                        {
                            for (int i = 0; i < cubeList.Count; i++)
                            {
                                if (cubeList[i].IsColorIn(color))
                                {
                                    b = cubeList[i].PaletteIndex;
                                    break;
                                }
                            }
                        }

                        currentLine[x + 2] = palette[b].R;
                        currentLine[x + 1] = palette[b].G;
                        currentLine[x] = palette[b].B;
                    }
                }
                if (save)
                    Buffer.addData();
                Buffer.Refrash();

            }
        }



        private void SplitCubes(Int32 colorCount)
        {
            // creates a holder for newly added cubes
            List<PaletteCube> newCubes = new List<PaletteCube>();


            for (int i = 0; i < cubeList.Count; i++)
            {
                PaletteCube newMedianCutCubeA, newMedianCutCubeB;

                // splits the cube along the red axis
                if (cubeList[i].RedSize >= cubeList[i].GreenSize && cubeList[i].RedSize >= cubeList[i].BlueSize)
                {
                    cubeList[i].SplitAtMedian(0, out newMedianCutCubeA, out newMedianCutCubeB);
                }
                else if (cubeList[i].GreenSize >= cubeList[i].BlueSize) // splits the cube along the green axis
                {
                    cubeList[i].SplitAtMedian(1, out newMedianCutCubeA, out newMedianCutCubeB);
                }
                else // splits the cube along the blue axis
                {
                    cubeList[i].SplitAtMedian(2, out newMedianCutCubeA, out newMedianCutCubeB);
                }

                // adds newly created cubes to our list; but one by one and if there's enough cubes stops the process
                newCubes.Add(newMedianCutCubeA);
                // if (newCubes.Count >= colorCount) break;
                newCubes.Add(newMedianCutCubeB);
            }


            // clears the old cubes
            cubeList.Clear();

            // adds the new cubes to the official cube list
            cubeList.AddRange(newCubes);
        }

        private List<RGB> GetPalette(Int32 colorCount)
        {
            // creates the initial cube covering all the pixels in the image
            PaletteCube initalMedianCutCube = new PaletteCube(colorList);
            cubeList.Add(initalMedianCutCube);

            // finds the minimum iterations needed to achieve the cube count (color count) we need
            Int32 iterationCount = 1;
            while ((1 << iterationCount) < colorCount) { iterationCount++; }

            for (Int32 iteration = 0; iteration < iterationCount; iteration++)
            {
                SplitCubes(colorCount);
            }

            // initializes the result palette
            List<RGB> result = new List<RGB>();
            Int32 paletteIndex = 0;

            // adds all the cubes' colors to the palette, and mark that cube with palette index for later use

            for (int i = 0, count = cubeList.Count; i < count; i++)
            {
                result.Add(cubeList[i].RGB);
                cubeList[i].SetPaletteIndex(paletteIndex++);
            }

            return result;
        }

        private void Clear()
        {
            cache.Clear();
            cubeList.Clear();
            colorList.Clear();
        }

    }
}