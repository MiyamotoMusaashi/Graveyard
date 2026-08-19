using System;
using System.IO;
using Newtonsoft.Json;

namespace RecoilController
{
    public class ConfigManager
    {
        private static string ConfigPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "settings.json"
        );

        public class SettingsData
        {
            public int Vertical { get; set; } = 110;
            public int Horizontal { get; set; } = -5;
            public int HorizontalDelay { get; set; } = 62;
            public int HorizontalDuration { get; set; } = 3398;
        }

        public static void Save(SettingsData data)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(ConfigPath, json);
            }
            catch { }
        }

        public static SettingsData Load()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    string json = File.ReadAllText(ConfigPath);
                    return JsonConvert.DeserializeObject<SettingsData>(json);
                }
            }
            catch { }
            return new SettingsData();
        }
    }
}