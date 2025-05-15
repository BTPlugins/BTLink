using Rocket.API;
using ShimmyMySherbet.MySQL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BTLinkPlugin
{
    public class BTLinkPluginConfiguration : IRocketPluginConfiguration
    {
        public bool DebugMode { get; set; }
        public DatabaseSettings DatabaseSettings = DatabaseSettings.Default;
        public string CodeCreatedWebhook { get; set; }
        public void LoadDefaults()
        {
            DatabaseSettings.DatabasePassword = "password";
            DatabaseSettings.DatabaseAddress = "127.0.0.1";
            DatabaseSettings.DatabaseName = "unturned";
            DatabaseSettings.DatabasePort = 3306;
            DatabaseSettings.DatabaseUsername = "root";
            CodeCreatedWebhook = "YourWebhookHere";
            DebugMode = false;
        }
    }
}
