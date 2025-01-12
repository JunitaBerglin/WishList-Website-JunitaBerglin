using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class WishListDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public required string Name { get; set; }

        public bool IsPrivate { get; set; }

        [Required]
        public required int UserId { get; set; }

        public List<WishListItemDTO> Items { get; set; } = new List<WishListItemDTO>();
    }
}