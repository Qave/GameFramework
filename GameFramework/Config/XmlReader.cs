using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace GameFramework.Config
{
    public class XmlReader
    {
        public static GameConfig ReadGameConfigFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameConfig), new XmlRootAttribute("GameConfig"));
            StreamReader reader = new StreamReader("GameConfig.xml");
            var x = (GameConfig)xmlSerializer.Deserialize(reader);
            reader.Close();
            
            return x;
        }

    }
}
