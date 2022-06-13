using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Common.Net;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Notifications;
using MediaBrowser.Model.Logging;
using Emby.Notification.DiscordWebhook.Configuration;
using MediaBrowser.Model.Serialization;

namespace Emby.Notification.DiscordWebhook
{
    public class DiscordWebhookNotifier : INotificationService
    {
        private readonly ILogger _logger;
        private readonly IHttpClient _httpClient;
        private readonly IJsonSerializer _jsonSerializer;

        public DiscordWebhookNotifier(ILogManager logManager, IHttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            _logger = logManager.GetLogger(GetType().Name);
            _httpClient = httpClient;
            _jsonSerializer = jsonSerializer;
        }

        public bool IsEnabledForUser(User user)
        {
            var options = GetOptions(user);

            return options != null && IsValid(options) && options.Enabled;
        }

        private DiscordWebhookPluginOptions GetOptions(User user)
        {
            return Plugin.Instance.Configuration.Options
                .FirstOrDefault(i => string.Equals(i.MediaBrowserUserId, user.Id.ToString("N"), StringComparison.OrdinalIgnoreCase));
        }

        public string Name
        {
            get { return Plugin.Instance.Name; }
        }

        public async Task SendNotification(UserNotification request, CancellationToken cancellationToken)
        {
            var options = GetOptions(request.User);

        }


        private bool IsValid(DiscordWebhookPluginOptions options)
        {
            return !string.IsNullOrEmpty(options.DiscordWebHookURI);
        }
    }
}

