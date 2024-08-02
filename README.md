Simple implementation of EDA (Event Driven Architecture)

Project components:
- Producer: application which sending events to RabbitMQ queue 
- SignalRTelemetry: application which handling events from RabbitMQ queue and implements SingnalR Hub
- SignalRClient: SignalR client connects to SignalR hub and recived handled events from it

To run this project locally You need to instal RabbitMQ.
