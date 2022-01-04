using Azure.Storage.Queues;

Console.WriteLine("Hello SENDER!");

var conString = "DefaultEndpointsProtocol=https;AccountName=mykursstorage;AccountKey=at1dzBlbOCqq0PCsyH8Z5CAZ8o2pYEm8KUdUV8cQY9ndteySbW5+6KkZ3nFTeb4UNXPEWQvM4eiSV2D+rE3R6Q==;EndpointSuffix=core.windows.net";

var client = new QueueClient(conString, "hallowelt");

while (true)
{
    client.SendMessage($"Hallo {DateTime.Now}");

    Console.WriteLine("Press any key for next msg");
    Console.ReadKey();
}


Console.WriteLine("Ende");
Console.ReadLine();