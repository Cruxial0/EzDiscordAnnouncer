using Rocket.API;
using Rocket.Unturned.Player;
using Crux.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crux.Plugin
{
    class DiscordCommand : IRocketCommand
    {
        public static Main.Plugin Instance;
        public static Config.Config Config => Instance.Configuration.Instance;

        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "discord";

        public string Help => "Requests a link to a discord";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer uCaller = (UnturnedPlayer)caller;   

            uCaller.Player.sendBrowserRequest("Join our official Discord guild!", Config.DiscordInviteURL);
        }
    }
}
