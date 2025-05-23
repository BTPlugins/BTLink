using Rocket.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLinkPlugin.Helpers.BaseHelpers
{
    public class DebugManager
    {
        public static void SendDebugMessage(string message)
        {
            if (BTLinkPlugin.Instance.Configuration.Instance.DebugMode)
            {
                Logger.Log("DEBUG >> " + message);
            }
        }
    }
}