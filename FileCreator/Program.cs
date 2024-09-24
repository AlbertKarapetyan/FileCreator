
using FileCreator;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true);

IConfiguration configuration = builder.Build();

// Bind the "AppSettings" section to the AppSettings object
var appSettings = new AppSettings();
configuration.GetSection("AppSettings").Bind(appSettings);

if (args.Length == 2)
{
    appSettings.DestinationFilePath = args[0];
    appSettings.DestinationFileSize = Convert.ToInt32(args[1]);
}
else if (args.Length > 0 && args.Length != 2)
{
    Console.WriteLine("Usage: FileCreator $DestinationFilePath $DestinationFileSizeInMB");
    return;
}


Console.WriteLine($"Start - {DateTime.Now.ToLongTimeString()}");

var creator = new Creator(appSettings);
creator.CreateFile();

Console.WriteLine($"End - {DateTime.Now.ToLongTimeString()}");
Console.ReadKey();