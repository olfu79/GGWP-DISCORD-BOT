using System;
using System.IO;
using System.Text;

using Newtonsoft.Json;

namespace ggwp.Core.ReactionsSystem
{
    public class ReactionChannels
    {
        private const string configFolder = "Resources";
        private const string configFile = "reaction_messages_id.json";

        public static ReactionChannel channels;

        static ReactionChannels()
        {
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);

            if (!File.Exists(configFolder + "/" + configFile))
            {
                channels = new ReactionChannel();
                string json = JsonConvert.SerializeObject(channels, Formatting.Indented);
                File.WriteAllText(configFolder + "/" + configFile, json);
            }
            else
            {
                string json = File.ReadAllText(configFolder + "/" + configFile);
                channels = JsonConvert.DeserializeObject<ReactionChannel>(json);
            }
        }

        public static void SaveChannels()
        {
            UserDataStorage.SaveChannels(channels, configFolder + "/" + configFile);
        }

    }
}
