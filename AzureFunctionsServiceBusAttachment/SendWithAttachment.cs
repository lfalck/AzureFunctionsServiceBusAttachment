using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AzureFunctionsServiceBusAttachment
{
    public static class SendWithAttachment
    {
        private static readonly string storageConnectionString = Environment.GetEnvironmentVariable("storageConnectionString");
        private static readonly AzureStorageAttachmentConfiguration config = new AzureStorageAttachmentConfiguration(storageConnectionString);

        [FunctionName("SendWithAttachment")]
        [return: ServiceBus("myqueue", Connection = "ServiceBusConnection")]
        public static async Task<Message> Run([HttpTrigger(AuthorizationLevel.Function, "post")]
        byte[] req, ILogger log)
        {
            log.LogInformation("SendWithAttachment function processed a request.");
            var message = new Message(req);
            return await message.UploadAzureStorageAttachment(config);
        }
    }
}
