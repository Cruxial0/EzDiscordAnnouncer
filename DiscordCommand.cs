using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.API;
using Rocket.Unturned.Player;

namespace Crux.Main
{
    public class DiscordCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "discord";

        public string Help => "Requests a link to a discord";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer uCaller = (UnturnedPlayer)caller;

            uCaller.Player.sendBrowserRequest("Join our official Discord guild!", Plugin.Config.DiscordInviteURL);
        }
    }
}
