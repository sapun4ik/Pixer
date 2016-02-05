using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace pixerApi.Inner
{
    internal class PaletteCube
    {
        // red bounds
        private Byte redLowBound;
        private Byte redHighBound;

        // green bounds
        private Byte greenLowBound;
        private Byte greenHighBound;

        // blue bounds
        private Byte blueLowBound;
        private Byte blueHighBound;

        private readonly List<Palette.RGB> colorList;


        public Int32 PaletteIndex { get; private set; }

        public PaletteCube(List<Palette.RGB> colors)
        {
            colorList = colors;
            Shrink();
        }

        public Int32 RedSize
        {
            get { return redHighBound - redLowBound; }
        }

        public Int32 GreenSize
        {
            get { return greenHighBound - greenLowBound; }
        }

        public Int32 BlueSize
        {
            get { return blueHighBound - blueLowBound; }
        }

        public Palette.RGB RGB
        {
            get
            {
                int countColorList = colorList.Count;
                Int32 red = 0, green = 0, blue = 0;
                for (int i = 0; i < countColorList; i++)
                {
                    red += colorList[i].R;
                    green += colorList[i].G;
                    blue += colorList[i].B;

                }

                red = countColorList == 0 ? 0 : red / countColorList;
                green = countColorList == 0 ? 0 : green / countColorList;
                blue = countColorList == 0 ? 0 : blue / countColorList;

                Palette.RGB result = new Palette.RGB((byte)red, (byte)green, (byte)blue);
                return result;
            }
        }

        private void Shrink()
        {
            redLowBound = greenLowBound = blueLowBound = 255;
            redHighBound = greenHighBound = blueHighBound = 0;
            int countColorList = colorList.Count;
            for (int i = 0; i < countColorList; i++)
            {
                if (colorList[i].R < redLowBound) redLowBound = colorList[i].R;
                if (colorList[i].R > redHighBound) redHighBound = colorList[i].R;
                if (colorList[i].G < greenLowBound) greenLowBound = colorList[i].G;
                if (colorList[i].G > greenHighBound) greenHighBound = colorList[i].G;
                if (colorList[i].B < blueLowBound) blueLowBound = colorList[i].B;
                if (colorList[i].B > blueHighBound) blueHighBound = colorList[i].B;
            }

        }

        public void SplitAtMedian(Byte componentIndex, out PaletteCube firstMedianCutCube, out PaletteCube secondMedianCutCube)
        {
            List<Palette.RGB> colors;

            switch (componentIndex)
            {
                // red colors
                case 0:
                    colors = colorList.OrderBy(color => color.R).ToList();
                    //colors = colorList.Sort(colorList.);
                    break;

                // green colors
                case 1:
                    colors = colorList.OrderBy(color => color.G).ToList();
                    break;

                // blue colors
                case 2:
                    colors = colorList.OrderBy(color => color.B).ToList();
                    break;

                default:
                    throw new NotSupportedException("Only three color components are supported (R, G and B).");

            }

            // retrieves the median index (a half point)
            Int32 medianIndex = colorList.Count >> 1;

            // creates the two half-cubes
            firstMedianCutCube = new PaletteCube(colors.GetRange(0, medianIndex));
            secondMedianCutCube = new PaletteCube(colors.GetRange(medianIndex, colors.Count - medianIndex));
        }

        public void SetPaletteIndex(Int32 newPaletteIndex)
        {
            PaletteIndex = newPaletteIndex;
        }

        public Boolean IsColorIn(Palette.RGB color)
        {
            return (color.R >= redLowBound && color.R <= redHighBound) &&
                   (color.G >= greenLowBound && color.G <= greenHighBound) &&
                   (color.B >= blueLowBound && color.B <= blueHighBound);
        }

    }
}
