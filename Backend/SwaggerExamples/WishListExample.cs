using Backend.DTOs;
namespace Backend.SwaggerExamples;
using Swashbuckle.AspNetCore.Filters;

public class WishListExample : IExamplesProvider<WishListDTO>
{
    public WishListDTO GetExamples()
    {
        return new WishListDTO
        {
            Name = "Birthday WishList",
            IsPrivate = true,
            UserId = 1,
            Items = new List<WishListItemDTO>
            {
                new WishListItemDTO
                {
                    Name = "Noise-cancelling headphones",
                    Description = "High-quality over-ear headphones",
                    Price = 250.00m,
                    IsPurchased = false,
                    Link = "https://example.com/headphones",
                    PurchasedByUserId = 1,
                    WishListId = 1
                }
            }
        };
    }
}
