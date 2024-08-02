
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace SignalRTelemetry.Services
{
    public class RabbitConsumerService : BackgroundService
    {
        private const string QueueName = "telemetry";
        private readonly ISignalRService _signalRService;
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitConsumerService(ISignalRService signalRService)
        {
            _signalRService = signalRService;
            _factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(QueueName, false, false, false, null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;

            _channel.BasicConsume(QueueName, true, consumer);

            return Task.CompletedTask;
        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var msg = Encoding.UTF8.GetString(body);

            Console.WriteLine("[x] recieved msg: {0}", msg);

            _signalRService.NotifyAllClients(msg).Wait();
        }
    }
}
