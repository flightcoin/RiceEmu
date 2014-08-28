using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rice.Server.Core;

namespace Rice.Server.Packets.Game
{
    public static class Shop
    {
        [RicePacket(405, RiceServer.ServerType.Game)]
        public static void BuyItem(RicePacket packet)
        {

            // 0 = ItemID
            // 1 = Unknown
            // 2 = Quantity
            Log.WriteLine("{0} {1} {2}", packet.Reader.ReadInt16(), packet.Reader.ReadInt16(), packet.Reader.ReadInt16());
        }
    }
}
