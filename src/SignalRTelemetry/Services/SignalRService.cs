
using SignalRTelemetry.Models;

namespace SignalRTelemetry.Services
{
    public class SignalRService : ISignalRService
    {
        private const string TELEMETRY_CONTROLER_URI = "https://localhost:7060/Telemetry";
        public async Task NotifyAllClients(string msg)
        {
#warning Code only for testing purposes do not use in production
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            };
            var client = new HttpClient(handler);

            var data = new TelemetryData()
            {
                Telemetry = msg
            };

            var result = await client.PostAsJsonAsync(TELEMETRY_CONTROLER_URI, data);

        }
    }
}
