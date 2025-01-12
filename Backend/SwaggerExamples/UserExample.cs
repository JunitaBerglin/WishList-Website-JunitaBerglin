using Swashbuckle.AspNetCore.Filters;
namespace Backend.SwaggerExamples;
using Backend.DTOs;

public class UserExample : IExamplesProvider<UserDTO>
{
    public UserDTO GetExamples()
    {
        return new UserDTO
        {
            Username = "testuser",
            WishLists = new List<WishListDTO>
                {
                    new WishListDTO
                    {
                        UserId = 1,
                        Name = "Birthday WishList",
                        IsPrivate = true,
                        Items = new List<WishListItemDTO>
                        {
                            new WishListItemDTO
                            {
                                WishListId = 1,
                                Name = "Noise-cancelling headphones",
                                Description = "High-quality over-ear headphones",
                                Price = 250.00m,
                                IsPurchased = false,
                                Link = "https://example.com/headphones",
                                PurchasedByUserId = null
                            }
                        }
                    }
                }
        };
    }
}
