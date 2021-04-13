using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Config
{
    public class ConfigSingleton
    {
        private static ConfigSingleton _instance = null;
        public GameConfig GameConfig { get; }

        public static ConfigSingleton Instance { get { return _instance ??= new ConfigSingleton(); } }
        public ConfigSingleton()
        {
            GameConfig = XmlReader.ReadGameConfigFile();
        }
    }
}
