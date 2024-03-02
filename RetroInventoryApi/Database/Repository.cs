using Microsoft.AspNetCore.Mvc;
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

        public void CreateItem(Item item)
        {
            _dbContext.Items.AddRange(item);
            _dbContext.SaveChanges();
        }

        public void CreateItems(IEnumerable<Item> items)
        {
            _dbContext.Items.AddRange(items);
            _dbContext.SaveChanges();
        }

        public void CreateItemGroups(IEnumerable<ItemGroup> itemGroups)
        {
            _dbContext.ItemGroups.AddRange(itemGroups);
            _dbContext.SaveChanges();
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
