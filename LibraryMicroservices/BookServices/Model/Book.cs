using System.ComponentModel.DataAnnotations;

namespace BookServices.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? BookTitle { get; set; }
        public string? BookAuthor { get; set; }
    }
}
