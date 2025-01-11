using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class WishList
    {
        public int WishListId { get; set; }
        public required string Name { get; set; }
        public bool IsPrivate { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public required User User { get; set; }
        public ICollection<WishListItem> Items { get; set; } = new List<WishListItem>();
    }
}
