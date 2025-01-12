using Swashbuckle.AspNetCore.Filters;
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
