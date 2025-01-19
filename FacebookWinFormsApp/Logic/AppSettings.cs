using System;
using System.IO;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    public class AppSettings
    {
        private const string k_SettingsFileName = "facebookAppSettings.xml";
        private static readonly string sr_SettingsFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, k_SettingsFileName);

        public bool RememberUser { get; set; }
        public string LastAccessToken { get; set; }

        public AppSettings()
        {
            RememberUser = false;
            LastAccessToken = null;

            if (!File.Exists(sr_SettingsFilePath))
            {
                File.Create(sr_SettingsFilePath).Dispose();
            }
        }

        public void SaveAppSettingsToFile()
        {
            using (Stream stream = new FileStream(sr_SettingsFilePath, FileMode.Truncate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                serializer.Serialize(stream, this);
            }
        }

        public static AppSettings LoadAppSettingsFromFile()
        {
            AppSettings loadedSettings = null;

            try
            {
                using (Stream stream = new FileStream(sr_SettingsFilePath, FileMode.OpenOrCreate))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    loadedSettings = serializer.Deserialize(stream) as AppSettings;
                }
            }
            catch
            {
                loadedSettings = new AppSettings();
            }

            return loadedSettings;
        }
    }
}
