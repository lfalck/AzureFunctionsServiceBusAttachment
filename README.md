[![license](https://img.shields.io/github/license/lfalck/AzureFunctionsServiceBusAttachment.svg)]()

# AzureFunctionsServiceBusAttachment
Azure function which uses [ServiceBus.AttachmentPlugin](https://github.com/SeanFeldman/ServiceBus.AttachmentPlugin) which makes it possible to send messages that exceed the maximum size.

**SendWithAttachment**  
Function with http trigger which uploads body to an Azure Storage blob.

**ReceiveWithAttachment**  
Function with service bus trigger which downloads body from Azure Storage blob.
