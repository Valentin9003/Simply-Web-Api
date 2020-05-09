using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AuthorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string BirthYear { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
