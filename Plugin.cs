using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crux.Config;
using Rocket.Core.Plugins;
using Rocket.Unturned;

using Logger = Rocket.Core.Logging.Logger;
using Rocket.Core;
using Rocket.Unturned.Player;
using System.Collections;
using UnityEngine;
using SDG.Unturned;

namespace Crux.Main
{
    public class Plugin : RocketPlugin<Config.Config>
    {
        public static Plugin Instance;
        public static Config.Config Config => Instance.Configuration.Instance;

        protected override void Load()
        {
            Instance = this;
            
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;

            Logger.Log("EzDiscordAnnouncer Loaded!", color: ConsoleColor.Green);

            void Trigger(IRocketPlayer caller)
            {
                if (Config.ShowInviteOnJoin == true)
                {
                    UnturnedPlayer plr = (UnturnedPlayer)caller;
                    plr.Player.sendBrowserRequest("Join our official Discord guild!", Config.DiscordInviteURL);
                }
            }
        }

        protected override void Unload()
        {
            Logger.Log("EzDiscordAnnouncer Unloaded!");

            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
        }

        void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            if (player != null && Configuration.Instance.ShowInviteOnJoin)
            {
                StartCoroutine(StartDelayedUrlRequest(player));
            }
        }

        public static void OpenUrl(UnturnedPlayer player, string url, string desc)
        {
            //player.Player.channel.send("askBrowserRequest", player.CSteamID, ESteamPacket.UPDATE_RELIABLE_BUFFER, desc, url);
            player.Player.sendBrowserRequest(desc, url);
        }

        private IEnumerator StartDelayedUrlRequest(UnturnedPlayer player)
        {
            yield return new WaitForSeconds(1.5f);
        }
    }
}
