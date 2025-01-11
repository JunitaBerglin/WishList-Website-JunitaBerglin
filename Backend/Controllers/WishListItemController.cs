using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}