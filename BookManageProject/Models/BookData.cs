using System.ComponentModel.DataAnnotations;

namespace BookManageProject.Models
{
    public class BookData
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)] // Adjust the length as per your database schema
        public string? BookName { get; set; }

        public int? BookPrice { get; set; }

        [MaxLength(1000)] // Adjust the length as per your database schema
        public string? BookDescription { get; set; }

        [MaxLength(255)] // Adjust the length as per your database schema
        public string? BookImage { get; set; }
    }
}
