using RetroInventoryApi.Domain;

namespace RetroInventory.Web.Services
{
    public class InventoryService
    {
        private readonly HttpClient _httpClient;

        public InventoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Item>> GetInventoryItems()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Item>>("api/Item/");
        }
    }
}
