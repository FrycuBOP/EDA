# Simple implementation of EDA (Event Driven Architecture)

## Project components:
- **Producer:** application which sending events to RabbitMQ queue 
- **SignalRTelemetry:** application which handling events from RabbitMQ queue and implements SingnalR Hub
- **SignalRClient:** SignalR client connects to SignalR hub and recived handled events from it

==To run this project locally You need to instal RabbitMQ==.

## Case description: 
That kind of implementation can be used for example to read data for IoT sensors like telemetry form Cars etc. 
As telemetry for cars can produce high traffic RabbitMQ is used for event streaming and SignalR is channel part of
implementation in this case which is resposible to notify client about new telemetry event occurs.
 In real word example thoes event can be stored in event store like MongoDb and create auditable event log used later to track what's going on with cars.
