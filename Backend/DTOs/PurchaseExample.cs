using Swashbuckle.AspNetCore.Filters;
using Backend.DTOs;

public class PurchaseExample : IExamplesProvider<PurchaseRequestDTO>
{
    public PurchaseRequestDTO GetExamples()
    {
        return new PurchaseRequestDTO
        {
            WishListItemId = 1,
            UserId = 2
        };
    }
}
