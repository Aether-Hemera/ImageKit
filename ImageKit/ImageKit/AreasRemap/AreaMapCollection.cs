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
            // top line
            Add(AreaMap.Init(32, 0).MoveY(0).SizeX(64));

            // bottom line
            Add(AreaMap.Init(0, 28).MoveY(4));
            Add(AreaMap.Init(16, 28 + 14).MoveY(-10));
            Add(AreaMap.Init(32, 28 + 14 + 14).MoveY(-24).SizeX(64));
            Add(AreaMap.Init(96, 28 + 14).MoveY(-10));
            Add(AreaMap.Init(112, 28).MoveY(4));
        }
    }
}
