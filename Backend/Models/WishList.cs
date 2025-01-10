namespace Backend.Models
{
    public class WishList
    {
        public int WishListId { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<WishListItem> Items { get; set; }
    }
}
