using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("SignalR Client Starting...");

const string SIGNALR_HUB_URL = "http://localhost:5089/telemetryHub";

Console.WriteLine("Connecting to hub...");

var connection = new HubConnectionBuilder().WithUrl(SIGNALR_HUB_URL, (opts) =>
{
    opts.HttpMessageHandlerFactory = (msg) =>
    {
        if (msg is HttpClientHandler httpHandler)
        {
            httpHandler.ServerCertificateCustomValidationCallback +=
            (sender, certificate, chain, sslPolicyErrors) => { return true; };
        }
        return msg;
    };
}).Build();

await connection.StartAsync();

Console.WriteLine("Connected successfuly. Connection state: {0}", connection.State);

connection.On<string>("TelemetryRecived",(msg)=>
{
     Console.WriteLine(msg);
     }
     );


Console.Read();