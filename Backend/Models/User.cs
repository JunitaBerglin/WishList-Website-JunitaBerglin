using System.Text.Json.Serialization;

namespace Backend.Models
{

    public class User
    {
        public int UserId { get; set; }
        public required string Username { get; set; }

        [JsonIgnore]
        public ICollection<WishList> WishLists { get; set; } = new List<WishList>();

        [JsonIgnore]
        public ICollection<WishListItem> PurchasedItems { get; set; } = new List<WishListItem>();
    }

}
