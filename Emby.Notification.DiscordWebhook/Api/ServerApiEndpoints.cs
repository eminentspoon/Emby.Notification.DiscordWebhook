using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBrowser.Common.Net;
using MediaBrowser.Controller.Net;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Services;
using Emby.Notification.DiscordWebhook.Configuration;
using System.Threading;
using MediaBrowser.Model.Serialization;

namespace Emby.Notification.DiscordWebhook.Api
{
    [Route("/Notification/DiscordWebhook/Test/{UserID}", "POST", Summary = "Tests Discord Webhook Notifications")]
    public class TestNotification : IReturnVoid
    {
        [ApiMember(Name = "UserID", Description = "User Id", IsRequired = true, DataType = "string", ParameterType = "path", Verb = "GET")]
        public string UserID { get; set; }
    }

    public class ServerApiEndpoints : IService
    {
        private readonly IHttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly IJsonSerializer _jsonSerializer;

        public ServerApiEndpoints(ILogManager logManager, IHttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            _logger = logManager.GetLogger(GetType().Name);
            _httpClient = httpClient;
            _jsonSerializer = jsonSerializer;
        }

        private DiscordWebhookPluginOptions GetOptions(String userID)
        {
            return Plugin.Instance.Configuration.Options
                .FirstOrDefault(i => string.Equals(i.MediaBrowserUserId, userID, StringComparison.OrdinalIgnoreCase));
        }

        public void Post(TestNotification request)
        {
            var task = PostAsync(request);
            Task.WaitAll(task);
        }

        public async Task PostAsync(TestNotification request)
        {
            var options = GetOptions(request.UserID);
        }
    }
}

