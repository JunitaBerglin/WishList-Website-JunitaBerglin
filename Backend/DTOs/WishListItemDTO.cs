using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class WishListItemDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public bool IsPurchased { get; set; }

        [Required]
        public required string Link { get; set; }

        public int? PurchasedByUserId { get; set; }

        [Required]
        public required int WishListId { get; set; }
    }
}
