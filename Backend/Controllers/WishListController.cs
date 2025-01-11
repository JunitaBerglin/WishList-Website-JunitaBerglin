using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishListController : ControllerBase
    {
        private readonly WishListContext _context;

        public WishListController(WishListContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WishList>> CreateWishList(WishList wishList)
        {
            _context.WishLists.Add(wishList);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWishList), new { id = wishList.WishListId }, wishList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WishList>> GetWishList(int id)
        {
            var wishList = await _context.WishLists.Include(w => w.Items)
                                                   .FirstOrDefaultAsync(w => w.WishListId == id);
            if (wishList == null) return NotFound();
            return Ok(wishList);
        }

        [HttpGet("{wishListId}/items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WishListItem>>> GetItemsForWishList(int wishListId)
        {
            var items = await _context.WishListItems.Where(i => i.WishListId == wishListId).ToListAsync();
            if (!items.Any()) return NotFound();
            return Ok(items);
        }
    }
}
