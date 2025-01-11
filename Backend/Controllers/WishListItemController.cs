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
        public async Task<ActionResult<WishListItem>> AddItem(WishListItem item)
        {
            _context.WishListItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetItemsForWishList", "WishList", new { wishListId = item.WishListId }, item);
        }
    }
}
