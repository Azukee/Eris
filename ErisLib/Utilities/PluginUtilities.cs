using System;
using System.Threading;
using System.Threading.Tasks;
using ErisLib.Server.Packets;
using ErisLib.Server.Packets.Models;
using ErisLib.Server.Packets.Server;

namespace ErisLib.Utilities
{
    public class PluginUtilities
    {
        public static NotificationPacket CreateNotification(int objectId, int color, string message)
        {
            NotificationPacket notif = (NotificationPacket)Packet.Create(PacketType.NOTIFICATION);
            notif.ObjectId = objectId;
            notif.Message = "{\"key\":\"blank\",\"tokens\":{\"data\":\"" + message + "\"}}";
            notif.Color = color;
            return notif;
        }
        
        public static void Delay(int ms, Action callback)
        {
            Task.Run(() =>
            {
                Thread.Sleep(ms);
                callback();
            });
        }
    }
}