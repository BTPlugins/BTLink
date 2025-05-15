using Rocket.API;
using Rocket.Core.Plugins;
using System;
using Logger = Rocket.Core.Logging.Logger;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using BTLink.Database;

namespace BTLinkPlugin
{
    public partial class BTLinkPlugin : RocketPlugin<BTLinkPluginConfiguration>
    {
        public static BTLinkPlugin Instance;
        public BTLinkPluginConfiguration Config => Configuration.Instance;
        public DatabaseManager Database { get; private set; }

        protected override void Load()
        {
            Instance = this;
            Logger.Log("#############################################", ConsoleColor.Yellow);
            Logger.Log("###             BTLink Loaded             ###", ConsoleColor.Yellow);
            Logger.Log("###   Plugin Created By blazethrower320   ###", ConsoleColor.Yellow);
            Logger.Log("###            Join my Discord:           ###", ConsoleColor.Yellow);
            Logger.Log("###     https://discord.gg/YsaXwBSTSm     ###", ConsoleColor.Yellow);
            Logger.Log("#############################################", ConsoleColor.Yellow);


            Database = new DatabaseManager(Config.DatabaseSettings);
            if (!Database.Connect(out var errorMsg))
            {
                Logger.LogError($"Failed to connect to database: {errorMsg}");
                UnloadPlugin(PluginState.Failure);
                return;
            }
            Database.CheckSchema();


        }

        protected override void Unload()
        {
            Logger.Log("BTLink Unloaded");
            Instance = null;
            Database = null;
            base.Unload();
        }
    }
}
