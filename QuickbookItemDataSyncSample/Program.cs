using Microsoft.Extensions.Configuration;
using QuickbookItemDataSyncSample;
using QuickbookItemDataSyncSample.Services;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


var authService = new AuthService(config);
var inventoryService = new InventoryService(config);

while (Global.ExitApp)
{
    var currentDate = DateTime.UtcNow;

    DateTime nextExecutionTime = DateTime.UtcNow.Date.AddHours(2);
    if (currentDate >= nextExecutionTime)
    {
        if (currentDate > authService.RefreshTokenExpiry)
        {
            Console.WriteLine("The refresh token has expired. Please close this window, update the authorization code in the app settings, and restart the application.");
        }

        if (currentDate > authService.AccessTokenExpiry)
        {
            await authService.GetAccessToken();
        }

        if (!authService.TokenAcquired)
        {
            Global.ExitApp = false;
            break;
        }

        await inventoryService.GetInventoriesFromQbAsync(authService.AccessToken!);

        if (inventoryService.IsDataRetrievalSuccessful)
        {
            await inventoryService.SynchronizeDataAsync();
        }

        nextExecutionTime = nextExecutionTime.AddDays(1);
    }

    TimeSpan sleepDuration = nextExecutionTime - DateTime.UtcNow;
    if (sleepDuration.TotalSeconds > 0)
    {
        Console.WriteLine($"Sleeping until {nextExecutionTime} UTC...");
        await Task.Delay(sleepDuration);
    }
}

Console.ReadKey();