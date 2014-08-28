using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rice.Server.Core;

namespace Rice.Server.Packets.Area
{
    public static class Chat
    {
        [RicePacket(146, RiceServer.ServerType.Game)]
        public static void ChatWrite(RicePacket packet)
        {
            string unknown = packet.Reader.ReadUnicode(); // 114 // room / channel / party / team 
            string unknown2 = packet.Reader.ReadUnicode(); // 111
            string unknown3 = packet.Reader.ReadUnicode(); // 111

            unknown = unknown.Substring(0, unknown.Length - 1);

            //Log.WriteLine("Channel: {0} {0} {0}", unknown, unknown2, unknown3);

            //Log.WriteLine("{0}", packet.Reader.ReadUInt32());

            int channel = 0;

            if (unknown.ToLower() == "room")
                channel = 0;
            else if (unknown.ToLower() == "channel")
                channel = 1;
            else if (unknown.ToLower() == "party")
                channel = 2;
            else if (unknown.ToLower() == "team")
                channel = 3;

            var ack = new RicePacket(147);
            ack.Writer.WriteUnicode("party  "); // Unknown maybe channel (7 bytes big)
            ack.Writer.WriteUnicode("GigaToni"); // Username
            ack.Writer.WriteUnicode("room9999"); // Unknown (8 bytes big)
            ack.Writer.WriteUnicode("This is the first Chat msg");
            packet.Sender.Send(ack);
        }
    }
}
