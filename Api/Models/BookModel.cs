using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class BookModel
    {
        public string BookId { get; set; }

        public string Title { get; set; }

        public string PublicationYear { get; set; }

        public string Genre { get; set; }
    }
}
