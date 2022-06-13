using System;
using System.Collections.Generic;
using MediaBrowser.Model.Plugins;

namespace Emby.Notification.DiscordWebhook.Configuration
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        public DiscordWebhookPluginOptions[] Options { get; set; }

        public PluginConfiguration()
        {
            Options = new DiscordWebhookPluginOptions[] { };
        }
    }

    public class DiscordWebhookPluginOptions
    {
        public string DiscordWebHookURI { get; set; }
        public Boolean Enabled { get; set; }
        public string MediaBrowserUserId { get; set; }
    }
}
