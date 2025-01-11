using Backend.DTOs;
using Swashbuckle.AspNetCore.Filters;

public class WishListItemExample : IExamplesProvider<WishListItemDTO>
{
    public WishListItemDTO GetExamples()
    {
        return new WishListItemDTO
        {
            Name = "Toy Car",
            Description = "A red toy car for kids",
            Price = 20.99m,
            IsPurchased = false,
            WishListId = 1,
            Link = "http://example.com/toycar",
            PurchasedByUserId = null
        };
    }
}
