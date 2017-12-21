using Rocket.API;
using System;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using System.Collections;
using UnityEngine;

using Logger = Rocket.Core.Logging.Logger;

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

        private IEnumerator StartDelayedUrlRequest(UnturnedPlayer player)
        {
            yield return new WaitForSeconds(1.5f);
            if (Config.ShowInviteOnJoin)
            {
                player.Player.sendBrowserRequest(Config.RequestMessage, Config.DiscordInviteURL);
            }
        }
    }
}
