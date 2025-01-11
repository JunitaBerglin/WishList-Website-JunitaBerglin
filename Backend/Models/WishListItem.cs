namespace Backend.Models
{
    public class WishListItem
    {
        public int ItemId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPurchased { get; set; }
        public int WishListId { get; set; }
        public required string Link { get; set; }
        public required WishList WishList { get; set; }
        public int? PurchasedByUserId { get; set; }
        public User? PurchasedBy { get; set; }
    }
}
