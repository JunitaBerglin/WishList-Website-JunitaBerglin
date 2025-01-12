using Swashbuckle.AspNetCore.Filters;
namespace Backend.SwaggerExamples;
using Backend.DTOs;

public class UpdateItemExample : IExamplesProvider<WishListItemDTO>
{
    public WishListItemDTO GetExamples()
    {
        return new WishListItemDTO
        {
            Name = "Updated Item Name",
            Description = "Updated Description",
            Price = 99.99M,
            IsPurchased = true,
            Link = "https://example.com/updated-item",
            PurchasedByUserId = 2,
            WishListId = 1
        };
    }
}