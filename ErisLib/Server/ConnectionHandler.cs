using System;
using System.Net;
using System.Text;
using ErisLib.Server.Packets;
using ErisLib.Server.Packets.Client;
using ErisLib.Server.Packets.Models;
using ErisLib.Server.Packets.Server;
using ErisLib.Utilities;

namespace ErisLib.Server
{
    public class ConnectionHandler
    {
        //cache
        private Proxy _proxy;

        public void Attach(Proxy proxy)
        {
            _proxy = proxy;
            proxy.HookPacket<HelloPacket>(OnHello);
            proxy.HookPacket<CreateSuccessPacket>(OnCreateSuccess);
            proxy.HookPacket<ReconnectPacket>(OnReconnect);
        }

        private void OnReconnect(Client client, ReconnectPacket packet)
        {
            if (packet.Host.Contains(".com"))
                packet.Host = Dns.GetHostEntry(packet.Host).AddressList[0].ToString();

            if (packet.Name.ToLower().Contains("nexusportal"))
            {
                ReconnectPacket recon = (ReconnectPacket)Packet.Create(PacketType.RECONNECT);
                recon.IsFromArena = false;
                recon.GameId = packet.GameId;
                recon.Host = packet.Host == "" ? client.State.ConTargetAddress : packet.Host;
                recon.Port = packet.Port == -1 ? client.State.ConTargetPort : packet.Port;
                recon.Key = packet.Key;
                recon.Stats = packet.Stats;
                recon.KeyTime = packet.KeyTime;
                recon.Name = packet.Name;
                client.State.LastRealm = recon;
            }
            else if (packet.Name != "" && !packet.Name.Contains("vault") && packet.GameId != -2)
            {
                ReconnectPacket drecon = (ReconnectPacket)Packet.Create(PacketType.RECONNECT);
                drecon.IsFromArena = false;
                drecon.GameId = packet.GameId;
                drecon.Host = packet.Host == "" ? client.State.ConTargetAddress : packet.Host;
                drecon.Port = packet.Port == -1 ? client.State.ConTargetPort : packet.Port;
                drecon.Key = packet.Key;
                drecon.Stats = packet.Stats;
                drecon.KeyTime = packet.KeyTime;
                drecon.Name = packet.Name;
                client.State.LastDungeon = drecon;
            }

            if (packet.Port != -1)
                client.State.ConTargetPort = packet.Port;

            if (packet.Host != "")
                client.State.ConTargetAddress = packet.Host;

            if (packet.Key.Length != 0)
                client.State.ConRealKey = packet.Key;

            packet.Key = Encoding.UTF8.GetBytes(client.State.GUID);
            packet.Host = "localhost";
            packet.Port = 2050;
        }

        private void OnCreateSuccess(Client client, CreateSuccessPacket packet)
        {
            PluginUtilities.Delay(2000,
                () => {
                    client.SendToClient(
                        PluginUtilities.CreateNotification(client.ObjectId, 0x00F20A, "Welcome to Eris!"));
                });
        }

        private void OnHello(Client client, HelloPacket packet)
        {
            client.State = _proxy.GetState(client, packet.Key);
            if (client.State.ConRealKey.Length != 0) {
                packet.Key = client.State.ConRealKey;
                client.State.ConRealKey = new byte[0];
                Console.WriteLine($"[HELLO PACKET] Packet Key: {packet.Key}\r\n" +
                                  $"               State  Key: {client.State.ConRealKey}");
            }

            client.Connect(packet);
            packet.Send = false;
        }
    }
}