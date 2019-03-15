using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionsServiceBusAttachment
{
    public static class ReceiveWithAttachment
    {
        [FunctionName("ReceiveWithAttachment")]
        public static async Task Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnection")]
        Message message, ILogger log)
        {
            log.LogInformation("ReceiveWithAttachment function processed a request.");
            await message.DownloadAzureStorageAttachment();
            string body = System.Text.Encoding.UTF8.GetString(message.Body);
            log.LogInformation(body);
        }
    }
}
