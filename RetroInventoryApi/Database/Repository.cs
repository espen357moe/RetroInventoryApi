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

        public async Task<IEnumerable<Collection>> GetCollections()
        {
            return await _dbContext.Collections.ToListAsync();
        }

        public async Task<Collection?> GetCollection(Guid id)
        {
            return await _dbContext.Collections.FindAsync(id);
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

        public async Task CreateGroup(Group group)
        {
            _dbContext.Groups.Add(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Group?> GetGroup(Guid id)
        {
            return await _dbContext.Groups.FindAsync(id);
        }

        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await _dbContext.Groups.ToListAsync();
        }

        public Task AddItemToGroup(Guid itemGroupId, Guid itemId)
        {
            throw new NotImplementedException();
        }
    }
}
