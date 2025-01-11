using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;

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
        [SwaggerRequestExample(typeof(WishListDTO), typeof(WishListExample))]
        public async Task<ActionResult<WishList>> CreateWishList(WishListDTO wishListDTO)
        {
            var user = await _context.Users.FindAsync(wishListDTO.UserId);
            if (user == null) return BadRequest("Invalid UserId.");

            var wishList = new WishList
            {
                Name = wishListDTO.Name,
                IsPrivate = wishListDTO.IsPrivate,
                UserId = wishListDTO.UserId,
                User = user,
                Items = new List<WishListItem>()
            };

            var items = wishListDTO.Items.Select(i => new WishListItem
            {
                Name = i.Name,
                Description = i.Description,
                Price = i.Price,
                IsPurchased = i.IsPurchased,
                Link = i.Link,
                PurchasedByUserId = i.PurchasedByUserId,
                PurchasedBy = user,
                WishList = wishList
            }).ToList();

            wishList.Items = items;

            _context.WishLists.Add(wishList);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWishList), new { id = wishList.WishListId }, wishList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WishListDTO>> GetWishList(int id)
        {
            var wishList = await _context.WishLists
                                         .Include(w => w.Items)
                                         .FirstOrDefaultAsync(w => w.WishListId == id);

            if (wishList == null) return NotFound();

            var wishListDTO = new WishListDTO
            {
                Name = wishList.Name,
                IsPrivate = wishList.IsPrivate,
                UserId = wishList.UserId,
                Items = wishList.Items.Select(i => new WishListItemDTO
                {
                    Name = i.Name,
                    Description = i.Description,
                    Price = i.Price,
                    IsPurchased = i.IsPurchased,
                    Link = i.Link,
                    PurchasedByUserId = i.PurchasedByUserId
                }).ToList()
            };

            return Ok(wishListDTO);
        }

        [HttpGet("{wishListId}/items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WishListItemDTO>>> GetItemsForWishList(int wishListId)
        {
            var items = await _context.WishListItems.Where(i => i.WishListId == wishListId).ToListAsync();
            if (!items.Any()) return NotFound();

            var itemDTOs = items.Select(i => new WishListItemDTO
            {
                Name = i.Name,
                Description = i.Description,
                Price = i.Price,
                IsPurchased = i.IsPurchased,
                Link = i.Link,
                PurchasedByUserId = i.PurchasedByUserId
            });

            return Ok(itemDTOs);
        }
    }
}
