namespace SignalRTelemetry.Services
{
    public interface ISignalRService
    {
        Task NotifyAllClients(string msg);
    }
}
