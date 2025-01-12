namespace Backend.DTOs
{
    public class UserDTO
    {
        public required string Username { get; set; }
        public List<WishListDTO> WishLists { get; set; } = new List<WishListDTO>();
    }
}