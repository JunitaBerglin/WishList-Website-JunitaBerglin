using Backend.Models;
using Backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly WishListContext _context;

        public UserController(WishListContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("User data is required.");
            }

            var user = new User
            {
                Username = userDTO.Username,
                WishLists = new List<WishList>()
            };

            foreach (var wlDTO in userDTO.WishLists)
            {
                var wishList = new WishList
                {
                    Name = wlDTO.Name,
                    IsPrivate = wlDTO.IsPrivate,
                    UserId = 0,
                    User = user,
                    Items = new List<WishListItem>()
                };

                var items = wlDTO.Items.Select(i => new WishListItem
                {
                    Name = i.Name,
                    Description = i.Description,
                    Price = i.Price,
                    IsPurchased = i.IsPurchased,
                    Link = i.Link,
                    PurchasedByUserId = i.PurchasedByUserId,
                    PurchasedBy = null,
                    WishList = wishList
                }).ToList();

                wishList.Items = items;
                user.WishLists.Add(wishList);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{id}/history")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WishListItemDTO>>> GetPurchasedItems(int id)
        {
            var user = await _context.Users.Include(u => u.PurchasedItems).FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var purchasedItems = user.PurchasedItems.Select(item => new WishListItemDTO
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                IsPurchased = item.IsPurchased,
                Link = item.Link,
                WishListId = item.WishListId,
                PurchasedByUserId = item.PurchasedByUserId
            });

            return Ok(purchasedItems);
        }
    }
}