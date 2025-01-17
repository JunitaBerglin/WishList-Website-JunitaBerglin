using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishListItemController : ControllerBase
    {
        private readonly WishListContext _context;

        public WishListItemController(WishListContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WishListItemDTO>> AddItem([FromBody] WishListItemDTO itemDTO)
        {
            if (itemDTO == null)
            {
                return BadRequest("Item data is required.");
            }

            var wishList = await _context.WishLists.FindAsync(itemDTO.WishListId);
            if (wishList == null)
            {
                return BadRequest("Invalid WishListId.");
            }

            User? user = null;
            if (itemDTO.PurchasedByUserId.HasValue)
            {
                user = await _context.Users.FindAsync(itemDTO.PurchasedByUserId);
                if (user == null)
                {
                    return BadRequest("Invalid PurchasedByUserId.");
                }
            }

            var newItem = new WishListItem
            {
                Name = itemDTO.Name,
                Description = itemDTO.Description,
                Price = itemDTO.Price,
                IsPurchased = itemDTO.IsPurchased,
                Link = itemDTO.Link,
                WishListId = itemDTO.WishListId,
                WishList = wishList,
                PurchasedByUserId = itemDTO.PurchasedByUserId,
                PurchasedBy = user
            };

            _context.WishListItems.Add(newItem);
            await _context.SaveChangesAsync();

            var createdItemDTO = new WishListItemDTO
            {
                Name = newItem.Name,
                Description = newItem.Description,
                Price = newItem.Price,
                IsPurchased = newItem.IsPurchased,
                Link = newItem.Link,
                PurchasedByUserId = newItem.PurchasedByUserId,
                WishListId = newItem.WishListId
            };

            return CreatedAtAction(
                "GetItemsForWishList",
                "WishList",
                new { wishListId = newItem.WishListId },
                createdItemDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateItem(int id, WishListItemDTO updatedItemDTO)
        {
            if (id != updatedItemDTO.WishListId)
            {
                return BadRequest("Item ID does not match.");
            }

            var existingItem = await _context.WishListItems.FindAsync(id);
            if (existingItem == null)
            {
                return NotFound("Item not found.");
            }

            existingItem.Name = updatedItemDTO.Name;
            existingItem.Description = updatedItemDTO.Description;
            existingItem.Price = updatedItemDTO.Price;
            existingItem.IsPurchased = updatedItemDTO.IsPurchased;
            existingItem.Link = updatedItemDTO.Link;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "An error occurred while updating the item.");
            }

            return Ok("Item updated successfully.");
        }

        [HttpPost("purchase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> MarkAsPurchased([FromBody] PurchaseRequestDTO purchaseRequest)
        {
            var item = await _context.WishListItems.FindAsync(purchaseRequest.WishListItemId);
            if (item == null)
            {
                return BadRequest("Invalid WishListItemId.");
            }

            var user = await _context.Users.FindAsync(purchaseRequest.UserId);
            if (user == null)
            {
                return BadRequest("Invalid UserId.");
            }

            if (item.IsPurchased)
            {
                return BadRequest("This item has already been purchased.");
            }

            item.IsPurchased = true;
            item.PurchasedByUserId = user.UserId;
            item.PurchasedBy = user;

            await _context.SaveChangesAsync();

            return Ok("Item marked as purchased.");
        }
    }
}