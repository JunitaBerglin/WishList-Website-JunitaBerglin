namespace Backend.DTOs
{
    public class WishListItemDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPurchased { get; set; }
        public required string Link { get; set; }
        public int? PurchasedByUserId { get; set; }
        public int WishListId { get; set; }
    }
}