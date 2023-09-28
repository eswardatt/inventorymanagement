using inventorymanagement.Models;
using inventorymanagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inventorymanagement.Controllers
{
    public class ItemController : BaseController
    {
        private readonly IItemRepo _itemRepo;

        public ItemController(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        // Example API endpoint to create an inventory item.
        [HttpPost("create")]
        public async Task<IActionResult> CreateItem([FromBody] InventoryItem item)
        {
            try
            {
                var createdItem = await _itemRepo.CreateItemAsync(item);
                return SuccessResponse(createdItem);
            }
            catch (Exception ex)
            {
                return ErrorResponse($"Error creating item: {ex.Message}");
            }
        }

        // Example API endpoint to get an inventory item by ID.
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                var item = await _itemRepo.GetItemByIdAsync(id);
                if (item != null)
                    return SuccessResponse(item);
                else
                    return NotFoundResponse($"no data found for \t {id}");
            }
            catch (Exception ex)
            {
                return ErrorResponse($"Error getting item: {ex.Message}");
            }
        }

        // Example API endpoint to get all inventory items.
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var items = await _itemRepo.GetAllItemsAsync();
                return SuccessResponse(items);
            }
            catch (Exception ex)
            {
                return ErrorResponse($"Error getting all items: {ex.Message}");
            }
        }

        // Example API endpoint to update an inventory item.
        [HttpPut("update")]
        public async Task<IActionResult> UpdateItem([FromBody] InventoryItem item)
        {
            try
            {
                var updatedItem = await _itemRepo.UpdateItemAsync(item);
                return SuccessResponse(updatedItem);
            }
            catch (Exception ex)
            {
                return ErrorResponse($"Error updating item: {ex.Message}");
            }
        }

        // Example API endpoint to delete an inventory item by ID.
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                await _itemRepo.DeleteItemAsync(id);
                return SuccessResponse($"Item {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return ErrorResponse($"Error deleting item: {ex.Message}");
            }
        }
    }

}
