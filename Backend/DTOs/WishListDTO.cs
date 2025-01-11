namespace Backend.DTOs
{
    public class WishListDTO
    {
        public required string Name { get; set; }
        public bool IsPrivate { get; set; }
        public required int UserId { get; set; }
        public List<WishListItemDTO> Items { get; set; } = [];
    }
}
