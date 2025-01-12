using Swashbuckle.AspNetCore.Filters;
namespace Backend.SwaggerExamples;
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
