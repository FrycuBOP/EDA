using Microsoft.AspNetCore.SignalR;

namespace SignalRTelemetry.Hubs
{
    public class TelemetryHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Telemetry Recived", user, message);
        }
    }
}
