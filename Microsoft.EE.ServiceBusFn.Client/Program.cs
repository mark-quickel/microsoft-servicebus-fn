
using Azure.Identity;
using Azure.Messaging.ServiceBus;

var ns = "contoso-bus.servicebus.windows.net";
await using var client = new ServiceBusClient(ns, new DefaultAzureCredential());

var sender = client.CreateSender("registrations");
var message = new ServiceBusMessage(Console.ReadLine());
// example request payload - {"studentid":1234,"name":"John Brown","classid":"2345","classname":"Azure Functions in C#"}

await sender.SendMessageAsync(message);