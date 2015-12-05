using System.Collections.Generic;
using System.Drawing;

namespace ImageKit.AreasRemap
{
    class AreaMapCollection : List<AreaMap>
    {
        public void Process(Image gifImg, Graphics destBitmap)
        {
            foreach (var map in this)
            {
                map.Process(gifImg, destBitmap);
            }
        }

        public void Load()
        {
            const int topRow = 0;
            const int bottomRow = 32;

            // smile row
            Add(AreaMap.Init(16 * 0, 28).ToXY(16 * 0, bottomRow)); // 1
            Add(AreaMap.Init(16 * 1, 42).ToXY(16 * 0, topRow)); // 2
            Add(AreaMap.Init(16 * 2, 56).ToXY(16 * 1, topRow)); // 4
            Add(AreaMap.Init(16 * 3, 56).ToXY(16 * 5, topRow)); // 12
            Add(AreaMap.Init(16 * 4, 56).ToXY(16 * 4, topRow)); // 10
            Add(AreaMap.Init(16 * 5, 56).ToXY(16 * 2, topRow)); // 6
            Add(AreaMap.Init(16 * 6, 42).ToXY(16 * 3, topRow)); // 8
            Add(AreaMap.Init(16 * 7, 28).ToXY(16 * 3, bottomRow)); // 7

            // eye row
            Add(AreaMap.Init(16 * 2, 0).ToXY(16 * 1, bottomRow)); // 3
            Add(AreaMap.Init(16 * 3, 0).ToXY(16 * 5, bottomRow)); // 11
            Add(AreaMap.Init(16 * 4, 0).ToXY(16 * 4, bottomRow)); // 9
            Add(AreaMap.Init(16 * 5, 0).ToXY(16 * 2, bottomRow)); // 5

            
        }
    }
}
