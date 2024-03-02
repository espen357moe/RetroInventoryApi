using Microsoft.EntityFrameworkCore;
using RetroInventoryApi.Domain;

namespace RetroInventoryApi.Database
{
    public class Repository
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public async Task<Item?> GetItem(Guid id)
        {
            return await _dbContext.Items.FindAsync(id);                            
        }

        public async Task CreateItem(Item item)
        {
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateItemGroup(ItemGroup itemGroup)
        {
            _dbContext.ItemGroups.Add(itemGroup);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ItemGroup?> GetItemGroup(Guid id)
        {
            return await _dbContext.ItemGroups.FindAsync(id);
        }

        public async Task<IEnumerable<ItemGroup>> GetItemGroups()
        {
            return await _dbContext.ItemGroups.ToListAsync();
        }

        public async Task<bool> DeleteItem(Guid id)
        {
            var itemToDelete = await _dbContext.Items.FindAsync(id);

            if (itemToDelete == null)
            {
                return false;
            }

            _dbContext.Items.Remove(itemToDelete);
            await _dbContext.SaveChangesAsync();                           

            return true;
        }
    }
}
