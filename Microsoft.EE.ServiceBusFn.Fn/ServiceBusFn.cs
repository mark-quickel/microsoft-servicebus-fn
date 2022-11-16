using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft.EE.ServiceBusFn.Fn
{
    public class ServiceBusFn
    {
        [FunctionName("ServiceBusFn")]
        public void Run([ServiceBusTrigger("Registrations", Connection = "ServiceBusConnection")]string queuedRegistration, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {queuedRegistration}");

            var registration = JsonConvert.DeserializeObject<Registration>(queuedRegistration);

            log.LogInformation($"Deserialized registration for {registration.studentid} with class {registration.classid}");
            
            // do additional work with the registration record ...
        }
    }
}
