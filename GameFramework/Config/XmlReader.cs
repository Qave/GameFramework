using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace GameFramework.Config
{
    public class XmlReader
    {
        public class GameConfig
        {
            //// World
            //public int WorldSizeX { get; set; }
            //public int WorldSizeY { get; set; }

            // Player
            public string PlayerName { get; set; }
            public string PlayerMarker { get; set; }


            public GameConfig(){}

            public override string ToString()
            {
                return $"Player name: {PlayerName}, Marker: {PlayerMarker}";
            }
        }



        public static T ReadGameConfigFile<T>()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute("GameConfig"));
            StreamReader reader = new StreamReader("GameConfig.xml");
            var x = (T)xmlSerializer.Deserialize(reader);
            reader.Close();
            
            return x;
        }

    }
}
