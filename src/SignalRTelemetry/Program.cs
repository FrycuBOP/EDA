using SignalRTelemetry.Hubs;
using SignalRTelemetry.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();
builder.Services.AddSingleton<ISignalRService, SignalRService>();
builder.Services.AddHostedService<RabbitConsumerService>();
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<TelemetryHub>("/telemetryHub");

app.Run();


