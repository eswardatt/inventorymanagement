using inventorymanagement.Models;

namespace inventorymanagement.Repository
{
    public interface IItemRepo
    {
        
        Task<InventoryItem> CreateItemAsync(InventoryItem item);
        Task<InventoryItem> GetItemByIdAsync(int id);
        Task<IEnumerable<InventoryItem>> GetAllItemsAsync();
        Task<InventoryItem> UpdateItemAsync(InventoryItem item);
        Task DeleteItemAsync(int id);
    }
}
