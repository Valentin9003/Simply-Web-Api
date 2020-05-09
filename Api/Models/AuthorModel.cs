using System.Collections.Generic;

namespace Api.Models
{
    public class AuthorModel
    {
        public string AuthorId { get; set; }

        public string Name { get; set; }

        public string BirthYear { get; set; }

        public List<BookModel> Books { get; set; } = new List<BookModel>();
    }
}
