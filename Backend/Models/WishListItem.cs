using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public required WishList WishList { get; set; }
        public required int PurchasedByUserId { get; set; }
        [JsonIgnore]
        public required User PurchasedBy { get; set; }
    }
}
