using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class AuthorModel
    {
        public string AuthorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string BirthYear { get; set; }

        public List<BookModel> Books { get; set; } = new List<BookModel>();
    }
}
