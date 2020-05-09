using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string PublicationYear { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
