using BTLink.Helpers;
using BTLinkPlugin.Helpers.BaseHelpers;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Utils;
using Rocket.Unturned.Player;
using SDG.Unturned;
using ShimmyMySherbet.DiscordWebhooks;
using ShimmyMySherbet.DiscordWebhooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTLinkPlugin.Commands
{
    internal class LinkCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "Link";

        public string Help => "Links your Discord Account to your Steam Account";

        public string Syntax => "/Link";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "BTLink.Link" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            Task.Run(async () =>
            {
                var linkedAccount = await BTLinkPlugin.Instance.Database.Links.GetLinkedAccount(player.CSteamID.m_SteamID);
                TaskDispatcher.QueueOnMainThread(() =>
                {
                    if (linkedAccount == null)
                    {
                        // Generate new Code
                        try
                        {
                            var code = CodeGeneratorHelper.GenerateCode();
                            TaskDispatcher.RunAsync(async () =>
                            {
                                await BTLinkPlugin.Instance.Database.Links.AddLink(player.CSteamID.m_SteamID, code);
                            });
                            TranslationHelper.SendMessageTranslation(player.CSteamID, "Code", code);
                            Task.Run(async () =>
                            {
                                var Embed = new WebhookMessage()
                                   .PassEmbed()
                                   .WithTitle("BTLink - Code")
                                   .WithColor(EmbedColor.Green)
                                   .WithThumbnail("https://i.imgur.com/kZpxoa5.png")
                                   .WithURL("https://steamcommunity.com/profiles/" + player)
                                   .WithTimestamp(DateTime.Now)
                                   .WithField("**Player**", player.CharacterName + " \n(" + player.CSteamID.m_SteamID.ToString() + ")")
                                   .WithField("**Code**", code)
                                   .WithField("**Date**", "``" + DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + "``");
                                Embed.Footer = new WebhookFooter() { Text = "[BTLink] " + Provider.serverName + " - " + DateTime.Now.ToString("dddd, dd MMMM yyyy") + "" };
                                var send = Embed.Finalize();
                                await DiscordWebhookService.PostMessageAsync(BTLinkPlugin.Instance.Config.CodeCreatedWebhook, send);
                            });
                            return;
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(ex);
                        }
                        if (!linkedAccount.Linked)
                        {
                            TranslationHelper.SendMessageTranslation(player.CSteamID, "Code", linkedAccount.Code);
                            return;
                        }
                        if (linkedAccount.Linked)
                        {
                            // Already Linked
                            TranslationHelper.SendMessageTranslation(player.CSteamID, "AlreadyLinked", linkedAccount.DiscordID);
                            return;
                        }
                    }
                });
            });
        }
    }
}
