using Rocket.API.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLinkPlugin
{
    public partial class BTLinkPlugin
    {
        public override TranslationList DefaultTranslations => new TranslationList
        {
            {
                "ProperUsage", "[color=#FF0000]{{BTLink}} [/color] [color=#F3F3F3]Proper Usage |[/color] [color=#3E65FF]{0}[/color]"
            },
            {
                "Code", "[color=#FF0000]{{BTLink}} [/color][color=#F3F3F3]Please enter the following code into the discord bot:[/color] [color=#3E65FF]{0}[/color]"
            },
            {
                "AlreadyLinked", "[color=#FF0000]{{BTLink}} [/color][color=#F3F3F3]Your Account is already linked to[/color] [color=#3E65FF]{0}[/color] [color=#F3F3F3]Discord[/color]"
            }

        };
    }
}