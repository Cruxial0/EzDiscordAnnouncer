using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crux.Config 
{
    public class Config : IRocketPluginConfiguration
    {
        public string DiscordInviteURL;
        public bool ShowInviteOnJoin;

        public void LoadDefaults()
        {
            DiscordInviteURL = "https://discord.gg/Wggg9YQ";
            ShowInviteOnJoin = true;
        }
    }

    public class WebsiteCommand
    {
        public string Url;
        public string Desc;
        public string CommandName;
        public string Help;
    }
}
