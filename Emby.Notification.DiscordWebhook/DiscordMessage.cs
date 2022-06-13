using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emby.Notification.DiscordWebhook
{
    /// <summary>
    /// Discord Webhook Message
    /// </summary>
    public class DiscordWebhookMessage
    {
        /// <summary>
        /// This is the text that will be posted to the webhook uri
        /// </summary>
        public string text { get; set; }
    }
}