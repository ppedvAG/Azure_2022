using Azure.Storage.Queues;

Console.WriteLine("Hello RECEIVER");

var conString = "DefaultEndpointsProtocol=https;AccountName=mykursstorage;AccountKey=at1dzBlbOCqq0PCsyH8Z5CAZ8o2pYEm8KUdUV8cQY9ndteySbW5+6KkZ3nFTeb4UNXPEWQvM4eiSV2D+rE3R6Q==;EndpointSuffix=core.windows.net";


var client = new QueueClient(conString, "hallowelt");

while (true)
{
    var msg = client.ReceiveMessage();
    if (msg.Value != null)
    {
        Console.WriteLine($"{msg.Value.Body} [{msg.Value.MessageId}]");
        client.DeleteMessage(msg.Value.MessageId, msg.Value.PopReceipt);
    }
    //Thread.Sleep(1000);
}


Console.WriteLine("Ende");
Console.ReadLine();