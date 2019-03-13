using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AzureFunctionsServiceBusAttachment
{
    public static class ReceiveWithAttachment
    {
        private static readonly string storageConnectionString = Environment.GetEnvironmentVariable("storageConnectionString");
        private static readonly AzureStorageAttachmentConfiguration config = new AzureStorageAttachmentConfiguration(storageConnectionString);
        
        [FunctionName("ReceiveWithAttachment")]
        public static async Task Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnection")]
        Message message, ILogger log)
        {
            log.LogInformation("ReceiveWithAttachment function processed a request.");
            await message.DownloadAzureStorageAttachment(config);
            string body = System.Text.Encoding.UTF8.GetString(message.Body);
            log.LogInformation(body);
        }
    }
}
