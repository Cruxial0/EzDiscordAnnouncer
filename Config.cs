using Rocket.API;

namespace Crux.Config 
{
    public class Config : IRocketPluginConfiguration
    {
        public string DiscordInviteURL;
        public string RequestMessage;
        public bool ShowInviteOnJoin;

        public void LoadDefaults()
        {
            DiscordInviteURL = "https://discord.gg/Wggg9YQ";
            RequestMessage = "Join our official Discord Guild!";
            ShowInviteOnJoin = true;


        }
    }
}
