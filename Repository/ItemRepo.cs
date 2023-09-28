using inventorymanagement.Models;
using Microsoft.EntityFrameworkCore;

namespace inventorymanagement.Repository
{
    public class ItemRepo :IItemRepo
    {
        private ApplicationContext _context;
        public ItemRepo(ApplicationContext applicationContext)
        {
            this._context = applicationContext;
        }

        public async Task<IEnumerable<InventoryItem>> GetAllItemsAsync()
        {
            // Retrieve all items from the database asynchronously.
            return await _context.InventoryItems.ToListAsync();
        }
        public async Task<InventoryItem> CreateItemAsync(InventoryItem item)
        {
            // Add item to the database asynchronously.
            item.isActive = 1;
            await _context.InventoryItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<InventoryItem> GetItemByIdAsync(int id)
        {
            // Retrieve an item from the database asynchronously by its Id.
            return await _context.InventoryItems.FirstOrDefaultAsync(item => item.Id == id);
        }
      
        public async Task<InventoryItem> UpdateItemAsync(InventoryItem item)
        {
            // Update the item in the database asynchronously.
            _context.InventoryItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task DeleteItemAsync(int id)
        {
            // Delete an item from the database asynchronously by its Id.
            var itemToRemove = await _context.InventoryItems.FirstOrDefaultAsync(item => item.Id == id);
            if (itemToRemove != null)
            {
                itemToRemove.isActive = 0;
                _context.InventoryItems.Update(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

    }
}
