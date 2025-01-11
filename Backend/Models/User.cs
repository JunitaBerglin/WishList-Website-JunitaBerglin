namespace Backend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public ICollection<WishList> WishLists { get; set; } = new List<WishList>();
        public ICollection<WishListItem> PurchasedItems { get; set; } = new List<WishListItem>();
    }
}
