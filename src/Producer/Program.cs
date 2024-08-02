using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Telemtry Producer Started!");

Send();

static void Send()
{
    var factory = new ConnectionFactory() { HostName = "localhost" };
    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();

    channel.QueueDeclare("telemetry",false,false,false,null);
    while (true)
    {
        Console.WriteLine("Pleas enter telemetry to send to queue:");
        string? telemetry = Console.ReadLine();
        if (!string.IsNullOrEmpty(telemetry))
        {
            var body = Encoding.UTF8.GetBytes(telemetry);

            channel.BasicPublish(exchange: "",routingKey: "telemetry",mandatory:false, basicProperties: null,body: body);

            Console.WriteLine("[x] sendt {0}", telemetry);
        }
    }
}