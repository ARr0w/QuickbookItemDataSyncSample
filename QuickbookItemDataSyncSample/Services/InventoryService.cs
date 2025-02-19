using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using QuickbookItemDataSyncSample.Models.QbResponseModels;

namespace QuickbookItemDataSyncSample.Services
{
    public class InventoryService
    {
        private readonly IConfiguration _configuration;
        private readonly string _companyId;

        private ItemResponseRootModel _itemResponse;

        public InventoryService(IConfiguration configuration) 
        {
            _configuration = configuration;
            _companyId = _configuration["company"]!;
        }

        public bool IsDataRetrievalSuccessful { get; set; } = false;

        public async Task GetInventoriesFromQbAsync(string accessToken)
        {
            IsDataRetrievalSuccessful = false;

            string baseUrl = $"https://sandbox-quickbooks.api.intuit.com/v3/company/{_companyId}/query";

            using HttpClient client = new();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string query = "SELECT * FROM Item";
            string requestUrl = $"{baseUrl}?query={Uri.EscapeDataString(query)}";

            HttpResponseMessage response = await client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Inventory Data Retrieved Successfully.");

                _itemResponse = JsonSerializer.Deserialize<ItemResponseRootModel>(responseBody)!;

                IsDataRetrievalSuccessful = true;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errorResponse);
            }
        }

        public async Task SynchronizeDataAsync()
        {
            await Task.FromResult("");
        }
    }
}
