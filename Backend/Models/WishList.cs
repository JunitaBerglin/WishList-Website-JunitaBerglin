namespace Backend.Models
{
    public class WishList
    {
        public int WishListId { get; set; }
        public required string Name { get; set; }
        public bool IsPrivate { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; }
        public ICollection<WishListItem> Items { get; set; } = new List<WishListItem>();
    }
}
