using Lykke.Service.RaiblocksSign.Core.Settings.ServiceSettings;
using Lykke.Service.RaiblocksSign.Core.Settings.SlackNotifications;

namespace Lykke.Service.RaiblocksSign.Core.Settings
{
    public class AppSettings
    {
        public RaiblocksSignSettings RaiblocksSignService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
        public MonitoringServiceClientSettings MonitoringServiceClient { get; set; }
    }
}
