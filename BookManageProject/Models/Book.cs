using System.ComponentModel.DataAnnotations;

namespace BookManageProject.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public int? ContactNumber { get; set; }

    }
}
