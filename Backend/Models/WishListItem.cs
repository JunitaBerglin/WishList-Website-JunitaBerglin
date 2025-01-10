namespace Backend.Models
{
    public class WishListItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Link { get; set; }
        public bool IsPurchased { get; set; }
        public int WishListId { get; set; }
        public WishList WishList { get; set; }

        public int? PurchasedByUserId { get; set; }
        public User PurchasedBy { get; set; }
    }
}
