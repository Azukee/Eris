using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using ErisLib.Game.Interfaces;
using ErisLib.Game.Packets;

namespace ErisLib.Game
{
    public class GameDataMap<IDType, DataType> where DataType : IStructure<IDType> {
        public Dictionary<IDType, DataType> Map { get; private set; }

        private GameDataMap() { }

        public GameDataMap(Dictionary<IDType, DataType> map) {
            Map = map;
        }

        public DataType ByID(IDType id) {
            return Map[id];
        }

        public DataType ByName(string name) {
            return Map.First(e => e.Value.Name == name).Value;
        }

        public DataType Match(Func<DataType, bool> f) {
            return Map.First(e => f(e.Value)).Value;
        }
    }
    
    public class GameData
    {
        public GameDataMap<byte, PacketStructure> Packets;
        
        public GameData()
        {
            Packets = new GameDataMap<byte, PacketStructure>(PacketStructure.Load(XDocument.Load(Directory.GetCurrentDirectory() + @"\data\packets.xml")));
        }
    }
}